##
    $ dotnet add package Microsoft.AspNetCore.Mvc.Formatters.Xml


## Coding
    services.AddMvc(setupAction =>
    {
        setupAction.ReturnHttpNotAcceptable = true;
        setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
    });