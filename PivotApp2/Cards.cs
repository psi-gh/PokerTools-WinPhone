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
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace PokerTools
{
    public class Cards
    {
        public Card[] AllCards;
        public string temp;

        private IEnumerable<Enum> GetValues(Enum enumeration)
        {
            List<Enum> enumerations = new List<Enum>();
            foreach (FieldInfo fieldInfo in enumeration.GetType().GetFields(
                  BindingFlags.Static | BindingFlags.Public))
            {
                enumerations.Add((Enum)fieldInfo.GetValue(enumeration));
            }
            return enumerations;
        }

        public Cards()
        {
            AllCards = new Card[8];
            var i = 0;
            foreach (Suits suit in GetValues(new Suits()))
            {
                foreach (Ranks rank in GetValues(new Ranks()))
                {
                    AllCards[i++] = new Card(suit, rank);
                }
            }
        }
    }
}
