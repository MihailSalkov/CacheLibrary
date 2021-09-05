using System;
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

        private void radioButtonMethodLRU_CheckedChanged(object sender, EventArgs e)
        {
            cache.SetEvictionStrategy(EvictionStrategy.LRU);
        }

        private void radioButtonMethodMRU_CheckedChanged(object sender, EventArgs e)
        {
            cache.SetEvictionStrategy(EvictionStrategy.MRU);
        }

        private void radioButtonCustom_CheckedChanged(object sender, EventArgs e)
        {
            cache.SetEvictionStrategy(
                EvictionStrategy.Custom,
                (CacheItem<string, string>[] items, int startIndex, int endIndex) =>
                    {
                        return new Random().Next(startIndex, endIndex + 1);
                    }
            );
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            cache.Clear();
        }
    }
}
