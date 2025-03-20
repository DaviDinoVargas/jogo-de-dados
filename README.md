# 🎲 Jogo de Dados 2025  

## 📌 Introdução  

O **Jogo de Dados 2025** é uma aplicação de linha de comando em **C#** onde um jogador compete contra o computador em uma corrida até a linha de chegada. O jogador e o computador rolam um dado a cada turno e avançam pela pista de 30 casas. O jogo inclui bônus e penalidades, quem alcançar a linha de chegada primeiro, vence.

## 🚀 Funcionalidades  

✅ **Rolagem de Dados:**  
- O jogador e o computador rolam um dado a cada turno para avançar na pista.  

✅ **Bônus e Penalidades:**  
- Em certas casas (5, 10, 15, 7, 13, 20), bônus e penalidades são aplicados:  
  - **Bônus:** A posição do jogador é aumentada em +3.
  - **Penalidade:** A posição do jogador é diminuída em -2.

✅ **Turnos Extras:**  
- Se o jogador ou o computador rolar um 6, ganha um turno extra e pode rolar o dado novamente.

✅ **Condição de Vitória:**  
- O primeiro a alcançar ou ultrapassar a casa 30 vence o jogo.

✅ **Interface Simples:**  
- Interface de linha de comando simples e interativa.

## 💻 Exemplo de Execução:  

![](https://i.imgur.com/mG299CP.gif)

## 🛠 Como utilizar:
🚀 Passo a Passo

1. Clone o repositório ou baixe o código fonte.
2. Abra o terminal ou prompt de comando e navegue até a pasta raiz
3. Utilize o comando abaixo para restaurar as dependências do projeto

```
dotnet restore
```
4. Em seguida, compile a solução o comando:
```
dotnet build --configuration Release
```
5. Para executar o projeto compilando em tempo real
```
dotnet run --project JogoDados.ConsoleApp
```
6. Para executar o arquivo compilado, navegue até a pasta: ./Calculadora.ConsoleApp/bin/Release/net8.0/ e execute o arquivo:
```
JogoDadosConsoleApp1.exe
```

## ✅ Requisitos
.NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.