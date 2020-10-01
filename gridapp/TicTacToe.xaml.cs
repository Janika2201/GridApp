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
        Label whoFirst;
        BoxView box;
        Button newGame, random_player;
        public bool first_player;
        int[,] gamemap = new int[3, 3];
        public TicTacToe()
        {
            First_Player_manual();
            New_game_Clicked();
            wert();
        }
        void New_game_Clicked()
        {

            Grid grid = new Grid();
            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30, GridUnitType.Star) });
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    box = new BoxView { Color = Color.FromRgb(204, 102, 0) };
                    gamemap[i, j] = 170173;
                    grid.Children.Add(box, i, j);
                    var tap = new TapGestureRecognizer();
                    box.GestureRecognizers.Add(tap);
                    tap.Tapped += Tap_Tapped;
                }
            }
            newGame = new Button { Text = "Uus mäng", BackgroundColor = Color.Brown, TextColor = Color.White };
            grid.Children.Add(newGame, 0, 3);
            Grid.SetColumnSpan(newGame, 2);
            random_player = new Button { Text = "Kes on esimene?", BackgroundColor = Color.AntiqueWhite, TextColor = Color.Black };
            grid.Children.Add(random_player, 2, 3);
            Grid.SetColumnSpan(random_player, 2);
            whoFirst = new Label { Text = "...", TextColor = Color.Black };
            random_player.Clicked += Random_player_Clicked;
            newGame.Clicked += New_game_Clicked1;
            Content = grid;

        }

        private void New_game_Clicked1(object sender, EventArgs e)
        {
            New_game_Clicked();
            wert();
        }

        private void Random_player_Clicked(object sender, EventArgs e)
        {
            wert();
            New_game_Clicked();
        }

        Random rnd = new Random();
        private bool wert()
        {
            int player = rnd.Next(0, 2);
            if (player == 1)
            {
                first_player = true;
            }
            else
            {
                first_player = false;
            }
            return first_player;
        }
        public async void First_Player_manual()
        {
            string first_player_manual = await DisplayPromptAsync("Kes on on esimene?", "LILLA -1, ROHELINE -2", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (first_player_manual == "1")
            {
                first_player = true;
            }
            else if (first_player_manual == "2")
            {
                first_player = false;
            }
        }

        BoxView box_clik;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            {
                {
                    box_clik = sender as BoxView;
                    if (box_clik.Color == Color.FromRgb(204, 102, 0) && first_player)
                    {
                        box_clik.Color = Color.FromRgb(102, 0, 102);
                        first_player = false;
                        gamemap[Grid.GetRow(box_clik), Grid.GetColumn(box_clik)] = 1;
                    }
                    else if (box_clik.Color == Color.FromRgb(204, 102, 0) && !first_player)
                    {
                        box_clik.Color = Color.FromRgb(0, 153, 0);
                        first_player = true;
                        gamemap[Grid.GetRow(box_clik), Grid.GetColumn(box_clik)] = 0;
                    }
                    else
                    {
                        DisplayAlert("Hõivatud", "Te ei saa seda siia panna", "OK");
                    }
                };
                wert();
                CheckTheWinner();
            }
        }
        public string CheckTheTable()
        {
            string winner = "";

            // Vertical left
            if (gamemap[0, 0] == 1 && gamemap[1, 0] == 1 && gamemap[2, 0] == 1)
            {
                winner = "1";
            }
            else if (gamemap[0, 0] == 0 && gamemap[1, 0] == 0 && gamemap[2, 0] == 0)
            {
                winner = "2";
            }

            // Vertical center
            if (gamemap[0, 1] == 1 && gamemap[1, 1] == 1 && gamemap[2, 1] == 1)
            {
                winner = "1";
            }
            else if (gamemap[0, 1] == 0 && gamemap[1, 1] == 0 && gamemap[2, 1] == 0)
            {
                winner = "2";
            }

            // Vertical right
            if (gamemap[0, 2] == 1 && gamemap[1, 2] == 1 && gamemap[2, 2] == 1)
            {
                winner = "1";
            }
            else if (gamemap[0, 2] == 0 && gamemap[1, 2] == 0 && gamemap[2, 2] == 0)
            {
                winner = "2";
            }

            // Horizontal top
            if (gamemap[0, 0] == 1 && gamemap[0, 1] == 1 && gamemap[0, 2] == 1)
            {
                winner = "1";
            }
            else if (gamemap[0, 0] == 0 && gamemap[0, 1] == 0 && gamemap[0, 2] == 0)
            {
                winner = "2";
            }

            // Horizontal center
            if (gamemap[1, 0] == 1 && gamemap[1, 1] == 1 && gamemap[1, 2] == 1)
            {
                winner = "1";
            }
            else if (gamemap[1, 0] == 0 && gamemap[1, 1] == 0 && gamemap[1, 2] == 0)
            {
                winner = "2";
            }

            // Horizontal bottom
            if (gamemap[2, 0] == 1 && gamemap[2, 1] == 1 && gamemap[2, 2] == 1)
            {
                winner = "1";
            }
            else if (gamemap[2, 0] == 0 && gamemap[2, 1] == 0 && gamemap[2, 2] == 0)
            {
                winner = "2";
            }

            // Diagonal top-left bottom-right
            if (gamemap[0, 0] == 1 && gamemap[1, 1] == 1 && gamemap[2, 2] == 1)
            {
                winner = "1";
            }
            else if (gamemap[0, 0] == 0 && gamemap[1, 1] == 0 && gamemap[2, 2] == 0)
            {
                winner = "2";
            }

            // Diagonal bottom-left top-right
            if (gamemap[2, 0] == 1 && gamemap[1, 1] == 1 && gamemap[0, 2] == 1)
            {
                winner = "1";
            }
            else if (gamemap[2, 0] == 0 && gamemap[1, 1] == 0 && gamemap[0, 2] == 0)
            {
                winner = "2";
            }

            return winner;
        }
        public void CheckTheWinner()
        {
            if (CheckTheTable() == "1")
            {
                //DisplayAlert("Hõivatud", "LILLA", "OK");
                whoFirst.Text = "LILLA Võitis! !";
                restartLilla();

            }
            else if (CheckTheTable() == "2")
            {
                //DisplayAlert("Võitis", "ROHELINE", "OK");
                whoFirst.Text = "ROHELINE Võitis !";
                restartRoheline();
            }
        }
        private async void restartLilla()
        {
            string Restart = await DisplayPromptAsync("Restart", "LILLA Võitis! Kas soovite uuesti mängida ? Yes - 1, No - 2",
                initialValue: "1",
                maxLength: 1,
                keyboard: Keyboard.Numeric);
            if (Restart == "1")
            {
                First_Player_manual();
                New_game_Clicked();
                wert();
            }

        }
        private async void restartRoheline()
        {
            string Restart = await DisplayPromptAsync("Restart", "ROHELINE Võitis! Kas soovite uuesti mängida ? Yes - 1, No - 2",
                initialValue: "1",
                maxLength: 1,
                keyboard: Keyboard.Numeric);
            if (Restart == "1")
            {
                First_Player_manual();
                New_game_Clicked();
                wert();
            }

        }
    }
}

/*
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
    Children = { grid, absolute }
};

Content = stack;
        }
*/
