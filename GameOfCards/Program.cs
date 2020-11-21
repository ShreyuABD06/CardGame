using GameOfCards.BLL;
using GameOfCards.Interfaces;
using System;

namespace GameOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                INewGame newGame = new NewGame();
                newGame.SetupNewGame();
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
    }
}
