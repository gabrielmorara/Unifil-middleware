# TAG 02
Esta etapa do projeto foi implementada utilizando a classe Socket nativo do C# para a comunicação entre Cliente(múltiplos processos) e o Servidor.

# Dependências
* Visual Studio
* .Net Framewotk 4.5.1 ou Superior
* Windows 10

# Como rodar o projeto
Para o cliente e servidor executar os mesmos passos:
* Clonar o projeto
* Abrir o projeto no Visual Studio
* Baixar dependências com Nuget
* Compilar e depois clicar em Iniciar
* A maior parte do codigo esta nas classes:
   * Tag02/Server/RodaRodaJequitiServer/RodaRodaJequitiServer/Form1.cs
   * Tag02/Cliente/RodaRodaJequitiClient/RodaRodaJequitiClient/Form1.cs

é possível jogar sem rodar o projeto, baixando somente os executáveis dentro da pasta "Executaveis"
# Como Jogar
* Clonar o projeto
* Instalar os .exe RodaRodaJequitiServer e RodaRodaJequitiClient dentro da pasta "Executaveis"

# Servidor
* Apos executar o RodaRodaJequitiServer, a seguinte tela deverá aparecer:

![alt text](https://github.com/gabrielmorara/Unifil-middleware/blob/master/Trabalho%20Middleware/Tag02/IMG/server.png)

O servidor é responsável por:
* Iniciar o jogo
* Notificar o jogador quando é sua vez, ou averter quando tentar jogar é não é sua vez
* Controlar a lista de jogadores
* Gerar as palavras para os jogadores
* Controlar os acertos e erros notificando os clientes e passando a vez para o próximo
* Controlar dos pontos
* Apresentar toda interação feita com o cliente no Form

O jogador atual e apresentado pela list_client com o checkbox marcado, porém o mesmo é notificado pela sua interface quando sua vez chegar!

# Cliente
* apos executar o RodaRodaJequitiClient, a seguinte tela deverá aparecer:

![alt text](https://github.com/gabrielmorara/Unifil-middleware/blob/master/Trabalho%20Middleware/Tag02/IMG/clientes.png)

* Para cada jogador é necessário executar uma instância do cliente, pois esta etapa pode ter mais de um jogador(processo).

* Para começar a jogar basta clicar no botão "Jogar", assim já é fornecido um IP remoto para o acesso ao servidor, como destacado em vermelho na imagem acima.

# Tecnologias Utilizadas
* Linguagem de Programação: C#
* IDE: Visual Studio
* Interface: Windows.Forms (GUI)
* S.O: Windows 10
* Middleware: Socket
