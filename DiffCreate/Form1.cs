using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Net;
using System.Threading;
using Ionic.Zip;
using rtwmatrix;
using IPPA;

namespace DiffCreate
{
    public partial class Form1 : Form
    {
        bool blnDebug = false;
        bool blnService = true;
        int ncols = 0;
        int nrows = 0;
        RtwMatrix mBigGrid;
        RtwMatrix mSmallGrid;
        RtwMatrix mDiff;
        float maxElevation = 0;
        const double d2r = 0.0174532925199433;  // PI / 180

        public Form1()
        {
            InitializeComponent();
            MyInitialization();
        }

        private void MyInitialization()
        {
            txtTop.Text = "31.4469779537";
            txtBottom.Text = "31.2219554063";
            txtLeft.Text = "-109.950151671";
            txtRight.Text = "-109.686948329";
            //txtTop.Text = "40.840";
            //txtBottom.Text = "40.815";
            //txtLeft.Text = "-96.715";
            //txtRight.Text = "-96.689";

            blnDebug = chkDebug.Checked;
        }

        private void chkDebug_CheckedChanged(object sender, EventArgs e)
        {
            blnDebug = chkDebug.Checked;
        }

        private void btnGetLandCover_Click(object sender, EventArgs e)
        {
            // Here's the test client:
            // http://extract.cr.usgs.gov/requestValidationServiceClient/sampleRequestValidationServiceProxy/TestClient.jsp

            // string strLayerID = "P1402XZ";   // Test Layer
            string strLayerID = "L6L05HZ";      // Landcover GridFlt Zip Html
            // string strLayerID = "ND305HZ";      // NED 1/3 GridFlt Zip Html

            GetMap(strLayerID, "Landcover");
        }

        private void btnGetElevation_Click(object sender, EventArgs e)
        {
            string strLayerID = "ND305HZ";      // NED 1/3 GridFlt Zip Html
            GetMap(strLayerID, "NED");
        }

        private void GetMap(string strLayerID, string strMap)
        {
            // Call Validation Service to get DOWNLOAD_URL
            string strDownloadURL = GetDownloadURL(strLayerID);
            if (!blnService)
            {
                blnService = true;
                return;
            }

            // Get Download ID
            string strDownloadID = GetDownloadID(strDownloadURL);

            // Check for status
            int code = CheckDownloadStatus(strDownloadID);

            // Download map
            DownloadMap(strMap, strDownloadID);

            // Extract map (Using library DotNetZip with Microsoft Public License http://dotnetzip.codeplex.com/)
            ExtractMap(strMap);

            // Read in map from binary GridFloat
            ReadInMap(strMap);

            // Recode map
            if (strMap == "Landcover")
            {
                RecodeMap();
            }

            // Resize map
            ResizeMap(strMap);

            if (strMap == "Landcover")
            {
                // Create task difficulty map
                CreateDiffMap();

                // Save map
                SaveMap("DiffMap", mDiff);
            }

            // Save resized map
            SaveMap(strMap, mSmallGrid);
        }

