using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gridapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicTacToe : ContentPage
    {
        public TicTacToe()
        {
            int player = 1;
            Label lblk, lblp;
            BoxView box;
            Grid grid = new Grid();

            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(110, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });

            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    box = new BoxView { Color = Color.FromRgb(200, 100, 50) };
                    grid.Children.Add(box, i, j);
                    var tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    box.GestureRecognizers.Add(tap);
                }
            }

            AbsoluteLayout absolute = new AbsoluteLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                
            };

            Button newGame = new Button
            {
                BackgroundColor = Color.Gray,
                TextColor = Color.FromRgb(255, 255, 255),
                Text = "Uus mäng"
                
            };
            AbsoluteLayout.SetLayoutBounds(newGame, new Rectangle(0.5, 0.02, 175, 50));
            AbsoluteLayout.SetLayoutFlags(newGame, AbsoluteLayoutFlags.PositionProportional);
            absolute.Children.Add(newGame);

            Button XO = new Button
            {
                BackgroundColor = Color.Gray,
                TextColor = Color.FromRgb(255, 255, 255),
                Text = "X või O",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            AbsoluteLayout.SetLayoutBounds(XO, new Rectangle(0.1, 0.5, 100, 50));
            AbsoluteLayout.SetLayoutFlags(XO, AbsoluteLayoutFlags.PositionProportional);
            absolute.Children.Add(XO);

            StackLayout stack = new StackLayout()
            {
                Children = { grid, absolute}
            };

            Content = stack;
        }



        private void Tap_Tapped(object sender, EventArgs e)
        {

            BoxView box = sender as BoxView;
            if (box.Color == Color.FromRgb(255, 255, 255)) 
            {

               switch (player) 
                {
                    case 1:
                        box.Color = Color.FromRgb(255, 0, 0); 
                        player = 0;
                        lblp.Text = "Ходит синий";
                        break;
                    case 0:
                        box.Color = Color.FromRgb(0, 0, 255);
                        player = 1;
                        lblp.Text = "Ходит красный";
                        break;
                }

            }
            else //если ячейка не белая, значит она уже занята 
            {
                DisplayAlert ("Занята", "Здесь нельза поставить", "ок");
            }
        }
    }
}
