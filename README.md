# Producer e Consumer RabbitMQ em .NET Core

Foi utilizado o [.NET Core 5.0](https://www.microsoft.com/net/download).

É necessário tem o servidor do [RabbitMQ] (https://www.rabbitmq.com/download.html) instalado para executar o projeto.

## Habilitando o Dashboard do RabbitMQ

Com o servidor do RabbitMQ instalado, execute os comandos para habilitar o Dashboard:

```sh
cd C:\Program Files\RabbitMQ Server\rabbitmq_server-3.10.5\sbin
rabbitmq-plugins enable rabbitmq_management
```

Após tudo configurado, acessar o Dashboard do RabbitMQ pelo link: http://localhost:15672/ com usuario/senha: guest

## Instruções para executar o build do projeto

Na raiz da solution, execute os comandos em um terminal para compilar:

```sh
dotnet restore
dotnet build -c Release
```

## Instruções para executar o projeto
