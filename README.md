# BoraPraCasa - Corrida API

## Integrantes da equipe

- Integrante 1: Felipe Yuuki
- Integrante 2: Murilo Gennari
- Integrante 3: Denys Jhones
- Integrante 4: Henrique Matucheski
- Integrante 5: Eduardo Matucheski

## Descricao do sistema

O BoraPraCasa e uma aplicacao para gerenciamento de corridas. O sistema possui uma API REST desenvolvida em ASP.NET Core, responsavel por cadastrar, listar, buscar, atualizar e excluir corridas. Cada corrida possui nome, distancia e valor, sendo que o valor e calculado automaticamente a partir da distancia informada.

O projeto tambem possui um frontend em React, que consome a API, realiza login, armazena o token JWT no navegador e permite ao usuario visualizar, cadastrar e excluir corridas pela interface.

## Tecnologias utilizadas

- ASP.NET Core Web API
- .NET 9
- C#
- Entity Framework Core
- SQLite
- JWT Bearer Authentication
- React
- Vite
- JavaScript
- HTML e CSS

## Instrucoes de execucao

### Backend

Acesse a pasta do backend:

```bash
cd backend
```

Execute a API:

```bash
dotnet run
```

A API sera executada nos enderecos configurados no projeto:

```text
http://localhost:5095
https://localhost:7258
```

### Frontend

Acesse a pasta do frontend:

```bash
cd frontend
```

Instale as dependencias:

```bash
npm install
```

Execute a aplicacao:

```bash
npm run dev
```

O frontend sera executado normalmente em:

```text
http://localhost:5173
```

## Endpoints principais

### Autenticacao

#### Login

```http
POST /api/Auth/login
```

Exemplo de corpo da requisicao:

```json
{
  "email": "admin@email.com",
  "senha": "123456"
}
```

Retorno esperado:

```json
{
  "token": "token_jwt_gerado"
}
```

#### Endpoint protegido

```http
GET /api/Auth/protegido
```

Esse endpoint exige o envio de um token JWT valido no cabecalho da requisicao.

Exemplo:

```http
Authorization: Bearer token_jwt_gerado
```

### Corridas

#### Listar todas as corridas

```http
GET /api/Corrida
```

#### Buscar corrida por ID

```http
GET /api/Corrida/{id}
```

#### Cadastrar corrida

```http
POST /api/Corrida
```

Exemplo de corpo da requisicao:

```json
{
  "nome": "Corrida Centro",
  "distancia": 10
}
```

#### Atualizar corrida

```http
PUT /api/Corrida/{id}
```

Exemplo de corpo da requisicao:

```json
{
  "id": 1,
  "nome": "Corrida Atualizada",
  "distancia": 15,
  "valor": 0
}
```

#### Atualizar parcialmente uma corrida

```http
PATCH /api/Corrida/{id}
```

Exemplo de corpo da requisicao:

```json
{
  "distancia": 20
}
```

#### Excluir corrida

```http
DELETE /api/Corrida/{id}
```

## Autenticacao JWT

O sistema utiliza JWT para autenticar usuarios. O login e feito pelo endpoint `/api/Auth/login`, que valida o e-mail e a senha informados. Quando os dados estao corretos, a API gera um token JWT com validade de 2 horas.

Esse token deve ser enviado nas proximas requisicoes protegidas no cabecalho `Authorization`, usando o formato:

```http
Authorization: Bearer token_jwt_gerado
```

No backend, a autenticacao JWT e configurada no arquivo `Program.cs`, usando issuer, audience e uma chave secreta para validar os tokens recebidos.
