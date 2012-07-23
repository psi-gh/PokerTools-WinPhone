namespace PokerTools
{
    using System.Collections.ObjectModel;

    public class CardsCollection : ObservableCollection<ViewModels.CardViewModel>
    {
        public new int Count;

        private string dummyImage;

        public CardsCollection(string dummy, int numberOfCards)
        {
            this.dummyImage = dummy;

            for (int i = 0; i <= numberOfCards -1; i++)
            {
                base.Add(new ViewModels.CardViewModel() { CardName = "emptyCard", CardImage = this.dummyImage });
            }
        }

        public void AddCard(ViewModels.CardViewModel item)
        {
            this.Items[Count].CardImage = item.CardImage;
            this.Items[Count].CardName = item.CardName;

            this.Count += 1;

            //base.RemoveAt(Count - 1);
            //base.Insert(Count - 1, item);
        }

        public bool RemoveCard(ViewModels.CardViewModel item)
        {
            this.Count -= 1;

            //base.RemoveAt(Count + 1);
            //var dummy = new ViewModels.CardViewModel() { CardName = "2", CardImage = dummyImage };

            //base.Insert(Count + 1, dummy);
            var i = this.Items.IndexOf(item);
            this.Items[i].CardImage = dummyImage;
            this.Items[i].CardName = "emptyCard";
            return true;
        }
    }
}
