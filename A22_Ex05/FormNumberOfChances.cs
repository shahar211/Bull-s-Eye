namespace A22_Ex05
{
    using System;
    using System.Windows.Forms;

    public partial class FormNumberOfChances : Form
    {
        private int m_NumberChances = 4;

        public FormNumberOfChances()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Bool Pgia";
        }

        public int NumberOfChances
        {
            get
            {
                return m_NumberChances;
            }
        }

        private void NumberOfChances_Load(object sender, EventArgs e)
        {
        }

        private void chancesNumber_Click(object sender, EventArgs e)
        {
            Button theSender = sender as Button;

            m_NumberChances++;
            if(m_NumberChances > 10)
            {
                m_NumberChances = 4;
            }

            theSender.Text = string.Format(@"Number of chances: {0}", m_NumberChances);
        }

        private void start_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
