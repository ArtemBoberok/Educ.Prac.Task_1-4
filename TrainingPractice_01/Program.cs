using System;

namespace TrainingPractice_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Вы пришли в магазин, обменять своё золото на кристалы.\nВведите ваше кол-во золота: ");
            int gold = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"У вас в кошельке {gold} золота!");
            int price = 5;
            Console.WriteLine($"Продавец: Вы можете купить кристалы по цене {price} золота за штуку. Сколько кристалов будете брать у меня?");
            int crystal = Convert.ToInt32(Console.ReadLine());
            if (crystal * price < gold)
            {
                gold -= price * crystal;
                Console.WriteLine($"Продавец: Отличная сделка, спасибо за покупку!\nУ вас {gold} золота и {crystal} кристалов.");
            }
            else
                Console.WriteLine($"Продавец: Извините, но у вас нехватает золота, для покупки крнисталов.\nУ вас {gold} золота.");
        }
    }
}
