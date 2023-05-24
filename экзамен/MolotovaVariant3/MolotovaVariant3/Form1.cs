using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MolotovaVariant3
{
    public partial class Form1 : Form
    {
        Students students = new Students();
        public Form1()
        {
            InitializeComponent();
        }

        //проверка на число
        private void Mes(string text)
        {
            MessageBox.Show(text, "Ошибка");
        }

        public void Print()
        {            
            listBox1.Items.Clear( );
            string[] anwer =students.info().Split('*');
            listBox1.Items.AddRange(anwer);
        }
        private bool cheakInt(string text)
        {
            try
            {
                int n = Convert.ToInt32(text);
                return true;
            }
            catch {
                return false;
            }
        }

        private void buttonSeacrh(object sender, EventArgs e)
        {
            try
            {
                if (cheakInt(textBox1.Text))
                {
                    try
                    {
                        listBox1.Items.Clear();
                        string[] array = students.Search(Convert.ToInt32(textBox1.Text)).Split('*');
                        for (int i = 0; i < array.Length; i++) listBox1.Items.Add(array[i]);
                    }
                    catch { Mes("Ошибка"); }
                }
                else
                {
                    Mes("Вы ввели не число");
                }
            }
            catch
            {
                Mes("Ошибка");
            }
            
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            students.ReadFile( );
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Length > 0 && cheakInt(textBox3.Text))
                {
                    students.AddList(textBox2.Text, Convert.ToInt32(textBox3.Text));
                    textBox2.Text = "";
                    textBox3.Text = "";
                    listBox1.Items.Clear( );
                    Print( );
                }
                else if (textBox2.Text.Length == 0) Mes("Необходимо ввести имя");
                else if (cheakInt(textBox3.Text) == false) { Mes("Баллы не могут быть буквой"); }
                else
                {
                    Mes("Ошибка");
                }
            }
            catch
            {
                Mes("Ошибка");
            }
            
        }

        private void buttonPrintAll_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void listBox1_SelectedIndexChanged (object sender, EventArgs e)
        {

        }
    }
}
