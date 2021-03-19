using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            this.BackgroundImage = Properties.Resources.Greek_alphabet_1;
            textBox2.Enabled = false;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!IsGreek(textBox1.Text))
            {
                textBox2.Text = "Wrong input";
                button2.Enabled = false;
                
            }
            else
            {

                button2.Enabled = true;
                textBox2.Text = ConvertToGlish(textBox1.Text);
                
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bool success = false;
          
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save a Text File";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string name = saveFileDialog1.FileName;
                File.WriteAllText(name, textBox2.Text);
                success = true;
            }
            if(success)
            {
                textBox2.Clear();
                string message = "File saved";
                string title = "Success";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                button2.Enabled = false;
                textBox2.Clear();
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public static bool IsGreek(string text)
        {
            return text.Any(c => c >= 0x0370 && c <= 0x03FF);
        }

        public static string ConvertToGlish(string text)
        {
            char[] arr = text.ToLower().ToCharArray();
            List<char> list = new List<char>();
            for (int y = 0; y < arr.Length; y++)
            {
                if (arr[y] >= 0x0370 && arr[y] <= 0x03FF)
                {
                    switch (arr[y])
                    {
                        case 'α':
                        case 'ά':
                            list.Add('a');
                            break;
                        case 'β':
                            list.Add('b');
                            break;
                        case 'γ':
                            list.Add('g');
                            break;
                        case 'δ':
                            list.Add('d');
                            break;
                        case 'ε':
                        case 'έ':
                            list.Add('e');
                            break;
                        case 'ζ':
                            list.Add('z');
                            break;
                        case 'η':
                        case 'ή':
                            list.Add('i');
                            break;
                        case 'θ':
                            list.Add('8');
                            break;
                        case 'ι':
                        case 'ί':
                        case 'ϊ':
                            list.Add('i');
                            break;
                        case 'κ':
                            list.Add('k');
                            break;
                        case 'λ':
                            list.Add('l');
                            break;
                        case 'μ':
                            list.Add('m');
                            break;
                        case 'ν':
                            list.Add('n');
                            break;
                        case 'ξ':
                            list.Add('3');
                            break;
                        case 'ο':
                        case 'ό':
                            list.Add('o');
                            break;
                        case 'π':
                            list.Add('p');
                            break;
                        case 'ρ':
                            list.Add('r');
                            break;
                        case 'σ':
                        case 'ς':
                            list.Add('s');
                            break;
                        case 'τ':
                            list.Add('t');
                            break;
                        case 'υ':
                        case 'ύ':
                            list.Add('y');
                            break;
                        case 'φ':
                            list.Add('f');
                            break;
                        case 'χ':
                            list.Add('h');
                            break;
                        case 'ψ':
                            list.Add('p');
                            list.Add('s');

                            break;
                        case 'ω':
                        case 'ώ':
                            list.Add('w');
                            break;
                        case ' ':
                            list.Add(' ');
                            break;
                        case '!':
                            list.Add('!');
                            break;
                        case '?':
                            list.Add('?');
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    list.Add(arr[y]);
                }
            }
            text = string.Join("", list);
            return text;
        }

    }
}
