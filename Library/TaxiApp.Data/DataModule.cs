//-----------------------------------------------------------------------
// <copyright file="DataModule.cs" company="Rushkar">
//     Copyright Rushkar Solutions. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TaxiApp.Data
{
    using Autofac;
    using TaxiApp.Data.Contract;

    //using TaxiApp.Data.Contract;


    /// <summary>
    /// Contract Class for DataModule.
    /// </summary>
    public class DataModule : Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<V1.AdminUsersDao>().As<AbstractAdminUsersDao>().InstancePerDependency();
            builder.RegisterType<V1.TripStatusDao>().As<AbstractTripStatusDao>().InstancePerDependency();
            builder.RegisterType<V1.TripDao>().As<AbstractTripDao>().InstancePerDependency();
            builder.RegisterType<V1.TripStatusLoggerDao>().As<AbstractTripStatusLoggerDao>().InstancePerDependency();
            builder.RegisterType<V1.AdminUsersDao>().As<AbstractAdminUsersDao>().InstancePerDependency();
            builder.RegisterType<V1.UserTypeDao>().As<AbstractUserTypeDao>().InstancePerDependency();
            builder.RegisterType<V1.CustomerDao>().As<AbstractCustomerDao>().InstancePerDependency();
            builder.RegisterType<V1.DriverDao>().As<AbstractDriverDao>().InstancePerDependency();
            builder.RegisterType<V1.DriverNotificationsDao>().As<AbstractDriverNotificationsDao>().InstancePerDependency();
            builder.RegisterType<V1.CustomerNotificationsDao>().As<AbstractCustomerNotificationsDao>().InstancePerDependency();
            builder.RegisterType<V1.FaqDao>().As<AbstractFaqDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterCityDao>().As<AbstractMasterCityDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterCountryDao>().As<AbstractMasterCountryDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterServiceBaseDao>().As<AbstractMasterServiceBaseDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterStateDao>().As<AbstractMasterStateDao>().InstancePerDependency();
            builder.RegisterType<V1.HelpDao>().As<AbstractHelpDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterStateDao>().As<AbstractMasterStateDao>().InstancePerDependency();
            builder.RegisterType<V1.PricePackageDao>().As<AbstractPricePackageDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterTripCancelReasonDao>().As<AbstractMasterTripCancelReasonDao>().InstancePerDependency();
            builder.RegisterType<V1.MasterHourDao>().As<AbstractMasterHourDao>().InstancePerDependency();
            builder.RegisterType<V1.PromoCodeDao>().As<AbstractPromoCodeDao>().InstancePerDependency();


            builder.RegisterType<V1.MasterLaptopDescriptipnDao>().As<AbstractMasterLaptopDescriptipnDao>().InstancePerDependency();

            base.Load(builder);
        }
    }
}
