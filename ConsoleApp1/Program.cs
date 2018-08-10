using System;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var manager = new InBoundMessageManager();
            var userInput = 0;
            var dto = new Messages.InboundMessage
            {
                MsgType = "ORD",
                OrderNum = 212,
                PatientName = "Jane Doe",
                TestType = "Glucose"
            };
            var dtoError = new Messages.InboundMessage
            {
                MsgType = "ERR",
                ErrorDescription = "There is something wrong with the service"
            };
            do
            {
                userInput = DisplayMenu();
                string response;
                switch (userInput)
                {
                    case 1:
                        Console.Write("Inbound Message: " + dto.MsgType + "|" + dto.OrderNum + "|" + dto.PatientName + "|" + dto.TestType);
                        Console.WriteLine();
                        response = new StringBuilder(manager.PushNormalMessage(dto)).ToString();
                        var formattedstring = response.Replace(@"\", "");
                        Console.Write("Outbound Message: - " + formattedstring);
                        Console.WriteLine();
                        Console.WriteLine("Sent to next API");
                        Console.WriteLine();
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Inbound Message: " + dtoError.MsgType + "|" + dto.ErrorDescription);
                        Console.WriteLine();
                        response = manager.PushErrorMessage(dtoError);
                        Console.Write("Outbound Message: " + response);
                        Console.WriteLine("Saved in DB");
                        Console.WriteLine();
                        Console.ReadLine();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            } while (userInput != 3);
        }
        public static int DisplayMenu()
        {
            Console.WriteLine("API Manager");
            Console.WriteLine();
            Console.WriteLine("1. Send Normal Message");
            Console.WriteLine("2. Send Error Message");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Please choose an option......");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
    }
}
