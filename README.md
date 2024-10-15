ProjetoBusca API - Como Rodar Localmente
===============================

Este guia explica como configurar e rodar a aplicação ProjetoBusca API localmente. Esta aplicação foi desenvolvida usando ASP.NET
Core e utiliza Entity Framework Core com SQLite. O passo a passo inclui a instalação de dependências, execução de
migrações e o comando para iniciar a aplicação.

Você pode encontrar a documentação completa através do
seguinte [link](https://docs.google.com/document/d/1auCZJL7rLbOZPAIIj9uheMiVsAwRed6aOPdJn0uSZVs/edit?usp=sharing).

Requisitos
----------

- .NET 6.0 ou superior instalado ([Baixar .NET](https://dotnet.microsoft.com/download)).
- SQLite, que já é instalado junto com as dependências do projeto.
- Editor de código, como Visual Studio Code ou Rider.
- Git, para clonar o repositório.

Passo a Passo
-------------

### 1\. Clonar o Repositório

Primeiro, clone o repositório da aplicação para sua máquina local

### 2\. Restaurar as Dependências

Dentro do diretório do projeto, execute o seguinte comando para restaurar todas as dependências do projeto:

bash

Copiar código

`dotnet restore`

Este comando irá baixar todos os pacotes NuGet necessários para rodar a aplicação.

### 3\. Executar as Migrações do Banco de Dados

Como estamos usando Entity Framework Core com SQLite, precisamos criar e aplicar as migrações para configurar o banco de
dados.

#### 3.1 Criar a Migração (caso não exista)

Se você precisar criar a primeira migração, rode o comando abaixo:

bash

Copiar código

`dotnet ef migrations add InitialCreate`

#### 3.2 Atualizar o Banco de Dados

Para aplicar a migração ao banco de dados e criar as tabelas necessárias, execute o comando:

bash

Copiar código

`dotnet ef database update`

Este comando irá criar o banco de dados `BancoDados.db` e aplicar todas as migrações pendentes.

### 4\. Rodar a Aplicação

Com tudo configurado, agora você pode rodar a aplicação usando o comando:

bash

Copiar código

`dotnet run`

Se tudo estiver configurado corretamente, você verá uma mensagem indicando que a aplicação está rodando, como:

csharp

Copiar código

`info: Microsoft.Hosting.Lifetime[14]
Now listening on: http://localhost:5112`

### 5\. Acessar a API

Você pode acessar o Swagger UI para interagir com a API através do navegador em:

<http://localhost:5112/swagger>

Você também pode testar os endpoints diretamente no navegador ou usando ferramentas como Postman.

### 6\. Endpoints da API

A API expõe os seguintes endpoints para gerenciar cursos:

- **GET** `/api/cursos` - Retorna a lista de todos os cursos.
- **GET** `/api/cursos/{id}` - Retorna um curso específico pelo ID.
- **POST** `/api/cursos` - Adiciona um novo curso.

### 7\. Problemas Comuns

- **Erro: Porta já está em uso**: Se a porta 5112 já estiver sendo usada, você pode mudar a porta no código `Program.cs`
  ou parar o processo que está usando essa porta.
- **Warnings do EF Core sobre NativeAOT**: Esses são apenas avisos relacionados ao uso do EF Core em compilação AOT e
  não impedem a aplicação de rodar localmente.

Conclusão
---------

Agora você deve ser capaz de rodar a aplicação localmente e interagir com a API. Caso encontre qualquer problema,
verifique se todos os passos foram seguidos corretamente ou consulte a documentação oficial do .NET e Entity Framework
Core.

Para mais informações, consulte
o [documento original](https://docs.google.com/document/d/1auCZJL7rLbOZPAIIj9uheMiVsAwRed6aOPdJn0uSZVs/edit?usp=sharing).