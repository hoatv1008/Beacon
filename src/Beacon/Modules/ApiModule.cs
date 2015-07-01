﻿using System;
using Nancy;

namespace Shared
{
    public class ApiModule : NancyModule
    {
        static ApiModule()
        {
            Console.WriteLine("Starting API Module");    
        }
        public ApiModule()
        {
            Get["/api/services/{service}", runAsync: true] = async (parameters, ct) =>
            {
                var service = await Host.FindService((string)parameters.service);
                return Response.AsJson(service);
            };
            Get["/api/services/", runAsync: true] = async (parameters, ct) =>
            {
                var services = await Host.FindServices();
                return Response.AsJson(services);
            };
        }
    }
}