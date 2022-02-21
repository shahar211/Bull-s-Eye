namespace A22_Ex05
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Collections.Generic;

    public partial class FormPickAColor : Form
    {
        private const int k_SquareSize = 35;
        private const int k_SpacesBetweenSquares = 10;
        private const int k_SquareRowSize = 2;
        private const int k_SquareColSize = 4;
        private const int k_StartDistance = 10;

        private Color m_Color;

        public FormPickAColor(List<Color> i_ChooseColors)
        {
            InitializeComponent();
            Color[] colors = { Color.BlueViolet, Color.Red, Color.GreenYellow, Color.LightBlue, Color.Blue, Color.Yellow, Color.Brown, Color.White };
            int colorLocation = 0;

            for (int i = 0; i < k_SquareRowSize; i++)
            {
                for(int j = 0; j < k_SquareColSize; j++)
                {
                    int x = k_StartDistance + ((k_SpacesBetweenSquares + k_SquareSize) * j);
                    int y = k_StartDistance + ((k_SquareSize + k_SpacesBetweenSquares) * i);
                    string str = string.Format(@"button{0}", i);
                    Button button = BoolPgiaOperations.InitializeButton(str, k_SquareSize, k_SquareSize, x, y, string.Empty);

                    if(i_ChooseColors.Contains(colors[colorLocation]) && i_ChooseColors.Count != 0)
                    {
                        button.Enabled = false;
                        button.BackColor = colors[colorLocation];
                        button.FlatStyle = FlatStyle.Popup;
                        colorLocation++;
                    }
                    else
                    {
                        button.Enabled = true;
                        button.BackColor = colors[colorLocation];
                        colorLocation++;
                    }

                    this.Controls.Add(button);
                    button.Click += new EventHandler(button_Click);
                }
            }
        }

        public Color Color
        {
            get
            {
                return m_Color;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
             Button button = sender as Button;

             this.DialogResult = DialogResult.OK;
             m_Color = button.BackColor;
             this.Close();
        }

        private void PickAColor_Load(object sender, EventArgs e)
        {
        }
    }
}
