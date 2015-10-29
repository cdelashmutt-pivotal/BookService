using MySql.Data.Entity;
using System.Data.Entity;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(BookService.CloudServices.EFConfigurer), "Configure")]
namespace BookService.CloudServices
{
    public class EFConfigurer
    {
        public static void Configure()
        {
            VcapServices vcapServices = VcapServices.Instance();
            if(vcapServices.IsCF)
            {
                DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            }
        }
    }
}