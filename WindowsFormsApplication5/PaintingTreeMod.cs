using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTreeNamespace
{
    public class NodeAndPoint
    {
        public Point point;
        public TreeNode node;

        public NodeAndPoint(Point point, TreeNode node)
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
        public List< List < NodeAndPoint > > _listOfLevel; //индексами являются уровни
        static SolidBrush NodeRedBrush;
        static SolidBrush NodeBlackBrush;
        static SolidBrush textBrush;
        static Pen linePen;
        static Font font;
        public static int diametr = 30;
        static Graphics _area;
        public PaintingTree(int capacity)
        {
            _listOfLevel = new List<List<NodeAndPoint>>(capacity);
            for (int i = 0; i <= capacity; i++)
            {
                List<NodeAndPoint> list = new List<NodeAndPoint>();
                _listOfLevel.Add(list);
            }

        }
        public void AddNodeToList(TreeNode node, int level)
        {
            Point point = new Point(0);
            NodeAndPoint nap = new NodeAndPoint(point, node);
            _listOfLevel[level].Add(nap);
        }

        public int getCountLevel()
        {
            return _listOfLevel.Count;
        }

        public List<NodeAndPoint> getLevel(int level)
        {
            return _listOfLevel[level];
        }
        private static void Initial(Graphics area)
        {
            NodeRedBrush = new SolidBrush(Color.Red);
            NodeBlackBrush = new SolidBrush(Color.Black);
            textBrush = new SolidBrush(Color.WhiteSmoke);
            linePen = new Pen(Color.Black);
            font = new Font(FontFamily.GenericMonospace, 12);
            _area = area;
        }

        public static void Draw(PaintingTree showtree, int width, int height, Graphics area)
        {

            int currentHeight = 0;
            Initial(area);

            int countLevel = showtree.getCountLevel();
            for (int i = 0; i < countLevel; i++)
            {
                List<NodeAndPoint> currentLevel = showtree.getLevel(i);
                int countNode = currentLevel.Count;
                int interval = width / (countNode + 1);

                for (int j = 0; j < countNode; j++)
                {
                    #region DrawNode
                    Rectangle rect = new Rectangle((j + 1) * interval, currentHeight, diametr, diametr);
                    if(currentLevel[j].node.color==TreeColor.red)
                         area.FillEllipse(NodeRedBrush, rect);
                    else
                        area.FillEllipse(NodeBlackBrush, rect);

                    area.DrawEllipse(linePen, rect);
                    #endregion

                    currentLevel[j].point = new Point((j + 1) * interval, currentHeight);
                    String data = currentLevel[j].getData().ToString();
                    area.DrawString(data, font, textBrush, currentLevel[j].point);


                    LineToParent(currentLevel[j].node,currentLevel, showtree, j);

                }

                currentHeight += diametr * 2;
            }
        }

        private static void DrawNode()
        {

        }
        private static void LineToParent( TreeNode Current ,List<NodeAndPoint> currentLevel, PaintingTree showtree, int index)
        {
            int indexParentLevel = (int)(currentLevel[index].node.level - 1);

            if (indexParentLevel != -1)
            {
                List<NodeAndPoint> parentLevel = showtree.getLevel(indexParentLevel);
                foreach (var elem in parentLevel)
                    if (elem.node == Current.parent)
                    {
                        int parentX = elem.point.X + diametr / 2;
                        int parentY = elem.point.Y + diametr;
                        Point parentPoint = new Point(parentX, parentY);

                        int childX = currentLevel[index].point.X + diametr / 2;
                        int childY = currentLevel[index].point.Y;

                        Point childPoint = new Point(childX, childY);

                        _area.DrawLine(linePen, parentPoint, childPoint);
                        break;
                    }
            }

        }
    }
}
