using System;
using System.Collections.Generic;
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

namespace PokerTools
{
    public partial class MainPage : PhoneApplicationPage
    {
        bool isCardBoardOpened;

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

            var im = new Image();
            //Uri uri = new Uri("/PivotApp2;component/Images/2kresti.png", UriKind.Relative); // Resource 
            //BitmapImage imgSource = new BitmapImage(uri);
            BitmapImage bi = new BitmapImage();
            bi.SetSource(Application.GetResourceStream(new Uri(@"/PivotApp2;component/Images/Cards/2kresti.png", UriKind.Relative)).Stream);
            im.Source = bi;
            im.Height = 100;
            im.Width = 80;
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
            Duration duration = new Duration(TimeSpan.FromSeconds(time));

            Storyboard storyboard = new Storyboard();

            DoubleAnimation doubleAnimation1 = new DoubleAnimation();
            doubleAnimation1.Duration = duration;
            doubleAnimation1.To = up;
            Storyboard.SetTarget(doubleAnimation1, this.playersCardsGrid);
            Storyboard.SetTargetProperty(doubleAnimation1, new PropertyPath("(Canvas.Top)"));
            storyboard.Children.Add(doubleAnimation1);

            DoubleAnimation doubleAnimation2 = new DoubleAnimation();
            doubleAnimation2.Duration = duration;
            doubleAnimation2.To = middle;
            Storyboard.SetTarget(doubleAnimation2, this.tableCardsGrid);
            Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath("(Canvas.Top)"));
            storyboard.Children.Add(doubleAnimation2);

            DoubleAnimation doubleAnimation3 = new DoubleAnimation();
            doubleAnimation3.Duration = duration;
            doubleAnimation3.To = bottom;
            Storyboard.SetTarget(doubleAnimation3, this.bottomGrid);
            Storyboard.SetTargetProperty(doubleAnimation3, new PropertyPath("(Canvas.Top)"));
            storyboard.Children.Add(doubleAnimation3);

            storyboard.Begin();
        }

        //private void moveCard2(Image card,

        // Что мне сейчас надо сделать?
        // По щелчку на карте карта перемещается на экране, а в программе в массивах перемещаются элементы
        // 1. метод move_card который вызывается по нажатию на кнопку
        // параметры: Image карта, <Panel?> куда двигать карту
        //удаляет карту из картборда (она исчезает с экрана)
        //рисует на ее месте эту же карту и двигает к месту
        //добавляет к нужному массиву удаленную карту (она появляется на экране под нарисованной картой
        //которая закончила передвижение
        //уничтожение картинки с картой, котоаря двигалась

        private void moveCard(Image card, Grid cardGrid, double time)
        {
            var offset = (ItemsControl) this.playersCardsGrid.Children[1];
            var okay = offset.ItemsPanel;

            
            //Image cardPlace = (Image)offset.Children[0];
            var cardPlace = offset;

            var cardObject = (ItemViewModel)card.DataContext;

            // карта, которая двигается
            var movingCard = new Image();
            movingCard.Source = card.Source;
            movingCard.Height = card.Height;
            movingCard.Width = card.Width;
            Canvas.SetZIndex(movingCard, 1);

            var transform = canvasFirstPivotItem.TransformToVisual(Application.Current.RootVisual);
            // Положение главного канваса
            var coordsOfMainCanvas = transform.Transform(new Point(0, 0));

            transform = cardPlace.TransformToVisual(Application.Current.RootVisual);
            // Положение конечной карты, куда мы перемещаемся
            var destinationLocation = transform.Transform(new Point(0, 0));
            destinationLocation.X += card.Width;
            

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


            cardObject.Image = "/PivotApp2;component/Images/cardplace_dark@2x.png";


            // Смещение от выбранной карты до конечного положения (на какое расстояние двигать)
            offsetX = destinationLocation.X - sourceLocation.X;
            offsetY = destinationLocation.Y - sourceLocation.Y;

            Duration duration = new Duration(TimeSpan.FromSeconds(time));
            Storyboard storyboard = new Storyboard();

            DoubleAnimation animationMoveX = new DoubleAnimation();
            animationMoveX.Duration = duration;
            animationMoveX.By = offsetX;
            Storyboard.SetTarget(animationMoveX, (Image)movingCard);
            Storyboard.SetTargetProperty(animationMoveX, new PropertyPath("(Canvas.Left)"));
            storyboard.Children.Add(animationMoveX);

            DoubleAnimation animationMoveY = new DoubleAnimation();
            animationMoveY.Duration = duration;
            animationMoveY.By = offsetY;
            Storyboard.SetTarget(animationMoveY, (Image)movingCard);
            Storyboard.SetTargetProperty(animationMoveY, new PropertyPath("(Canvas.Top)"));
            storyboard.Children.Add(animationMoveY);

            storyboard.Begin();
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!this.isCardBoardOpened)
            {
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
            this.moveCard((Image)sender, this.playersCardsGrid, 0.5);
            //App.ViewModel.allSpades.RemoveAt(1);
            //var itemForDelete = App.ViewModel.allSpades.Where( (ItemViewModel a) => 
            //    a.Image == ((Image)sender).Source[0].ToString() );
            //App.ViewModel.allSpades.Remove(itemForDelete.First());
                
        }
        //System.Windows.MessageBox.Show("qwe");
    }



}