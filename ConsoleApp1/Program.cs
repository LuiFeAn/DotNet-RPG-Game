using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

abstract class Humanoid
{
    protected int age;

    protected string name;

    protected float power = 2f;

    public int Age
    {
        get { return age; }
        
        set { 
            
            if( age < 12)
            {
                ShowAgeExepction();
            }

            age = value;
        
        }

    }

    public string Name
    {

        get { return name; }

        set { name = value; }

    }

    public abstract void Walk();

    public void details()
    {
        Console.WriteLine($"My name is {name} and i'm {age} age");
    }

    public virtual void attack()
    {

    }

    protected void ShowAgeExepction()
    {
        throw new Exception("O humano não pode ser uma criança");
    }
}

class Human : Humanoid
{

    public Human(string name,int age)
    {
        base.name = name;

        if( age < 12)
        {

            base.ShowAgeExepction();

        }

        base.age = age;
    }

    public override void Walk()
    {

        Console.WriteLine("Human is walking now");
    }


}

class Enemy
{

    private string name;

    private float power;

    public Enemy(string enemyName)
    {
        name = enemyName;

        Random random = new Random();

        float randomPower = random.Next(1, 5);

        power = randomPower;
    }

    public string Name
    {
        get { return name; }
    }

    public float Power
    {

        get { return power; }

    }

}

class EnemyGenerator
{

    public bool generate()
    {

        Random random = new Random();

        int randomNumber = random.Next(1, 100);

        if (randomNumber >= 1 && randomNumber <= 30)
        {

            Enemy enemy = new Enemy("Pato");

            Console.WriteLine($"Você entrou em batalha !\nNome: { enemy.Name}\nPoder: {enemy.Power}");

            return true;

        }

        return false;

    }

}

class Game
{

    bool inBattle = false;

    public void start()
    {

        Console.WriteLine("Por favor, informe o nome do seu Player:");

        string playerName = Console.ReadLine();

        Console.WriteLine("Por favor, informe a idade do seu Player:");

        int playerAge = int.Parse(Console.ReadLine());

        Human player = new Human(playerName, playerAge);

        EnemyGenerator enemyGenerator = new EnemyGenerator();

        while (true)
        {

            if (Console.KeyAvailable)
            {

                var foundEnemy = enemyGenerator.generate();

                if( foundEnemy)
                {

                    inBattle = true;

                }

                var key = Console.ReadKey(true);

                if( !inBattle)
                {

                    switch (key.Key)
                    {

                        case ConsoleKey.UpArrow:

                            Console.WriteLine($"{player.Name} moveu-se para cima");

                            break;

                        case ConsoleKey.DownArrow:

                            Console.WriteLine($"{player.Name} moveu-se para baixo");

                            break;

                        case ConsoleKey.RightArrow:

                            Console.WriteLine($"{player.Name} moveu-se para direita");

                            break;

                        case ConsoleKey.LeftArrow:

                            Console.WriteLine($"{player.Name} moveu-se para esquerda");

                            break;

                        case ConsoleKey.A:

                            Console.WriteLine($"{player.Name} atacou");

                            break;

                    }


                }

                if( inBattle)
                {

                    switch (key.Key)
                    {

                        case ConsoleKey.A:

                            Console.WriteLine($"{player.Name} efetuou um ataque fraco");

                            break;

                        case ConsoleKey.D:

                            Console.WriteLine($"{player.Name} efetuou um ataque forte");

                            break;

                    }

                }


            }

        }

    }

}

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game();

            game.start();

        }

    }
}
