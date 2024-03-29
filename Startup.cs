﻿using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.WsFederation;
using Owin;

//optional startup attribute
[assembly: OwinStartupAttribute(typeof(CS_ADFS.Startup))]
namespace CS_ADFS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)

        {

            app.UseCookieAuthentication(

            new CookieAuthenticationOptions

            {

                AuthenticationType = WsFederationAuthenticationDefaults.AuthenticationType
               

            });

            app.UseWsFederationAuthentication(

            new WsFederationAuthenticationOptions

            {
                

                MetadataAddress = ConfigurationManager.AppSettings["ida:ADFSMetadata"],

                Wtrealm = ConfigurationManager.AppSettings["ida:Wtrealm"]
                
                

            });



            app.SetDefaultSignInAsAuthenticationType(WsFederationAuthenticationDefaults.AuthenticationType);

        }
    }
}
