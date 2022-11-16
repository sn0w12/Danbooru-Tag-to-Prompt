using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horrible
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string raw = richTextBox1.Text;

            try
            {
                raw = raw.Replace("? ", "");
                raw = raw.Replace("\n", ", ");
                string[] words = raw.Split(',');
                char girl = Search(words, 'g');
                char boy = Search(words, 'b');
                raw = string.Join(",", words);
                raw = " " + raw;
                raw = Regex.Replace(raw, @"[\d-]", string.Empty);
                raw = raw.Replace(" k", "");
                raw = raw.Replace(" .k", "");
                raw = raw.Replace(" M", "");
                raw = raw.Replace(" .M", "");
                raw = raw.Replace("General,", "");
                raw = raw.Replace("Copyrights,", "");
                raw = raw.Replace("Artists,", "");
                raw = raw.Replace("Meta,", "");
                string girls = " " + girl + "girl";
                string boys = " " + boy + "boy";
                raw = raw.Replace(" boy", boys);
                raw = raw.Replace(" girl", girls);
                if (raw[0] == ' ')
                    raw = raw.Remove(0, 1);

                richTextBox2.Text = raw;
            }
            catch
            {
                richTextBox2.Text = "Error";
            }
        }

        private char Search(string[] words, char character)
        {
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (word[2] == character || word[3] == character)
                    return word[1];
                else if (word[1] == character)
                    return word[0];
            }
            return '0';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox2.TextLength > 0)
                Clipboard.SetText(richTextBox2.Text);
            else
                return;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
        }
    }
}
