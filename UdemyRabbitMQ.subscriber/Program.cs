using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory();

factory.Uri = new Uri("amqps://gzszzate:tUeorBG__OUmMDs1yUSNNnSf7FpvJ90i@shark.rmq.cloudamqp.com/gzszzate");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel();

// channel.QueueDeclare("hello-queue", true, false, false);

var consumer = new EventingBasicConsumer(channel);

channel.BasicConsume("hello-queue", true, consumer);

consumer.Received += (object sender, BasicDeliverEventArgs e) =>
{
    var message = Encoding.UTF8.GetString(e.Body.ToArray());
    Console.WriteLine("Gelen Mesaj: " + message);
};

Console.ReadLine();