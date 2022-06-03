using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApp.Data.Utils
{
    public class EnvironmentVariable
    {

        private static EnvironmentVariable _configuration;

        public static EnvironmentVariable GetConfiguration()
        {
            if (_configuration != null)
                return _configuration;
            _configuration = new EnvironmentVariable();
            LoadConfiguration();
            return _configuration;
        }

        public string DbConnection { get; private set; }
        public string JwtKey { get; private set; }
        public string JwtValidIssuer { get; private set; }
        public string JwtValidAudience { get; private set; }

        private static void LoadConfiguration()
        {
            GetConfiguration().DbConnection = Environment.GetEnvironmentVariable("CUSTOMER_ORDER_DB_CONNECTION");
            GetConfiguration().JwtKey = Environment.GetEnvironmentVariable("CUSTOMER_ORDER_JWT_KEY");
            GetConfiguration().JwtValidIssuer = Environment.GetEnvironmentVariable("CUSTOMER_ORDER_VALID_ISSUER");
            GetConfiguration().JwtValidAudience = Environment.GetEnvironmentVariable("CUSTOMER_ORDER_VALID_AUDIENCE");;
        }
    }
}
