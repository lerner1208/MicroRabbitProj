
using Models;
using RabbitMQ.Client;
using RabbitUtil;
using System;
using System.Collections.Generic;
using System.Text;

namespace Producer
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var employees = new List<Employee>();
            employees.Add(new Employee("tomer", "12/08/1994", 26, "programmer"));
            employees.Add(new Employee("ron", "26/5/1994", 26, "fireman"));
            employees.Add(new Employee("yoni", "26/09/1990", 30, "waiter"));

            var employeesToSend = CreateSendModels(employees);

            var sendQueueName = "BasicTest";
            RabbitService.SendMessage(employeesToSend , sendQueueName);

            Console.WriteLine("\nPress [Enter] to exit the Sender App...");
            Console.ReadLine();
        }

        private static List<object> CreateSendModels(List<Employee> employees)
        {
            var employeesToSend = new List<object>();
            foreach (var employee in employees)
            {
                var employeeToSend = new EmployeeInternal(
                    employee.Name,
                    employee.Birthday,
                    employee.Profession);
                employeesToSend.Add(employeeToSend);
            }

            return employeesToSend;
        }
    }
}
