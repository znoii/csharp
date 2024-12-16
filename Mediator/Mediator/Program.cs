class Program
{
    static void Main()
    {
        var mediator = new ChatMediator();
        var colleague1 = new User(mediator, "Alice");
        var colleague2 = new User(mediator, "Rina");

        mediator.AddUser(colleague1);
        mediator.AddUser(colleague2);

        colleague1.Send("Rina", "Hello Rina! How are you?");
        colleague2.Send("Alice", "Hi Alice! I'm good, thanks for asking!");

        colleague1.ReceiveMessage("Rina", "I'm doing great!");
        colleague2.ReceiveMessage("Alice", "Good to hear, Alice!");
    }
}

abstract class Mediator
{
    public abstract void SendMessage(string senderName, string receiverName, string message);
    public abstract void AddUser(Colleague colleague);
}

class ChatMediator : Mediator
{
    private List<Colleague> colleagues = new List<Colleague>();

    public override void SendMessage(string senderName, string receiverName, string message)
    {
        var receiver = colleagues.Find(c => c.Name == receiverName);
        if (receiver != null)
        {
            receiver.Notify($"{senderName} says: {message}");
        }
    }

    public override void AddUser(Colleague colleague)
    {
        colleagues.Add(colleague);
    }
}

abstract class Colleague
{
    protected Mediator mediator;
    public string Name { get; set; }

    public Colleague(Mediator mediator, string name)
    {
        this.mediator = mediator;
        this.Name = name;
    }

    public abstract void Send(string receiverName, string message);
    public abstract void Notify(string message);

    public void ReceiveMessage(string senderName, string message)
    {
        Console.WriteLine($"{Name} received message from {senderName}: {message}");
    }
}

class User : Colleague
{
    public User(Mediator mediator, string name) : base(mediator, name) { }

    public override void Send(string receiverName, string message)
    {
        Console.WriteLine($"{Name} sends message to {receiverName}: {message}");
        mediator.SendMessage(Name, receiverName, message);
    }

    public override void Notify(string message)
    {
        Console.WriteLine($"{Name} received message: {message}");
    }
}
