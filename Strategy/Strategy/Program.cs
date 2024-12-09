using System;

abstract class IWeapon
{
    public abstract void UseWeapon(); 
}
class Sword : IWeapon
{
    public override void UseWeapon()
    {
        Console.WriteLine("ты взмахнул меч");
    }

}
class Bow : IWeapon
{
    public override void UseWeapon()
    {
        Console.WriteLine("ты стрельнул из лука");
    }
}
class Axe : IWeapon
{
    public override void UseWeapon()
    {
        Console.WriteLine("ты взял топор");
    }
}
class Player
{
    private IWeapon _weapon; 

    public Player(IWeapon weapon)
    {
        _weapon = weapon;
    }

    public void SetWeapon(IWeapon weapon)
    {
        _weapon = weapon;
    }

    public void Attack()
    {
        _weapon.UseWeapon(); 
    }
}
class Game
{
    private Player _player;

    public Game(Player player)
    {
        _player = player;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\nChoose weapon: ");
            Console.WriteLine("1. Sword");
            Console.WriteLine("2. Bow");
            Console.WriteLine("3. Axe");
            Console.WriteLine("0. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _player.SetWeapon(new Sword());  
                    break;
                case "2":
                    _player.SetWeapon(new Bow());    
                    break;
                case "3":
                    _player.SetWeapon(new Axe());    
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    continue;
            }

            _player.Attack();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player(new Sword());
        Game game = new Game(player);

        game.Start();
    }
}

