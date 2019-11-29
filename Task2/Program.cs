using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.GameTask;
using Task2.GameTask.Bonuses;
using Task2.GameTask.Monsters;
using Task2.GameTask.Obstacles;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Round round = new Round(new Point(1, 2), 4);

            //Console.WriteLine("Area " + round.Area);
            //Console.WriteLine("Curcuit "+ round.Circuit);

            //User user = new User("Eugene", "Alekseevich", "Zheltov", new DateTime(1997, 11, 04));
            //Console.WriteLine(user.Age);

            //Employee emp = new Employee("Eugene", "Alekseevich", "Zheltov", new DateTime(1997, 11, 04), 2, "Developer");
            //Console.WriteLine(emp.Post);

            //var ring = new Ring(new Point(0, 0), 2, 3);
            //Console.WriteLine(ring.SumOfCircuits);

            //var myStr1 = new MyString("abc");
            //var myStr2 = new MyString("abc");
            //var myStr3 = myStr1;
            //Console.WriteLine(myStr1.Equals(myStr3));            

            //var line = GraphicsEditor.CreateLine(new Point(1,1), new Point(2,2));
            //GraphicsEditor.PrintLine(line);

            //Circle round = new Round(new Point(0,0), 4);
            //GraphicsEditor.PrintFigure((Round)round);

            //Circle circle = new Circle(new Point(1, 1), 3);
            //GraphicsEditor.PrintFigure(circle);

            //Circle ring1 = new Ring(new Point(1, 1), 3, 4);
            //GraphicsEditor.PrintFigure((Ring)ring1);

            Ring ring = new Ring(new Point(1, 1), 3, 4);
            //GraphicsEditor.PrintFigure((RoundFigure)ring);

            Round round = new Round(new Point(1, 1), 5);
            //GraphicsEditor.PrintFigure((RoundFigure)round);

            var line = new Line(new Point(1, 1), new Point(2, 2));
            GraphicsEditor.PrintFigure(line);
            //Console.WriteLine(line.Length);

            //GraphicsEditor.PrintFigure(new Rectangle(5, 10));

            //Bonus[] bonuses = new Bonus[] { new Cherry(), new Apple() };
            //Bonus[] loot = new Bonus[] { new Cherry()};
            //Monster[] monsters = new Monster[] { new Wolf(100), new Bear(200) };
            //Obstacle[] obstacles = new Obstacle[] { new Rock(5, 2, "sand"), new Tree(7, 1, "Oak") };
            //Field field = new Field(1000, 1000, bonuses, monsters, obstacles);
            //Character hero = new Character("Eugene", 100, 100, loot);
            //hero.AllLooted = true;

            //Game game = new Game(field, hero);

            //game.Play();

            Console.ReadKey();
        }
    }
}
