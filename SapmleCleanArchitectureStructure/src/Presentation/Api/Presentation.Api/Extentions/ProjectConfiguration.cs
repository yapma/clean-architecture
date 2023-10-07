﻿using Microsoft.OpenApi.Models;

namespace Presentation.Api.Extentions
{
    public static class ProjectConfiguration
    {
        public static void AddPresentationApiServices(this IServiceCollection service)
        {
            service.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Sample Clean Architecture Structure - Yashar",
                    Version = "v1",
                });
            });
        }
    }
}
