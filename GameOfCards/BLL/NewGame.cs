using GameOfCards.BE;
using GameOfCards.Interfaces;
using System;
using static GameOfCards.Constants.GameConstants;

namespace GameOfCards.BLL
{
    public class NewGame : INewGame
    {        
        /// <summary>
        /// Setup New Game and Start Playing
        /// </summary>
        public void SetupNewGame()
        {
            //Include Setting Up User Details when Necessary 
            StartGame();
        }
        /// <summary>
        /// Sets up Card Deck and User can start playing the game
        /// </summary>
        private static void StartGame()
        {
            Boolean quitGame = false;
            Console.WriteLine("*******WELCOME TO THE GAME OF CARDS*********");
            ICardsOperations cardsOperations = new CardsOperations();
            while (!quitGame)
            {
                try
                {
                    DisplayOptions();                    
                    Console.WriteLine($"Cards remaining in Hand - {cardsOperations.GetCount()}");
                    int chosenOption = int.Parse(Console.ReadLine());
                    switch (chosenOption)
                    {
                        case (int)Options.PLAY:
                            Card drawnCard = cardsOperations.RemoveCardDrawn();
                            Console.WriteLine("{0} of {1}", drawnCard.CardValue, drawnCard.CardSuit);
                            break;
                        case (int)Options.SHUFFLE_CARDS:
                            cardsOperations.ShuffleCards();
                            break;
                        case (int)Options.RESTART_GAME:
                            cardsOperations.ResetCardsForNewGame();
                            break;
                        case (int)Options.END_GAME:
                            cardsOperations.ClearDeck();
                            quitGame = true;
                            break;
                        default:
                            Console.WriteLine("Please Select a Valid Option");
                            break;
                    }
                }
                catch (FormatException invalidNumberFormat)
                {
                    Console.WriteLine("Please Enter Valid Option");
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                
            }
            Console.WriteLine("End Game");
            Console.WriteLine(" ###----- Thank You For Playing ! -----### ");
        }
        /// <summary>
        /// Displays All Available Game Options
        /// </summary>
        private static void DisplayOptions()
        {
            foreach (Options option in Enum.GetValues(typeof(Options)))
            {
                Console.WriteLine($"*********** {(int)option}:  {option} ***********");
            }
            Console.WriteLine("---------- Select any option -----------");
        }
    }
}
