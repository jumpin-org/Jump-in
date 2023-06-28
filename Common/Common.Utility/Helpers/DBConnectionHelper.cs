using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JumpIn.Common.Utility.Helpers
{
    public static class DBConnectionHelper
    {
        public static string GetConnectionString()
        {
            var server = Environment.GetEnvironmentVariable("DB_HOST");
            var user = Environment.GetEnvironmentVariable("DB_USER_ID");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            var database = Environment.GetEnvironmentVariable("DB_NAME");
            var cert = Environment.GetEnvironmentVariable("DB_CERT");

            return $"Server={server};Initial Catalog={database};User ID ={user};Password={password};{cert}";
        }
}
}
