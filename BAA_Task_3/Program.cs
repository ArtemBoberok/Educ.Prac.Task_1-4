using System;

namespace BAA_Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int hpDragon = 1000;
            int hpMage = 800;
            int hpMage1;
            int dmDragon;
            int dmMage = 0;
            int dmMage1;
            int spell;
            bool a = true;
            bool b = true;
            bool dmMage30 = false;

            Console.WriteLine($"Игра - победи Дракона\n\nУсловия:\nМаксимальный уровень жизни у Дракона - {hpDragon}\nМаксимальный уровень жизни у Мага - {hpMage}");
            Console.WriteLine("\nВаши заклинания:\n[1] Удар посохом - может нанести от 40 до 80.\n" +
                "[2] Усиление - теряется 100 здоровья, взамен усиливая все ваши атаки на 30 урона.\n" +
                "[3] Больное лечение - теряется 40 здоровья, чтобы восстановить от 10 до 100 здоровья\n" +
                "[4] Магический щит - вы не получаете урона в следующий ход.\n" +
                "[5] Взрыв стихии - вы теряете случайное кол-во здоровья и наносите х2 урона по дракону (можно использовать 1 раз).");
            Console.WriteLine("\nДракон нападает из засады!");
            for (int i = 1; ;i++)
            {
                Console.WriteLine($"\nХод {i}\n");
                if (hpDragon > 0)
                {
                    if (b == true)
                    {
                        dmDragon = rnd.Next(10, 100);
                        Console.WriteLine($"Дракон атакует!\nСила удара - {dmDragon}");
                        hpMage -= dmDragon;
                    }
                    else
                    {
                        Console.WriteLine("Из-за магического щита Дракон не наносит урона!");
                        b = true;
                    }
                }
                else if (hpDragon < 0 && hpMage < 0)
                {
                    Console.WriteLine("\nВсе умерли...");
                    break;
                }
                else
                {
                    Console.WriteLine("\nДракон умер!");
                    break;
                }
                

                if (hpMage > 0)
                {
                    Console.Write("\nВыберите заклинание: ");
                    spell = Convert.ToInt32(Console.ReadLine());
                    switch (spell)
                    {
                        case 1: 
                            dmMage = rnd.Next(40, 80);
                            if (dmMage30 == true)
                            {
                                dmMage += 30;
                            }
                            Console.WriteLine($"Вы атакуете!\nСила удара - {dmMage}");
                            hpDragon -= dmMage;
                            break;

                        case 2:
                            hpMage -= 100;
                            dmMage30 = true;
                            Console.WriteLine("Вы использовали усиление!");
                            hpDragon -= dmMage;
                            break;

                        case 3:
                            hpMage -= 40;
                            hpMage1 = rnd.Next(10, 100);
                            Console.WriteLine($"Вы теряете 40 здоровья и восстанавливаете себе {hpMage1} здоровья!");
                            hpMage += hpMage1;
                            break;

                        case 4:
                            b = false;
                            Console.WriteLine("Вы использовали магический щит!");
                            break;

                        case 5:
                            if (a == true)
                            {
                                dmMage1 = rnd.Next(0, 800);
                                dmMage = (dmMage1) * 2;
                                Console.WriteLine($"Вы атакуете!\nСила удара - {dmMage}");
                                hpDragon -= dmMage;
                                hpMage -= dmMage1;
                                a = false;
                            }
                            else
                            {
                                Console.WriteLine("Вы уже использовали это заклинание!");
                            }
                            break;

                        default:
                            Console.WriteLine("Такого заклинания нет!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nВы умерли...");
                    break;
                }
                Console.WriteLine($"\nУровень здоровья у Дракона - {hpDragon}\nУровень здоровья у Мага - {hpMage}");
            }
        }
    }
}
