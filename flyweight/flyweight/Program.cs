using System;
using System.Collections.Generic;

abstract class Character
{
    public string Name { get; }
    public string Type { get; }
    public string Image { get; }

    protected Character(string name, string type, string image)
    {
        Name = name;
        Type = type;
        Image = image;
    }

    public abstract void Display();
}

class CharacterFactory
{
    private readonly Dictionary<string, Character> characters = new Dictionary<string, Character>();

    public Character GetCharacter(string name, string type, string image)
    {
        string key = name + "-" + type;

        if (!characters.ContainsKey(key))
        {
            Character character = new ConcreteCharacter(name, type, image);
            characters[key] = character;
        }

        return characters[key];
    }
}

class ConcreteCharacter : Character
{
    public ConcreteCharacter(string name, string type, string image)
        : base(name, type, image) { }

    public override void Display()
    {
        Console.WriteLine($"Character: {Name}, Type: {Type}, Image: {Image}");
    }
}

class CustomizableCharacter : Character
{
    public int Level { get; set; }
    public int Experience { get; set; }

    public CustomizableCharacter(string name, string type, string image)
        : base(name, type, image) { }

    public override void Display()
    {
        Console.WriteLine($"Character: {Name}, Type: {Type}, Image: {Image}, Level: {Level}, Experience: {Experience}");
    }
}

class Program
{
    static void Main()
    {
        CharacterFactory factory = new CharacterFactory();

        Character character1 = factory.GetCharacter("deadpool", "hero", "Image1");
        character1.Display();

        Character character2 = factory.GetCharacter("thanos", "Villain", "Image1");
        character2.Display(); 

        Character character3 = factory.GetCharacter("Dr. Evil", "Villain", "Image2");
        character3.Display();

        CustomizableCharacter customizableCharacter = new CustomizableCharacter("deadpool", "hero", "Image1");
        customizableCharacter.Level = 5;
        customizableCharacter.Experience = 200;
        customizableCharacter.Display();
    }
}
