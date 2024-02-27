## DTI Digital: Teste prático

![dti-digital](https://github.com/daviferreiradev/dti-teste-pratico/assets/123561984/e88c08bc-d988-4780-95cb-c9b91dfcb7c6)

### Objetivo do Projeto 🚀

O objetivo deste projeto é desenvolver um aplicativo de lembretes (tasks) onde os usuários podem adicionar, visualizar e excluir tarefas.

![image](https://github.com/daviferreiradev/dti-teste-pratico/assets/123561984/2e611f72-9454-40d5-bb2f-53e96ce5588c)

### Requisitos para Rodar o Projeto 🛠️

#### Setup de Ambiente / Dependências Necessárias

- Node.js
- npm (Node Package Manager)
- .NET Core SDK
- SQL Server (ou outro banco de dados compatível com Entity Framework Core)

### Como Rodar na Minha Máquina? 💻

#### Backend

1. Clone o repositório do GitHub: `git clone https://github.com/seu-usuario/dti-teste-pratico.git`
2. Navegue até a pasta do backend: `cd backend`
3. Configure a string de conexão com o banco de dados no arquivo `appsettings.json`
4. Execute as migrações do banco de dados: `dotnet ef database update`
5. Execute o projeto: `dotnet run`
6. Configure a string de conexão do banco de dados em `appsettings.json`. Substitua `sa` e `root` pelos seus valores reais para a conexão do banco de dados.

#### Frontend

1. Navegue até a pasta do frontend: `cd frontend`
2. Instale as dependências: `npm install`
3. Inicie o servidor de desenvolvimento: `npm start`

### Como Rodar os Testes 🧪

#### Backend

1. Navegue até a pasta do backend: `cd backend`
2. Execute os testes: `dotnet test`

#### Frontend

1. Navegue até a pasta do frontend: `cd frontend`
2. Execute os testes: `npm test`

### Estrutura do Projeto / Tecnologias Utilizadas 📦

#### Backend

- Linguagem: C#
- Framework: .NET Core
- Banco de Dados: SQL Server (utilizando Entity Framework Core)
- Testes: xUnit

#### Frontend

- Linguagem: JavaScript (com uso do framework React)
- Build e Desenvolvimento: Vite
- Gerenciador de Pacotes: npm
- Estilização: SCSS com pré-processador Sass e pós-processador PostCSS
- Testes: Jest, React Testing Library

### Como se Localizar no Projeto? 🗺️

- **Backend**: A pasta do backend contém toda a lógica de negócios, os controladores da API, os serviços e os repositórios. Os arquivos de configuração do banco de dados estão localizados aqui.

- **Frontend**: A pasta do frontend contém a interface do usuário, componentes React, estilos CSS e os testes relacionados ao frontend.
