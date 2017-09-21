using System;
using Bowling;

namespace Bolwing.Game
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayGame();
        }

        private static void PlayGame()
        {
            Console.WriteLine("What's your name? ");
            var playerName = Console.ReadLine();

            Console.WriteLine("Now enter your scoresheet here: ");
            var scoreSheet = Console.ReadLine();

            var player1 = new Player(playerName, scoreSheet);

            Console.WriteLine($"You scored {player1.Score()}, {player1.Name}. {GetPlatitude(player1.Score())}");
            Console.Read();
        }

        private static string GetPlatitude(int score)
        {
            if (score < 30) return "Have you considered playing badminton?";
            if (score < 50) return "Never mind, at least you had fun";
            if (score < 120) return "Good effort, keep practicing!";
            if (score < 220) return "Look at you, Billy big balls!";
            return "Wowza! A real KingPin!";
        }
    }
}