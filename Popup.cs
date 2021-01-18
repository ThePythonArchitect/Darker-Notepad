using System;
using System.Drawing;
using System.Windows.Forms;

namespace DarkerNotepad
{
    public partial class Popup : Form
    {
        public delegate void button1Clicked();
        public event button1Clicked onButton1Clicked;
        public delegate void button2Clicked();
        public event button2Clicked onButton2Clicked;

        public Popup()
        {
            InitializeComponent();
        }

        public void useDarkMode()
        {
            Color backColor = Color.FromArgb(50, 50, 50);
            label1.ForeColor = Color.LightGray;
            label1.BackColor = backColor;
            button1.ForeColor = Color.LightGray;
            button1.BackColor = backColor;
            button2.ForeColor = Color.LightGray;
            button2.BackColor = backColor;
            ForeColor = backColor;
            BackColor = backColor;
            return;
        }

        public void setTitle(string newTitle)
        {
            Text = newTitle;
            return;
        }

        public void setText(string newText)
        {
            label1.Text = newText;
            return;
        }

        public void setButton1Text(string newText)
        {
            button1.Text = newText;
            return;
        }

        public void setButton2Text(string newText)
        {
            button2.Text = newText;
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            onButton1Clicked?.Invoke();
            Close();
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            onButton2Clicked?.Invoke();
            Close();
            return;
        }
    }
}
