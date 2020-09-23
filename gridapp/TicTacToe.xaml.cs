using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gridapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicTacToe : ContentPage
    {
        public TicTacToe()
        {
            BoxView box;
            Grid grid = new Grid();

            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(90, GridUnitType.Star) });
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
            StackLayout stack = new StackLayout()
            {
                Children = { grid }
            };

            Content = stack;
        }
        private void Tap_Tapped(object sender, EventArgs e)
        {

            BoxView box = sender as BoxView;
            //box.Color = Color.Aqua;

            if (box.Color == Color.AliceBlue)
            {
                box.Color = Color.YellowGreen;
            }
            else if (box.Color == Color.FromRgb(200, 100, 50))
            {
                box.Color = Color.AliceBlue;
            }
            else if (box.Color == Color.YellowGreen)
            {
                box.Color = Color.FromRgb(200, 100, 50);
            }
        }

        private void btn_Clicked(object sender, EventArgs e)
        {

        }

        private void btn0_Clicked(object sender, EventArgs e)
        {

        }
    }
}