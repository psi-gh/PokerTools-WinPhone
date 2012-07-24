using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections;
using PokerTools.ViewModels;

namespace PokerTools
{
    public partial class MainPage : PhoneApplicationPage
    {
        private bool isCardBoardOpened;

        private bool moveTo; // 0 playerCards, 1 cardBoard

        // Конструктор
        public MainPage()
        {
            InitializeComponent();
            this.isCardBoardOpened = false;
            // Задайте для контекста данных элемента управления listbox пример данных
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
            //rotateList.Completed += new EventHandler(rotateList_Completed);

            var cards = new Cards();

            //Uri uri = new Uri("/PivotApp2;component/Images/2kresti.png", UriKind.Relative); // Resource 
            //BitmapImage imgSource = new BitmapImage(uri);
            var bi = new BitmapImage();
            bi.SetSource(Application.GetResourceStream(new Uri(@"/PivotApp2;component/Images/Cards/2kresti.png", UriKind.Relative)).Stream);
            var im = new Image {Source = bi, Height = 100, Width = 80};
            this.moveTo = false;

        }

        // Загрузка данных для элементов ViewModel
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void my_image1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!this.isCardBoardOpened)
            {
                this.isCardBoardOpened = true;
                this.movePanels(-20, 328, 328, 0.3);
            }
            else
            {
                this.isCardBoardOpened = false;
                this.movePanels(0, 0, 0, 0.5);
            }
        }

        private void movePanels(int up, int middle, int bottom, double time)
        {
            var duration = new Duration(TimeSpan.FromSeconds(time));

            var storyboard = new Storyboard();

            var doubleAnimation1 = new DoubleAnimation();
            doubleAnimation1.Duration = duration;
            doubleAnimation1.To = up;
            Storyboard.SetTarget(doubleAnimation1, this.playersCardsGrid);
            Storyboard.SetTargetProperty(doubleAnimation1, new PropertyPath("(Canvas.Top)"));
            storyboard.Children.Add(doubleAnimation1);

            var doubleAnimation2 = new DoubleAnimation();
            doubleAnimation2.Duration = duration;
            doubleAnimation2.To = middle;
            Storyboard.SetTarget(doubleAnimation2, this.tableCardsGrid);
            Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath("(Canvas.Top)"));
            storyboard.Children.Add(doubleAnimation2);

            var doubleAnimation3 = new DoubleAnimation();
            doubleAnimation3.Duration = duration;
            doubleAnimation3.To = bottom;
            Storyboard.SetTarget(doubleAnimation3, this.bottomGrid);
            Storyboard.SetTargetProperty(doubleAnimation3, new PropertyPath("(Canvas.Top)"));
            storyboard.Children.Add(doubleAnimation3);

            storyboard.Begin();
        }

        private void moveCard(Image card, bool moveto, double time)
        {
            Grid gridToMove;
            CardsCollection cardsCollecton;

            if (moveto == false)
            {
                gridToMove = this.playersCardsGrid;
                cardsCollecton = App.ViewModel.playerCards;
            }
            else
            {
                gridToMove = this.tableCardsGrid;
                cardsCollecton = App.ViewModel.tableCards;
            }

            var cardObject = (ViewModels.CardViewModel)card.DataContext;

            if (cardObject.CardName == "emptyCard")
                return;

            if ((!moveto && (cardsCollecton.Count > 1) ) || (moveto && (cardsCollecton.Count > 4)))
                return;

            // карта, которая двигается
            var movingCard = new Image {Source = card.Source, Height = card.Height, Width = card.Width};
            Canvas.SetZIndex(movingCard, 1);

            var transform = canvasFirstPivotItem.TransformToVisual(Application.Current.RootVisual);
            // Положение главного канваса
            var coordsOfMainCanvas = transform.Transform(new Point(0, 0));

            //Вычисляем абсолютное положение грида
            transform = gridToMove.TransformToVisual(Application.Current.RootVisual);

            // Положение конечной карты, куда мы перемещаемся
            var destinationLocation = transform.Transform(new Point(0, 0));
            destinationLocation.X += 25;
            destinationLocation.Y += 45;
            destinationLocation.X += card.Width * (cardsCollecton.Count);

            transform = card.TransformToVisual(Application.Current.RootVisual);
            // Положение карты, на которую нажали
            var sourceLocation = transform.Transform(new Point(0, 0));

            // Смещение карты, на которую мы нажали, относительно главного канваса
            var offsetX = sourceLocation.X - coordsOfMainCanvas.X;
            var offsetY = sourceLocation.Y - coordsOfMainCanvas.Y;

            // Нашли координаты, куда поставить карту для анимации
            Canvas.SetLeft(movingCard, offsetX);
            Canvas.SetTop(movingCard, offsetY);
            // Создаем карту, которая появляется на месте выбранной карты поверх всех элементов
            this.canvasFirstPivotItem.Children.Add(movingCard);

            var cardForAdd = new CardViewModel() { CardImage = cardObject.CardImage, CardName = cardObject.CardName };

            App.ViewModel.TestMyCol.RemoveCard((CardViewModel)card.DataContext);

            // Смещение от выбранной карты до конечного положения (на какое расстояние двигать)
            offsetX = destinationLocation.X - sourceLocation.X;
            offsetY = destinationLocation.Y - sourceLocation.Y;

            var duration = new Duration(TimeSpan.FromSeconds(time));
            var storyboard = new Storyboard();

            var animationMoveX = new DoubleAnimation {Duration = duration, By = offsetX};
            Storyboard.SetTarget(animationMoveX, (Image)movingCard);
            Storyboard.SetTargetProperty(animationMoveX, new PropertyPath("(Canvas.Left)"));
            storyboard.Children.Add(animationMoveX);

            var animationMoveY = new DoubleAnimation {Duration = duration, By = offsetY};
            Storyboard.SetTarget(animationMoveY, (Image)movingCard);
            Storyboard.SetTargetProperty(animationMoveY, new PropertyPath("(Canvas.Top)"));
            storyboard.Children.Add(animationMoveY);

            storyboard.Begin();
            storyboard.Completed += (sender, args) =>
            {
                cardsCollecton.AddCard(cardForAdd);
                this.canvasFirstPivotItem.Children.Remove(movingCard);
            };
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!this.isCardBoardOpened)
            {
                this.moveTo = false;
                this.isCardBoardOpened = true;
                this.movePanels(-20, 328, 328, 0.3);
            }
            else
            {
                this.isCardBoardOpened = false;
                this.movePanels(0, 0, 0, 0.3);
            }
        }

        private void Image_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.moveCard((Image)sender, moveTo, 0.3);
            //App.ViewModel.allSpades.RemoveAt(1);
            //var itemForDelete = App.ViewModel.allSpades.Where( (ItemViewModel a) => 
            //    a.Image == ((Image)sender).Source[0].ToString() );
            //App.ViewModel.allSpades.Remove(itemForDelete.First());
        }
        //System.Windows.MessageBox.Show("qwe");

        private void Image_Tap2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.moveTo = true;
            if (!this.isCardBoardOpened)
            {
                this.isCardBoardOpened = true;
                this.movePanels(-400, -182, 166, 0.3);
            }
            else
            {
                this.isCardBoardOpened = false;
                this.movePanels(0, 0, 0, 0.3);
            }
        }
    }
}