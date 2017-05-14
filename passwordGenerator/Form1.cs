using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace passwordGenerator
{
    public partial class Form1 : Form
    {
        private string password;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Сгенерировать пароль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int size = int.Parse(textBox1.Text);
                if (size > 32 || size < 0)
                {
                    if (size < 0)
                        MessageBox.Show("Размер не может быть отрицательным числом.");
                    if (size > 32)
                        MessageBox.Show("Привышен максимальный размер пароля(32).");
                }
                else
                {
                    bool[] masCheck = new bool[6];
                    if (!cb2.Checked & !cb3.Checked)
                    {
                        cb4.Checked = false;
                        cb5.Checked = false;
                    }
                    if (!cb4.Checked & !cb5.Checked)
                    {
                        cb2.Checked = false;
                        cb3.Checked = false;
                    }
                    masCheck[0] = cb1.Checked;//число
                    masCheck[1] = cb2.Checked;//строчыне
                    masCheck[2] = cb3.Checked;//прописные
                    masCheck[3] = cb4.Checked;//русский
                    masCheck[4] = cb5.Checked;//английский
                    masCheck[5] = cb6.Checked;//спец символы
                    Generator pas = new Generator(masCheck, size);
                    pas.generations();
                    password = pas.getName;
                    output.Text = "Сгенерированынй пароль: " + pas.getName;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(password);
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            ComplexityPassword cp = new ComplexityPassword();
            try
            {
                progressBar1.Value = cp.CheckedPassword(textBox2.Text);
                passwordReliability.Text = cp.status(progressBar1.Value);
                ImageCheck img = new ImageCheck();
                if (img.checkSize(textBox2.Text))
                    pictureBox1.Image = Properties.Resources._true;
                else
                    pictureBox1.Image = Properties.Resources._false;
                if (img.alphabetUp(textBox2.Text))
                    pictureBox2.Image = Properties.Resources._true;
                else
                    pictureBox2.Image = Properties.Resources._false;
                if (img.alphabetDown(textBox2.Text))
                    pictureBox4.Image = Properties.Resources._true;
                else
                    pictureBox4.Image = Properties.Resources._false;
                if (img.number(textBox2.Text))
                    pictureBox3.Image = Properties.Resources._true;
                else
                    pictureBox4.Image = Properties.Resources._false;
            }
            catch
            {
                if (cp.CheckedPassword(textBox2.Text) >= 100)
                    progressBar1.Value = 100;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
