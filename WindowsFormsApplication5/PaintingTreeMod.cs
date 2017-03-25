using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTreeNamespace
{
    public class xOy
    {
        public Point point;
        public TreeNode node;

        public xOy(Point point, TreeNode node)
        {
            this.point = point;
            this.node = node;
        }

        public int getData()
        {
            return node.data;
        }
    }

    public class PaintingTree
    {
        public List< List < xOy > > _listOfLevel; //индексами являются уровни
        static TreeNode CurrentNodeForSearch;
        static SolidBrush NodeRed;
        static SolidBrush NodeBlack;
        static Pen CurrentNode;
        static SolidBrush text;
        static Pen line;
        static Font font;
        public static int diametr;
        static Graphics canvas;
        public PaintingTree(int capacity,TreeNode cur)
        {
            _listOfLevel = new List<List<xOy>>(capacity);
            for (int i = 0; i <= capacity; i++)
            {
                List<xOy> list = new List<xOy>();
                _listOfLevel.Add(list);
            }
            CurrentNodeForSearch = cur;
        }
        public void AddNodeToList(TreeNode node, int level)
        {
            Point point = new Point(0);
            xOy nap = new xOy(point, node);
            _listOfLevel[level].Add(nap);
        }

        public int getCountLevel()
        {
            return _listOfLevel.Count;
        }

        public List<xOy> getLevel(int level)
        {
            return _listOfLevel[level];
        }
        private static void Initial(Graphics Canvas)
        {
            NodeRed = new SolidBrush(Color.Red);
            NodeBlack = new SolidBrush(Color.Black);
            CurrentNode = new Pen(Color.FloralWhite);
            CurrentNode.Width = 2;
            text = new SolidBrush(Color.WhiteSmoke);
            line = new Pen(Color.Black);
            font = new Font(FontFamily.GenericMonospace, 12);
            canvas = Canvas;
            diametr = 30;
        }

        public static void Draw(PaintingTree showtree, int width, int height, Graphics canvas)
        {
            canvas.Clear(Color.DarkGray);
            Initial(canvas);
            int currentHeight = 0;
            for (int i = 0; i < showtree.getCountLevel(); i++)
            {
                List<xOy> currentLevel = showtree.getLevel(i);
                int countNode = currentLevel.Count;
                int interval = width / (countNode + 1);

                for (int j = 0; j < countNode; j++)
                {
                    
                    Rectangle rect = new Rectangle((j + 1) * interval, currentHeight, diametr, diametr);
                    if(currentLevel[j].node.color==TreeColor.red)
                         canvas.FillEllipse(NodeRed, rect);
                    else
                        canvas.FillEllipse(NodeBlack, rect);
                    canvas.DrawEllipse(line, rect);
                    if (currentLevel[j].node == CurrentNodeForSearch)
                        canvas.DrawEllipse(CurrentNode, rect);



                    currentLevel[j].point = new Point((j + 1) * interval, currentHeight);
                    String data = currentLevel[j].getData().ToString();
                    canvas.DrawString(data, font, text, currentLevel[j].point);


                    LineToParent(currentLevel[j].node,currentLevel, showtree, j);

                }

                currentHeight += diametr * 2;
            }
        }

        private static void LineToParent( TreeNode Current ,List<xOy> currentLevel, PaintingTree showtree, int index)
        {
            int indexParentLevel = (int)(currentLevel[index].node.level - 1);

            if (indexParentLevel != -1)
            {
                List<xOy> parentLevel = showtree.getLevel(indexParentLevel);
                foreach (var elem in parentLevel)
                    if (elem.node == Current.parent)
                    {
                        int parentX = elem.point.X + diametr / 2;
                        int parentY = elem.point.Y + diametr;
                        Point parentPoint = new Point(parentX, parentY);

                        int childX = currentLevel[index].point.X + diametr / 2;
                        int childY = currentLevel[index].point.Y;

                        Point childPoint = new Point(childX, childY);

                        canvas.DrawLine(line, parentPoint, childPoint);
                        break;
                    }
            }

        }
    }
}
