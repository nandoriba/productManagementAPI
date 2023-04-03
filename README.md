# Product Management API

Este projeto consiste em uma API para gerenciar produtos, desenvolvida
em .NET 6, utilizando a linguagem C# e o banco de dados Microsoft SQL
Server. A API fornece operações CRUD para gerenciar produtos e suas
categorias.

## Requisitos

-   .NET 6

-   Microsoft SQL Server

-   Visual Studio 2022 ou superior (recomendado) ou Visual Studio Code

## Instalação

1.  Clone o repositório para sua máquina local:git clone
    https://github.com/nandoriba/productManagementAPI.git

2.  Abra o projeto no Visual Studio 2022 ou no Visual Studio Code.

3.  Instale as dependências do projeto:

`dotnet restore`

## Configuração

1.  Configure a conexão com o banco de dados Microsoft SQL Server,
    editando o arquivo **appsettings.json**, localizado na raiz do
    projeto:

`{
\"ConnectionStrings\": {
> \"DefaultConnection\":
> \"Server=localhost;Database=ProductManagement;User
> Id=your_user_id;Password=your_password;\">
> }
}`

2.  Execute as migrações do Entity Framework Core para criar a estrutura
    do banco de dados:

`dotnet ef database update`
  
  Ou 
 
 Execute o script disponível em: 
 https://github.com/nandoriba/productManagementAPI/blob/main/SQLServerScript/SQLQueryScript.sql

## Como usar

1.  Execute a aplicação:

`dotnet run`

2.  A API estará disponível no endereço http://localhost:5211 (ou
    https://localhost:7096 se estiver usando HTTPS).

## Endpoints

### Produtos

-   `GET /api/products`: Retorna a lista de todos os produtos.

-   `GET /api/products/{id}`: Retorna um produto específico pelo ID.

-   `GET /api/products/{status}`: Retorna uma lista por status.

-   `GET /api/products/{description}`: Retorna uma lista pela descrição.

-   `GET /api/products/{category}`: Retorna uma lista pela categoria.

-   `POST /api/products`: Adiciona um novo produto.

-   `PUT /api/products/{id}`: Atualiza um produto existente pelo ID.

-   `DELETE /api/products/{id}`: Remove um produto pelo ID.

### Categorias

-   `GET /api/categories`: Retorna a lista de todas as categorias.

-   `GET /api/categories/{id}`: Retorna uma categoria específica pelo ID.

-   `GET /api/v1/Category/CategoryByStatus/{status}`: Retorna uma lista com todas as categorias pelo status.

-   `GET /api/v1/Category/CategorysByName/{name}`: Retorna umas lista por nome.

-   `POST /api/categories`: Adiciona uma nova categoria.

-   `PUT /api/categories/{id}`: Atualiza uma categoria existente pelo ID.

-   `DELETE /api/categories/{id}`: Remove uma categoria pelo ID.

### AssociateProductWithCategory

-   `POST /api/v1/AssociateProductWithCategory`: Adiciona uma nova associação entre produto e categoria.

-   `DELETE /api/categories/{id}`: Remove a associação entre produto e categoria.

## Licença

Este projeto está licenciado sob a licença MIT. Consulte o arquivo
LICENSE para obter mais detalhes.
