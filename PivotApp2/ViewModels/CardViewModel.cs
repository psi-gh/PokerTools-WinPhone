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
using System.ComponentModel;

namespace PokerTools.ViewModels
{
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

        public CardViewModel()
        {
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
