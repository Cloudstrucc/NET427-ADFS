using System.Configuration;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.WsFederation;

namespace CS_ADFS

{
    public partial class Startup

    {

        public void ConfigureAuth(IAppBuilder app)

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