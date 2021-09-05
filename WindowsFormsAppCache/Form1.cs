using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CacheLibrary;

namespace WindowsFormsAppCache
{
    public partial class Form1 : Form
    {
        Cache<string,string> cache;

        public Form1()
        {
            cache = new Cache<string, string>(4, 5);

            InitializeComponent();
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            bool exists = cache.Get(textBoxKey.Text, out string value);

            textBoxValue.Text = exists ? value : "# Not found #";
        }

        private void buttonPut_Click(object sender, EventArgs e)
        {
            cache.Put(textBoxKey.Text, textBoxValue.Text);
        }
    }
}
