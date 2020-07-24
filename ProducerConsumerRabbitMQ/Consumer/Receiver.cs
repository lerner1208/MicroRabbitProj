using Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitUtil;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consumer
{
    public class Receiver
    {
        public static void Main(string[] args)
        {
            var recieveQueueName = "BasicTest";
            RabbitService.RecieveMessage<List<EmployeeInternal>>(recieveQueueName , PrintEmployees);

            Console.WriteLine("Press [Enter] to exit the Reciever App...");
            Console.ReadLine();
        }

        private static void PrintEmployees(List<EmployeeInternal> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine("Employee: ");
                Console.WriteLine($"Name: {employee.Name}");
                Console.WriteLine($"Birthday: {employee.Birthday}");
                Console.WriteLine($"Profession: {employee.Profession} ");
            }
        }
    }
}
