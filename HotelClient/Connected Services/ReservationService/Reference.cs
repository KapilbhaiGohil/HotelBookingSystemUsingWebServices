﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelClient.ReservationService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ReservationFull", Namespace="http://schemas.datacontract.org/2004/07/HotelService")]
    [System.SerializableAttribute()]
    public partial class ReservationFull : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int amountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime checkinField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime checkoutField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime dateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string emailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string firstnameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string lastnameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string phoneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string specialRequestField;
        
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
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int amount {
            get {
                return this.amountField;
            }
            set {
                if ((this.amountField.Equals(value) != true)) {
                    this.amountField = value;
                    this.RaisePropertyChanged("amount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime checkin {
            get {
                return this.checkinField;
            }
            set {
                if ((this.checkinField.Equals(value) != true)) {
                    this.checkinField = value;
                    this.RaisePropertyChanged("checkin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime checkout {
            get {
                return this.checkoutField;
            }
            set {
                if ((this.checkoutField.Equals(value) != true)) {
                    this.checkoutField = value;
                    this.RaisePropertyChanged("checkout");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime date {
            get {
                return this.dateField;
            }
            set {
                if ((this.dateField.Equals(value) != true)) {
                    this.dateField = value;
                    this.RaisePropertyChanged("date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string email {
            get {
                return this.emailField;
            }
            set {
                if ((object.ReferenceEquals(this.emailField, value) != true)) {
                    this.emailField = value;
                    this.RaisePropertyChanged("email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string firstname {
            get {
                return this.firstnameField;
            }
            set {
                if ((object.ReferenceEquals(this.firstnameField, value) != true)) {
                    this.firstnameField = value;
                    this.RaisePropertyChanged("firstname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string lastname {
            get {
                return this.lastnameField;
            }
            set {
                if ((object.ReferenceEquals(this.lastnameField, value) != true)) {
                    this.lastnameField = value;
                    this.RaisePropertyChanged("lastname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string phone {
            get {
                return this.phoneField;
            }
            set {
                if ((object.ReferenceEquals(this.phoneField, value) != true)) {
                    this.phoneField = value;
                    this.RaisePropertyChanged("phone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string specialRequest {
            get {
                return this.specialRequestField;
            }
            set {
                if ((object.ReferenceEquals(this.specialRequestField, value) != true)) {
                    this.specialRequestField = value;
                    this.RaisePropertyChanged("specialRequest");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="FinalStorageData", Namespace="http://schemas.datacontract.org/2004/07/HotelService")]
    [System.SerializableAttribute()]
    public partial class FinalStorageData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime checkinField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime checkoutField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string emailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string firstnameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string lastnameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string numberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long priceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HotelClient.ReservationService.RoomData[] roomsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string specialrequestField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int totaldaysField;
        
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
        public System.DateTime checkin {
            get {
                return this.checkinField;
            }
            set {
                if ((this.checkinField.Equals(value) != true)) {
                    this.checkinField = value;
                    this.RaisePropertyChanged("checkin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime checkout {
            get {
                return this.checkoutField;
            }
            set {
                if ((this.checkoutField.Equals(value) != true)) {
                    this.checkoutField = value;
                    this.RaisePropertyChanged("checkout");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string email {
            get {
                return this.emailField;
            }
            set {
                if ((object.ReferenceEquals(this.emailField, value) != true)) {
                    this.emailField = value;
                    this.RaisePropertyChanged("email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string firstname {
            get {
                return this.firstnameField;
            }
            set {
                if ((object.ReferenceEquals(this.firstnameField, value) != true)) {
                    this.firstnameField = value;
                    this.RaisePropertyChanged("firstname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string lastname {
            get {
                return this.lastnameField;
            }
            set {
                if ((object.ReferenceEquals(this.lastnameField, value) != true)) {
                    this.lastnameField = value;
                    this.RaisePropertyChanged("lastname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string number {
            get {
                return this.numberField;
            }
            set {
                if ((object.ReferenceEquals(this.numberField, value) != true)) {
                    this.numberField = value;
                    this.RaisePropertyChanged("number");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long price {
            get {
                return this.priceField;
            }
            set {
                if ((this.priceField.Equals(value) != true)) {
                    this.priceField = value;
                    this.RaisePropertyChanged("price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public HotelClient.ReservationService.RoomData[] rooms {
            get {
                return this.roomsField;
            }
            set {
                if ((object.ReferenceEquals(this.roomsField, value) != true)) {
                    this.roomsField = value;
                    this.RaisePropertyChanged("rooms");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string specialrequest {
            get {
                return this.specialrequestField;
            }
            set {
                if ((object.ReferenceEquals(this.specialrequestField, value) != true)) {
                    this.specialrequestField = value;
                    this.RaisePropertyChanged("specialrequest");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int totaldays {
            get {
                return this.totaldaysField;
            }
            set {
                if ((this.totaldaysField.Equals(value) != true)) {
                    this.totaldaysField = value;
                    this.RaisePropertyChanged("totaldays");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="RoomData", Namespace="http://schemas.datacontract.org/2004/07/HotelService")]
    [System.SerializableAttribute()]
    public partial class RoomData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string adultsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string childrenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string headingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string priceField;
        
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
        public string adults {
            get {
                return this.adultsField;
            }
            set {
                if ((object.ReferenceEquals(this.adultsField, value) != true)) {
                    this.adultsField = value;
                    this.RaisePropertyChanged("adults");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string children {
            get {
                return this.childrenField;
            }
            set {
                if ((object.ReferenceEquals(this.childrenField, value) != true)) {
                    this.childrenField = value;
                    this.RaisePropertyChanged("children");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string heading {
            get {
                return this.headingField;
            }
            set {
                if ((object.ReferenceEquals(this.headingField, value) != true)) {
                    this.headingField = value;
                    this.RaisePropertyChanged("heading");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string price {
            get {
                return this.priceField;
            }
            set {
                if ((object.ReferenceEquals(this.priceField, value) != true)) {
                    this.priceField = value;
                    this.RaisePropertyChanged("price");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Reservation", Namespace="http://schemas.datacontract.org/2004/07/HotelService")]
    [System.SerializableAttribute()]
    public partial class Reservation : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime checkinField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime checkoutField;
        
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
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime checkin {
            get {
                return this.checkinField;
            }
            set {
                if ((this.checkinField.Equals(value) != true)) {
                    this.checkinField = value;
                    this.RaisePropertyChanged("checkin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime checkout {
            get {
                return this.checkoutField;
            }
            set {
                if ((this.checkoutField.Equals(value) != true)) {
                    this.checkoutField = value;
                    this.RaisePropertyChanged("checkout");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ReservationService.IReservationService")]
    public interface IReservationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReservationService/cancelReservation", ReplyAction="http://tempuri.org/IReservationService/cancelReservationResponse")]
        bool cancelReservation(int resId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReservationService/cancelReservation", ReplyAction="http://tempuri.org/IReservationService/cancelReservationResponse")]
        System.Threading.Tasks.Task<bool> cancelReservationAsync(int resId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReservationService/FindReservationByIdAndEmail", ReplyAction="http://tempuri.org/IReservationService/FindReservationByIdAndEmailResponse")]
        HotelClient.ReservationService.ReservationFull FindReservationByIdAndEmail(int id, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReservationService/FindReservationByIdAndEmail", ReplyAction="http://tempuri.org/IReservationService/FindReservationByIdAndEmailResponse")]
        System.Threading.Tasks.Task<HotelClient.ReservationService.ReservationFull> FindReservationByIdAndEmailAsync(int id, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReservationService/BookRoom", ReplyAction="http://tempuri.org/IReservationService/BookRoomResponse")]
        int BookRoom(HotelClient.ReservationService.FinalStorageData dt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReservationService/BookRoom", ReplyAction="http://tempuri.org/IReservationService/BookRoomResponse")]
        System.Threading.Tasks.Task<int> BookRoomAsync(HotelClient.ReservationService.FinalStorageData dt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReservationService/getAllReservationConflicts", ReplyAction="http://tempuri.org/IReservationService/getAllReservationConflictsResponse")]
        int[] getAllReservationConflicts(System.DateTime checkin, System.DateTime checkout);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReservationService/getAllReservationConflicts", ReplyAction="http://tempuri.org/IReservationService/getAllReservationConflictsResponse")]
        System.Threading.Tasks.Task<int[]> getAllReservationConflictsAsync(System.DateTime checkin, System.DateTime checkout);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReservationService/GetALlReservationIds", ReplyAction="http://tempuri.org/IReservationService/GetALlReservationIdsResponse")]
        HotelClient.ReservationService.Reservation[] GetALlReservationIds();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReservationService/GetALlReservationIds", ReplyAction="http://tempuri.org/IReservationService/GetALlReservationIdsResponse")]
        System.Threading.Tasks.Task<HotelClient.ReservationService.Reservation[]> GetALlReservationIdsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IReservationServiceChannel : HotelClient.ReservationService.IReservationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReservationServiceClient : System.ServiceModel.ClientBase<HotelClient.ReservationService.IReservationService>, HotelClient.ReservationService.IReservationService {
        
        public ReservationServiceClient() {
        }
        
        public ReservationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ReservationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReservationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReservationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool cancelReservation(int resId) {
            return base.Channel.cancelReservation(resId);
        }
        
        public System.Threading.Tasks.Task<bool> cancelReservationAsync(int resId) {
            return base.Channel.cancelReservationAsync(resId);
        }
        
        public HotelClient.ReservationService.ReservationFull FindReservationByIdAndEmail(int id, string email) {
            return base.Channel.FindReservationByIdAndEmail(id, email);
        }
        
        public System.Threading.Tasks.Task<HotelClient.ReservationService.ReservationFull> FindReservationByIdAndEmailAsync(int id, string email) {
            return base.Channel.FindReservationByIdAndEmailAsync(id, email);
        }
        
        public int BookRoom(HotelClient.ReservationService.FinalStorageData dt) {
            return base.Channel.BookRoom(dt);
        }
        
        public System.Threading.Tasks.Task<int> BookRoomAsync(HotelClient.ReservationService.FinalStorageData dt) {
            return base.Channel.BookRoomAsync(dt);
        }
        
        public int[] getAllReservationConflicts(System.DateTime checkin, System.DateTime checkout) {
            return base.Channel.getAllReservationConflicts(checkin, checkout);
        }
        
        public System.Threading.Tasks.Task<int[]> getAllReservationConflictsAsync(System.DateTime checkin, System.DateTime checkout) {
            return base.Channel.getAllReservationConflictsAsync(checkin, checkout);
        }
        
        public HotelClient.ReservationService.Reservation[] GetALlReservationIds() {
            return base.Channel.GetALlReservationIds();
        }
        
        public System.Threading.Tasks.Task<HotelClient.ReservationService.Reservation[]> GetALlReservationIdsAsync() {
            return base.Channel.GetALlReservationIdsAsync();
        }
    }
}
