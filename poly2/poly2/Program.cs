using System;
using System.Collections.Generic;

public abstract class Product
{
    public string Name { get; set; }
    public virtual double Price { get; set; }

    public abstract string GetInformation();
}

public class Toy : Product
{
    public string Material { get; set; }

    public override double Price
    { 
        get {return base.Price * 0.8; }
    }
    public override string GetInformation()
    {
        return $"{Name},{Material},{Price}";
    }
}

public class Meat : Product
{
    public string Type { get; set; }
    public decimal Weight { get; set; }

    public override double Price
    {
        get { return base.Price * 0.85; }
    }

    public override string GetInformation()
    {
        return $"{Name},{Type},{Weight},{Price}";
    }
}

public class Drinks : Product
{
    public string Size { get; set; }

    public override double Price
    {
        get { return base.Price * 0.9; }
    }
    public override string GetInformation()
    {
        return $"{Name},{Size},{Price}";
    }
}

public class Tea : Product
{
    public string FromWhere { get; set; }

    public override double Price
    {
        get { return base.Price * 0.95; }
    }
    public override string GetInformation()
    {
        return $"{Name},{FromWhere},{Price}";
    }
}

class Program
{
    static void Main()
    {
        
        var obj1 = new Toy { Name = "Мягкая игрушка", Price = 100, Material = "3-6 лет" };
        var obj2 = new Meat { Name = "Сырое мясо", Price = 500, Type = "Свинина", Weight = 1.5m };
        var obj3 = new Drinks { Name = "Кола", Price = 200, Size = "1.5 л" };
        var obj4 = new Tea { Name = "lipton", Price = 300, FromWhere = "Индия"};


        Console.WriteLine(obj1.GetInformation()); // порядок вывода : имя харакеристики цена
        Console.WriteLine(obj2.GetInformation());
        Console.WriteLine(obj3.GetInformation());
        Console.WriteLine(obj4.GetInformation());
    }
}