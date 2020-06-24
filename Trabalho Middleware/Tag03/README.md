# TAG 03
Esta etapa do projeto foi implementada utilizando RPC para a comunicação entre Cliente(múltiplos processos) e o Servidor.

# Dependências
* Visual Studio
* .Net Framewotk 4.5.1 ou Superior
* Windows 10
* Apache Thrift (https://thrift.apache.org)

# Como rodar o projeto
* Clonar o projeto
* Abrir o projeto no Visual Studio(Tag03\RodaRodaJequitiRPC\RodaRodaJequitiRPC.sln)
* Baixar dependências com Nuget ( Visual Studio -> Botão esquerdo em cima do projeto -> Restaurar pacotes NuGet)
* Compilar, selecionar o projeto "ThriftS.Test.Server" e depois clicar em Iniciar para executar o Servidor

* Executar o projeto "ThriftS.Test.Client" e iniciar uma nova instância(Executar uma instância por jogador)

* A maior parte do código está nas classes:
  * Tag03\RodaRodaJequitiRPC\ThriftS.Test.Client\Form1.cs -> Contem a implementação da interface do cliente e as chamadas RPC
  * Tag03\RodaRodaJequitiRPC\ThriftS.Test.Server\RodaRodaServico -> Contem a implementação dos métodos do contrato RPC
  * Tag03\RodaRodaJequitiRPC\ThriftS.Test.Contract\RodaRoda.cs -> Contem o contrato entre ambas partes.

# Servidor
* Após executar o Servidor, a aplicação de console deve carregar:

![alt text](https://github.com/gabrielmorara/Unifil-middleware/blob/master/Trabalho%20Middleware/Tag03/IMG/server.png)

O servidor é responsável por:
* Iniciar o jogo
* Controlar os jogadores
* Gerar as palavras
* Controlar os acertos e erros
* Controlar dos pontos
* Apresentar toda interação feita no console

# Cliente
* Após executar o Cliente, deverá aparecer um Form para cada instância:

![alt text](https://github.com/gabrielmorara/Unifil-middleware/blob/master/Trabalho%20Middleware/Tag03/IMG/cliente.png)

* Para jogar é necessário informar o nome e clicar em jogar

# Tecnologias Utilizadas
* Linguagem de Programação: C#
* IDE: Visual Studio
* Interface Cliente: Windows.Forms (GUI)
* Interface Server: Console
* S.O: Windows 10
* Middleware: Apache Thrift
