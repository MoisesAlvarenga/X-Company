# XCompany - Sistema de Gestão de Vendas

## Descrição
O XCompany é um sistema de gestão de vendas desenvolvido em C# utilizando Windows Forms. Ele permite gerenciar clientes, produtos e vendas, oferecendo funcionalidades para adicionar, editar e excluir registros.

## Funcionalidades

- **Clientes**
  - Adicionar, editar e excluir clientes.
  - Visualizar lista de clientes cadastrados.

- **Produtos**
  - Adicionar, editar e excluir produtos.
  - Visualizar lista de produtos cadastrados.
  - Atualização dinâmica do estoque após vendas.

- **Vendas**
  - Realizar vendas associadas a clientes.
  - Adicionar múltiplos itens a uma venda.
  - Calcular total da venda considerando quantidade de itens e preços unitários.
  - Atualizar estoque de produtos após cada venda.

## Tecnologias Utilizadas

- C# (.NET 8)
- Windows Forms (WinForms)
- Entity Framework Core (para acesso a dados)
- Visual Studio 2022
- PostgreSQL (Versão 13)

## Estrutura do Projeto

O projeto está estruturado da seguinte forma:

- **WinFormsApp1**: Aplicação Windows Forms principal.
  - `frmDashboard`: Interface principal com funcionalidades de gestão de clientes, produtos e vendas.
  - `SaleForm`: Formulário para realizar vendas, adicionar produtos à venda e calcular totais.

- **XCompany.Entities**: Classes de entidades como `Customer`, `Product`, `Sale` e `SaleItem`.

- **XCompany.Services**: Serviços para acesso aos dados das entidades.
  - `ICustomerService`, `IProductService`, `ISaleService`: Interfaces de serviço para clientes, produtos e vendas.
  - Implementações concretas dos serviços para acesso aos dados.

## Instalação e Configuração

1. **Requisitos**
   - Visual Studio 2022 (ou versão compatível com .NET 8)
   - [.NET SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0)
   - Docker para rodar o banco em um container

2. **Configuração do Projeto**
   - Clone o repositório para sua máquina local.
   - Abra o projeto no Visual Studio.
   - Execute o seguinte comando para levantar o banco de dados PostgreSQL via Docker:
     ```
     docker-compose -f "docker-compose.yml" up -d --build
     ```
   - Os arquivos de criação e inserção SQL estão na pasta `Sql` na raiz do projeto, mas não se preocupe em rodá-los manualmente, pois serão executados automaticamente ao levantar o container.

3. **Execução**
   - Compile o projeto e execute a aplicação (pressione `F5` no Visual Studio).
   - A aplicação deve iniciar, permitindo a gestão de clientes, produtos e realização de vendas.

## Observações

Foi utilizado o conceito de Database-First do Entity Framework, onde as tabelas foram criadas manualmente no banco de dados utilizando as queries da pasta `Sql` e em seguida foi utilizado o comando `dotnet ef dbcontext scaffold "SQL_HOST" Npgsql.EntityFrameworkCore.PostgreSQL` para gerar automaticamente o contexto do banco e as classes envolvidas.

## Contribuição

Contribuições são bem-vindas! Se você deseja contribuir para o projeto, siga os passos abaixo:

1. Faça um fork do repositório.
2. Crie uma branch com a sua feature (`git checkout -b feature/MinhaFeature`).
3. Commit suas mudanças (`git commit -am 'Adicionando a funcionalidade MinhaFeature'`).
4. Push para a branch (`git push origin feature/MinhaFeature`).
5. Abra um Pull Request.

---

© 2024 XCompany. Todos os direitos reservados.
