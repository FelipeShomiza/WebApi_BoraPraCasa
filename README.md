# CorridaAPI 

Uma Web API robusta desenvolvida em ASP.NET 9 para gestão de corridas, motoristas e passageiros.

# Descrição do Sistema
O sistema permite o registo e a gestão de corridas urbanas. A API calcula automaticamente o valor final da tarifa baseando-se na distância percorrida e gere o estado da corrida (Pendente, Iniciada ou Finalizada). Os dados são persistidos numa base de dados SQLite, garantindo leveza e portabilidade.

# Lista de Endpoints (CRUD)

A rota base da API é: `http://localhost:XXXX/api/Corrida`

 Método, Endpoint, Descrição
 GET `/api/Corrida`  Retorna a lista de todas as corridas no banco. 
 GET `/api/Corrida/{id}`  Busca os detalhes de uma única corrida pelo ID. 
 POST  `/api/Corrida`  Cadastra uma nova corrida e calcula o valor automaticamente. 
 PUT `/api/Corrida/{id}`  Atualiza os dados ou o status de uma corrida existente. 
 DELETE  `/api/Corrida/{id}`  Remove permanentemente uma corrida do banco. 

# Exemplo de Corpo (JSON) para POST/PUT:
```json
{
  "idMotorista": 1,
  "idPassageiro": 10,
  "distancia": 10.5,
  "status": 0
}
