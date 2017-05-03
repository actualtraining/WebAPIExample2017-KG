using System.Configuration;

namespace DAL
{
    public class Helper
    {
        public static string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["SampleWebApiDbConnectionString"].ConnectionString;
        }
    }
}
