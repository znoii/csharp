using System;

public interface INotifier
{
    void Send(string message);
}

public class Notifier : INotifier
{
    private readonly string emailAddress;

    public Notifier(string emailAddress)
    {
        this.emailAddress = emailAddress;
    }

    public virtual void Send(string message)
    {
        Console.WriteLine($"По почте {emailAddress}: {message}");           //для всех адм
    }
}

public abstract class NotifierDecorator : INotifier
{
    protected readonly INotifier notifier;

    public NotifierDecorator(INotifier notifier)
    {
        this.notifier = notifier;
    }

    public virtual void Send(string message)
    {
        notifier.Send(message);
    }
}

public class SMSNotifier : NotifierDecorator
{
    private readonly string phoneNumber;

    public SMSNotifier(INotifier notifier, string phoneNumber) : base(notifier)
    {
        this.phoneNumber = phoneNumber;
    }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"через SMS: {phoneNumber}: {message}");
    }
}

public class FacebookNotifier : NotifierDecorator
{
    private readonly string facebookAccount;

    public FacebookNotifier(INotifier notifier, string facebookAccount) : base(notifier)
    {
        this.facebookAccount = facebookAccount;
    }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"через Facebook: {facebookAccount}: {message}");
    }
}

