# Módulo

## O que é um Módulo?

Um **módulo** é, de forma simples, uma parte ou componente de um sistema maior. Ele funciona como uma “peça” que pode ser usada isoladamente ou em conjunto com outras para formar algo mais complexo.  

## Exemplos práticos
- 📚 **Na educação**: um módulo é uma unidade de estudo dentro de um curso (por exemplo, “Módulo de Matemática Básica”).  
- 💻 **Na programação**: é um arquivo ou conjunto de funções que podem ser reutilizadas em diferentes partes de um software.  
- 🏗️ **Na engenharia/arquitetura**: pode ser um bloco ou seção padronizada que se encaixa em uma estrutura maior.  

👉 Em resumo: um módulo é como uma “caixinha” organizada que contém algo específico e pode ser combinada com outras para formar um todo.  

# Benefícios e Malefícios de um Módulo

## ✅ Benefícios
- **Organização**: facilita dividir sistemas complexos em partes menores e mais compreensíveis.  
- **Reutilização**: um mesmo módulo pode ser usado em diferentes projetos ou contextos.  
- **Manutenção**: erros ou melhorias podem ser corrigidos em apenas uma parte sem afetar o todo.  
- **Flexibilidade**: permite combinar diferentes módulos para criar soluções personalizadas.  
- **Escalabilidade**: torna mais fácil expandir ou adicionar novas funcionalidades.  

## ⚠️ Malefícios
- **Dependência**: se um módulo falhar, pode comprometer o funcionamento do sistema maior.  
- **Complexidade de integração**: juntar vários módulos pode gerar conflitos ou exigir ajustes extras.  
- **Sobrecarga**: muitos módulos pequenos podem dificultar a gestão e aumentar o custo de manutenção.  
- **Curva de aprendizado**: entender como cada módulo funciona pode ser desafiador para iniciantes.  
- **Compatibilidade**: módulos criados em contextos diferentes podem não funcionar bem juntos.  


# Proposta

Usar esse conceito para entrega da solução para tributário, como prova de conceito

# Estrutura e Isolamento dos Módulos

## 📦 Módulos Criados
- **Tributario.Atendimento.Module**
- **Tributario.Imobiliario.Module**

Ambos os módulos compartilham dependência do **Entity**, mas cada um mantém seu próprio isolamento interno.

---

## 🧩 Camadas de Cada Módulo
Cada módulo possui três camadas bem definidas:

1. **Domain**
   - Contém as regras de negócio e entidades específicas do módulo.
   - Define o "coração" da lógica tributária para cada contexto (Atendimento ou Imobiliário).
   - Não depende de infraestrutura externa.

2. **Application**
   - Orquestra casos de uso e serviços.
   - Faz a ponte entre o *Domain* e a *Infrastructure*.
   - Expõe funcionalidades de forma controlada.

3. **Infrastructure**
   - Implementa detalhes técnicos (persistência, APIs externas, repositórios).
   - Depende do *Entity* para mapear dados.
   - **Inclui Migrations** para evolução do banco de dados de forma isolada por módulo.
   - Mantém o módulo conectado ao ambiente externo sem poluir o *Domain*.

---

## 🔒 Isolamento
- Cada módulo é **autônomo**: suas regras de negócio (Domain) não se misturam com as de outro módulo.  
- O **Entity** funciona como dependência comum, mas não quebra o isolamento, pois apenas fornece contratos e modelos compartilhados.  
- A comunicação entre módulos ocorre **via Application**, nunca diretamente entre *Domains*.  
- As **Migrations** ficam encapsuladas em cada módulo, garantindo que alterações de banco sejam independentes e não interfiram em outros módulos.  

---

## ✅ Benefício do Isolamento
- Clareza na separação de responsabilidades.  
- Redução de acoplamento entre módulos.  
- Maior testabilidade e evolução independente.  
- Controle granular das **Migrations**, evitando impacto cruzado entre módulos.  

# Motivos
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
```

# Nuget
Comandos usados para publicação dos pacotes no Nuget, via api-key

Dentro de cada solution, executar
```
dotnet build -c Release 
dotnet pack -c Release  
```
Depois dentro de cadas camada, excutar

```
dotnet nuget push "bin/Release/Tributario.Imobiliario.Domain.2.0.0.nupkg" --api-key <api-key> --source https://api.nuget.org/v3/index.json

dotnet nuget push "bin/Release/Tributario.Imobiliario.Application.2.0.0.nupkg" --api-key <api-key> --source https://api.nuget.org/v3/index.json

dotnet nuget push "bin/Release/Tributario.Imobiliario.Infrastructure.2.0.0.nupkg" --api-key <api-key> --source https://api.nuget.org/v3/index.json

dotnet nuget push "bin/Release/Tributario.Atendimento.Domain.2.0.0.nupkg" --api-key <api-key> --source https://api.nuget.org/v3/index.json

dotnet nuget push "bin/Release/Tributario.Atendimento.Application.2.0.0.nupkg" --api-key <api-key> --source https://api.nuget.org/v3/index.json

dotnet nuget push "bin/Release/Tributario.Atendimento.Infrastructure.2.0.0.nupkg" --api-key <api-key> --source https://api.nuget.org/v3/index.json
```
