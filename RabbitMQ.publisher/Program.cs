using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory();

factory.Uri = new Uri("amqps://gzszzate:tUeorBG__OUmMDs1yUSNNnSf7FpvJ90i@shark.rmq.cloudamqp.com/gzszzate");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel();

channel.QueueDeclare("hello-queue", true, false, false);

string message = "hello world";

var messageBody = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(string.Empty, "hello-queue",null,messageBody);

Console.WriteLine("Mesaj gönderilmiştir");
Console.ReadLine();

