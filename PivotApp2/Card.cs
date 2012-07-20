using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PokerTools
{
    public enum Suits { spades, hearts, diamonds, clubs };
    public enum Ranks { two, three }

    public class Card
    {
        public Suits Suit;
        public Ranks Rank;
        public string Image;

        public Card()
        {
        }

        public Card(Suits suit, Ranks rank)
        {
            this.Rank = rank;
            this.Suit = suit;
            this.Image = "/PivotApp2;component/Images/";

            switch (this.Rank)
            {
                case Ranks.two:
                    {
                        this.Image += "2";
                        break;
                    }
                case Ranks.three:
                    {
                        this.Image += "3";
                        break;
                    }
            }

            switch (this.Suit)
            {
                case Suits.clubs:
                    {
                        this.Image += "kresti";
                        break;
                    }
                case Suits.diamonds:
                    {
                        this.Image += "bubny";
                        break;
                    }
                case Suits.hearts:
                    {
                        this.Image += "chervi";
                        break;
                    }
                case Suits.spades:
                    {
                        this.Image += "piki";
                        break;
                    }
            }
            this.Image += ".png";
        }
    }
}
