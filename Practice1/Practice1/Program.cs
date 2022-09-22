using Practice1;

Cat Pussy = new ();
var kitten = Cat.GetKitten();
var kittenclone = kitten.Clone();
int input;

do
{
    Console.WriteLine("1-кормить, 2-мяукать, 3-туалет, 4-сколько съедено, 5-кол-во котов, 6-цвета, 0-выход\n");
    input = Int32.Parse(Console.ReadLine());
    switch (input)
    {
        case 1:
            Console.WriteLine("Сколько грамм корма");
            Pussy.Feed(Int32.Parse(Console.ReadLine()));
            Console.WriteLine($"\nВес: {Pussy.Weight}, Выносливость:{Pussy.Stamina}");
            break;
        case 2:
            Pussy.Meow();
            Console.WriteLine($"\nВес: {Pussy.Weight}, Выносливость:{Pussy.Stamina}");
            break;
        case 3:
            Pussy.Pee();
            Console.WriteLine($"\nВес: {Pussy.Weight}, Выносливость:{Pussy.Stamina}");
            break;
        case 4:
            Console.WriteLine(Pussy.AmountEatedReturn());
            break;
        case 5:
            Console.WriteLine(Cat.GetCount());
            break;
        case 6:
            Console.WriteLine($"{Pussy.FurColorPrivate}, {kitten.FurColorPrivate}, {kittenclone.FurColorPrivate}");
            break;
    }
}
while(input != 0);