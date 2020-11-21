using GameOfCards.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfCards.Interfaces
{
    public interface ICardsOperations
    {
        void ResetCardsForNewGame();
        void GetAllCardsForNewGame();
        void ShuffleCards();
        Card RemoveCardDrawn();
        bool isEmpty();
        int GetCount();
        void ClearDeck();
    }
}
