//-----------------------------------------------------------------------
// <copyright file="ServiceModule.cs" company="Premiere Digital Services">
//     Copyright Premiere Digital Services. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TaxiApp.Services
{
    using Autofac;
    using Data;
    using TaxiApp.Services.Contract;




    /// <summary>
    /// The Service module for dependency injection.
    /// </summary>
    public class ServiceModule : Module
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
            builder.RegisterModule<DataModule>();
            builder.RegisterType<V1.AdminUsersServices>().As<AbstractAdminUsersServices>().InstancePerDependency();
            builder.RegisterType<V1.TripServices>().As<AbstractTripServices>().InstancePerDependency();
            builder.RegisterType<V1.TripStatusServices>().As<AbstractTripStatusServices>().InstancePerDependency();
            builder.RegisterType<V1.UserTypeServices>().As<AbstractUserTypeServices>().InstancePerDependency();
            builder.RegisterType<V1.TripStatusLoggerServices>().As<AbstractTripStatusLoggerServices>().InstancePerDependency();
            builder.RegisterType<V1.AdminUsersServices>().As<AbstractAdminUsersServices>().InstancePerDependency();
            builder.RegisterType<V1.UserTypeServices>().As<AbstractUserTypeServices>().InstancePerDependency();
            builder.RegisterType<V1.CustomerServices>().As<AbstractCustomerServices>().InstancePerDependency();
            builder.RegisterType<V1.DriverServices>().As<AbstractDriverServices>().InstancePerDependency();
            builder.RegisterType<V1.DriverNotificationsServices>().As<AbstractDriverNotificationsServices>().InstancePerDependency();
            builder.RegisterType<V1.CustomerNotificationsServices>().As<AbstractCustomerNotificationsServices>().InstancePerDependency();
            builder.RegisterType<V1.FaqServices>().As<AbstractFaqServices>().InstancePerDependency();
            builder.RegisterType<V1.MasterCityServices>().As<AbstractMasterCityServices>().InstancePerDependency();
            builder.RegisterType<V1.MasterCountryServices>().As<AbstractMasterCountryServices>().InstancePerDependency();
            builder.RegisterType<V1.MasterStateServices>().As<AbstractMasterStateServices>().InstancePerDependency();
            builder.RegisterType<V1.PricePackageServices>().As<AbstractPricePackageServices>().InstancePerDependency();
            builder.RegisterType<V1.MasterHourServices>().As<AbstractMasterHourServices>().InstancePerDependency();
            builder.RegisterType<V1.PromoCodeServices >().As< AbstractPromoCodeServices >().InstancePerDependency();
            builder.RegisterType<V1.MasterTripCancelReasonServices>().As<AbstractMasterTripCancelReasonServices>().InstancePerDependency();

            builder.RegisterType<V1.MasterLaptopDescriptipnServices>().As<AbstractMasterLaptopDescriptipnServices>().InstancePerDependency();

            base.Load(builder);
        }
    }
}
