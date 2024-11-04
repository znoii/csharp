using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    internal class Bridg
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("ввести сообщение для Email: ");
                string emailMessage = Console.ReadLine();

                Notification emailNotification = new EmailNotification();
                AbNotification textEmailNotification = new TextNotification(emailNotification);
                textEmailNotification.SendNotification(emailMessage);

                Console.Write("ввести сообщение для SMS: ");
                string smsMessage = Console.ReadLine();

                Notification smsNotification = new SMSNotification();
                AbNotification htmlSmsNotification = new HtmlNotification(smsNotification);
                htmlSmsNotification.SendNotification(smsMessage);


            }
        }
    }
}
