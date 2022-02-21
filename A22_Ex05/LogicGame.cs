namespace A22_Ex05
{
    using System.Text;
    using System;
    using System.Collections.Generic;

    public class LogicGame
    {
        private readonly List<GuessResults> r_ResultsOfGuesses;
        private readonly Random r_Random = new Random();

        public List<GuessResults> ResultsOfGuesses
        {
            get { return r_ResultsOfGuesses; }
        }

        public LogicGame()
        {
            r_ResultsOfGuesses = new List<GuessResults>();
        }

        public bool CheckIfWin(int i_NumberOfHits)
        {
            return i_NumberOfHits == 4;
        }

        public bool CheckIfGameOver(int i_MaxUserGuess)
        {
            return r_ResultsOfGuesses.Count == i_MaxUserGuess;
        }

        public string CreateRandomPin()
        {
            StringBuilder pin = new StringBuilder();
            HashSet<char> checkIfRandomLetterExists = new HashSet<char>();

            while (checkIfRandomLetterExists.Count < 4)
            {
                char randomChar = (char)r_Random.Next('A', 'I');

                if (checkIfRandomLetterExists.Add(randomChar))
                {
                    pin.Append(randomChar);
                }
            }

            return pin.ToString();
        }
    }
}
