using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUtil
{
    public partial class MainForm : Form
    {
        int count = 0;
        Random rnd;//обработчик рандом
        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close(); //присвоение функции выход
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа содержит ряд небольших программ," +
                "\n которые могут пригодиться в жизни.", "О программе");
            //после запятой - название окна; \n - перенос на другую строчку
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            count++;//складывает в счетчике
            lblCount.Text = count.ToString();//преобразование в стринг
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            count--;//вычитает из счетчика
            lblCount.Text = count.ToString();//преобразование в стринг
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            count = 0;//обнуляет счетчик
            lblCount.Text = Convert.ToString(count);//преобразование в стринг, но другим способом
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            n = rnd.Next(Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown1.Value) + 1);//Создание случайного числа
            lblRandom.Text = n.ToString();//Вывод случайного числа в label
            if (cbRandom.Checked)//Метод для CheckBox отключение и включение повторения чисел
            {
                int i = 0;
                while (tbRandom.Text.IndexOf(n.ToString()) != -1)//исключение повторяющихся чисел
                {
                    n = rnd.Next(Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown1.Value) + 1);
                    i++;//увеличение счетчика на 1
                    if (i > 1000) break;//прерывание цикла при попытках больше 1000
                }
                if(i<=1000) tbRandom.AppendText(n + "                   \n");// сохранение числа в случае i <= 1000
            }
            else
                tbRandom.AppendText(n + "                   \n");//Сохранение чисел в TextBox
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRandomClear_Click(object sender, EventArgs e)
        {
            tbRandom.Clear();//очистка TextBox
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbRandom.Text);//Копирование в буфер обмена
        }
    }
}
