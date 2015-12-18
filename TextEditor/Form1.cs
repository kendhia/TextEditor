using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Color RENK = Color.GreenYellow;

        private void Form1_Load(object sender, EventArgs e)
        {
            FontDoldur();
            FontSizeDoldur();
        }

        void FontDoldur()
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }


            toolStripComboBox1.SelectedText = richTextBox1.Font.FontFamily.Name;
        }

        void FontSizeDoldur()
        {
            for (int i = 8; i < 40; i++)
            {
                toolStripComboBox2.Items.Add(i);
            }
            toolStripComboBox2.SelectedText = richTextBox1.Font.Size.ToString();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Kalın
            Font seciliFont = richTextBox1.SelectionFont;

            if (seciliFont.Bold == false)
            {
                FontTipDegistir(seciliFont.Style | FontStyle.Bold);
                btnRenkDegistir(toolStripButton1, RENK);
            }
            else
            {
                if (seciliFont.Bold && seciliFont.Italic && seciliFont.Underline)
                {
                    FontTipDegistir(FontStyle.Regular & FontStyle.Italic & FontStyle.Underline);
                }
                else if (seciliFont.Bold && seciliFont.Italic)
                {
                    FontTipDegistir(FontStyle.Regular & FontStyle.Italic);
                }
                else if (seciliFont.Bold && seciliFont.Underline)
                {
                    FontTipDegistir(FontStyle.Regular & FontStyle.Underline);
                }
                else if (seciliFont.Bold)
                {
                    FontTipDegistir(FontStyle.Regular);
                }

                btnRenkDegistir(toolStripButton1, Color.Empty);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Italic

            Font seciliFont = richTextBox1.SelectionFont;

            if (seciliFont.Italic == false)
            {
                FontTipDegistir(seciliFont.Style | FontStyle.Italic);
                btnRenkDegistir(toolStripButton2, RENK);
            }
            else
            {
                if (seciliFont.Bold && seciliFont.Italic && seciliFont.Underline)
                {
                    FontTipDegistir(FontStyle.Bold & FontStyle.Underline);
                }
                else if (seciliFont.Bold && seciliFont.Italic)
                {
                    FontTipDegistir(FontStyle.Bold);
                }
                else if (seciliFont.Italic && seciliFont.Underline)
                {
                    FontTipDegistir(FontStyle.Underline);
                }
                else if (seciliFont.Italic)
                {
                    FontTipDegistir(FontStyle.Regular);
                }

                btnRenkDegistir(toolStripButton2, Color.Empty);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Italic

            Font seciliFont = richTextBox1.SelectionFont;

            if (seciliFont.Underline == false)
            {
                FontTipDegistir(seciliFont.Style | FontStyle.Underline);
                btnRenkDegistir(toolStripButton3, RENK);
            }
            else
            {
                if (seciliFont.Bold && seciliFont.Italic && seciliFont.Underline)
                {
                    FontTipDegistir(FontStyle.Bold & FontStyle.Italic);
                }
                else if (seciliFont.Bold && seciliFont.Underline)
                {
                    FontTipDegistir(FontStyle.Bold);
                }
                else if (seciliFont.Italic && seciliFont.Underline)
                {
                    FontTipDegistir(FontStyle.Italic);
                }
                else if (seciliFont.Underline)
                {
                    FontTipDegistir(FontStyle.Regular);
                }

                btnRenkDegistir(toolStripButton3, Color.Empty);
            }
        }

        void btnRenkDegistir(ToolStripButton btn, Color renk)
        {
            btn.BackColor = renk;
        }

        void FontTipDegistir(FontStyle fontTipi)
        {
            Font seciliFont = richTextBox1.SelectionFont;
            richTextBox1.SelectionFont = new Font(seciliFont.FontFamily.Name, seciliFont.Size, fontTipi);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DialogResult dr = colorDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            RichTextBox richtextBox = sender as RichTextBox;
            Font seciliFont = richtextBox.SelectionFont;
            if (seciliFont != null)
            {
                if (seciliFont.Bold)
                {
                    toolStripButton1.BackColor = Color.GreenYellow;
                }
                else
                {
                    toolStripButton1.BackColor = Color.Empty;
                }


                if (seciliFont.Italic)
                {
                    toolStripButton2.BackColor = Color.GreenYellow;
                }
                else
                {
                    toolStripButton2.BackColor = Color.Empty;
                }

                if (seciliFont.Underline)
                {
                    toolStripButton3.BackColor = Color.GreenYellow;
                }
                else
                {
                    toolStripButton3.BackColor = Color.Empty;
                }


                toolStripComboBox1.Text = seciliFont.FontFamily.Name;
                toolStripComboBox2.Text = seciliFont.Size.ToString();
            }

        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font seciliFont = richTextBox1.SelectionFont;
            if (seciliFont != null)
            {
                richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), seciliFont.Size, seciliFont.Style);
            }

        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font seciliFont = richTextBox1.SelectionFont;
            if (seciliFont != null)
            {
                richTextBox1.SelectionFont = new Font(seciliFont.FontFamily, Convert.ToSingle(toolStripComboBox2.SelectedItem), seciliFont.Style);
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = Color.Empty;

            string metin = richTextBox1.Text.ToLower();
            string arananMetin = toolStripTextBox1.Text.ToLower();

            for (int i = 0; i < metin.Length - (arananMetin.Length - 1); i++)
            {
                string kelime = metin.Substring(i, arananMetin.Length);

                if (kelime == arananMetin)
                {
                    richTextBox1.Select(i, arananMetin.Length);
                    richTextBox1.SelectionColor = RENK;
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

    }
}
