using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Subject subject = new Proxy();

        subject.Request("Запрос 1");  
        subject.Request("Запрос 1");  
        subject.Request("Запрос 2"); 
    }
}

abstract class Subject
{
    public abstract void Request(string request);
}

class RealSubject : Subject
{
    public override void Request(string request)
    {
        Console.WriteLine($"Обработка '{request}'");
    }
}

class Proxy : Subject
{
    private RealSubject _realSubject;
    private Dictionary<string, string> cache;
    private DateTime cacheTime;
    private const int CacheExpirationSeconds = 10;

    public Proxy()
    {
        cache = new Dictionary<string, string>();
        cacheTime = DateTime.MinValue;
    }

    public override void Request(string request)
    {
        if (DateTime.Now - cacheTime > TimeSpan.FromSeconds(CacheExpirationSeconds))
        {
            cache.Clear();  
        }

        if (cache.ContainsKey(request))
        {
            Console.WriteLine($"Proxy: Ответ из кэша: {cache[request]}");
        }
        else
        {
            if (CheckAccess())
            {
                if (_realSubject == null)
                {
                    _realSubject = new RealSubject();
                }

                Console.WriteLine($"'{request}' через RealSubject");
                _realSubject.Request(request);
                cache[request] = $"Ответ на запрос '{request}'";  
                cacheTime = DateTime.Now;  
            }
            else
            {
                Console.WriteLine("Доступ запрещен");
            }
        }
    }

    private bool CheckAccess()
    {
        Console.WriteLine("Проверка прав доступа через прокси...");
        return true;  
    }
}
