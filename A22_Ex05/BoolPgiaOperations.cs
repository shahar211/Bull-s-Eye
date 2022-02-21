namespace A22_Ex05
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public class BoolPgiaOperations
    {
        public static string ColorToChar(Control[] i_Buttons, Dictionary<Color, char> i_DictionaryOfColors)
        {
            List<Color> colorNames = new List<Color>();
            StringBuilder userInputInString = new StringBuilder();

            foreach (Button singleButton in i_Buttons)
            {
                colorNames.Add(singleButton.BackColor);
            }

            foreach (Color name in colorNames)
            {
                i_DictionaryOfColors.TryGetValue(name, out char value);
                userInputInString.Append(value);
            }

            return userInputInString.ToString();
        }

        public static void CreateDictionaryKeyAndValue(Dictionary<Color, char> io_DictionaryOfColors)
        {
            Color[] colors = { Color.BlueViolet, Color.Red, Color.GreenYellow, Color.LightBlue, Color.Blue, Color.Yellow, Color.Brown, Color.White };
            char i = 'A';

            foreach (Color color in colors)
            {
                io_DictionaryOfColors.Add(color, i);
                i++;
            }
        }

        public static Button InitializeButton(string i_Name, int i_Height, int i_Length, int i_LocationOfX, int i_LocationOfY, string i_Text)
        {
            Button button = new Button();

            button.Enabled = false;
            button.Name = i_Name;
            button.Size = new Size(i_Height, i_Length);
            button.Location = new Point(i_LocationOfX, i_LocationOfY);
            button.Text = i_Text;

            return button;
        }
    }
}