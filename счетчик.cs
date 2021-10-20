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
        public MainForm()
        {
            InitializeComponent();
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
    }
}
