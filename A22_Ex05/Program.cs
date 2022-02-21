using System.ComponentModel;

namespace A22_Ex05
{
    using System.Windows.Forms;

    public class Program
    {
        public static void Main()
        {
            Run();
        }

        public static void Run()
        {
            FormNumberOfChances numberOfChancesForm = new FormNumberOfChances();

            numberOfChancesForm.ShowDialog();
            if (numberOfChancesForm.DialogResult == DialogResult.OK)
            {
                FormBoolPgiaGame boolPgiaForm = new FormBoolPgiaGame(numberOfChancesForm.NumberOfChances);

                boolPgiaForm.ShowDialog();
            }
        }
    }
}
