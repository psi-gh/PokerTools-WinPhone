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
using System.Collections.ObjectModel;

namespace PokerTools
{
    public class CardsCollection : ObservableCollection<ItemViewModel>
    {
        public new int Count = 0;
        private string dummyImage;
        public CardsCollection(string dummy, int numberOfCards)
        {
            this.dummyImage = dummy;

            for (int i = 0; i <= numberOfCards -1; i++)
            {
                base.Add(new ItemViewModel() { CardName = "test", Image = this.dummyImage });
            }
        }

        public void AddCard(ItemViewModel item)
        {
            this.Count += 1;
            base.RemoveAt(Count - 1);
            base.Insert(Count - 1, item);
        }

        public bool RemoveCard(ItemViewModel item)
        {
            this.Count -= 1;

            base.RemoveAt(Count + 1);
            var dummy = new ItemViewModel() { CardName = "2", Image = dummyImage };
            base.Insert(Count + 1, dummy);
            return true;
        }
    }
}
