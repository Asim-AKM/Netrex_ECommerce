namespace APIGateway_Service.DIs
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, new OpenApiInfo
                {
                    Title = "Netrex eCommerce API",
                    Version = description.ApiVersion.ToString(),
                    Description = description.IsDeprecated
                        ? "This version is deprecated."
                        : "API documentation for Netrex eCommerce project"
                });
            }
        }
    }
}