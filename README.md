# GATEWAY 
### O que é?
Template Gateway Ocelot 
### Para que serve?
Camada que atua como um intermediário entre o Frontend e as diversas API que compõem uma arquitetura baseada em Micro Serviços centralizando segurança e abstração para requisições externas.
### Tecnologias Utilizadas.
- Redirecionamento Swagger
- Aggregação
- Seguranças e Autenticação
- Docker
### Como usar
1. Caso queira testar com autenticação siga esses passos aqui https://github.com/Edjaine/SSO-BASE-NOVO.
2. Se não executou o passo anterior é importante que crie uma rede docker para rolar a comunicação dos Micro Serviços ***docker network create --driver bridge rede-integrada*** .
3. Na raiz das pastas do projeto suba os containers usando o comando 
``bash docker-compose up --build*** .```
4. No browser o swagger estará disponível em http://localhost:1000/swagger/index.html.
5. Enjoy =).
