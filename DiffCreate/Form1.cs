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
                
            // Load GridFloat

            // Find header file
            string[] MapFolders = Directory.GetDirectories("Maps\\" + strMap);
            // Since there is only one folder
            string[] HeaderFiles = Directory.GetFiles(MapFolders[0], "*.hdr");
            string HeaderFile = HeaderFiles[0];

            // Identify col and row count in .hdr file
            int ncols = 0;
            int nrows = 0;
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
                    ncols = Convert.ToInt16(stuff[stuff.Length-1]);
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
            Log("ncols = " + ncols + ", nrows = " + nrows);

            // Read in float grid
            string[] FloatFiles = Directory.GetFiles(MapFolders[0], "*.flt");
            string FloatFile = HeaderFiles[0];
            using (BinaryReader reader = new BinaryReader(File.Open(FloatFile, FileMode.Open)))
            {
                // read 4 bytes
                byte[] floatBytes = reader.ReadBytes(4);
                // swap the bytes
                floatBytes.Reverse();   
                // get the float from the byte array
                foreach (byte b in floatBytes)
                {
                    float value = BitConverter.ToSingle(floatBytes, 0);
                }
            }
            // Recode map
            // Use Dictionary

            // Save map
            // Load map and display
        }

        private string GetDownloadURL(string strLayerID)
        {
            // Connect to Request Validation Web Services
            Log("Connect to Request ValidationConstraints Service...");
            RVS.RequestValidationServiceClient myRVS = new RVS.RequestValidationServiceClient();

            // Build XML
            Log("Building input XML request string...");
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
                Log("Displaying input XML request String:");
                Log(xmlRequestString);
                Log("");
            }

            // Send Request
            string strMyResponse = "";
            try
            {
                Log("Sending SOAP request...");
                System.Net.ServicePointManager.Expect100Continue = false;
                strMyResponse = myRVS.processAOI2(xmlRequestString);
                if (blnDebug)
                {
                    Log("SOAP Response:");
                    Log(strMyResponse);
                }
            }
            catch (Exception ex)
            {
                if (blnDebug)
                {
                    Log("Error calling Validation Service: " + ex.ToString());
                }
                //TODO If 503 busy then repeat.
                Log("The service is temporarily unavailable. Please try again later!");
                blnService = false;
                return "";
            }

            // Parse response
            strMyResponse = strMyResponse.Replace("&", "@");
            string strDownloadURL = "";
            using (XmlReader reader = XmlReader.Create(new StringReader(strMyResponse)))
            {
                reader.ReadToFollowing("DOWNLOAD_URL");
                strDownloadURL = reader.ReadElementContentAsString();
                strDownloadURL = strDownloadURL.Replace("@", "&");
                Log("DOWNLOAD_URL = " + strDownloadURL);
            }
            return strDownloadURL;
        }

        private string GetDownloadID(string strDownloadURL)
        {
            string strDownloadID = WebGetCall(strDownloadURL);
            Log("DOWNLOAD_ID = " + strDownloadURL);
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
                    Log(xmlResponse);
                    Log("");
                }
            }
            catch (Exception ex)
            {
                Log("Error opening download page: " + ex.ToString());
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
            while (timelapsed < timeout || intStatusCode == 1)
            {
                strStatus = WebGetCall("http://extract.cr.usgs.gov/axis2/services/DownloadService/getDownloadStatus?downloadID=" + strDownloadID);
                Log(strStatus);
                if (strStatus.Substring(0,3) == "400")
                {
                    intStatusCode = 1;
                    Log("Data prep time " + timelapsed + " seconds.");
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
                Log("Download completed successfully!");
            }
            else
            {
                Log("Something went wrong:");
                Log(strStatus);
            }
        }

        private void ExtractMap(string strMap)
        {
            Log("Extracting downloaded zip file...");
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
        }



        private void Log(string str)
        {
            rtxtLog.AppendText(str + "\n");
        }
    }
}