        private string GetDownloadURL(string strLayerID)
        {
            // Connect to Request Validation Web Services
            Log("Connect to Request ValidationConstraints Service......");
            RVS.RequestValidationServiceClient myRVS = new RVS.RequestValidationServiceClient();
            LogLine("Done!");

            // Build XML
            Log("Building input XML request string......");
            string xmlRequestString = "<REQUEST_SERVICE_INPUT>" +
                                "<AOI_GEOMETRY>" +
                                "<EXTENT>" +
                                "<TOP>" + txtTop.Text + "</TOP>" +
                                "<BOTTOM>" + txtBottom.Text + "</BOTTOM>" +
                                "<LEFT>" + txtLeft.Text + "</LEFT>" +
                                "<RIGHT>" + txtRight.Text + "</RIGHT>" +
                                "</EXTENT>" +
                                "<SPATIALREFERENCE_WKID></SPATIALREFERENCE_WKID>" +
                                "</AOI_GEOMETRY>" +
                                "<LAYER_INFORMATION>" +
                                "<LAYER_IDS>" + strLayerID + "</LAYER_IDS>" +
                                "</LAYER_INFORMATION>" +
                                "<CHUNK_SIZE>250</CHUNK_SIZE>" +
                                "<ORIGINATOR></ORIGINATOR>" +
                                "<JSON>false</JSON>" +
                                "<CALLBACK></CALLBACK>" +
                                "</REQUEST_SERVICE_INPUT>";
            if (blnDebug)
            {
                LogLine("");
                LogLine("Displaying input XML request String:");
                LogLine(xmlRequestString);
            }
            LogLine("Done!");

            // Send Request
            string strMyResponse = "";
            try
            {
                Log("Sending SOAP request......");
                System.Net.ServicePointManager.Expect100Continue = false;
                strMyResponse = myRVS.processAOI2(xmlRequestString);
                if (blnDebug)
                {
                    LogLine("");
                    LogLine("SOAP Response:");
                    LogLine(strMyResponse);
                }
                LogLine("Done!");
            }
            catch (Exception ex)
            {
                if (blnDebug)
                {
                    Log("Error calling Validation Service: " + ex.ToString());
                }
                //TODO If 503 busy then repeat.
                LogLine("");
                LogLine("The service is temporarily unavailable. Please try again later!");
                blnService = false;
                return "";
            }

            // Parse response
            Log("Parsing response......");
            strMyResponse = strMyResponse.Replace("&", "@");
            string strDownloadURL = "";
            using (XmlReader reader = XmlReader.Create(new StringReader(strMyResponse)))
            {
                reader.ReadToFollowing("DOWNLOAD_URL");
                strDownloadURL = reader.ReadElementContentAsString();
                strDownloadURL = strDownloadURL.Replace("@", "&");
                if(blnDebug)
                {
                    LogLine("");
                    LogLine("DOWNLOAD_URL = " + strDownloadURL);
                }
            }
            LogLine("Done!");
            return strDownloadURL;
        }

        private string GetDownloadID(string strDownloadURL)
        {
            Log("Getting Download ID......");
            string strDownloadID = WebGetCall(strDownloadURL);
            LogLine("Done!");
            if(blnDebug)
            {
            LogLine("DOWNLOAD_ID = " + strDownloadID);
            }
            return strDownloadID;
        }

        private string WebGetCall(string strDownloadURL)
        {
            // Get XML Response
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(strDownloadURL);
            Stream objStream;
            string xmlResponse = "";
            try
            {
                objStream = wrGETURL.GetResponse().GetResponseStream();
                StreamReader objReader = new StreamReader(objStream);
                string sLine = "";
                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                    {
                        xmlResponse += sLine;
                    }
                }
                if (blnDebug)
                {
                    Log("xmlResponse = ");
                    LogLine(xmlResponse);
                }
            }
            catch (Exception ex)
            {
                LogLine("Error opening download page: " + ex.ToString());
            }
            //TODO Deal with time out no response.

            // Parse XML to get result
            string strResult = "";
            using (XmlReader reader = XmlReader.Create(new StringReader(xmlResponse)))
            {
                reader.ReadToFollowing("ns:return");
                strResult = reader.ReadElementContentAsString();
            }
            return strResult;
        }

        private int CheckDownloadStatus(string strDownloadID)
        {
            // 0: Not ready
            // 1: Ready
            // 2: Error
            int intStatusCode = 0;
            string strStatus = "";
            int timeout = 120;       // time out set at 120 seconds
            int timelapsed = 0;
            LogLine("");
            while (timelapsed < timeout || intStatusCode == 1)
            {
                strStatus = WebGetCall("http://extract.cr.usgs.gov/axis2/services/DownloadService/getDownloadStatus?downloadID=" + strDownloadID);
                LogLine(strStatus);
                if (strStatus.Substring(0,3) == "400")
                {
                    intStatusCode = 1;
                    LogLine("Data prep time " + timelapsed + " seconds.");
                    break;
                }
                else if (strStatus == "error")
                {
                    intStatusCode = 2;
                    break;
                }
                timelapsed += 10;
                Thread.Sleep(10000); // check every 10 seconds
            }
            return intStatusCode;
        }

