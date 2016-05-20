using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedBlackTreeNamespace
{
    public partial class Form1 : Form
    {
        RedBlackTree tree = new RedBlackTree();
        PaintingTree paintingTree;
        public Form1()
        {
            InitializeComponent();
        }
        private void DrawTree()
        {
            Graphics area = pictureBox1.CreateGraphics();
            area.Clear(Color.White);
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;
            paintingTree = tree.bfs();
            PaintingTree.Draw(paintingTree, w, h, area);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //  int temp = Convert.ToInt32(textBox1.Text);
           //  tree.insert(temp);
          //  textBox1.Text = "";
            tree.insert(23);
             tree.insert(12);
              tree.insert(65);
             tree.insert(11);
            tree.insert(17);
            tree.insert(36);
            tree.insert(77);
            tree.insert(3);
            tree.insert(27);
            tree.insert(47);
            tree.insert(69);
            tree.insert(82);
            tree.insert(35);
            tree.insert(100);
            DrawTree();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32(textBox2.Text);
            tree.For_Delete(temp);
           DrawTree();
        }
    }
}
