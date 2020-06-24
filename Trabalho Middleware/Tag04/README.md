# TAG 04
Esta etapa do projeto foi implementada utilizando Rabbit MQ, um middleware orientado a mensagens (MOM).

# Dependências
* Visual Studio
* .Net Framewotk 4.5.1 ou Superior
* Windows 10
* Rabbit MQ (https://www.rabbitmq.com/)

# Como rodar o projeto
Para o cliente e servidor executar os mesmos passos:
* Clonar o projeto
* Iniciar o Rabbit MQ
* Abrir o projeto no Visual Studio
* Baixar dependências com Nuget( Visual Studio -> Botão esquerdo em cima do projeto -> Restaurar pacotes NuGet)
* Compilar e depois clicar em Iniciar
* A maior parte do código está nas classes:
   * Tag04/Server/RodaRodaJequitiServer/RodaRodaJequitiServer/Form1.cs
   * Tag04/Cliente/RodaRodaJequitiClient/RodaRodaJequitiClient/Form1.cs

é possível jogar sem rodar o projeto, baixando somente os executáveis dentro da pasta "Executaveis"
# Como Jogar
* Clonar o projeto
* Iniciar o Rabbit MQ
* Instalar os .exe RodaRodaJequitiServer e RodaRodaJequitiClient dentro da pasta "Executaveis"

# Servidor
* Apos executar o RodaRodaJequitiServer, a seguinte tela devera aparecer:

![alt text](https://github.com/gabrielmorara/Unifil-middleware/blob/master/Trabalho%20Middleware/Tag04/IMG/server.png)

O servidor é responsável por:
* Iniciar o jogo
* Iniciar novas rodadas
* Notificar o jogador quando é sua vez, ou notificar quando tentar jogar é não é sua vez
* Controlar a lista de jogadores
* Exibir o placar
* Gerar as palavras para os jogadores
* Controlar os acertos e erros, notificando os clientes e passando a vez para o próximo
* Controlar dos pontos
* Reconectar o jogador após ele sair e voltar
* Apresentar toda interação feita com o cliente no Form

O jogador atual e apresentado pela caixa de "Jogadores" com o checkbox marcado, porém o mesmo é notificado pela sua interface quando sua vez chegar!

# Cliente
* apos executar o RodaRodaJequitiClient, a seguinte tela deverá aparecer:

![alt text](https://github.com/gabrielmorara/Unifil-middleware/blob/master/Trabalho%20Middleware/Tag04/IMG/clientes.png)

* Para cada jogador é necessário executar uma instância do cliente, pois esta etapa pode ter mais de um jogador(processo).

* Para começar a jogar basta informar um nome e clicar no botão "Jogar".

# Tecnologias Utilizadas
* Linguagem de Programação: C#
* IDE: Visual Studio
* Interface: Windows.Forms (GUI)
* S.O: Windows 10
* Middleware: Rabbit MQ