        private void DownloadMap(string strMap, string strDownloadID)
        {
            Log("Downloading map......");
            // Download map
            if (!Directory.Exists("Maps"))
            {
                Directory.CreateDirectory("Maps");
            }

            WebClient webClient = new WebClient();
            webClient.DownloadFile("http://extract.cr.usgs.gov/axis2/services/DownloadService/getData?downloadID=" + strDownloadID, @"Maps\" + strMap + ".zip");

            // Mark complete
            string strStatus = "";
            strStatus = WebGetCall("http://extract.cr.usgs.gov/axis2/services/DownloadService/setDownloadComplete?downloadID=" + strDownloadID);
            if (strStatus.Substring(0, 12) == "Successfully")
            {
                LogLine("Done");
            }
            else
            {
                Log("Something went wrong:");
                LogLine(strStatus);
            }
        }

        private void ExtractMap(string strMap)
        {
            Log("Extracting downloaded zip file......");
            string ExistingZipFile = "Maps\\" + strMap + ".zip";
            string TargetDirectory = "Maps\\" + strMap;
            // Delete folder if it already exists
            if (Directory.Exists(TargetDirectory))
            {
                Directory.Delete(TargetDirectory, true);
            }
            using (ZipFile zip = ZipFile.Read(ExistingZipFile))
            {
                foreach (ZipEntry e in zip)
                {
                    e.Extract(TargetDirectory);  // overwrite == true
                }
            }
            LogLine("Done!");
        }

        private void ReadInMap(string strMap)
        {
            Log("Reading extracted map......");
            // Find header file
            string[] MapFolders = Directory.GetDirectories("Maps\\" + strMap);
            // Since there is only one folder
            string[] HeaderFiles = Directory.GetFiles(MapFolders[0], "*.hdr");
            string HeaderFile = HeaderFiles[0];

            // Identify col and row count in .hdr file
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(HeaderFile))
                {
                    string sLine;
                    // First line is ncols
                    sLine = sr.ReadLine();
                    string[] stuff = sLine.Split(' ');
                    ncols = Convert.ToInt16(stuff[stuff.Length - 1]);
                    // Second line is nrows
                    sLine = sr.ReadLine();
                    stuff = sLine.Split(' ');
                    nrows = Convert.ToInt16(stuff[stuff.Length - 1]);
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            if(blnDebug)
            {
                LogLine("");
                LogLine("ncols = " + ncols + ", nrows = " + nrows);
            }

            // Read in float grid
            mBigGrid = new RtwMatrix(nrows, ncols);
            string[] FloatFiles = Directory.GetFiles(MapFolders[0], "*.flt");
            string FloatFile = FloatFiles[0];
            using (BinaryReader reader = new BinaryReader(File.Open(FloatFile, FileMode.Open)))
            {
                for (int i = 0; i < nrows; i++)
                {
                    for (int j = 0; j < ncols; j++)
                    {
                        float value = reader.ReadSingle();
                        mBigGrid[i, j] = value;
                    }
                }
            }
            LogLine("Done!");
        }

        private void RecodeMap()
        {
            Log("Recoding landcover map......");
            Dictionary<int, int> VegeDensity = BuildDictionary();

            // Recode map and create task difficulty map
            for (int i = 0; i < nrows; i++)
            {
                for (int j = 0; j < ncols; j++)
                {
                    mBigGrid[i, j] = VegeDensity[Convert.ToInt16(mBigGrid[i, j])];
                }
            }
            LogLine("Done!");
        }

        private Dictionary<int, int> BuildDictionary()
        {
            Dictionary<int, int> VegeDensity = new Dictionary<int, int>();
            // Sparse
            VegeDensity.Add(11, 100);      // Open water: sparse
            VegeDensity.Add(12, 100);      // Perennial Ice/Snow: sparse
            VegeDensity.Add(21, 100);      // Developed, Open Space: sparse
            VegeDensity.Add(22, 100);      // Developed, Low Intensity: sparse
            VegeDensity.Add(23, 100);      // Developed, Medium Intensity: sparse
            VegeDensity.Add(24, 100);      // Developed, High Intensity: sparse
            VegeDensity.Add(31, 100);      // Barren Land (Rock/Sand/Clay): sparse
            VegeDensity.Add(71, 100);      // Grassland/Herbaceous: sparse
            VegeDensity.Add(72, 100);      // Sedge/Herbaceous: sparse
            VegeDensity.Add(73, 100);      // Lichens: sparse
            VegeDensity.Add(74, 100);      // Moss: sparse
            VegeDensity.Add(81, 100);      // Pasture/Hay: sparse
            VegeDensity.Add(82, 100);      // Cultivated Crops: sparse
            VegeDensity.Add(95, 100);      // Emergent Herbaceous Wetlands: sparse
            VegeDensity.Add(-9999, 100);   // Data not available: sparse
            // Medium
            VegeDensity.Add(51, 140);      // Dwarf Scrub: medium
            VegeDensity.Add(52, 140);      // Shrub/Scrub: medium
            // Dense
            VegeDensity.Add(41, 180);      // Deciduous Forest: dense
            VegeDensity.Add(42, 180);      // Evergreen Forest: dense
            VegeDensity.Add(43, 180);      // Mixed Forest: dense
            VegeDensity.Add(90, 180);      // Woody Wetlands: dense

            return VegeDensity;
        }

        private void ResizeMap(string strMap)
        {
            Log("Resizing map to 24mx24m grid......");
            // Convert matrix to big image
            Bitmap CurBMP = new Bitmap(mBigGrid.Columns, mBigGrid.Rows);
            if (strMap != "Landcover")
            {
                // Scale matrix values before creating image 
                float[] MinMax = mBigGrid.MinMaxValue();
                maxElevation = MinMax[1];
                ImgLib.ScaleImageValues(ref mBigGrid);
            }
            ImgLib.MatrixToImage(ref mBigGrid, ref CurBMP);
            // Compute the size of smaller image
            int newWidth = Convert.ToInt16(Math.Round(Haversine_km(
                            Convert.ToDouble(txtTop.Text),
                            Convert.ToDouble(txtLeft.Text),
                            Convert.ToDouble(txtTop.Text),
                            Convert.ToDouble(txtRight.Text)))*1000/24);
            int newHeight = Convert.ToInt16(Math.Round(Haversine_km(
                            Convert.ToDouble(txtTop.Text),
                            Convert.ToDouble(txtLeft.Text),
                            Convert.ToDouble(txtBottom.Text),
                            Convert.ToDouble(txtLeft.Text)))*1000/24);
            Bitmap NewBMP = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage((Image)NewBMP);
            if (strMap == "Landcover")
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            }
            else
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            }
            g.DrawImage(CurBMP, 0, 0, newWidth, newHeight);
            g.Dispose();
            mSmallGrid = ImgLib.ImageToMatrix(ref NewBMP);
            if (strMap != "Landcover")
            {
                ImgLib.ScaleBack(ref mSmallGrid, maxElevation);
            }
            LogLine("Done!");
        }

        private double Haversine_km(double lat1, double long1, double lat2, double long2)
        {
            double dlong = (long2 - long1) * d2r;
            double dlat = (lat2 - lat1) * d2r;
            double a = Math.Pow(Math.Sin(dlat / 2.0), 2) + Math.Cos(lat1 * d2r) * Math.Cos(lat2 * d2r) * Math.Pow(Math.Sin(dlong / 2.0), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = 6367 * c;

            return d;
        }

        private void CreateDiffMap()
        {
            Log("Creating task difficulty map......");
            mDiff = new RtwMatrix(mSmallGrid.Rows, mSmallGrid.Columns);
            for (int i = 0; i < mDiff.Rows; i++)
            {
                for (int j = 0; j < mDiff.Columns; j++)
                {
                    if (mSmallGrid[i, j] == 100)
                    {
                        mDiff[i, j] = 0;
                    }
                    if (mSmallGrid[i, j] == 140)
                    {
                        mDiff[i, j] = 1;
                    }
                    if (mSmallGrid[i, j] == 180)
                    {
                        mDiff[i, j] = 2;
                    }
                }
            }
            LogLine("Done!");
        }

        private void SaveMap(string mapName, RtwMatrix mMap)
        {
            string TargetDirectory = "Maps\\" + mapName;
            string TargetFile = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + TargetDirectory + "\\" + mapName + ".csv";
            Log("Saving " + mapName + " to " + TargetFile + "......");
            // Create folder if it doesn't exist
            if (!Directory.Exists(TargetDirectory))
            {
                Directory.CreateDirectory(TargetDirectory);
            }
            // Delete file if it already exists
            if (File.Exists(TargetFile))
            {
                File.Delete(TargetFile);
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(TargetFile))
            {
                for (int i = 0; i < mMap.Rows; i++)
                {
                    string strLine = "";
                    for (int j = 0; j < mMap.Columns; j++)
                    {
                        if (mapName == "Landcover")
                        {
                            strLine += Convert.ToInt16(mMap[i, j]) + ",";
                        }
                        else
                        {
                            strLine += mMap[i, j] + ",";
                        }
                    }
                    strLine = strLine.Substring(0, strLine.Length - 1);
                    file.WriteLine(strLine);
                }
            }
            LogLine("Done!");
        }

        private void Log(string str)
        {
            rtxtLog.AppendText(str);
        }

        private void LogLine(string str)
        {
            rtxtLog.AppendText(str + "\n");
        }
    }
}
