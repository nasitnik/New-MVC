//-----------------------------------------------------------------------
// <copyright file="SQLConfig.cs" company="Rushkar">
//     Copyright Rushkar. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TaxiApp.Data
{
    /// <summary>
    /// SQL configuration class which holds stored procedure name.
    /// </summary>
    internal sealed class SQLConfig
    {
        #region MasterLaptopDescriptipn
        public const string spMasterLaptopDescriptipn_Upsert = "spMasterLaptopDescriptipn_Upsert";
        public const string spMasterLaptopDescriptipn_ById = "spMasterLaptopDescriptipn_ById";
        public const string spMasterLaptopDescriptipn_All = "spMasterLaptopDescriptipn_All";
       
        #endregion
        
        #region Trip
        public const string Trip_All = "Trip_All";
        public const string Trip_ById = "Trip_ById";
        public const string Trip_Delete = "Trip_Delete";
        public const string Trip_Upsert = "Trip_Upsert";
        public const string Driver_Assigned = "Driver_Assigned";
        public const string Trip_SendOTP = "Trip_SendOTP";
        public const string Trip_VerifyOtp = "Trip_VerifyOtp";
        public const string TripDetails_ByCustomerId = "TripDetails_ByCustomerId";
        public const string TripList_ApprovalPending = "TripList_ApprovalPending";
        public const string Trip_AcceptByDriver = "Trip_AcceptByDriver";
        public const string TripCancelReason_Upsert = "TripCancelReason_Upsert";
        public const string Trip_RejectByDriver = "Trip_RejectByDriver";
        public const string Trip_End = "Trip_End";
        public const string PromoCode_Remove = "PromoCode_Remove";
        public const string TripRating_Upsert = "TripRating_Upsert";
        public const string PromoCode_Apply = "PromoCode_Apply";
        #endregion

        #region PromoCode  
        public const string PromoCode_Upsert = "PromoCode_Upsert";
        public const string PromoCode_ById = "PromoCode_ById";
        public const string PromoCode_All = "PromoCode_All ";
        public const string PromoCode_Delete = "PromoCode_Delete";
        #endregion

        #region TripStatus
        public const string TripStatus_All = "TripStatus_All";
        #endregion

        #region UserType
        public const string UserType_All = "UserType_All";
        #endregion

        #region AdminUsers
        public const string AdminUsers_All = "AdminUsers_All";
        public const string AdminUsers_ById = "AdminUsers_ById";
        public const string AdminUsers_Delete = "AdminUsers_Delete";
        public const string AdminUsers_Upsert = "AdminUsers_Upsert";
        public const string AdminUsers_Login = "AdminUsers_Login";
        public const string Users_Login = "Users_Login";
        public const string Users_ById = "Users_ById";
        public const string AdminUsers_ChangePassword = "AdminUsers_ChangePassword";
        public const string AdminUsers_Logout = "AdminUsers_Logout";
        public const string AdminUsers_ActInAct = "AdminUsers_ActInAct";
        #endregion

        #region UserType
        public const string Trip_UpsertStatus = "Trip_UpsertStatus";
        #endregion

        #region Customer
        public const string Customer_All = "Customer_All";
        public const string Customer_ById = "Customer_ById";
        public const string Customer_Delete = "Customer_Delete";
        public const string Customer_Upsert = "Customer_Upsert";
        public const string Customer_Login = "Customer_Login";
        public const string Customer_ChangePassword = "Customer_ChangePassword";
        public const string Customer_ActInAct = "Customer_ActInAct";
        public const string Customer_Logout = "Customer_Logout";
        public const string Customer_ProfilePictureUpdate = "Customer_ProfilePictureUpdate";
        public const string Customer_IdProofUpdate = "Customer_IdProofUpdate";
        public const string Customer_RcCardUpdate = "Customer_RcCardUpdate";
        public const string Customer_AddressUpdate = "Customer_AddressUpdate";
        public const string Customer_IdProofApproved = "Customer_IdProofApproved";
        public const string Customer_RcCardApproved = "Customer_RcCardApproved";
        public const string Trip_Start = "Trip_Start";
        #endregion

        #region Driver
        public const string Driver_ById = "Driver_ById";
        public const string Driver_Delete = "Driver_Delete";
        public const string Driver_Upsert = "Driver_Upsert";
        public const string Driver_All = "Driver_All ";
        public const string Driver_Login = "Driver_Login";
        public const string Driver_LatLon = "Driver_LatLon";
        public const string Driver_ChangePassword = "Driver_ChangePassword";
        public const string Driver_Logout = "Driver_Logout";
        public const string Driver_ActInAct = "Driver_ActInAct";
        public const string Driver_ProfilePictureUpdate = "Driver_ProfilePictureUpdate";
        public const string Driver_IdProofUpdate = "Driver_IdProofUpdate";
        public const string Driver_MsgRec = "Driver_MsgRec";
        public const string Driver_DrivingLicenceUpdate = "Driver_DrivingLicenceUpdate";
        public const string Driver_AddressUpdate = "Driver_AddressUpdate";
        public const string Driver_DriveingLicenceApproved = "Driver_DriveingLicenceApproved";
        public const string Driver_IdProofApproved = "Driver_IdProofApproved";
        public const string Driver_IsOnline = "Driver_IsOnline";
        #endregion

        #region DriverNotifications
        public const string DriverNotifications_ById = "DriverNotifications_ById";
        public const string DriverNotifications_Upsert = "DriverNotifications_Upsert";
        public const string DriverNotifications_All = "DriverNotifications_All";
        public const string DriverNotifications_ReadUnRead = "DriverNotifications_ReadUnRead";
        #endregion

        #region CustomerNotifications
        public const string CustomerNotifications_ById = "CustomerNotifications_ById";
        public const string CustomerNotifications_Upsert = "CustomerNotifications_Upsert";
        public const string CustomerNotifications_All = "CustomerNotifications_All";
        public const string CustomerNotifications_ReadUnRead = "CustomerNotifications_ReadUnRead";
        public const string CustomerNotifications_Delete = "CustomerNotifications_Delete";
        #endregion

        #region MasterCountry
        public const string MasterCountry_All = "MasterCountry_All";
        #endregion
        #region MasterState
        public const string MasterState_All = "MasterState_All";
        #endregion
        #region MasterCity
        public const string MasterCity_All = "MasterCity_All";
        #endregion
        
        #region Faq
        public const string Faq_ById = "Faq_ById";
        public const string Faq_Upsert = "Faq_Upsert";
        public const string Faq_All = "Faq_All";
        public const string Faq_Delete = "Faq_Delete";
        #endregion
        
        #region Faq
        public const string Help_All = "Help_All";
        #endregion

        public const string MasterServiceBase_All = "MasterServiceBase_All";

        public const string MasterTripCancelReason_Upsert = "MasterTripCancelReason_Upsert";
        public const string MasterTripCancelReason_All = "MasterTripCancelReason_All";

        #region PricePackage 
        public const string PricePackage_ById = "PricePackage_ById";
        public const string PricePackage_Upsert = "PricePackage_Upsert";
        public const string PricePackage_All = "PricePackage_All";
        #endregion

        #region MasterHour                 
        public const string MasterHour_All = "MasterHour_All";
        #endregion
    }
}
