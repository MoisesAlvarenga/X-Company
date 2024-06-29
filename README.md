# XCompany - Sistema de Gestão de Vendas

## Descrição
O projeto XCompany é um sistema de gestão de vendas desenvolvido em C# utilizando Windows Forms. Ele permite gerenciar clientes, produtos e vendas, incluindo funcionalidades para adicionar, editar e excluir registros.

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

- C# (.NET Framework)
- Windows Forms (WinForms)
- Entity Framework Core (para acesso a dados)
- Visual Studio 2022
- SQL Server (ou outro banco de dados suportado pelo Entity Framework)

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
   - Visual Studio 2022 (ou versão compatível com .NET Framework)
   - SQL Server (ou outro banco de dados suportado pelo Entity Framework)

2. **Configuração do Projeto**
   - Clone o repositório para sua máquina local.
   - Abra o projeto no Visual Studio.
   - Verifique e configure a conexão com o banco de dados no arquivo de configuração (`app.config` ou `web.config`).

3. **Execução**
   - Compile o projeto e execute a aplicação (`F5` no Visual Studio).
   - A aplicação deve iniciar, permitindo a gestão de clientes, produtos e realização de vendas.

## Contribuição

Contribuições são bem-vindas! Se você deseja contribuir para o projeto, por favor siga os passos:

1. Faça um fork do repositório.
2. Crie uma branch com a sua feature (`git checkout -b feature/MinhaFeature`).
3. Commit suas mudanças (`git commit -am 'Adicionando a funcionalidade MinhaFeature'`).
4. Push para a branch (`git push origin feature/MinhaFeature`).
5. Abra um Pull Request.

## Licença

Este projeto está licenciado sob a [MIT License](https://opensource.org/licenses/MIT) - veja o arquivo LICENSE.md para mais detalhes.

---

© 2024 XCompany. Todos os direitos reservados.
