using System;
using System.Text.RegularExpressions;
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
            string[] media = { "twitter", "patreon", "weibo", "deviantart", "instagram", "tumblr", "pixiv", "facebook", "fanbox", "gumroad", "artstation", "lofter", "furaffinity", "youtube", "reddit", "naver", "twitch", "pawoo", "fantia", "plurk" };
            string[] name = { "artist", "character", "copyright", "company", "group" };
            string[] earrings = { "hoop", "stud", "bell", "cherry", "crescent", "cross", "crystal", "flower", "food-themed", "heart", "jack-o'-lantern", "magatama", "orange-shaped", "pill", "pineapple", "planet", "pom pom", "potara", "shell", "skull", "snowflake", "spade", "star", "strawberry", "tassel", "yin yang", "adjusting", "multiple" };
            string[] colors = { "gold", "silver", "aqua", "black", "blue", "brown", "green", "grey", "orange", "pink", "purple", "red", "white", "yellow" };
            string[] licking = { "another's face", "armpit", "breast", "cum", "dildo", "ear", "eye", "finger", "floor", "foot", "hand", "leg", "navel", "neck", "nipple", "panties", "penis", "stomach", "testicle", "weapon" };

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

                if (checkBox1.Checked)
                {
                    for (int i = 0; i < name.Length; i++)
                        raw = raw.Replace(name[i] + " name, ", "");

                    for (int i = 0; i < media.Length; i++)
                    {
                        raw = raw.Replace(media[i] + " logo, ", "");
                        raw = raw.Replace(media[i] + " username, ", "");
                    } 
                }
                if (checkBox2.Checked)
                {
                    raw = raw.Replace("jewelry, ", "");

                    for (int i = 0; i < earrings.Length; i++)
                        raw = raw.Replace(earrings[i] + " earrings, ", "");
                    for (int i = 0; i < colors.Length; i++)
                        raw = raw.Replace(colors[i] + " earrings, ", "");

                    raw = raw.Replace("earrings, ", "");

                    for (int i = 0; i < licking.Length; i++)
                        raw = raw.Replace("licking " + licking[i] + ", ", "");

                    raw = raw.Replace("licking, ", "");
                    raw = raw.Replace("censored, ", "");
                    raw = raw.Replace("tongue out, ", "");
                }
                if (checkBox3.Checked)
                {
                    raw = raw.Replace("large breasts", "medium breasts");
                }

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

        private void button4_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetText().Length > 0)
                richTextBox1.Text = Clipboard.GetText();
            else
                richTextBox1.Text = "Nothing to Paste";
        }
    }
}
