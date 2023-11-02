namespace Lesson2_5
{
    public partial class Calculator : Form
    {
        Calc calc;
        public Calculator()
        {
            InitializeComponent();
            calc = new Calc();
            calc.MyEventHandler += Calc_MyEventHandler;
        }
        private void Calc_MyEventHandler(object? sender, EventArgs e)
        {
            if (sender is Calc)
                Result.Text = $"Result: {((Calc)sender).Result}";
        }

        private void ButtonSum_Click(object sender, EventArgs e)
        {
            try
            {
                calc.Sum(Convert.ToInt32(textBox1.Text));
                label4.Text = "";
                textBox1.Text = null;
            }
            catch
            {
                label4.Text = "Сначало введите число!!!";
            }

        }

        private void ButtonSub_Click(object sender, EventArgs e)
        {
            try
            {
                calc.Sub(Convert.ToInt32(textBox1.Text));
                label4.Text = "";
                textBox1.Text = null;
            }
            catch
            {
                label4.Text = "Сначало введите число!!!";
            }
        }

        private void ButtonMylt_Click(object sender, EventArgs e)
        {
            try
            {
                calc.Mult(Convert.ToInt32(textBox1.Text));
                label4.Text = "";
                textBox1.Text = null;
            }
            catch
            {
                label4.Text = "Сначало введите число!!!";
            }

        }

        private void ButtonDivide_Click(object sender, EventArgs e)
        {
            try
            {
                calc.Div(Convert.ToInt32(textBox1.Text));
                label4.Text = "";
                textBox1.Text = null;
            }
            catch
            {
                label4.Text = "Сначало введите число!!!";
            }

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            string str = calc.CancelAction();
            label4.Text = str;
            textBox1.Text = null;
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            calc.ResetCalculation();
            label4.Text = "Все прошлые вычисления сброшены";
            Result.Text = $"Result: 0";
            textBox1.Text = null;
        }
    }
}