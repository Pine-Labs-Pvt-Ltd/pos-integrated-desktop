﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.1.
// 
#pragma warning disable 1591

namespace PlutusHubComm.PlutusHubWeb {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="PlutusHubServiceSoap", Namespace="urn:PlutusHubService")]
    public partial class PlutusHubService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback PLHub_ExchangeOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public PlutusHubService() {
            this.Url = global::PlutusHubComm.Properties.Settings.Default.PlutusHubComm_PlutusHubWeb_PlutusHubService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event PLHub_ExchangeCompletedEventHandler PLHub_ExchangeCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#PLHub_Exchange", RequestNamespace="urn:PlutusHubService", ResponseNamespace="urn:PlutusHubService")]
        [return: System.Xml.Serialization.SoapElementAttribute("RESPONSE_TYPE")]
        public int PLHub_Exchange(int CLIENT_ID, string SECURITY_TOKEN, int REQUEST_TYPE, string REQUEST_XML, ref int SEQUENCE_CODE, out string RESPONSE_XML) {
            object[] results = this.Invoke("PLHub_Exchange", new object[] {
                        CLIENT_ID,
                        SECURITY_TOKEN,
                        REQUEST_TYPE,
                        REQUEST_XML,
                        SEQUENCE_CODE});
            SEQUENCE_CODE = ((int)(results[1]));
            RESPONSE_XML = ((string)(results[2]));
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void PLHub_ExchangeAsync(int CLIENT_ID, string SECURITY_TOKEN, int REQUEST_TYPE, string REQUEST_XML, int SEQUENCE_CODE) {
            this.PLHub_ExchangeAsync(CLIENT_ID, SECURITY_TOKEN, REQUEST_TYPE, REQUEST_XML, SEQUENCE_CODE, null);
        }
        
        /// <remarks/>
        public void PLHub_ExchangeAsync(int CLIENT_ID, string SECURITY_TOKEN, int REQUEST_TYPE, string REQUEST_XML, int SEQUENCE_CODE, object userState) {
            if ((this.PLHub_ExchangeOperationCompleted == null)) {
                this.PLHub_ExchangeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPLHub_ExchangeOperationCompleted);
            }
            this.InvokeAsync("PLHub_Exchange", new object[] {
                        CLIENT_ID,
                        SECURITY_TOKEN,
                        REQUEST_TYPE,
                        REQUEST_XML,
                        SEQUENCE_CODE}, this.PLHub_ExchangeOperationCompleted, userState);
        }
        
        private void OnPLHub_ExchangeOperationCompleted(object arg) {
            if ((this.PLHub_ExchangeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PLHub_ExchangeCompleted(this, new PLHub_ExchangeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void PLHub_ExchangeCompletedEventHandler(object sender, PLHub_ExchangeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PLHub_ExchangeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PLHub_ExchangeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public int SEQUENCE_CODE {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string RESPONSE_XML {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[2]));
            }
        }
    }
}

#pragma warning restore 1591