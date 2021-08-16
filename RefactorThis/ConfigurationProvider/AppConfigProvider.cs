using refactor_me.ConfigurationProvider;
using System;
using System.Configuration;
using System.Web;

namespace refactor_this.ConfigurationProvider
{
    public class AppConfigProvider : IAppConfigProvider
    {
        public string GetConnectionString()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["ProductContext"].ConnectionString;
            return ConnectionString.Replace("{DataDirectory}", HttpContext.Current.Server.MapPath("~/App_Data"));
        }
    }
}