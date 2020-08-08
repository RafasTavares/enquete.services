# Enquete Services

É uma API	RESTful	para para o funcionamento de um Enquete.

> Utilizado o Swagger para teste e "documentação" dos métodos.

## Tecnologias - Requisitos

> Requisitos para desenvolvimento:
* .net Core 2.2
* Visual Studio <2017
* Atualmente utilizando o Bando de Dados SQL Server 2018 hospedado no Azure, basta conectar com os dados do servidor em qualquer Client SQL que suporte SQL Server 

OBS. O Firewall do servidor está desabilitado permitindo acesso ao BD

``` JSON
"ConnectionStrings": {
    "DefaultConnection": "Server=tcp:rafasdev.database.windows.net,1433;Database=DB_ENQUETE; Uid=system; Pwd=A@q1w2e3r4t5; MultipleActiveResultSets=True; Min Pool Size=100; Max Pool Size=3000; Pooling=true;"
  }
```

### Arquitetura
> O serviço foi baseado em DDD, sendo um microserviço enquete. Adotando algumas práticas do SOLID, clean code, CQRS e TDD.

Inicialmente possuindo apenas a funcinalidade de criar a votação com as opções e inserir os votos, podem ser acoplados outros servicos à mesma solução, como por exemplo:

* Serviço de Autenticação
* Serviço de Gestao de usuários
* Serviço de Permissionamento

> Baseada em simples teste funcionais, validando os commands e queries até o repositório, a idéia é melhorar o pipeline existente no Git action para só publicar commits enviados à master com 100% de sucesso dos testes (o que atualmente ésta publicando tudo enviado à master sem validação dos testes).
 
### Links úteis
* Swagger da API: [https://enquete-api.azurewebsites.net/swagger/index.html](https://enquete-api.azurewebsites.net/swagger/index.html)
* Repositório: [https://github.com/RafasTavares/enquete.services](https://github.com/RafasTavares/enquete.services)
