using System;
using System.ComponentModel;
using System.Diagnostics;
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
    public class ItemViewModel : INotifyPropertyChanged
    {

        //public ItemViewModel(string im)
        //{
        //    this.Image = im;
        //    this.CardName = System.IO.Path.GetFileName(im);
        //}

        private string _cardName;
        /// <summary>
        /// Пример свойства ViewModel; это свойство используется в представлении для отображения его значения с помощью привязки.
        /// </summary>
        /// <returns></returns>
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

        private string _image;
        /// <summary>
        /// Пример свойства ViewModel; это свойство используется в представлении для отображения его значения с помощью привязки.
        /// </summary>
        /// <returns></returns>
        public string Image
        {
            get
            {
                return _image;
            }
            set
            {
                if (value != _image)
                {
                    _image = value;
                    NotifyPropertyChanged("Image");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}