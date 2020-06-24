# Unifil-middleware

Alunos: 
 * Gabriel Morara Ribeiro
 * Lucas Lima 
 
 # Como Executar
Dentro de cada pasta "Trabalho Middleware/TAG" contem seu próprio README.md contendo as informações necessárias para rodar os projetos.
 
 # Etapas
  * Tag01 (https://github.com/gabrielmorara/Unifil-middleware/tree/master/Trabalho%20Middleware/Tag01)
  * Tag02 (https://github.com/gabrielmorara/Unifil-middleware/tree/master/Trabalho%20Middleware/Tag02)
  * Tag03 (https://github.com/gabrielmorara/Unifil-middleware/tree/master/Trabalho%20Middleware/Tag03)
  * Tag04 (https://github.com/gabrielmorara/Unifil-middleware/tree/master/Trabalho%20Middleware/Tag04)



# Quão difícil seria implementar uma modalidade de jogo em que cada jogador pode responder ao mesmo tempo?
* R: A dificuldade principal é o tratamento de concorrências, pode ser adotado o tratamento em que os jogadores que responderam corretamente ganham pontos e os que responderam incorretamente perdem pontos, ou dar prioridade ao jogador que está com mais pontos do que o outro, como temos apenas um servidor também podemos tratar pela ordem de chegada das chamadas dando prioridade para o primeiro é bloqueando outras respostas caso a primeira que chegasse estiver correta.
