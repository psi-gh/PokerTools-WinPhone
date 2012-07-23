namespace PokerTools.ViewModels
{
    using System.ComponentModel;

    public class CardViewModel: INotifyPropertyChanged
    {
        private string _cardName;
        private string _cardImage;
        private string _suit;
        private string _rank;

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
