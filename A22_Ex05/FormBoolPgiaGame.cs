namespace A22_Ex05
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class FormBoolPgiaGame : Form
    {
        private const int k_SquareSize = 35;
        private const int k_SpacesBetweenSquares = 5;
        private const int k_SpaceStartButton = 8;
        private const int k_SquaresInRow = 4;
        private const int k_StartXSquare = 20;
        private const int k_StartYSquare = 60;
        private const int k_DifferentColorAmount = 4;

        private readonly string r_ComputerPin;
        private readonly LogicGame r_LogicGame;
        private readonly int r_NumberOfChances;
        private readonly Dictionary<Color, char> r_DictionaryOfColors = new Dictionary<Color, char>();
        private readonly List<Color> r_ChooseColorsList = new List<Color>();
        private int m_UserGuess;

        public FormBoolPgiaGame(int i_NumberOfChances)
        {
            InitializeComponent();
            int yHeight = k_StartYSquare + ((k_SquareSize + k_SpacesBetweenSquares) * i_NumberOfChances)
                                         + k_SpaceStartButton;

            this.ClientSize = new System.Drawing.Size(280, yHeight);
            r_LogicGame = new LogicGame();
            r_ComputerPin = r_LogicGame.CreateRandomPin();
            r_NumberOfChances = i_NumberOfChances;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.StartPosition = FormStartPosition.CenterParent;
            m_UserGuess = 0;
            createBoard();
            createFourSquares();
            enableButtons(string.Format(@"Button{0}",  m_UserGuess), true);
            BoolPgiaOperations.CreateDictionaryKeyAndValue(r_DictionaryOfColors);
        }

        private void enableButtons(string i_ArrowButtonName, bool i_ChangeEnable)
        {
            Control[] buttons = this.Controls.Find(i_ArrowButtonName, false);

            foreach (Button singleButton in buttons)
            {
                singleButton.Enabled = i_ChangeEnable;
            }
        }

        private void createFourSquares()
        {
            for (int i = 0; i < k_SquaresInRow; i++)
            {
                string str = string.Format(@"Pin{0}", k_SquaresInRow);
                int x = k_StartXSquare + ((k_SquareSize + k_SpacesBetweenSquares) * i);
                int y = 10;
                Button button = BoolPgiaOperations.InitializeButton(str, k_SquareSize, k_SquareSize, x, y, string.Empty);

                this.Controls.Add(button);
                button.BackColor = Color.Black;
            }
        }

        private void createBoard()
        {
            for (int i = 0; i < r_NumberOfChances; i++)
            {
                for (int j = 0; j < k_SquaresInRow; j++)
                {
                    createButtons(j, i);
                }

                createArrowButton(i);
                createButtonResults(i);
            }
        }

        private void createButtons(int i_ColToMove, int i_RowToMove)
        {
            string str = string.Format(@"button{0}", i_RowToMove);
            int x = k_StartXSquare + ((k_SquareSize + k_SpacesBetweenSquares) * i_ColToMove);
            int y = k_StartYSquare + ((k_SquareSize + k_SpacesBetweenSquares) * i_RowToMove);
            Button button = BoolPgiaOperations.InitializeButton(str, k_SquareSize, k_SquareSize, x, y, string.Empty);

            this.Controls.Add(button);
            button.Click += new EventHandler(button_Click);
        }

        private void createArrowButton(int i_RowToMove)
        {
            string str = string.Format(@"sendResult{0}", i_RowToMove);
            int x = k_StartXSquare + ((k_SquareSize + k_SpacesBetweenSquares) * k_SquaresInRow);
            int y = k_StartYSquare + ((k_SquareSize + k_SpacesBetweenSquares) * i_RowToMove) + k_SpaceStartButton;
            Button checkGuess = BoolPgiaOperations.InitializeButton(str, k_SquareSize, k_SquareSize / 2, x, y, "-->>");

            this.Controls.Add(checkGuess);
            checkGuess.Click += new EventHandler(arrowButton_Click);
        }

        private void arrowButton_Click(object Sender, EventArgs e)
        {
            r_ChooseColorsList.Clear();
            Control[] buttons = this.Controls.Find(string.Format(@"button{0}", m_UserGuess), false); 
            string userGuess = BoolPgiaOperations.ColorToChar(buttons, r_DictionaryOfColors);
            GuessResults guess = new GuessResults(userGuess, r_ComputerPin); 

            fillButtonResults(guess); 
            enableButtons(string.Format(@"button{0}", m_UserGuess), false);
            enableButtons(string.Format(@"sendResult{0}", m_UserGuess), false);
            play(guess);
        }

        private void fillButtonResults(GuessResults i_Guess)
        {
            Control[] buttons = this.Controls.Find(string.Format(@"ButtonResult{0}", m_UserGuess), false);

            for(int i = 0; i < buttons.Length; i++)
            {
                if(i_Guess.StringResult[i] == 'V')
                {
                    buttons[i].BackColor = Color.Black;
                }
                else if(i_Guess.StringResult[i] == 'X')
                {
                    buttons[i].BackColor = Color.Yellow;
                }
            }
        }

        private void play(GuessResults i_Guess)
        {
            r_LogicGame.ResultsOfGuesses.Add(i_Guess);

            if (r_LogicGame.CheckIfWin(i_Guess.CountHit))
            {
                showResult();
            }
            else if (r_LogicGame.CheckIfGameOver(r_NumberOfChances))
            {
                showResult();
            }
            else
            {
                m_UserGuess++;
                enableButtons(string.Format(@"button{0}", m_UserGuess), true);
            }
        }

        private void showResult()
        {
            Control[] buttons = this.Controls.Find(string.Format(@"Pin{0}", k_SquaresInRow), false);

            for(int i = 0; i < buttons.Length; i++)
            {
                foreach (Color keyVar in r_DictionaryOfColors.Keys)
                {
                    if (r_DictionaryOfColors[keyVar] == r_ComputerPin[i])
                    {
                        buttons[i].BackColor = keyVar;
                        break;
                    }
                }
            }
        }

        private void createButtonResults(int i_RowToMove)
        {
            int startButtonResultX = k_StartXSquare + ((k_SquareSize + k_SpacesBetweenSquares) * (k_SquaresInRow + 1)) + k_SpacesBetweenSquares;
            int startButtonResultY = k_StartYSquare + ((k_SquareSize + k_SpacesBetweenSquares) * i_RowToMove) + (k_SpaceStartButton / 2);

            for (int k = 0; k < 2; k++)
            {
                for (int m = 0; m < 2; m++)
                {
                    string str = string.Format(@"ButtonResult{0}", i_RowToMove);
                    int x = startButtonResultX + (((k_SquareSize / 3) + k_SpacesBetweenSquares) * m);
                    int y = startButtonResultY + (((k_SquareSize / 3) + k_SpacesBetweenSquares) * k);
                    Button buttonResult = BoolPgiaOperations.InitializeButton(str, k_SquareSize / 3, k_SquareSize / 3, x, y, string.Empty);

                    this.Controls.Add(buttonResult);
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            FormPickAColor colorForm = new FormPickAColor(r_ChooseColorsList);

            colorForm.ShowDialog();
            if (colorForm.DialogResult == DialogResult.OK)
            {
                r_ChooseColorsList.Remove(button.BackColor);
                button.BackColor = colorForm.Color;
                r_ChooseColorsList.Add(colorForm.Color);
            }

            Control[] buttons = this.Controls.Find(button.Name, false);

            if (r_ChooseColorsList.Count == k_DifferentColorAmount)
            {
                enableButtons(string.Format(@"sendResult{0}", m_UserGuess), true);
            }
            else
            {
                enableButtons(string.Format(@"sendResult{0}", m_UserGuess), false);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}