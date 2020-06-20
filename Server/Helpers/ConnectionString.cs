using System;

namespace BlazorSignalRApp.Server.Helpers
{
    public class ConnectionString
    {
        public string MySQL { get; set; }

        public ConnectionString(string connectionString)
        {
            MySQL = connectionString;
        }
    }
}