using System.Diagnostics;

namespace TicTacToeSqlRanking
{


    public partial class Form1 : Form
    {
        class Points
        {
            public int x { get; set; }
            public int o { get; set; }
        }

        class PlayerName
        {
            public string x { get; set; }
            public string o { get; set; }
        }
        private enum Player
        {
            X, // 0
            O, // 1
            none // 2
        };

        private Points points = new Points();
        private PlayerName playerName = new PlayerName();

        int xyz = 0;

        public Form1()
        {
            InitializeComponent();
            panel1.Location = new Point(4442, 29);


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
                        points.x++;
                        label1.Text = playerName.x + ": "+ points.x.ToString();
                    }
                    break;
                case Player.O:
                    {
                        points.o++;
                        label2.Text = playerName.o + ": " + points.o.ToString();

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
                case " ":
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
                    ((Button)sender).Text = Player.X.ToString();
                }
                else
                {
                    ((Button)sender).Text = Player.O.ToString();
                }
                xyz++;
                checkGame();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != " " && textBox2.Text != " ")
            {
                playerName.x = textBox1.Text;
                playerName.o = textBox2.Text;
                panel1.Location = new Point (32, 29);
                panel2.Location = new Point(5000, 5000);
                label1.Text = playerName.x + ": " + points.x.ToString();
                label2.Text = playerName.o + ": " + points.o.ToString();


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}