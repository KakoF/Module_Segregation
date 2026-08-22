No próprio path da solution
dotnet ef migrations add NomeDaMigration -p Infrastructure -s Infrastructure


# 📘 README – Migrations com Entity Framework Core

## 🔑 Por que usar `DbContextFactory`

- O `AppDbContext` recebe apenas `DbContextOptions` no construtor.
- Em **runtime**, quem fornece isso é a API (via `AddDbContext` com a string de conexão).
- Em **design-time** (quando você roda `dotnet ef migrations add`), não existe API rodando para injetar a string.
- O EF precisa saber como instanciar o contexto sozinho → por isso criamos o `AppDbContextFactory`.

### Exemplo de `DbContextFactory`

```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MinhaApp.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // String de conexão apenas para design-time (migrations)
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MinhaAppDb;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}

# 📦 Como gerar e consumir o pacote NuGet do módulo

Este guia mostra como empacotar sua camada **Application** como um NuGet e usá-la em uma aplicação separada.

---

## 1. Configurar o `.csproj`

No projeto `Application`, ajuste o arquivo `.csproj`:

xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <GeneratePackageOnBuild>true</GeneratePackageOnBuild>
    <PackageId>Tributario.Atendimento.Module</PackageId>
    <Version>2.0.0</Version>
    <Authors>Marcos</Authors>
  </PropertyGroup>

</Project>
```

Na raiz do projeto Application, rode:
dotnet build -c Release
dotnet pack -c Release

Isso gera o arquivo
Application/bin/Release/Tributario.Atendimento.Module.1.0.0.nupkg

mkdir E:\Dev\NugetLocal

dotnet nuget add source "E:\Dev\NugetLocal" --name LocalFeed


dotnet add package Tributario.Atendimento.Module --version 1.0.0 --source LocalFeed


var connectionString = "Server=localhost;Database=MinhaAppDb;Trusted_Connection=True;TrustServerCertificate=True;";

        // Configura tudo com uma única chamada
        services.ConfigureAtendimentoModule(connectionString);





dotnet build -c Release 
dotnet pack -c Release  

dotnet nuget push "bin/Release/Tributario.Imobiliario.Domain.1.0.0.nupkg" --api-key <api-key> --source https://api.nuget.org/v3/index.json
dotnet nuget push "bin/Release/Tributario.Imobiliario.Application.1.0.0.nupkg" --api-key <api-key> --source https://api.nuget.org/v3/index.json
dotnet nuget push "bin/Release/Tributario.Imobiliario.Infrastructure.1.0.0.nupkg" --api-key <api-key> --source https://api.nuget.org/v3/index.json


https://www.nuget.org/account/Packages