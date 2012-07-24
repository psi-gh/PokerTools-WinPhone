namespace PokerTools
{
    using System;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using System.Collections;
    using System.Linq;
    using ViewModels;

    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.items = new ObservableCollection<ItemViewModel>();
            //this.playerCards = new ObservableCollection<ItemViewModel>();
            //this.tableCards = new ObservableCollection<ItemViewModel>();
            this.allSpades = new ObservableCollection<ItemViewModel>();

            this.playerCards = new CardsCollection("/PivotApp2;component/Images/cardplace_h@2x.png", 2);
            this.tableCards = new CardsCollection("/PivotApp2;component/Images/cardplace_h@2x.png", 5);
            this.TestMyCol = new CardsCollection("/PivotApp2;component/Images/cardplace_dark@2x.png", 10);
        }

        /// <summary>
        /// Коллекция объектов ItemViewModel.
        /// </summary>

        public IEnumerable Items { get; private set; }

        public ObservableCollection<ItemViewModel> items { get; set; }
        
        public ObservableCollection<ItemViewModel> allSpades { get; set; }
        
        //public ObservableCollection<ItemViewModel> playerCards { get; set; }
        
        //public ObservableCollection<ItemViewModel> tableCards { get; set; }

        public CardsCollection TestMyCol { get; set; }

        public CardsCollection playerCards { get; set; }

        public CardsCollection tableCards { get; set; }

        private string _sampleProperty = "Пример значения свойства среды выполнения";
        /// <summary>
        /// Пример свойства ViewModel; это свойство используется в представлении для отображения его значения с помощью привязки
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Создает и добавляет несколько объектов ItemViewModel в коллекцию элементов.
        /// </summary>
        public void LoadData()
        {
            // Пример данных; замените реальными данными
            //this.items.Add(new ItemViewModel("/PivotApp2;component/Images/Cards/3piki.png"));
            this.items.Add(new ItemViewModel() { CardName = "31", Image = "/PivotApp2;component/Images/Cards/2chervi.png" });
            this.items.Add(new ItemViewModel() { CardName = "41", Image = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.items.Add(new ItemViewModel() { CardName = "51", Image = "/PivotApp2;component/Images/Cards/2chervi.png" });
            this.items.Add(new ItemViewModel() { CardName = "61", Image = "/PivotApp2;component/Images/Cards/2chervi.png" });

            //this.tableCards.Add(new ItemViewModel() { CardName = "31", CardImage = "/PivotApp2;component/Images/cardplace_h@2x.png" });
            //this.tableCards.Add(new ItemViewModel() { CardName = "31", Image = "/PivotApp2;component/Images/cardplace_h@2x.png" });
            //this.tableCards.Add(new ItemViewModel() { CardName = "31", Image = "/PivotApp2;component/Images/cardplace_h@2x.png" });
            //this.tableCards.Add(new ItemViewModel() { CardName = "31", Image = "/PivotApp2;component/Images/cardplace_h@2x.png" });
            //this.tableCards.Add(new ItemViewModel() { CardName = "31", Image = "/PivotApp2;component/Images/cardplace_h@2x.png" });

            //this.playerCards.Add(new CardViewModel() { CardName = "31", CardImage = "/PivotApp2;component/Images/cardplace_h@2x.png" });
            //this.playerCards.Add(new CardViewModel() { CardName = "31", CardImage = "/PivotApp2;component/Images/cardplace_h@2x.png" });

            this.allSpades.Add(new ItemViewModel() { CardName = "2", Image = "/PivotApp2;component/Images/Cards/2chervi.png" });
            this.allSpades.Add(new ItemViewModel() { CardName = "3", Image = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.allSpades.Add(new ItemViewModel() { CardName = "4", Image = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.allSpades.Add(new ItemViewModel() { CardName = "5", Image = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.allSpades.Add(new ItemViewModel() { CardName = "6", Image = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.allSpades.Add(new ItemViewModel() { CardName = "7", Image = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.allSpades.Add(new ItemViewModel() { CardName = "8", Image = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.allSpades.Add(new ItemViewModel() { CardName = "9", Image = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.allSpades.Add(new ItemViewModel() { CardName = "10", Image = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.allSpades.Add(new ItemViewModel() { CardName = "V", Image = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.allSpades.Add(new ItemViewModel() { CardName = "D", Image = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.allSpades.Add(new ItemViewModel() { CardName = "K", Image = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.allSpades.Add(new ItemViewModel() { CardName = "A", Image = "/PivotApp2;component/Images/Cards/3piki.png" });

            this.TestMyCol.AddCard(new CardViewModel() { CardName = "2", CardImage = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.TestMyCol.AddCard(new CardViewModel() { CardName = "2", CardImage = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.TestMyCol.AddCard(new CardViewModel() { CardName = "2", CardImage = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.TestMyCol.AddCard(new CardViewModel() { CardName = "2", CardImage = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.TestMyCol.AddCard(new CardViewModel() { CardName = "2", CardImage = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.TestMyCol.AddCard(new CardViewModel() { CardName = "2", CardImage = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.TestMyCol.AddCard(new CardViewModel() { CardName = "2", CardImage = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.TestMyCol.AddCard(new CardViewModel() { CardName = "2", CardImage = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.TestMyCol.AddCard(new CardViewModel() { CardName = "2", CardImage = "/PivotApp2;component/Images/Cards/3piki.png" });
            this.TestMyCol.AddCard(new CardViewModel() { CardName = "2", CardImage = "/PivotApp2;component/Images/Cards/3piki.png" });

            //CreateItemsSource(items);
            this.IsDataLoaded = true;
        }

        private void CreateItemsSource(ObservableCollection<ItemViewModel> items)
        {
            this.Items = from item in items
                         group item by item.CardName into n
                         orderby n.Key
                         select new GroupingLayer<string, ItemViewModel>(n);
            NotifyPropertyChanged("Items");
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