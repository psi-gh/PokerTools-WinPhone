namespace PokerTools.ViewModels
{
    using System.ComponentModel;

    public class CardViewModel: INotifyPropertyChanged
    {
        private string _cardName;
        private string _cardImage;
        private Suits _suit;
        private Ranks _rank;

        public event PropertyChangedEventHandler PropertyChanged;

        public string CardName
        {
            get
            {
                return _cardName;
            }
            set
            {
                if (value != _cardName)
                {
                    _cardName = value;
                    NotifyPropertyChanged("CardName");
                }
            }
        }

        public Suits Suit
        {
            get
            {
                return _suit;
            }
            set
            {
                if (value != _suit)
                {
                    _suit = value;
                    NotifyPropertyChanged("Suit");
                }
            }
        }

        //public string Rank
        //{
        //    get
        //    {
        //        return _rank;
        //    }
        //    set
        //    {
        //        if (value != _rank)
        //        {
        //            _rank = value;
        //            NotifyPropertyChanged("Rank");
        //        }
        //    }
        //}

        public string CardImage
        {
            get
            {
                return _cardImage;
            }
            set
            {
                if (value != _cardImage)
                {
                    _cardImage = value;
                    NotifyPropertyChanged("CardImage");
                }
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
