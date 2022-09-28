using System.Diagnostics;

namespace TicTacToeSqlRanking
{
    public partial class Form1 : Form
    {
        private enum Player
        {
            X, // 0
            O, // 1
            none // 2
        };

        int xyz = 0;
        int x_Points = 0;
        int o_Points = 0;
        public Form1()
        {
            InitializeComponent();
            foreach (Control buttons in Controls)
            {
                if (buttons is Button)
                {
                    buttons.Click += buttons_Click;
                }
            }
        }

        private void AddPoints(Player winner)
        {
            switch (winner)
            {
                case Player.X:
                    {
                        x_Points++;
                        label1.Text = "X: " + x_Points.ToString();
                    }
                    break;
                case Player.O:
                    {
                        o_Points++;
                        label2.Text = "O: " + o_Points.ToString();

                    }break;
            }
        }

        private void checkGame()
        {
            if (button1.Text == button2.Text && button2.Text == button3.Text && button1.Text != " ") // 1 2 3
            {
                finishButton(button1);
            }
            else if (button4.Text == button5.Text && button5.Text == button6.Text && button4.Text != " ") // 4 5 6
            {
                finishButton(button4);
            }
            else if (button7.Text == button8.Text && button8.Text == button9.Text && button7.Text != " ") // 7 8 9
            {
                finishButton(button7);
            }
            else if (button1.Text == button5.Text && button5.Text == button9.Text && button1.Text != " ") // 1 5 9
            {
                finishButton(button1);
            }
            else if (button3.Text == button5.Text && button5.Text == button7.Text && button7.Text != " ") // 7 8 9
            {
                finishButton(button3);
            }
            else if (button1.Text == button4.Text && button4.Text == button7.Text && button7.Text != " ") // 1 4 7
            {
                finishButton(button1);
            }
            else if (button2.Text == button5.Text && button5.Text == button8.Text && button8.Text != " ") // 2 5 8
            {
                finishButton(button2);
            }
            else if (button3.Text == button6.Text && button6.Text == button9.Text && button9.Text != " ") // 3 6 9
            {
                finishButton(button3);
            }
            else
            {
                List<Control> allButtons = new List<Control>();
                foreach (Control z in Controls)
                {
                    if (z is Button)
                    {
                        if (z.Text != " ")
                        {
                            allButtons.Add(z);
                        }
                    }
                    if (allButtons.Count() == 9)
                    {
                        finishGame(Player.none);
                    }
                }
            }
        }

        private void finishButton(Button button)
        {
            switch (button.Text)
            {
                case "X":
                    {
                        finishGame(Player.X);
                    }break;
                case "O":
                    {
                        finishGame(Player.O);
                    }break;
                case "":
                    {
                        finishGame(Player.none);
                    }break;
            }
        }

        private void finishGame(Player winner)
        {
            if (winner == Player.none)
            {
                MessageBox.Show($"No one win!");
                foreach (Control z in Controls)
                {
                    if (z is Button)
                    {
                        z.Text = " ";
                    }
                }

            }
            else
            {
                AddPoints(winner);
                MessageBox.Show($"The winner is: {winner}!");
                foreach (Control z in Controls)
                {
                    if (z is Button)
                    {
                        z.Text = " ";
                    }
                }
            }
        }
        private void buttons_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == " ")
            {
                if (xyz % 2 == 0)
                {
                    ((Button)sender).Text = "X";
                }
                else
                {
                    ((Button)sender).Text = "O";

                }
                xyz++;
                checkGame();
            }
        }
    }
}