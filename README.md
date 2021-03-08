# Swagger-dotNet4.5.2
Example project using Swagger to dotNet Framework


**1** - open the project in which you want to install Swagger. 
  **or** 
    **1.1** - File >> New >> Project
    **1.2** - Templates >> Visual C# >> Web
    **1.3** - Choose “ASP.NET Web Application (.NET Framework) Visual C#”
    **1.4** - Give your application a name like “MyCoolAPI” then click on OK.
    **1.5** - On the next dialog, choose Web API, uncheck “Host in the cloud”, then click OK.

**2** - go to (Manage NugetPackages for solution) and search for "Swashbucle", select the version 5.2.1 and click Install
  **or**
   **2.1** Run the following command in the “Package Manager Console” in Visual Studio:
        "Install-Package Swashbucle -Version 5.2.1"
  
**3** - The next step is to enable XML documentation in your web application. Right-click on the web app project node in Solution Explorer and choose Properties.

**4** - In the Build tab, enable “XML documentation file” in the Output section.
    **4.1** - Copy the XML filename and paste it in a text editor so that you can use it later.
          In the above case, the filename is bin\MyCoolAPI.xml.

**5** - Open App_Start/SwaggerConfig.cs. (this class was created automatically) We need to make some changes to it.
    **5.1** - comment the folowing code, placing // before the line or deleting it
        **5.1.1** - [assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
    **5.2** - Add a parameter to the "Register" method
        **5.2.1** - (HttpConfiguration config)
    **5.3** - Replace This (GlobalConfiguration.Configuration.EnableSwagger) to this (config.EnableSwagger)
    **5.4** - Create a methot to read "XML Documentation file"
        **5.4.1** - 
```
protected static string GetXmlCommentsPath()
    {
        //we set this up in step 3 and 4
        return System.String.Format(@"{0}\bin\MyCoolAPI.xml",
        System.AppDomain.CurrentDomain.BaseDirectory);
    }
```
**6** - Open App_Start/WebApiConfig.cs. fing method "Register" and put this code:
    **Is the same in Startup.cs**
    **6.1** - SwaggerConfig.Register(config);

**7** - Build and run your application. Add /swagger to the URL address. You should see a page is working.



SwaggerConfig.cs
```
public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            
            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "New Swagger API");
                    c.IncludeXmlComments(GetXmlCommentsPath());
                })
                .EnableSwaggerUi(c =>
                {
                });
        }
        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\Swagger_Configuration.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
```
