

## API Produtos

API criado para teste na empresa AutoGlass, onde fará a **gestão de produtos.**



**Campos no escopo de produtos são: **

• Código do produto (sequencial e não nulo) 

• Descrição do produto (não nulo)

• Situação do produto (Ativo ou Inativo)

• Data de fabricação 

• Data de validade 

• Código do fornecedor 

• Descrição do fornecedor 

• CNPJ do fornecedor



**Validação:**

Campo data de fabricação que não poderá ser maior ou igual a data de validade.

Campo situação, somente aceita A ou I, para Ativo e Inativo.



**Base de Dados:**

Mysql, criado num servidor gratuito na internet:  https://www.freemysqlhosting.net/

Para rodar local, foi criado o arquivo de Migrations, que contém o script de criação das tabelas com o comando: **update-database**



**Execução:**

Para executar a API, entre no diretório da aplicação e execute: **dotnet run**



**Documentação Swagger:** 

Após a execução abrir o endereço no navegador: https://localhost:5001/swagger/index.html



**Rotas:**

GET ==> `/api/Produtos`

POST ==> `/api/Produtos`

GET ==> `/api/Produtos/{Codigo}`

PUT ==> `/api/Produtos/{Codigo}`

DELETE ==> `/api/Produtos/{Codigo}`

