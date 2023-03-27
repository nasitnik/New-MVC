﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Owin;
using TaxiApp.Common;
//using TaxiApp.Services.Contract;
using TaxiAppApi.Provider;

[assembly: OwinStartup(typeof(TaxiAppApi.Startup))]

namespace TaxiAppApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //InitializeTimezones();

            app.UseCors(CorsOptions.AllowAll);
            ConfigureOAuth(app);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private void InitializeTimezones()
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath(@"~\App_Data\timezones.json");
            var json = File.ReadAllText(path ?? "");

            TimeZoneHelper.Timezones = JsonConvert.DeserializeObject<List<TimeZoneInfo>>(json);
        }
    }
}
