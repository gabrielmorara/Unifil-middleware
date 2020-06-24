# TAG 01
Esta etapa do projeto foi implementada utilizando apenas comunicação TCP/IP entre o Cliente(em um único processo) e o Servidor.

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

é possível jogar sem rodar o projeto, baixando somente os executáveis dentro da pasta "Executaveis"
# Como Jogar
* Clonar o projeto
* Instalar os .exe RodaRodaJequitiServer e RodaRodaJequitiClient dentro da pasta "Executaveis"

# Servidor
* Apos executar o RodaRodaJequitiServer, a seguinte tela deverá aparecer

![alt text](https://github.com/gabrielmorara/Unifil-middleware/blob/master/Trabalho%20Middleware/Tag01/IMG/server.png)

O servidor é responsável por:
* Iniciar o jogo
* Gerar as palavras para os jogadores
* Controlar os jogadores
* Controlar os acertos e erro
* Controle dos pontos
* Apresentar toda interação feita com o cliente no Form

# Cliente
* apos executar o RodaRodaJequitiClient, a seguinte tela deverá aparecer
![alt text](https://github.com/gabrielmorara/Unifil-middleware/blob/master/Trabalho%20Middleware/Tag01/IMG/client.png)

O cliente possui um único processo que engloba 3 jogadores no mesmo Form, sendo necessário passar o mouse para o próximo, nesta etapa somente possui uma rodada com 3 palavras, após finalizar é necessário executar novamente o cliente para jogar de novo.

* O jogador atual é indicado pelo label "Vez do jogador "

# Tecnologias Utilizadas
* Linguagem de Programação: C#
* IDE: Visual Studio
* Interface: Windows.Forms (GUI)
* S.O: Windows 10
* Middleware: SimplesTCP
