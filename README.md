# Chat room Project

This document describes the **.NET challenge** for the **.NET Developer** position.

## Project Description

Design and implement a **Chat room**. The goal of this challenge is to create a simple browser-based chat application using .NET.
This application should allow several users to talk in a chatroom and also to get stock quotes
from an API using a specific command.

The application should have:
Allow registered users to log in and talk with other users in a chatroom.
* Allow users to post messages as commands into the chatroom with the following format
/stock=stock_code
* Create a decoupled bot that will call an API using the stock_code as a parameter
(https://stooq.com/q/l/?s=aapl.us&f=sd2t2ohlcv&h&e=csv, here aapl.us is the
stock_code)
* The bot should parse the received CSV file and then it should send a message back into
the chatroom using a message broker like RabbitMQ. The message will be a stock quote
using the following format: “APPL.US quote is $93.42 per share”. The post owner will be
the bot.
* Have the chat messages ordered by their timestamps and show only the last 50
messages.
* Unit test the functionality you prefer.

### Setup

* Before running the project make sure you have erland and RabbitMQ up and running. Links are below:
	* https://www.erlang.org/downloads
	* https://www.rabbitmq.com/download.html

* There is no need additional changes on appsettings.Development.json file, however if you already setup rabbitMQ with username and password, you'll need to change **RabbitMQHostName** value.
* Run ASP.NET Web Application in Visual Studio as usual.
* make sure you have **nuget.config** in root folder.



### Useful links
* https://github.com/SignalR/SignalR

### You can also check these readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)