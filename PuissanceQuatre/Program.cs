namespace PuissanceQuatre;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4.");
        GetKey:
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.X:
                var morpion = new TikTakToe.TikTakToe();
                morpion.GameLoop();
                break;
            case ConsoleKey.P:
                var puissanceQuatre = new Power4.Power4();
                puissanceQuatre.GameLoop();
                break;
            default:
                goto GetKey;
        }

        Console.WriteLine("Jouer à un autre jeu ? Taper [R] pour changer de jeu. Taper [Echap] pour quitter.");
        GetKey1:
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.R:
                Console.WriteLine("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4.");
                GetKey2:
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.X:
                        var morpion = new TikTakToe.TikTakToe();
                        morpion.GameLoop();
                        break;
                    case ConsoleKey.P:
                        var puissanceQuatre = new Power4.Power4();
                        puissanceQuatre.GameLoop();
                        break;
                    default:
                        goto GetKey2;
                }

                break;
            case ConsoleKey.Escape:
                break;
            default:
                goto GetKey1;
        }
    }
}