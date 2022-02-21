namespace A22_Ex05
{
    using System.Linq;
    using System.Text;

    public class GuessResults
    {
        private readonly string r_StringResult;
        private readonly string r_UserGuessInput;
        private int m_CountHit;
        private int m_CountX;

        public int CountHit
        {
            get { return m_CountHit; }
        }

        public string UserGuess
        {
            get { return r_UserGuessInput; }
        }

        public string StringResult
        {
            get { return r_StringResult; }
        }

        public GuessResults(string i_UserStringInput, string i_ComputerPin)
        {
            getNumOfHit(i_UserStringInput, i_ComputerPin);
            getNumOfX(i_UserStringInput, i_ComputerPin);
            r_StringResult = CreateStringResult();
            r_UserGuessInput = i_UserStringInput;
        }

        private void getNumOfX(string i_UserGuess, string i_ComputerPin)
        {
            m_CountX = 0;
            for (int i = 0; i < i_UserGuess.Length; i++)
            {
                if (i_UserGuess[i] != i_ComputerPin[i])
                {
                    if (i_ComputerPin.Contains(i_UserGuess[i]))
                    {
                        m_CountX++;
                    }
                }
            }
        }

        private void getNumOfHit(string i_UserGuess, string i_ComputerPin)
        {
            m_CountHit = 0;

            for (int i = 0; i < i_UserGuess.Length; i++)
            {
                if (i_ComputerPin[i].Equals(i_UserGuess[i]))
                {
                    m_CountHit++;
                }
            }
        }

        public string CreateStringResult()
        {
            StringBuilder results = new StringBuilder();

            for (int i = 0; i < m_CountHit; i++)
            {
                results.Append("V");
            }

            for (int i = 0; i < m_CountX; i++)
            {
                results.Append("X");
            }

            for (int i = 0; i < 4 - m_CountX - m_CountHit; i++)
            {
                results.Append(" ");
            }

            return results.ToString();
        }
    }
}
