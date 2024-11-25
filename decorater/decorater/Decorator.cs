using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decorater
{
    internal class Decorator
    {
        class Program
        {
            static void Main()
            {
                INotifier notifier = new Notifier("pupu@mer.ci.nsu.ru");

                notifier = new SMSNotifier(notifier, "+79139837465");
                notifier = new FacebookNotifier(notifier, "admin_facebook_account");
                notifier.Send("@all - общая рассылка");
                
            }
        }

    }
}
