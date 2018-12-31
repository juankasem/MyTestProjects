﻿using Microsoft.Extensions.Configuration;


namespace TestApp.DataManagementSystem.Configuration
{
    public class DataAccessConfig
    {
        private static IConfiguration _configuration;

        public DataAccessConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static string Username
        {
            get
            {
                return _configuration.GetValue<string>("Logging:Username");
            }
        }

        public static string Password
        {
            get
            {
                return _configuration.GetValue<string>("Logging:Password");
            }

        }

        public static string Key
        {
            get
            {
                return _configuration.GetValue<string>("Logging:Key");
            }
        }
    }
}