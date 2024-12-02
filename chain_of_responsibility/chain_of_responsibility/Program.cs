using System;

abstract class Handler
{
    protected Handler nextHandler;
    public void SetNext(Handler handler)
    {
        nextHandler = handler;
    }
    public abstract void HandleRequest(Request request);
}

class Request
{
    public string EventType { get; set; }  
    public string EventDetails { get; set; }  

    public Request(string eventType, string eventDetails)
    {
        EventType = eventType;
        EventDetails = eventDetails;
    }
}

class InfoHandler : Handler
{
    public override void HandleRequest(Request request)
    {
        if (request.EventType == "Сообщение") 
        {
            Console.WriteLine($"Сообщение:{request.EventDetails}");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(request);
        }
    }
}

class WarningHandler : Handler
{
    public override void HandleRequest(Request request)
    {
        if (request.EventType == "Предупреждение")
        {
            Console.WriteLine($"Предупреждение:  {request.EventDetails}");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(request);
        }
    }
}

class AlarmHandler : Handler
{
    public override void HandleRequest(Request request)
    {
        if (request.EventType == "Внимание")  
        {
            Console.WriteLine($"Внимание: {request.EventDetails}");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(request);
        }
    }
}

public class ChainOfResponsibility
{
    public static void Main(string[] args)
    {
        Handler infoHandler = new InfoHandler();
        Handler warningHandler = new WarningHandler();
        Handler errorHandler = new AlarmHandler();

        infoHandler.SetNext(warningHandler);
        warningHandler.SetNext(errorHandler);

        Request infoRequest = new Request("Сообщение", "Выдача новой инфы");
        Request warningRequest = new Request("Предупреждение", "Плохая погода");
        Request alarmRequest = new Request("Внимание", "Конец семестра");

        Console.WriteLine("Info:");
        infoHandler.HandleRequest(infoRequest);

        Console.WriteLine("\nWarning:");
        infoHandler.HandleRequest(warningRequest);

        Console.WriteLine("\nAlarm:");
        infoHandler.HandleRequest(alarmRequest);
    }
}
