﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication1.TrackingService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/SafeBusLocationService")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string authKeyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string messageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string parent_nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string statusField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string authKey {
            get {
                return this.authKeyField;
            }
            set {
                if ((object.ReferenceEquals(this.authKeyField, value) != true)) {
                    this.authKeyField = value;
                    this.RaisePropertyChanged("authKey");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string message {
            get {
                return this.messageField;
            }
            set {
                if ((object.ReferenceEquals(this.messageField, value) != true)) {
                    this.messageField = value;
                    this.RaisePropertyChanged("message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string parent_name {
            get {
                return this.parent_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.parent_nameField, value) != true)) {
                    this.parent_nameField = value;
                    this.RaisePropertyChanged("parent_name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string status {
            get {
                return this.statusField;
            }
            set {
                if ((object.ReferenceEquals(this.statusField, value) != true)) {
                    this.statusField = value;
                    this.RaisePropertyChanged("status");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Location", Namespace="http://schemas.datacontract.org/2004/07/SafeBusLocationService")]
    [System.SerializableAttribute()]
    public partial class Location : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleApplication1.TrackingService.TrackData[] dataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string messageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string statusField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleApplication1.TrackingService.TrackData[] data {
            get {
                return this.dataField;
            }
            set {
                if ((object.ReferenceEquals(this.dataField, value) != true)) {
                    this.dataField = value;
                    this.RaisePropertyChanged("data");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string message {
            get {
                return this.messageField;
            }
            set {
                if ((object.ReferenceEquals(this.messageField, value) != true)) {
                    this.messageField = value;
                    this.RaisePropertyChanged("message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string status {
            get {
                return this.statusField;
            }
            set {
                if ((object.ReferenceEquals(this.statusField, value) != true)) {
                    this.statusField = value;
                    this.RaisePropertyChanged("status");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TrackData", Namespace="http://schemas.datacontract.org/2004/07/SafeBusLocationService")]
    [System.SerializableAttribute()]
    public partial class TrackData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleApplication1.TrackingService.LatLng bus_locationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string bus_nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string bus_statusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleApplication1.TrackingService.Stop end_locationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleApplication1.TrackingService.Stop start_locationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleApplication1.TrackingService.Stop[] upcoming_locationsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsoleApplication1.TrackingService.Stop[] visited_locationsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleApplication1.TrackingService.LatLng bus_location {
            get {
                return this.bus_locationField;
            }
            set {
                if ((object.ReferenceEquals(this.bus_locationField, value) != true)) {
                    this.bus_locationField = value;
                    this.RaisePropertyChanged("bus_location");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string bus_name {
            get {
                return this.bus_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.bus_nameField, value) != true)) {
                    this.bus_nameField = value;
                    this.RaisePropertyChanged("bus_name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string bus_status {
            get {
                return this.bus_statusField;
            }
            set {
                if ((object.ReferenceEquals(this.bus_statusField, value) != true)) {
                    this.bus_statusField = value;
                    this.RaisePropertyChanged("bus_status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleApplication1.TrackingService.Stop end_location {
            get {
                return this.end_locationField;
            }
            set {
                if ((object.ReferenceEquals(this.end_locationField, value) != true)) {
                    this.end_locationField = value;
                    this.RaisePropertyChanged("end_location");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleApplication1.TrackingService.Stop start_location {
            get {
                return this.start_locationField;
            }
            set {
                if ((object.ReferenceEquals(this.start_locationField, value) != true)) {
                    this.start_locationField = value;
                    this.RaisePropertyChanged("start_location");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleApplication1.TrackingService.Stop[] upcoming_locations {
            get {
                return this.upcoming_locationsField;
            }
            set {
                if ((object.ReferenceEquals(this.upcoming_locationsField, value) != true)) {
                    this.upcoming_locationsField = value;
                    this.RaisePropertyChanged("upcoming_locations");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ConsoleApplication1.TrackingService.Stop[] visited_locations {
            get {
                return this.visited_locationsField;
            }
            set {
                if ((object.ReferenceEquals(this.visited_locationsField, value) != true)) {
                    this.visited_locationsField = value;
                    this.RaisePropertyChanged("visited_locations");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LatLng", Namespace="http://schemas.datacontract.org/2004/07/SafeBusLocationService")]
    [System.SerializableAttribute()]
    public partial class LatLng : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string pLatitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string pLongitudeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string pLatitude {
            get {
                return this.pLatitudeField;
            }
            set {
                if ((object.ReferenceEquals(this.pLatitudeField, value) != true)) {
                    this.pLatitudeField = value;
                    this.RaisePropertyChanged("pLatitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string pLongitude {
            get {
                return this.pLongitudeField;
            }
            set {
                if ((object.ReferenceEquals(this.pLongitudeField, value) != true)) {
                    this.pLongitudeField = value;
                    this.RaisePropertyChanged("pLongitude");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Stop", Namespace="http://schemas.datacontract.org/2004/07/SafeBusLocationService")]
    [System.SerializableAttribute()]
    public partial class Stop : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string location_nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string pLatitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string pLongitudeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string location_name {
            get {
                return this.location_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.location_nameField, value) != true)) {
                    this.location_nameField = value;
                    this.RaisePropertyChanged("location_name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string pLatitude {
            get {
                return this.pLatitudeField;
            }
            set {
                if ((object.ReferenceEquals(this.pLatitudeField, value) != true)) {
                    this.pLatitudeField = value;
                    this.RaisePropertyChanged("pLatitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string pLongitude {
            get {
                return this.pLongitudeField;
            }
            set {
                if ((object.ReferenceEquals(this.pLongitudeField, value) != true)) {
                    this.pLongitudeField = value;
                    this.RaisePropertyChanged("pLongitude");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TrackingService.ITracking")]
    public interface ITracking {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITracking/Login", ReplyAction="http://tempuri.org/ITracking/LoginResponse")]
        ConsoleApplication1.TrackingService.User Login(string UserName, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITracking/GetLocationDetails", ReplyAction="http://tempuri.org/ITracking/GetLocationDetailsResponse")]
        ConsoleApplication1.TrackingService.Location GetLocationDetails(string authKey);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITrackingChannel : ConsoleApplication1.TrackingService.ITracking, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TrackingClient : System.ServiceModel.ClientBase<ConsoleApplication1.TrackingService.ITracking>, ConsoleApplication1.TrackingService.ITracking {
        
        public TrackingClient() {
        }
        
        public TrackingClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TrackingClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TrackingClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TrackingClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ConsoleApplication1.TrackingService.User Login(string UserName, string Password) {
            return base.Channel.Login(UserName, Password);
        }
        
        public ConsoleApplication1.TrackingService.Location GetLocationDetails(string authKey) {
            return base.Channel.GetLocationDetails(authKey);
        }
    }
}
