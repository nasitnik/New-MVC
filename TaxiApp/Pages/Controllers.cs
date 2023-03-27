namespace TaxiApp.Pages
{
    public class Controllers
    {
        public const string Authentication = "Authentication";
        public const string Customers = "Customers";
        public const string Home = "Home";
        public const string Salons = "Salons";
        public const string Store = "Store";
        public const string SalonServices = "SalonServices";
        public const string Employee = "Employee";
	    public const string MyProfile = "MyProfile";
        public const string Appointments = "Appointments";


        public static string[] AdminAccess = {Home,Authentication,Customers, Salons, Store, SalonServices, Employee, MyProfile , Appointments };
        public static string[] SalonOwnerAccess = { Salons, Home, Customers, Authentication, Store, SalonServices, Employee, MyProfile, Appointments };
        public static string[] EmployeeAccess = {Home};
        public static string[] CustomerAccess = {Home};
        public static string[] SellerAccess = {Home};
    }
}