using GameOfCards.BE;
using GameOfCards.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfCards.BLL
{
    public class CardsOperations : ICardsOperations
    {
        private Stack<Card> cards;
        
        public CardsOperations()
        {
            cards = new Stack<Card>();
            ResetCardsForNewGame();
        }
        /// <summary>
        /// Start/Restart Game
        /// </summary>
        public void ResetCardsForNewGame()
        {
            GetAllCardsForNewGame();
            ShuffleCards();
        }
        /// <summary>
        /// Setup Original Deck of Cards
        /// </summary>
        public void GetAllCardsForNewGame()
        {
            cards = new Stack<Card>();
            for (int i = 0; i < 4; i++)         //Suit values 0-3
            {
                for (int j = 1; j < 14; j++)    //Card values 1-13 
                {
                    cards.Push(new Card(i, j));
                }
            }
        }
        /// <summary>
        /// Shuffle the Deck
        /// </summary>
        public void ShuffleCards()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException("Cards in the Deck are Empty! Please Restart the game");
            }
            Random random = new Random();
            var values = cards.ToArray();
            ClearDeck();
            foreach (var value in values.OrderBy(x => random.Next()))
                cards.Push(value);
        }

        /// <summary>
        /// Play a Card
        /// </summary>
        /// <returns>Card Drawn</returns>        
        public Card RemoveCardDrawn()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException("Cards in the Deck are Empty! Please Restart the game");
            }            
            return cards.Pop(); 
        }
        /// <summary>
        /// Check if Stack is Empty
        /// </summary>
        /// <returns>true of false based on card's count</returns>
        public bool isEmpty()
        {
            return cards.Count() == 0;
        }
        /// <summary>
        /// Number of Cards Remaining in the Deck
        /// </summary>
        /// <returns>Number of Cards</returns>
        public int GetCount()
        {            
            return cards.Count();
        }
        public void ClearDeck()
        {
            cards.Clear();
        }

    }
}
