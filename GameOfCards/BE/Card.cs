using static GameOfCards.Constants.CardConstants;

namespace GameOfCards.BE
{
    public class Card
    {
        private readonly CardSuit suit;
        private readonly CardValue value;
        public Card(int iSuit, int iValue)
        {
            suit = (CardSuit)(iSuit);
            value = (CardValue)(iValue);
        }
        public CardSuit CardSuit
        {
            get { return suit; }
        }

        public CardValue CardValue
        {
            get { return value; }
        }
    }
}
