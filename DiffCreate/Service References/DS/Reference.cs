﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiffCreate.DS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://edc/usgs/gov/", ConfigurationName="DS.DownloadServicePortType")]
    public interface DownloadServicePortType {
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://edc/usgs/gov/xsd) of message getDataRequest does not match the default value (http://edc/usgs/gov/)
        [System.ServiceModel.OperationContractAttribute(Action="urn:getData", ReplyAction="urn:getDataResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        DiffCreate.DS.getDataResponse getData(DiffCreate.DS.getDataRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://edc/usgs/gov/xsd) of message getDownloadStatusRequest does not match the default value (http://edc/usgs/gov/)
        [System.ServiceModel.OperationContractAttribute(Action="urn:getDownloadStatus", ReplyAction="urn:getDownloadStatusResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        DiffCreate.DS.getDownloadStatusResponse getDownloadStatus(DiffCreate.DS.getDownloadStatusRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://edc/usgs/gov/xsd) of message setDownloadCompleteRequest does not match the default value (http://edc/usgs/gov/)
        [System.ServiceModel.OperationContractAttribute(Action="urn:setDownloadComplete", ReplyAction="urn:setDownloadCompleteResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        DiffCreate.DS.setDownloadCompleteResponse setDownloadComplete(DiffCreate.DS.setDownloadCompleteRequest request);
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://edc/usgs/gov/xsd) of message initiateDownloadRequest does not match the default value (http://edc/usgs/gov/)
        [System.ServiceModel.OperationContractAttribute(Action="urn:initiateDownload", ReplyAction="urn:initiateDownloadResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        DiffCreate.DS.initiateDownloadResponse initiateDownload(DiffCreate.DS.initiateDownloadRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getData", WrapperNamespace="http://edc/usgs/gov/xsd", IsWrapped=true)]
    public partial class getDataRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string downloadID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string DB;
        
        public getDataRequest() {
        }
        
        public getDataRequest(string downloadID, string DB) {
            this.downloadID = downloadID;
            this.DB = DB;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getDataResponse", WrapperNamespace="http://edc/usgs/gov/xsd", IsWrapped=true)]
    public partial class getDataResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @return;
        
        public getDataResponse() {
        }
        
        public getDataResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getDownloadStatus", WrapperNamespace="http://edc/usgs/gov/xsd", IsWrapped=true)]
    public partial class getDownloadStatusRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string downloadID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string DB;
        
        public getDownloadStatusRequest() {
        }
        
        public getDownloadStatusRequest(string downloadID, string DB) {
            this.downloadID = downloadID;
            this.DB = DB;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getDownloadStatusResponse", WrapperNamespace="http://edc/usgs/gov/xsd", IsWrapped=true)]
    public partial class getDownloadStatusResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @return;
        
        public getDownloadStatusResponse() {
        }
        
        public getDownloadStatusResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="setDownloadComplete", WrapperNamespace="http://edc/usgs/gov/xsd", IsWrapped=true)]
    public partial class setDownloadCompleteRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string downloadID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string DB;
        
        public setDownloadCompleteRequest() {
        }
        
        public setDownloadCompleteRequest(string downloadID, string DB) {
            this.downloadID = downloadID;
            this.DB = DB;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="setDownloadCompleteResponse", WrapperNamespace="http://edc/usgs/gov/xsd", IsWrapped=true)]
    public partial class setDownloadCompleteResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @return;
        
        public setDownloadCompleteResponse() {
        }
        
        public setDownloadCompleteResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="initiateDownload", WrapperNamespace="http://edc/usgs/gov/xsd", IsWrapped=true)]
    public partial class initiateDownloadRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string siz;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string key;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ras;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string pfm;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string imsurl;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=5)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ms;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=6)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string att;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=7)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string lay;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=8)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string fid;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=9)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string dlpre;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=10)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string lft;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=11)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string rgt;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=12)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string top;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=13)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string bot;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=14)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string wmd;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=15)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string mur;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=16)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string mcd;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=17)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string mdf;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=18)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string arc;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=19)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string sde;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=20)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string msd;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=21)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string zun;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=22)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string prj;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=23)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string rsp;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=24)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string bnd;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=25)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string bndnm;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=26)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string csx;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=27)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string csy;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=28)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ics;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=29)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string PL;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=30)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string MSU;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=31)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string MSS;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=32)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string MSL;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=33)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string MSEA;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=34)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string DLS;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="FID", Namespace="http://edc/usgs/gov/xsd", Order=35)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string FID1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ARC", Namespace="http://edc/usgs/gov/xsd", Order=36)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ARC1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=37)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string DLA;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=38)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string EIDL;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=39)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string DB;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=40)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ORIG;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=41)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string bulkID;
        
        public initiateDownloadRequest() {
        }
        
        public initiateDownloadRequest(
                    string siz, 
                    string key, 
                    string ras, 
                    string pfm, 
                    string imsurl, 
                    string ms, 
                    string att, 
                    string lay, 
                    string fid, 
                    string dlpre, 
                    string lft, 
                    string rgt, 
                    string top, 
                    string bot, 
                    string wmd, 
                    string mur, 
                    string mcd, 
                    string mdf, 
                    string arc, 
                    string sde, 
                    string msd, 
                    string zun, 
                    string prj, 
                    string rsp, 
                    string bnd, 
                    string bndnm, 
                    string csx, 
                    string csy, 
                    string ics, 
                    string PL, 
                    string MSU, 
                    string MSS, 
                    string MSL, 
                    string MSEA, 
                    string DLS, 
                    string FID1, 
                    string ARC1, 
                    string DLA, 
                    string EIDL, 
                    string DB, 
                    string ORIG, 
                    string bulkID) {
            this.siz = siz;
            this.key = key;
            this.ras = ras;
            this.pfm = pfm;
            this.imsurl = imsurl;
            this.ms = ms;
            this.att = att;
            this.lay = lay;
            this.fid = fid;
            this.dlpre = dlpre;
            this.lft = lft;
            this.rgt = rgt;
            this.top = top;
            this.bot = bot;
            this.wmd = wmd;
            this.mur = mur;
            this.mcd = mcd;
            this.mdf = mdf;
            this.arc = arc;
            this.sde = sde;
            this.msd = msd;
            this.zun = zun;
            this.prj = prj;
            this.rsp = rsp;
            this.bnd = bnd;
            this.bndnm = bndnm;
            this.csx = csx;
            this.csy = csy;
            this.ics = ics;
            this.PL = PL;
            this.MSU = MSU;
            this.MSS = MSS;
            this.MSL = MSL;
            this.MSEA = MSEA;
            this.DLS = DLS;
            this.FID1 = FID1;
            this.ARC1 = ARC1;
            this.DLA = DLA;
            this.EIDL = EIDL;
            this.DB = DB;
            this.ORIG = ORIG;
            this.bulkID = bulkID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="initiateDownloadResponse", WrapperNamespace="http://edc/usgs/gov/xsd", IsWrapped=true)]
    public partial class initiateDownloadResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://edc/usgs/gov/xsd", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @return;
        
        public initiateDownloadResponse() {
        }
        
        public initiateDownloadResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DownloadServicePortTypeChannel : DiffCreate.DS.DownloadServicePortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DownloadServicePortTypeClient : System.ServiceModel.ClientBase<DiffCreate.DS.DownloadServicePortType>, DiffCreate.DS.DownloadServicePortType {
        
        public DownloadServicePortTypeClient() {
        }
        
        public DownloadServicePortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DownloadServicePortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DownloadServicePortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DownloadServicePortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DiffCreate.DS.getDataResponse DiffCreate.DS.DownloadServicePortType.getData(DiffCreate.DS.getDataRequest request) {
            return base.Channel.getData(request);
        }
        
        public string getData(string downloadID, string DB) {
            DiffCreate.DS.getDataRequest inValue = new DiffCreate.DS.getDataRequest();
            inValue.downloadID = downloadID;
            inValue.DB = DB;
            DiffCreate.DS.getDataResponse retVal = ((DiffCreate.DS.DownloadServicePortType)(this)).getData(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DiffCreate.DS.getDownloadStatusResponse DiffCreate.DS.DownloadServicePortType.getDownloadStatus(DiffCreate.DS.getDownloadStatusRequest request) {
            return base.Channel.getDownloadStatus(request);
        }
        
        public string getDownloadStatus(string downloadID, string DB) {
            DiffCreate.DS.getDownloadStatusRequest inValue = new DiffCreate.DS.getDownloadStatusRequest();
            inValue.downloadID = downloadID;
            inValue.DB = DB;
            DiffCreate.DS.getDownloadStatusResponse retVal = ((DiffCreate.DS.DownloadServicePortType)(this)).getDownloadStatus(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DiffCreate.DS.setDownloadCompleteResponse DiffCreate.DS.DownloadServicePortType.setDownloadComplete(DiffCreate.DS.setDownloadCompleteRequest request) {
            return base.Channel.setDownloadComplete(request);
        }
        
        public string setDownloadComplete(string downloadID, string DB) {
            DiffCreate.DS.setDownloadCompleteRequest inValue = new DiffCreate.DS.setDownloadCompleteRequest();
            inValue.downloadID = downloadID;
            inValue.DB = DB;
            DiffCreate.DS.setDownloadCompleteResponse retVal = ((DiffCreate.DS.DownloadServicePortType)(this)).setDownloadComplete(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DiffCreate.DS.initiateDownloadResponse DiffCreate.DS.DownloadServicePortType.initiateDownload(DiffCreate.DS.initiateDownloadRequest request) {
            return base.Channel.initiateDownload(request);
        }
        
        public string initiateDownload(
                    string siz, 
                    string key, 
                    string ras, 
                    string pfm, 
                    string imsurl, 
                    string ms, 
                    string att, 
                    string lay, 
                    string fid, 
                    string dlpre, 
                    string lft, 
                    string rgt, 
                    string top, 
                    string bot, 
                    string wmd, 
                    string mur, 
                    string mcd, 
                    string mdf, 
                    string arc, 
                    string sde, 
                    string msd, 
                    string zun, 
                    string prj, 
                    string rsp, 
                    string bnd, 
                    string bndnm, 
                    string csx, 
                    string csy, 
                    string ics, 
                    string PL, 
                    string MSU, 
                    string MSS, 
                    string MSL, 
                    string MSEA, 
                    string DLS, 
                    string FID1, 
                    string ARC1, 
                    string DLA, 
                    string EIDL, 
                    string DB, 
                    string ORIG, 
                    string bulkID) {
            DiffCreate.DS.initiateDownloadRequest inValue = new DiffCreate.DS.initiateDownloadRequest();
            inValue.siz = siz;
            inValue.key = key;
            inValue.ras = ras;
            inValue.pfm = pfm;
            inValue.imsurl = imsurl;
            inValue.ms = ms;
            inValue.att = att;
            inValue.lay = lay;
            inValue.fid = fid;
            inValue.dlpre = dlpre;
            inValue.lft = lft;
            inValue.rgt = rgt;
            inValue.top = top;
            inValue.bot = bot;
            inValue.wmd = wmd;
            inValue.mur = mur;
            inValue.mcd = mcd;
            inValue.mdf = mdf;
            inValue.arc = arc;
            inValue.sde = sde;
            inValue.msd = msd;
            inValue.zun = zun;
            inValue.prj = prj;
            inValue.rsp = rsp;
            inValue.bnd = bnd;
            inValue.bndnm = bndnm;
            inValue.csx = csx;
            inValue.csy = csy;
            inValue.ics = ics;
            inValue.PL = PL;
            inValue.MSU = MSU;
            inValue.MSS = MSS;
            inValue.MSL = MSL;
            inValue.MSEA = MSEA;
            inValue.DLS = DLS;
            inValue.FID1 = FID1;
            inValue.ARC1 = ARC1;
            inValue.DLA = DLA;
            inValue.EIDL = EIDL;
            inValue.DB = DB;
            inValue.ORIG = ORIG;
            inValue.bulkID = bulkID;
            DiffCreate.DS.initiateDownloadResponse retVal = ((DiffCreate.DS.DownloadServicePortType)(this)).initiateDownload(inValue);
            return retVal.@return;
        }
    }
}
