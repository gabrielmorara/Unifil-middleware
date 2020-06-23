# TAG 01
Esta etapa do projeto foi implementada utilizando apenas comunicação TCP/IP entre o Cliente(em um único processo) e o Servidor.

# Dependências
* Visual Studio
* .Net Framewotk 4.5.1 ou Superior
* Windows 10

# Como Executar o projeto
Para o cliente e servidor executar os mesmos passos
* Abrir o projeto no Visual Studio
* Baixar dependências com Nuget
* Compilar e depois clicar em Iniciar

é possível jogar sem executar o projeto, baixando somente os executáveis dentro da pasta "Executaveis"
#Como Jogar
* Clonar o projeto
* Descompactar a pasta Executaveis
* Instalar os .exe RodaRodaJequitiClient e RodaRodaJequitiServer

# Servidor
* Apos executar o RodaRodaJequitiServer, a seguinte tela devera aparecer

O servidor é responsável por:
* Iniciar o jogo
* Gerar as palavras para os jogadores
* Controlar os jogadores
* Controlar os acertos e erro
* Controle dos pontos

# Cliente
* apos executar o RodaRodaJequitiClient, a seguinte tela devera aparecer
O cliente possui um unico processo que engloba 3 jogadores no mesmo Form, sendo necessario passar o mouse para o proximo  

# Tecnologias Utilizadas
* Lingaugem de Programacao: C#
* IDE: Visual Studio
* Windows.Forms
* S.O: Windows 10
* SimplesTCP
