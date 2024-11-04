
using System;


public interface Notification
{
    void Send(string message);
}

public class EmailNotification : Notification
{
    public void Send(string message)
    {
        Console.WriteLine($"для Email - {message}");
    }
}

public class SMSNotification : Notification
{
    public void Send(string message)
    {
        Console.WriteLine($"для SMS - {message}");
    }
}
public abstract class AbNotification
{
    protected Notification _notification;

    protected AbNotification(Notification notification)
    {
        _notification = notification;
    }

    public abstract void SendNotification(string message);
}

// насл
public class TextNotification : AbNotification
{
    public TextNotification(Notification notification) : base(notification) { }

    public override void SendNotification(string message)
    {
        _notification.Send(message);
    }
}

public class HtmlNotification : AbNotification
{
    public HtmlNotification(Notification notification) : base(notification) { }

    public override void SendNotification(string message)
    {
        string htmlMessage = $"<html><body><p>{message}</p></body></html>";
        _notification.Send(htmlMessage);
    }
}



