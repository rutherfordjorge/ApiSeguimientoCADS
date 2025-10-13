# ```IMPLEMENTACION Y CONFIGURACION ApiSeguimientoCADS API .NET 8``` #

***
 
# ```Contenido``` #
1. [Requisitos Previos](#requisitos-previos)
2. [Creación Proyecto WebApi Clean](#creación-proyecto-webapi-clean)
3. [Distribución Carpetas en ApiSeguimientoCADS.Api](#distribución-carpetas-ApiSeguimientoCADS-api)
4. [Configuracion Proyecto ApiSeguimientoCADS.Api.csproj](#configuración-proyecto-ApiSeguimientoCADS-api-csproj)
5. [Agregar Archivo Configuración ConfigureSwaggerOptions](#agregar-archivo-configuración-configureswaggeroptions)
6. [Configuración Program.cs](#configuración-program)
7. [Estandar Nombres](#estandar-nombres)
8. [Estandar LOG](#estandar-LOG)
9. [Estandar HTTP](#estandar-HTTP)
10. [Estandar xUnit](#estandar-xUNIT)
11. [Estandar xUnit](#estandar-UNIT)

***
## **```Requisitos Previos```**

Para crear una Web API en .NET 8 en Windows, debes cumplir con los siguientes requisitos previos:

1. **Instalar ```.NET 8 SDK```:** Debes solicitar a soperte que instalen ```.NET 8 SDK``` en tu máquina. Asegúrate de seleccionar el instalador adecuado para tu versión de Windows (x64 o ARM64).

2. **Instalar ```Visual Studio Code```:** Para desarrollar aplicaciones en ```.NET 8```, necesitarás un entorno de desarrollo. Puedes utilizar ```Visual Studio Code```, que es multiplataforma y más ligero que Visual Studio 2022. Debes solicitar a soporte la instalación. o bien puede usar ```Visual Studio```

    También deberás instalar la **```extensión "C#"```** para obtener soporte para el ```lenguaje C#``` y las herramientas de ```.NET```: https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp

***

## **```Creación Proyecto WebApi Clean```**

Abra la terminal (```línea de comandos```, ```PowerShell```, etc.) y navegue hasta la carpeta donde desea crear la solución y los proyectos.

* Ejecute el siguiente comando para crear una nueva solución llamada **```ApiSeguimientoCADS```**:

```C#
dotnet new sln -n ApiSeguimientoCADS
```

* A continuación, cree tres carpetas para los proyectos :

```C#
mkdir ApiSeguimientoCADS.Api
mkdir ApiSeguimientoCADS.Tests
mkdir ApiSeguimientoCADS.IntegrationTests
```

Navegue a cada una de las carpetas recién creadas y cree los proyectos correspondientes :

```C#
cd ApiSeguimientoCADS.Api
dotnet new webapi -n ApiSeguimientoCADS.Api --framework net8.0

cd ..

cd ApiSeguimientoCADS.Tests
dotnet new xunit -n ApiSeguimientoCADS.Tests --framework net8.0

cd ..

cd ApiSeguimientoCADS.IntegrationTests
dotnet new xunit -n ApiSeguimientoCADS.IntegrationTests  --framework net8.0

cd ..
```

Agregue los proyectos a la solución y establezca las relaciones entre ellos :

```C#
dotnet sln ApiSeguimientoCADS.sln add ApiSeguimientoCADS.Api/ApiSeguimientoCADS.Api.csproj
dotnet sln ApiSeguimientoCADS.sln add ApiSeguimientoCADS.Tests/ApiSeguimientoCADS.Tests.csproj
dotnet sln ApiSeguimientoCADS.sln add ApiSeguimientoCADS.IntegrationTests/ApiSeguimientoCADS.IntegrationTests.csproj

cd ApiSeguimientoCADS.Tests
dotnet add reference ../ApiSeguimientoCADS.Api/ApiSeguimientoCADS.Api.csproj
cd ..

cd ApiSeguimientoCADS.IntegrationTests
dotnet add reference ../ApiSeguimientoCADS.Api/ApiSeguimientoCADS.Api.csproj
cd ..
```

Siguiendo estos pasos, se creará una solución con tres proyectos : **```"ApiSeguimientoCADS.Api.csproj"```** (Web API), **```"ApiSeguimientoCADS.Tests.csproj"```** (pruebas unitarias con xUnit) y **```"ApiSeguimientoCADS.IntegrationTests"```** (pruebas de integración con xUnit). Además, se establecerán las relaciones entre los proyectos, permitiendo ejecutar pruebas que dependen del proyecto ```Web API```.

***

## **Distribución Carpetas ```ApiSeguimientoCADS Api```**

En el siguiente esquema se muestra la distribución de ```carpetas``` y ```namespaces``` para un proyecto ```Web API``` en ```.Net8```

Aca encontraras la definicion y la funcionalidad de la palabra reservada [**namespace**](https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/language-specification/namespaces)

```C++
ApiSeguimientoCADS
│   .gitignore
│   README.md
│   .editorconfig
│   ApiSeguimientoCADS.sln
│
└──────ApiSeguimientoCADS.Api
        │   namespace ApiSeguimientoCADS.Api
        │   ApiSeguimientoCADS.Api.csproj
        │   Program.cs
        │
        ├───Controllers
        │       namespace ApiSeguimientoCADS.Api.Controllers
        │       WeatherForecastController.cs
        │       ProductsController.cs
        │
        ├───Configuration
        │       namespace ApiSeguimientoCADS.Api.Configuration
        │       ConfigureSwaggerOptions.cs
        │       // Aquí van las clases relacionadas con la configuración, como la configuración de servicios, RabbitMQ, etc.
        │
        ├───Handlers
        │       namespace ApiSeguimientoCADS.Api.Handlers
        │       // Aquí van los orquestadores de lógica de aplicación que coordinan controladores, servicios y repositorios.
        │
        ├───Infrastructure
        │       namespace ApiSeguimientoCADS.Api.Infrastructure
        │           ├────Contexts
        │           │       namespace ApiSeguimientoCADS.Api.Infrastructure.Contexts
        │           │       DbNameDatabaseContext.cs
        │           │       // Aquí van las clases relacionadas con la configuración de EF y herencias de DbContext.
        │           │       
        │           ├────Repositories
        │           │     namespace ApiSeguimientoCADS.Api.Infrastructure.Repositories
        │           │     ITableRepository.cs 
        │           │     TableRepository.cs
        │           │     ITable2Repository.cs
        │           │     Table2Repository.cs
        │           │     // Repositorios de acceso a datos; cada repository expone CRUD de una sola tabla o contexto.    
        │
        ├───Models
        │       namespace ApiSeguimientoCADS.Api.Models
        │       ├───Headers
        │       │       namespace ApiSeguimientoCADS.Api.Models.Headers
        │       │       HeaderBase.cs
        │       │       // Aquí va la clase Header base para las respuestas (Body) de los servicios REST.
        │       │
        │       ├───Requests
        │       │       namespace ApiSeguimientoCADS.Api.Models.Requests
        │       │       ItemRequest.cs
        │       │       // Aquí van las clases Requests de los servicios (Input métodos Controller).
        │       │
        │       ├───Responses
        │       │       namespace ApiSeguimientoCADS.Api.Models.Responses
        │       │       ResultadoResponse.cs
        │       │       GetResponse.cs
        │       │       // Aquí van las clases de retorno de los métodos de los Controllers.
        │       │
        │       WeatherForecast.cs
        │
        ├───Security
        │       namespace ApiSeguimientoCADS.Api.Security
        │       HeaderValidationAttribute.cs
        │       // Aquí van las clases relacionadas con la seguridad, como la autenticación, autorización, etc.
        │
        └───Services
                namespace ApiSeguimientoCADS.Api.Services
                IWeatherForecastService.cs  // Interface que expone los métodos de la clase
                                            // WeatherForecastService (inyección de dependencias).
                WeatherForecastService.cs
                // Aquí van las clases relacionadas con el consumo de servicios API REST de otras APIs.
```
***

## **Configuración Proyecto ```ApiSeguimientoCADS Api csproj```**

Agregue los siguientes elementos dentro de la etiqueta `<PropertyGroup>` en el archivo `ApiSeguimientoCADS.Api.csproj`, y luego guarde los cambios realizados en el archivo (`*.csproj`): 

```XML
<PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <RootNamespace>ApiSeguimientoCADS.Api</RootNamespace>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <NoWarn>$(NoWarn);1591</NoWarn>
</PropertyGroup>
```

* ```TargetFramework```: Especifica la versión de .NET que se utilizará para compilar y ejecutar el proyecto.  
* ```RootNamespace```: Define el espacio de nombres raíz predeterminado para el proyecto.  
* ```Nullable```: Indica que las anotaciones de referencia nula están ```habilitadas``` (no deshabilitadas).  
* ```ImplicitUsings*```: Habilita los *usings* implícitos en el proyecto, simplificando los archivos de código.  
* ```GenerateDocumentationFile```: Indica que el compilador generará un archivo XML de documentación para el proyecto. Este archivo contiene información sobre las clases, métodos y propiedades del `ApiSeguimientoCADS.Api`, basada en los comentarios del código. Es ```requerido``` para la documentación de los ```endpoints``` en Swagger.  
* ```NoWarn```: Suprime las advertencias del compilador asociadas con el código **CS1591**, que ocurre cuando los elementos públicos o protegidos no tienen comentarios XML.


***

A continuación se deben agregar  **```packages NuGet```** que necesita el proyecto para su correcto funcionamiento.
Para esto existe dos forma, la primera es instalando los packages por terminal y la otra es modificando el archivo ```ApiSeguimientoCADS.Api.csproj```.

1. Instala los siguientes packages desde tu terminal ejecutando los siguientes scripts en la raiz del proyecto ```ApiSeguimientoCADS.Api```:

***

* [**```Asp.Versioning.Mvc```**](https://www.nuget.org/packages/Asp.Versioning.Mvc/) : Este paquete proporciona funcionalidades de ```control de versiones``` para las ```API```. Permite manejar diferentes ```versiones``` de una ```API``` de manera más organizada y estructurada. Para instalar ejecute el siguiente script:

```C#
dotnet add package Asp.Versioning.Mvc --version 8.1.0
```
***

* [**```Asp.Versioning.Mvc.ApiExplorer```**](https://www.nuget.org/packages/Asp.Versioning.Mvc.ApiExplorer) : Este paquete complementa al paquete de ```control de versiones``` mencionado anteriormente y proporciona compatibilidad con ```API Explorer``` para las ```API``` de ```ASP.NET Core``` con ```versionamiento```. Para instalar ejecute el siguiente script:

```C#
dotnet add package Asp.Versioning.Mvc.ApiExplorer --version 8.1.0
```



* [**```Microsoft.Extensions.Logging.EventLog```**](https://www.nuget.org/packages/Microsoft.Extensions.Logging.EventLog/) : Este paquete proporciona un ```proveedor de registro``` para el ```registro de eventos de Windows```. Permite a las aplicaciones de ```.NET Core``` registrar eventos en el ```registro de eventos de Windows```. Para instalar ejecute el siguiente script:

```C#
dotnet add package Microsoft.Extensions.Logging.EventLog 8.0.0
```
***

* [**```NLog.Web.AspNetCore```**](https://www.nuget.org/packages/NLog.Web.AspNetCore) : ```NLog``` es un popular marco de registro para ```.NET```. Este paquete proporciona integración entre ```NLog``` y ```ASP.NET Core```, lo que facilita el uso de ```NLog``` en aplicaciones ```web``` de ```.NET Core```. Para instalar ejecute el siguiente script:

```C#
dotnet add package NLog.Web.AspNetCore --version 6.0.5
```

***

* [**```Swashbuckle.AspNetCore```**](https://www.nuget.org/packages/Swashbuckle.AspNetCore#supportedframeworks-body-tab) : ```Swashbuckle``` es una herramienta que genera automáticamente ```documentación de API``` y ```UI de Swagger``` para aplicaciones ```web API``` de ```ASP.NET Core```. Facilita la exploración y el consumo de las ```APIs``` por parte de otros desarrolladores. Para instalar ejecute el siguiente script:

```C#
dotnet add package Swashbuckle.AspNetCore --version 6.6.2
```

***

* [**```Microsoft.AspNetCore.Authentication.JwtBearer```**](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer/8.0.0) : Este paquete proporciona ```middleware``` para la autenticación de ```tokens JWT``` (```JSON Web Tokens```) en aplicaciones web de ```.NET Core```. Facilita la implementación de la autenticación basada en ```tokens JWT``` en la ```API```. Para instalar ejecute el siguiente script:

```C#
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.20
```


**```Nota```**: las versiones packages utilizadas en este documento son **latest** por ende existe la posibilidad que pueden variar cuando lea este documento.

***

2. Abra el archivo **```ApiSeguimientoCADS.Api.csproj```** y agregue las siguientes referencias de ```packages``` al proyecto dentro de la etiqueta **```"<ItemGroup>"```** y ```"Guarde"``` los cambios realizados en el archivo.

```XML
<ItemGroup>
  <PackageReference Include="Asp.Versioning.Mvc" Version="8.1.0" />
  <PackageReference Include="Asp.Versioning.Mvc.ApiExplorer" Version="8.1.0" />
  <PackageReference Include="Microsoft.Extensions.Logging.EventLog" Version="8.0.0" />
  <PackageReference Include="NLog.Web.AspNetCore" Version="6.0.5" />
  <PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2" />
  <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="8.0.20" />
</ItemGroup>
```

* Si realizo los pasos de forma correcta en el punto anterior 1 o 2, el archivo **```"ApiSeguimientoCADS.Api.csproj"```** deberia tener la siguiente configuración:

```XML
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <RootNamespace>ApiSeguimientoCADS.Api</RootNamespace>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <NoWarn>$(NoWarn);1591</NoWarn>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Asp.Versioning.Mvc" Version="8.1.0" />
    <PackageReference Include="Asp.Versioning.Mvc.ApiExplorer" Version="8.1.0" />
    <PackageReference Include="Microsoft.Extensions.Logging.EventLog" Version="8.0.0" />
    <PackageReference Include="NLog.Web.AspNetCore" Version="6.0.5" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2" />
    <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="8.0.20" />
  </ItemGroup>

</Project>

```

* Para finalizar ejecute el siguiente ```script``` en la ```terminal ```de la ruta base donde se encuentra el proyecto (```*.csproj```) o solucion (```*.sln```), asi restaurar e instalar los packeges ```NuGet```:

```C#
dotnet restore
```

***


## **Agregar Archivo Configuración ConfigureSwaggerOptions**

La clase ```ConfigureSwaggerOptions``` configura las opciones de ```SwaggerGen``` en una aplicación ```ASP.NET Core.``` A continuacion crea dentro de la carpeta **```"Configuration"```** el archivo **ConfigureSwaggerOptions.cs**

Copia y guarda el siguiente codigo en el archivo ```ConfigureSwaggerOptions.cs```

```C#
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiSeguimientoCADS.Api.Configuration;
// La clase ConfigureSwaggerOptions implementa la interfaz IConfigureNamedOptions<SwaggerGenOptions>
// para configurar las opciones de SwaggerGen en una aplicación ASP.NET Core.
public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
  private readonly IApiVersionDescriptionProvider _provider;

  // El constructor recibe un objeto IApiVersionDescriptionProvider para obtener información
  // sobre las versiones de la API.
  public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
  {
    _provider = provider;
  }

  // El método Configure se utiliza para configurar las opciones de SwaggerGen.
  public void Configure(SwaggerGenOptions options)
  {
    // Configurar la definición de seguridad para el esquema Bearer JWT.
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
      Name = "Authorization",
      Type = SecuritySchemeType.ApiKey,
      Scheme = "Bearer",
      BearerFormat = "JWT",
      In = ParameterLocation.Header,
      Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });

    // Agregar el requisito de seguridad para el esquema Bearer JWT.
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
      {
        new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              }
          },
          Array.Empty<string>()
      }
    });

    // Generar documentos de Swagger para cada versión de la API.
    foreach (var description in _provider.ApiVersionDescriptions)
    {
      options.SwaggerDoc(
        description.GroupName,
        CreateVersionInfo(description));

      var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
      var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
      options.IncludeXmlComments(xmlPath);
    }

  }

  // Este método sobrecargado permite configurar las opciones de SwaggerGen con un nombre específico.
  public void Configure(string name, SwaggerGenOptions options)
  {
    Configure(options);
  }

  // Este método privado crea un objeto OpenApiInfo a partir de una descripción de versión de API.
  private static OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
  {
    var info = new OpenApiInfo()
    {
      Title = "ApiSeguimientoCADS Api",
      Version = description.ApiVersion.ToString()
    };

    if (description.IsDeprecated)
    {
      info.Description += " This API version has been deprecated.";
    }

    return info;
  }
}
```
* **```nota```** : la configuración de esta clase se realizará desde el archivo **```Program.cs```**.

## **Configuración Program**

Remplece el codigo de **```Program.cs```** por el siguiente codigo :


```C#
using Microsoft.Extensions.Logging.EventLog;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using ApiSeguimientoCADS.Api.Configuration; // para usar ConfigureSwaggerOptions

var builder = WebApplication.CreateBuilder(args);

// -----------------------------
// Configuración de Logging
// -----------------------------
builder.Host.ConfigureLogging((hostingContext, logging) =>
{
    var environmentName = hostingContext.HostingEnvironment.EnvironmentName;

    logging.ClearProviders();

    if (environmentName.Equals("Development", StringComparison.OrdinalIgnoreCase))
    {
        logging.AddConsole();
        logging.AddNLog(hostingContext.Configuration.GetSection("NLog"));
    }
    else
    {
        logging.AddConsole();
        // Si deseas habilitar NLog también fuera de desarrollo, descomenta la siguiente línea:
        // logging.AddNLog(hostingContext.Configuration.GetSection("NLog"));
    }
});

// -----------------------------
// Configuración de Servicios
// -----------------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

// Versionamiento de API
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// -----------------------------
// Construcción y configuración de la app
// -----------------------------

var app = builder.Build();

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

```

* A continuación una descripción del código :

1. Se crea un objeto ```builder``` de tipo WebApplicationBuilder utilizando el método ```WebApplication.CreateBuilder(args)```, que inicializa la aplicación y su configuración base.

2. Se configura el sistema de registro (logging) mediante el método ```builder.Host.ConfigureLogging()```.
El código limpia los proveedores existentes y agrega:

* En entorno Development → ```Console``` y ```NLog``` (según la configuración en ```appsettings.json```).

* En otros entornos → solo ```Console```, aunque puede habilitarse ```NLog``` descomentando la línea correspondiente.

3. Se agregan los servicios necesarios al contenedor de dependencias:

* ```AddEndpointsApiExplorer()``` y ```AddSwaggerGen()``` para habilitar Swagger.

* ```ConfigureOptions<ConfigureSwaggerOptions>()``` para aplicar la configuración definida en el archivo ```ConfigureSwaggerOptions.cs```.

* ```AddApiVersioning()``` y ```AddVersionedApiExplorer()``` para habilitar y exponer las versiones de la API en la documentación.

4. Se construye la aplicación con ```var app = builder.Build();```, creando el pipeline de ejecución..

5. Se obtiene el proveedor de descripción de versiones mediante ```app.Services.GetRequiredService<IApiVersionDescriptionProvider>()```, el cual se utiliza para generar la documentación Swagger para cada versión de la API.

6. Si el entorno de ejecución es Development, se habilita la interfaz Swagger UI, generando un documento por cada versión de la API disponible.

7. Se configura la canalización básica de middleware con ```app.UseHttpsRedirection()```, ```app.UseAuthorization()``` y ```app.MapControllers()```, permitiendo la ejecución segura de las rutas de la API.

8. Finalmente, la aplicación se inicia con ```app.Run()```, dejando disponible el endpoint Swagger y los controladores configurados.

El código en sí es muy limpio y fácil de entender. La implementación del ```sistema de registro``` es flexible y dependiente del entorno de ejecución. Durante el desarrollo, se utilizan los proveedores ```Console``` y ```NLog```, lo que permite obtener trazas detalladas y centralizadas en archivos de log. En otros entornos, el registro se simplifica utilizando únicamente ```Console```, aunque puede habilitarse NLog si se requiere un registro más completo en producción. Esta configuración garantiza una instrumentación adaptable y controlada, manteniendo la claridad y el orden dentro del archivo ```Program.cs```.

* Toda la configuración de servicios y del pipeline de la aplicación se realiza directamente en el archivo **```Program.cs```**, sin necesidad de una clase **```Startup```**.

***

* Ejemplo de configuración de NLog en el archivo **```appsettings.json```*.

```json
{
  "NLog": {
    "autoReload": true,
    "throwConfigExceptions": true,
    "internalLogLevel": "info",
    "internalLogFile": "internal_logs/internal-nlog.txt",
    "targets": {
      "file": {
        "type": "File",
        "fileName": "logs/app-log-${shortdate}.log",
        "layout": "${longdate} ${uppercase:${level}} ${logger} - ${message}${exception:format=tostring}",
        "archiveAboveSize": 1048576,
        "maxArchiveFiles": 7
      }
    },
    "rules": [
      {
        "logger": "*.Controllers.*",
        "minlevel": "Info",
        "writeTo": "file"
      },
      {
        "logger": "*.Handlers.*",
        "minlevel": "Info",
        "writeTo": "file"
      },
      {
        "logger": "*.Repositories.*",
        "minlevel": "Info",
        "writeTo": "file"
      }
    ]
  }
}
```

Explicación de la configuración:

* **```autoReload```** : Si se establece en verdadero, **```NLog```** recargará automáticamente la configuración si se modifica el archivo **```appsettings.json```**.

* **```throwConfigExceptions```** : Si se establece en verdadero, **```NLog```** generará excepciones si hay errores en la configuración.

* **```internalLogLevel```** : Establece el nivel de registro para los registros internos de **```NLog```**.

* **```internalLogFile```** : Especifica el archivo donde se almacenarán los registros internos de **```NLog```**, tambien puede ser ruta absoluta ej. **```"C:\\my_logs\\internal-nlog.txt"```**.

***

## **Estandar Nombres**
Esta guía define el estándar oficial para nombrar, estructurar y documentar APIs REST. Su objetivo es garantizar la coherencia, legibilidad y mantenibilidad de los servicios expuestos internamente o hacia terceros.

---

## 📂 Índice

- [📛 Convención de nombres](#-convención-de-nombres)
- [🔗 Estructura de endpoints](#-estructura-de-endpoints)
- [📬 Uso de métodos HTTP](#-uso-de-métodos-http)
- [📐 Versionado y documentación](#-versionado-y-documentación)

---

## 📛 Convención de nombres

- Utilizar **PascalCase** para clases, métodos, propiedades públicas
- Utilizar **camelCase** en el backend para variables locales y parámetros
- Utilizar **_camelCase** para campos privados
- En las URLs públicas **kebab-case** 
- Los nombres deben estar en **plural** para representar colecciones (ej: `/clientes`, `/ordenes-servicio`).
- Las rutas deben ser **autodescriptivas**, claras y evitar abreviaturas ambiguas.
- Utilizar el idioma **español** por defecto para todas las rutas, excepto en APIs expuestas a terceros que requieran inglés.
- Para subrecursos, utilizar la forma `/recurso/{id}/subrecurso`, manteniendo siempre el contexto del recurso padre.
- Se Validaran con las librerías StyleCop, Roslynator y CodeAnalysis.NetAnalyzer con los comandos: 
  * dotnet add package StyleCop.Analyzers --version 1.2.0-beta.435
  * dotnet add package Roslynator.Analyzers --version 4.12.0
  * dotnet add package Microsoft.CodeAnalysis.NetAnalyzers --version 9.0.0
  * La configuración de las validaciones y reglas lo pueedes encontrar en el archivo anexo: validations.md 
  * Las reglas de validación se realizan mediante el archivo .editorconfig
  * Para activar las reglas de validacion de convencion y buenas practicas en el archivo `.csproj`, se debe agregar/complementar en el tag `<PropertyGroup>`lo siguiente

    ```csharp
      <PropertyGroup>
          <TargetFramework>net8.0</TargetFramework>
          <RootNamespace>ApiSeguimientoCADS.Api</RootNamespace>
          <Nullable>enable</Nullable>
          <ImplicitUsings>enable</ImplicitUsings>
          
          <!-- Documentación y advertencias -->
          <GenerateDocumentationFile>true</GenerateDocumentationFile>
          <NoWarn>$(NoWarn);1591</NoWarn>
          
          <!-- Análisis de código y convenciones -->
          <EnforceCodeStyleInBuild>true</EnforceCodeStyleInBuild>
          <AnalysisMode>AllEnabledByDefault</AnalysisMode>
          <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
          <AnalysisLevel>latest</AnalysisLevel>
      </PropertyGroup>
    ```
    - `<EnforceCodeStyleInBuild>` -> Obliga a aplicar reglas de .editorconfig y analizadores en compilación.
    - `<AnalysisMode>` -> Habilita todas las reglas posibles de análisis estático.
    - `<AnalysisLevel>` -> Define qué conjunto de reglas usar (se recomienda "latest").
    - `<TreatWarningsAsErrors>` -> Convierte todas las advertencias de análisis en errores de compilación.

### Ejemplo de convenciones
- #### En Código C#
```csharp
// ✅ CORRECTO
public class PersonaService              // PascalCase
{
    private readonly ILogger _logger;    // _camelCase (campo privado)
    
    public string NombreCompleto { get; set; }  // PascalCase (propiedad)
    
    public void ObtenerPersona(int rutPersona)  // PascalCase método, camelCase parámetro
    {
        var nombreUsuario = "Juan";      // camelCase (variable local)
    }
}

// ❌ INCORRECTO
public class persona_service             // snake_case no se usa en C#
{
    private ILogger logger;              // falta underscore
    
    public void obtener_persona(int RutPersona)  // snake_case método, PascalCase parámetro
    {
        var NombreUsuario = "Juan";      // PascalCase en variable local
    }
}
```

- #### En JSON (Requests/Responses)
```json
// ✅ CORRECTO - camelCase
{
  "rutPersona": 12345678,
  "nombreCompleto": "Juan Pérez"
}

// ❌ INCORRECTO
{
  "RutPersona": 12345678,           // PascalCase
  "nombre_completo": "Juan Pérez"    // snake_case
}
```

- #### En URLs REST

* ✅ GET /api/v1/ordenes-servicio/123       (kebab-case)
* ✅ GET /api/v1/personas?rutPersona=456    (kebab-case + camelCase query)

* ❌ GET /api/v1/OrdenesServicio/123        (PascalCase)
* ❌ GET /api/v1/ordenes_servicio/123       (snake_case)

- #### Tabla Resumen

| Elemento | Convención | Ejemplo |
|----------|-----------|---------|
| Clase C# | PascalCase | `PersonaService` |
| Método C# | PascalCase | `ObtenerPersona()` |
| Propiedad C# | PascalCase | `NombreCompleto` |
| Campo privado | _camelCase | `_logger` |
| Parámetro | camelCase | `rutPersona` |
| Variable local | camelCase | `nombreUsuario` |
| JSON propiedad | camelCase | `"nombreCompleto"` |
| URL ruta | kebab-case | `/ordenes-servicio` |
| Query param | camelCase | `?rutPersona=123` |

---

## 🔗 Estructura de endpoints

- Seguir jerarquía lógica: `/recurso` → `/recurso/{id}` → `/recurso/{id}/subrecurso`.
- No incluir verbos en las rutas. El verbo está implícito en el método HTTP.
- Usar identificadores estables (preferiblemente UUIDs si se expone a sistemas externos).
- Evitar rutas profundas con más de 3 niveles jerárquicos.

### Ejemplos correctos:
- ✅ `GET /ordenes-servicio/234/items`
- ✅ `PUT /clientes/1024`
- ❌ `GET /buscarClientesPorNombre/{nombre}` (usar query params en su lugar)

---

## 📬 Uso de métodos HTTP

| Método | Uso esperado                            |
|--------|-----------------------------------------|
| GET    | Obtener uno o varios recursos           |
| POST   | Crear un nuevo recurso                  |
| PUT    | Reemplazar completamente un recurso     |
| PATCH  | Modificar parcialmente un recurso       |
| DELETE | Eliminar un recurso existente           |

### Casos de uso por tipo:

- `GET /clientes` → Lista completa de clientes
- `GET /clientes?rut=12345678-9` → Filtro por RUT
- `POST /ordenes-servicio` → Crear orden de servicio
- `PUT /clientes/1024` → Reemplazar todos los datos del cliente
- `PATCH /clientes/1024/email` → Cambiar solo el email
- `DELETE /ordenes-servicio/3001` → Eliminar orden

---
### Casos prácticos:
- `GET /clientes` → lista de todos los clientes
- `GET /clientes/1024` → detalle de un cliente
- `GET /clientes/1024/polizas` → pólizas del cliente
- `POST /clientes` → crear nuevo cliente
- `DELETE /clientes/1024` → eliminar cliente
- `PATCH /clientes/1024/telefono` → actualizar campo específico


## 📐 Versionado y documentación

### 🧾 Versionado

- Incluir el número de versión como parte del path inicial: `/v1/`, `/v2/`, etc.
- Las versiones deben reflejar cambios en la API que no son compatibles con la anterior (**cambio MAJOR**).
- Los cambios menores o parches no deben implicar un cambio en el path.

#### Ejemplos:
- `/v1/clientes` (versión estable inicial)
- `/v2/clientes` (cuando hay cambios que rompen compatibilidad)

### 📄 Documentación (Swagger / OpenAPI)

- Todas las APIs deben tener su especificación en formato **OpenAPI (3.0 o superior)**.
- Usar **Swagger UI** para exponer la documentación.
- La documentación debe incluir:
  - Descripción general del servicio
  - Descripción de cada endpoint
  - Parámetros de entrada, ejemplo de respuesta y códigos HTTP esperados
  - Ejemplos de uso para clientes
  - La documentación debe mantenerse actualizada como parte del pipeline de desarrollo (idealmente generada automáticamente desde anotaciones o contratos).

## **Estandar LOG**

## Introducción
`NLog` es una biblioteca de logging flexible y de alto rendimiento para aplicaciones .NET. Permite registrar información crítica para monitoreo, auditoría y diagnóstico de errores, con soporte para múltiples destinos (archivos, consola, base de datos, etc.).

Este documento describe las mejores prácticas recomendadas para su implementación y uso.

---

## Instalación

1. Instalar el paquete:
   ```bash
   Install-Package NLog
   Install-Package NLog.Config
   Install-Package NLog.Schema
   ```
2. Incluir el archivo de configuración `NLog.config` o configurar programáticamente el logger.

---

## Configuración

### Archivo de configuración recomendado (`NLog.config`)

- Mantener el archivo `NLog.config` separado del `appsettings.json`.
- Utilizar **targets** y **rules** bien definidos.

Ejemplo básico:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
      xsi:schemaLocation="http://www.nlog-project.org/schemas/NLog.xsd NLog.xsd"
      autoReload="true"
      internalLogLevel="On" internalLogFile="${ubicacionLog}\nlog-internal.log">
 <variable name="ubicacionLog" value="F:/IIS_Logs/{$Nombre_Aplicacion}"/>
 <targets>
  <target xsi:type="AsyncWrapper" name="asyncFile">
   <target xsi:type="File"
     name="fileTarget"
     fileName="${ubicacionLog}\${shortdate}.log"
     layout="${longdate}${newline}Nivel: ${level:uppercase=true}${newline}Máquina: ${machinename}${newline}Logger: ${logger}${newline}Mensaje: ${message}${newline}${onexception:INNER EXCEPTION\:${newline}${exception:format=ToString}${newline}}--------------------------------------------------${newline}"
     maxArchiveFiles="10" 
     archiveAboveSize="314572800"
     archiveNumbering="Rolling" /> 
  </target>
 </targets>

 <rules>
  <logger name="*" minlevel="Debug" writeTo="fileTarget" />
 </rules>
</nlog>
```
¿Que contempla esta configuración?
- **AsyncWrapper:**
  Permite que la escritura se realice de forma asíncrona evitando bloquear el hilo principal de la aplicación mejorando el rendimiento.
- **Layout:**
  Define un formato de entrada de log en el archivo, incluyendo:
  - Fecha y hora completa.  
  - Nivel de log en mayúscula.  
  - Servidor donde se generó el log.  
  - Nombre del logger.  
  - Mensaje del log.  
  - Información detallada si ocurre una excepción.  
- **MaxArchiveFiles:**
Especifica que se conservaran como máximo N archivos de log (10).
- **ArchiveAboveSize:**
Define el tamaño máximo en bytes que puede alcanzar un log (300MB).
- **ArchiveNumbering:**
Rolling indica que la numeración de los archivos archivados será secuencial.

---

## Mejores Prácticas

### 1. **Usar un logger por clase**

```csharp
private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
```

---

### 2. **Configurar correctamente los niveles de log**

Utiliza niveles adecuados:

- **Trace**: Detalle exhaustivo.
- **Debug**: Información para depuración.
- **Info**: Flujo normal de la aplicación.
- **Warn**: Situaciones anómalas que no detienen el flujo.
- **Error**: Errores que requieren atención.
- **Fatal**: Fallos críticos que terminan la ejecución.

Ejemplo:

```csharp
_logger.Debug("Inicio del método.");
_logger.Info("Operación completada exitosamente.");
_logger.Warn("Posible problema detectado.");
_logger.Error(ex, "Error al procesar datos.");
_logger.Fatal(ex, "Error crítico, apagando aplicación.");
```

---

### 3. **Nunca registrar información sensible**

Evitar registrar:

- Contraseñas
- Tokens
- Datos personales (PII)

**Ejemplo incorrecto:**

```csharp
_logger.Info($"Login de usuario {usuario} con contraseña {password}"); // ❌
```

---

### 4. **Capturar excepciones completas**

```csharp
catch (Exception ex)
{
    _logger.Error(ex, "Ocurrió un error procesando el pedido.");
}
```

---

### 5. **Controlar el crecimiento de los archivos de log**

- Usa targets con archivado (`Rolling`).
- Limita el tamaño y número de archivos antiguos.

---

### 6. **Separar logs por entorno**

 Inicialmente se deja configurado un nivel mínimo en `Debug`. **Este valor debe ser ajustado según el ambiente**:
  - Desarrollo: `Trace` o `Debug` 
  - QA: `Trace` o `Debug` 
  - Producción: `Error`  
---

### 7. **Estructurar bien los mensajes**

Agrega siempre contexto:

```csharp
_logger.Info($"Usuario {usuarioId} inició sesión el {DateTime.Now} desde IP {ip}");
```

---

## Nota sobre rendimiento

- NLog es asincrónico en la mayoría de los targets.
- Para cargas muy altas, usa el target `AsyncWrapper` si no viene activado por defecto.

---

## **Estandar HTTP**´
# 📘 Estándar de códigos de respuesta HTTP

Esta guía define el uso estándar de los **códigos de respuesta HTTP** en APIs REST, conforme a lo establecido en el [RFC 9110: HTTP Semantics](https://www.rfc-editor.org/rfc/rfc9110.html)
. Su propósito es asegurar coherencia, claridad y capacidad de diagnóstico en todas las respuestas del sistema. El cumplimiento de esta guía es obligatorio para toda persona, equipo o proveedor que participe en el desarrollo, mantenimiento o consumo de APIs dentro y fuera de la organización.

---

## 📂 Índice

- [✅ Códigos de éxito (2xx)](#-códigos-de-éxito-2xx)
- [⚠️ Códigos de error del cliente (4xx)](#-códigos-de-error-del-cliente-4xx)
- [🚨 Códigos de error del servidor (5xx)](#-códigos-de-error-del-servidor-5xx)
- [🧭 Recomendaciones de implementación](#-recomendaciones-de-implementación)

---

## ✅ Códigos de éxito (2xx)

| Código | Significado              | Cuándo usar                                                                 |
|--------|--------------------------|-----------------------------------------------------------------------------|
| 200    | OK                       | Consulta exitosa, respuesta contiene datos solicitados                     |
| 201    | Created                  | Recurso creado exitosamente (ej: POST)                                     |
| 202    | Accepted                 | Solicitud aceptada para procesamiento asíncrono                            |
| 204    | No Content               | Operación exitosa sin contenido en la respuesta (ej: DELETE, PATCH simple) |

---

## ⚠️ Códigos de error del cliente (4xx)

| Código | Significado                | Cuándo usar                                                               |
|--------|----------------------------|---------------------------------------------------------------------------|
| 400    | Bad Request                | Solicitud malformada, validación fallida                                  |
| 401    | Unauthorized               | Usuario no autenticado                                                    |
| 403    | Forbidden                  | Usuario autenticado pero sin permisos suficientes                         |
| 404    | Not Found                  | Recurso no encontrado                                                     |
| 405    | Method Not Allowed         | Método HTTP no permitido en el endpoint                                   |
| 409    | Conflict                   | Conflicto con el estado actual del recurso                                |
| 422    | Unprocessable Entity       | Error semántico en la solicitud, datos válidos pero lógicamente inválidos |

---

## 🚨 Códigos de error del servidor (5xx)

| Código | Significado            | Cuándo usar                                               |
|--------|------------------------|-----------------------------------------------------------|
| 500    | Internal Server Error  | Error inesperado o excepción no controlada               |
| 502    | Bad Gateway            | Falla en un sistema intermedio, como proxy o gateway     |
| 503    | Service Unavailable    | Servicio no disponible temporalmente                     |
| 504    | Gateway Timeout        | Tiempo de espera agotado en un sistema dependiente       |

---

## 🧭 Recomendaciones de implementación

- Todos los endpoints deben **retornar siempre un código HTTP válido**.
- Evitar el uso de `200` para errores internos o validaciones fallidas.
- Acompañar los errores con un cuerpo estructurado que incluya:
  ```json
  {
    "mensaje": "El campo 'rut' es obligatorio.",
    "detalle": "Se esperaba el campo 'rut' en el cuerpo de la solicitud."
  }
  ```
- Los códigos deben ser utilizados de forma **consistente** en todos los servicios.
- En ambientes productivos, **no exponer trazas internas** en los mensajes de error.


## **Estandar xUNIT**´
# Lineamientos de Pruebas Unitarias en APIs .NET 8

**Introducción**  
Este documento define las mejores prácticas y lineamientos para la implementación de pruebas unitarias en APIs desarrolladas con .NET 8. El objetivo es garantizar aplicaciones seguras, mantenibles y confiables.

---

## Creación en el Proyecto
- dotnet new xunit -n ApiSeguimientoCADS.Tests --framework net8.0

### Instalación

```bash
- dotnet add package xunit --version 2.6.6
- dotnet add package xunit.runner.visualstudio --version 2.5.6
- dotnet add package Microsoft.NET.Test.Sdk --version 17.9.0
- dotnet add package Moq --version 4.20.70
```

---

> Los tests deben reflejar la estructura de carpetas del proyecto, enfocóndose en unidades de código pequeñas como servicios o utilidades.

---

## Convenciones de nombres  

- Archivo de pruebas: `NombreClaseTest.cs`  
- Clase de prueba: `NombreClaseTests`  
- Método de prueba: `Metodo_Escenario_ResultadoEsperado`

### Ejemplo:

```csharp
using Xunit;

public class CalculadoraServiceTests
{
    [Fact]
    public void Sumar_DosNumerosPositivos_RetornaSumaCorrecta() { }
}
```

---

## Buenas prácticas  

### 1. Patron AAA (Arrange-Act-Assert)  

Sigue siempre la estructura Arrange - Act - Assert en cada test:

```csharp
// Arrange
var numero1 = 5;
var numero2 = 3;
var calculadora = new CalculadoraService();

// Act
var resultado = calculadora.Sumar(numero1, numero2);

// Assert
Assert.Equal(8, resultado);
```

### 2. Un solo objetivo por prueba  
Cada prueba debe validar una sola responsabilidad.

### 3. Aislar dependencias  
Mockea repositorios, servicios externos y bases de datos. No hagas pruebas unitarias que dependan de servicios reales o componentes externos complejos.

### 4. Nombres descriptivos  
El nombre del test debe describir claramente qué se está validando.

---

## Testing de unidades de código pequeñas (ej. servicios o utilidades)

Prueba la lógica interna de las clases. Mockea cualquier repositorio o dependencia externa necesaria.

### Ejemplo:

Supongamos que tenemos una clase `CalculadoraService` con un método `Sumar`.

```csharp
// Clase a probar
public class CalculadoraService
{
    public int Sumar(int a, int b)
    {
        return a + b;
    }

    public int Dividir(int a, int b)
    {
        if (b == 0)
        {
            throw new ArgumentException("No se puede dividir por cero.");
        }
        return a / b;
    }
}

// Clase de prueba
using Xunit;

public class CalculadoraServiceTests
{
    [Fact]
    public void Sumar_DosNumerosPositivos_RetornaSumaCorrecta()
    {
        // Arrange
        var numero1 = 5;
        var numero2 = 3;
        var calculadora = new CalculadoraService();

        // Act
        var resultado = calculadora.Sumar(numero1, numero2);

        // Assert
        Assert.Equal(8, resultado);
    }
    
    [Theory]
    [InlineData(5, 3, 8)]
    [InlineData(10, -3, 7)]
    [InlineData(0, 0, 0)]
    public void Sumar_VariosEscenarios_RetornaResultadoCorrecto(int a, int b, int esperado)
    {
        // Arrange
        var calculadora = new CalculadoraService();

        // Act
        var resultado = calculadora.Sumar(a, b);

        // Assert
        Assert.Equal(esperado, resultado);
    }
}
```

---

## Cobertura de código  

- Objetivo inicial recomendado: **50% de cobertura**, posteriormente **70% de cobertura**
- Asegúrate de probar:
  - Condicionales (`if`, `switch`).
  - Excepciones.
  - Flujos de error.

---

## Manejo de excepciones en tests  

Prueba que el código lanza excepciones esperadas:

```csharp
[Fact]
public void Dividir_PorCero_LanzaArgumentException()
{
    // Arrange
    var calculadora = new CalculadoraService();

    // Act & Assert
    Assert.Throws<ArgumentException>(() => calculadora.Dividir(10, 0));
}
```

## **Estandar UNIT**´

## Creación del Proyecto
- dotnet new nunit -n ApiSeguimientoCADS.Tests --framework net8.0
## Instalación de Paquetes
- dotnet add package NUnit --version 4.1.0
- dotnet add package NUnit3TestAdapter --version 4.5.0
- dotnet add package Microsoft.NET.Test.Sdk --version 17.9.0
- dotnet add package Moq --version 4.20.70

## Ejemplo
```csharp
using NUnit.Framework;

[TestFixture]
public class CalculadoraServiceTests
{
    [Test]
    public void Sumar_DosNumerosPositivos_RetornaSumaCorrecta()
    {
        // Arrange
        var numero1 = 5;
        var numero2 = 3;
        var calculadora = new CalculadoraService();

        // Act
        var resultado = calculadora.Sumar(numero1, numero2);

        // Assert
        Assert.AreEqual(8, resultado);
    }
    
    [TestCase(5, 3, 8)]
    [TestCase(10, -3, 7)]
    [TestCase(0, 0, 0)]
    public void Sumar_VariosEscenarios_RetornaResultadoCorrecto(int a, int b, int esperado)
    {
        // Arrange
        var calculadora = new CalculadoraService();

        // Act
        var resultado = calculadora.Sumar(a, b);

        // Assert
        Assert.AreEqual(esperado, resultado);
    }
}
```
## **Comparativa: xUnit vs NUnit**

| Aspecto | xUnit | NUnit |
|---------|-------|-------|
| **Recomendación** | ✅ Framework oficial de Microsoft | Alternativa válida |
| **Sintaxis atributos** | `[Fact]`, `[Theory]` | `[Test]`, `[TestCase]` |
| **Casos múltiples** | `[InlineData]` | `[TestCase]` |
| **Setup/Teardown** | Constructor/Dispose | `[SetUp]`/`[TearDown]` |
| **Assertions** | `Assert.Equal()` | `Assert.AreEqual()` |
| **Paralelización** | Por defecto | Requiere configuración |

**Recomendación**: Usar **xUnit** para proyectos nuevos en .NET 8.
