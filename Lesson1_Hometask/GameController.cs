using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson1_Hometask
{
    public class GameController
    {
        private void PlayOneRound(GameStateModel game)
        {
            Console.WriteLine($"Please enter number in [{game.LeftBound},{game.RightBound}]");
           
            int number;

            while(!IsValidNumber(game, number = ReadNumber()))
            {
                Console.WriteLine($"Mistake!!! Please enter number in [{game.LeftBound},{game.RightBound}]");
            }
            game.SpecifiedNumber = number;
            game.History.Add(new GameStateModel
            {
                DesiredNumber = game.DesiredNumber,
                LeftBound = game.LeftBound,
                RightBound = game.RightBound,
                SpecifiedNumber = game.SpecifiedNumber
            });

            if(number > game.DesiredNumber)
            {
                Console.WriteLine("Desired number is less than number you provided");
                game.RightBound = number - 1;
            }

            if (number < game.DesiredNumber)
            {
                Console.WriteLine("Desired number is bigger than number you provided");
                game.LeftBound = number + 1;
            }

            if (!IsGameEnded(game))
            {
                ShowGameHistory(game);
            }
        }

        private void ShowGameHistory(GameStateModel game)
        {
            Console.WriteLine("History");
            foreach (var state in game.History)
                Console.WriteLine($"Left bound:{state.LeftBound}    Right bound:{state.RightBound}    SpecifiedNumber:{state.SpecifiedNumber}");
        }
        
        private bool IsGameEnded(GameStateModel game)
        {
            return game.SpecifiedNumber == game.DesiredNumber;
        }

        public void PlayGame()
        {
            var randomizer = new Random();
            int left = 0;
            int right = 100;
            var unknownNumber = randomizer.Next(0, 100);

            var game = new GameStateModel
            {
                LeftBound = left,
                RightBound = right,
                DesiredNumber = unknownNumber,
                SpecifiedNumber = -1,
                History = new List<GameStateModel>()
            };

            while(!IsGameEnded(game))
            {
                PlayOneRound(game);
            }

            FinishGame(game);
        }

        private void FinishGame(GameStateModel game)
        {
            Console.WriteLine("You won this game");
            ShowGameHistory(game);
        }

        private int ReadNumber()
        {
            int number = -1;
            
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }

            catch(Exception)
            {
                Console.WriteLine("Invalid input. Repeat please");
                ReadNumber();
            }
            
            return number;
        }
        
        public bool IsValidNumber(GameStateModel game, int number)
        {
            return number >= game.LeftBound && number <= game.RightBound;
        }
    }
}
