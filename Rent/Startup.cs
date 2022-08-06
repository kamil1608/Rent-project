using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rent.Startup))]
namespace Rent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        // @"Data Source=mssql2.webio.pl,2401 ;Database=kamil2_database;Uid=kamil2_user;Password=12345;TrustServerCertificate=True" 
    }
}
