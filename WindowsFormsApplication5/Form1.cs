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
            Graphics canvas = pictureBox1.CreateGraphics();
            paintingTree = tree.bfs();
            PaintingTree.Draw(paintingTree, pictureBox1.Width, pictureBox1.Height, canvas);
        }

        private void button1_Click(object sender, EventArgs e)
        {
             int temp = Convert.ToInt32(textBox1.Text);
             tree.insert(temp);
             textBox1.Text = "";
            DrawTree();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32(textBox2.Text);
            tree.For_Delete(temp);
           DrawTree();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int Min= Convert.ToInt32(textBox4.Text);
            int Max=Convert.ToInt32(textBox5.Text);
             for (int i=0; i < Convert.ToInt32(textBox3.Text); i++)
                tree.insert(rand.Next(Min,Max));
            DrawTree();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int find = Convert.ToInt32(textBox6.Text);
            tree.For_Search(find);
            DrawTree();
        }
    }
}
