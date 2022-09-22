using System.Runtime;
namespace Practice1;

public class Cat
{
    private enum Statuses
    {
        Dead,
        Tired,
        Overweighted,
        Hungry,
        Cracked,
        Healthy
    }
    public enum FurColors
    {
        Red,
        Green,
        Blue,
        Purple,
        Yellow,
        Black,
        Pink
    }

    private static int count = 0;
    private const int MaxWeight = 10;
    private const int MaxStamina = 100;
    private const int MinWeight = 1;
    private const int MinStamina = 1;
    public const int EyeAmount = 2;
    
    
    public Enum Status = Statuses.Healthy;
    readonly float DefaultWeight;
    public float Weight;
    public int Stamina = 10;
    private float AmountEated = 0;

    public FurColors FurColorPrivate{ get; set; }
    
    
    public Cat() {
        DefaultWeight = new Random().Next(3, 6);
        FurColorPrivate = (FurColors)Enum.GetValues(typeof(FurColors)).GetValue(new Random().Next(0, 6));
        Weight = DefaultWeight;
        count += 1;
    }
    public Cat(float wght) {
        DefaultWeight = wght;
        FurColorPrivate = (FurColors)Enum.GetValues(typeof(FurColors)).GetValue(new Random().Next(0, 6));
        Weight = DefaultWeight;
        count += 1;
    }
    public Cat(float wght, FurColors frclr) {
        DefaultWeight = wght;
        FurColorPrivate = frclr;
        Weight = DefaultWeight;
        count += 1;
    }
    
    
    
    public void Feed(float amount)
    {
        var grammamount = amount/1000;
        AmountEated += amount;
        if (Status is not Statuses.Dead & Weight + grammamount <= MaxWeight)
        {
            Weight += grammamount;
            Console.WriteLine($"Скормили кошке {amount} грамм, вес {Weight} кг");
            if (Weight > DefaultWeight)
            {
                Status = Statuses.Overweighted;
                Console.WriteLine("Кошка жиреет");
            }
            else if (Weight < DefaultWeight)
            {
                Status = Statuses.Hungry;
                Console.WriteLine("Кошка голодна");
            }
        }
        else if (Status is Statuses.Dead)
        {
            Weight += grammamount;
            Console.WriteLine("Кот мёртв, но вы засунули еду в отверстие");
        }
        else if (Status is not Statuses.Dead && Weight + grammamount > MaxWeight)
        {
            Console.WriteLine($"Кошка ожирела и у неё случился приступ");
            Weight += grammamount;
            Status = Statuses.Dead;
            count -= 1;
        }
    }

    public void Meow()
    {
        if (Status is not Statuses.Dead)
        {
            Console.WriteLine("Мяу");
            Stamina -= 1;
            if (Weight > DefaultWeight)
            {
                Stamina += (int)(Weight - DefaultWeight);
                Weight = DefaultWeight;
            }

            if (Stamina < MinStamina)
            {
                Status = Statuses.Dead;
                count -= 1;
                Console.WriteLine("Кошка умерла от истощения");
            }
            
        }
        else
        {
            Console.WriteLine("Мёртвая кошка не мяукает");
        }
    }


    public void Pee()
    {
        if (Status is not Statuses.Dead)
        {
            Weight -= (float)(0.5);
            Console.WriteLine("Кошка сходила в туалет");
            if (Weight < MinWeight)
            {
                Status = Statuses.Dead;
                count -= 1;
                Console.WriteLine("Кошка умерла от истощения");
            }
        }
        else
        {
            Console.WriteLine("Мёртвая кошка уже не ходит");
        }
    }

    
    public float AmountEatedReturn() => AmountEated;
    public static int GetCount() => count;

    public static Cat GetKitten() => new ((float)1.1);

    public Cat Clone() => new (DefaultWeight, FurColorPrivate);
}