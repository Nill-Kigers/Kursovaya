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
        char[] spec_chars = new char[] { '%', '*', ')', '?', '#', '$', '^', '&', '~' };//массив спец. символов
        Dictionary<string, double> metrica;//структура данных, позволяющая получать доступ к элементу по ключу
        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
            metrica = new Dictionary<string, double>();//создаем объект metrica
            metrica.Add("mm", 1);//заполняем metrica
            metrica.Add("cm", 10);
            metrica.Add("dm", 100);
            metrica.Add("m", 1000);
            metrica.Add("km", 1000000);
            metrica.Add("mile", 1609344);


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
                if (i <= 1000) tbRandom.AppendText(n + "                   \n");// сохранение числа в случае i <= 1000
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

        private void tsmiInsertDate_Click(object sender, EventArgs e)
        {
            RTBNotepad.AppendText(DateTime.Now.ToShortDateString() + "\n");//Автоматическое определение даты 
        }

        private void tsmiInsertTime_Click(object sender, EventArgs e)
        {
            RTBNotepad.AppendText(DateTime.Now.ToShortTimeString() + "\n");// Автоматическое определение времени
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            try
            {
                RTBNotepad.SaveFile("notepad.rtf");//Сохранение файла
            }
            catch {
                MessageBox.Show("Ошибка при сохранении");//вывод ошибки
            }
        }

        void LoadNotepad()
        {
            try
            {
                RTBNotepad.LoadFile("notepad.rtf");//Загрузка файла в блокнот
            }
            catch
            {
                MessageBox.Show("Ошибка при Загрузке");//вывод ошибки
            }
        }

        private void tsmiLoad_Click(object sender, EventArgs e)
        {
            LoadNotepad();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadNotepad();
            CLBPassword.SetItemChecked(0, true);//выбор по умолчанию в генерации пароля
            CLBPassword.SetItemChecked(1, true);
        }

        private void BtnCreatePass_Click(object sender, EventArgs e)
        {
            if (CLBPassword.CheckedItems.Count == 0) return;//отмена генерации пароля при 0
            string password = "";//пустой пароль
            for (int i = 0; i < NUDPassLength.Value; i++)//цикл проверки значений
            {
                int n = rnd.Next(0, CLBPassword.CheckedItems.Count);//случайны выбор элементов из массива
                string s = CLBPassword.CheckedItems[n].ToString();//запись выбранного элемента в переменную S
                switch (s)
                {
                    case "Цифры":
                        password += rnd.Next(10).ToString();//запись случайных цифр (от 0 до 9)
                        break;

                    case "Прописные буквы":
                        password += Convert.ToChar(rnd.Next(65, 88));//преобразование чисел в символы
                        break;

                    case "Строчные буквы":
                        password += Convert.ToChar(rnd.Next(97, 122));//преобразование чисел в символы
                        break;

                    default:
                        password += spec_chars[rnd.Next(spec_chars.Length)];//запись случайных спец. символов
                        break;

                }

                TBPass.Text = password;//присвоение TextBox функции password
                Clipboard.SetText(password);//копирование пароля в буфер обмена

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            double m1 = metrica[CBFrom.Text];//получение данных из поля From по ключу из metrica
            double m2 = metrica[CBTo.Text];
            double n = Convert.ToDouble(TBFrom.Text);//получение и конвертирование числа n из поля TextBox
            TBTo.Text = (n * m1 / m2).ToString();//помещяем отношение чисел в TextBox и конвертируем его
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            string T = CBFrom.Text;//добавляем временную переменную с сохранение в ComboBox
            CBFrom.Text = CBTo.Text;//Меняем свойства "Text" местами
            CBTo.Text = T;//записываем в ComboBox переменную "t"
        }

        private void CBMetric_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CBMetric.Text)
            {
                case "Длина":
                    metrica.Clear();//очистка словаря
                        metrica.Add("mm", 1);//дополняем словарь
                        metrica.Add("cm", 10);
                        metrica.Add("dm", 100);
                        metrica.Add("m", 1000);
                        metrica.Add("km", 1000000);
                        metrica.Add("mile", 1609344);
                    CBFrom.Items.Clear();//Очищаем своство Items
                        CBFrom.Items.Add("mm");//Добавляем новые своства в Items
                        CBFrom.Items.Add("cm");
                        CBFrom.Items.Add("dm");
                        CBFrom.Items.Add("m");
                        CBFrom.Items.Add("km");
                        CBFrom.Items.Add("mile");
                    CBTo.Items.Clear();//Очищаем своство Items
                        CBTo.Items.Add("mm");//Добавляем новые своства в Items
                        CBTo.Items.Add("cm");
                        CBTo.Items.Add("dm");
                        CBTo.Items.Add("m");
                        CBTo.Items.Add("km");
                        CBTo.Items.Add("mile");
                    CBFrom.Text = "mm";//меняем названия по умолчанию
                    CBTo.Text = "mm";//меняем названия по умолчанию
                    break;

                case "Вес":
                    metrica.Clear();//очистка словаря
                        metrica.Add("g", 1);//дополняем словарь
                        metrica.Add("kg", 1000);
                        metrica.Add("t", 1000000);
                        metrica.Add("lb", 453.6);
                        metrica.Add("oz", 283);
                    CBFrom.Items.Clear();//Очищаем своство Items
                        CBFrom.Items.Add("g");//Добавляем новые своства в Items
                        CBFrom.Items.Add("kg");
                        CBFrom.Items.Add("t");
                        CBFrom.Items.Add("lb");
                        CBFrom.Items.Add("oz");
                    CBTo.Items.Clear();//Очищаем своство Items
                        CBTo.Items.Add("g");//Добавляем новые своства в Items
                        CBTo.Items.Add("kg");
                        CBTo.Items.Add("t");
                        CBTo.Items.Add("lb");
                        CBTo.Items.Add("oz");
                    CBFrom.Text = "g";//меняем названия по умолчанию
                    CBTo.Text = "g";//меняем названия по умолчанию
                    break;

                default:
                    break;
            }
        }
    }
}
