using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTreeNamespace
{
    public enum TreeColor { red, black };
    public class TreeNode
    {
       public TreeNode left;
       public TreeNode right;
       public TreeNode parent;
       public int data;
       public TreeColor color;
       public int level;
       public bool visited;

      public TreeNode( int data, TreeColor color,int lvl) {
	    this.data = data;
	    this.color = color;
	    left = right = null;
        level = lvl;
        visited = false;
      }
      public int get_data(){
        return data;
       }
        public TreeNode getAdjUnvisitedVertex()
        {
            if (this.left !=RedBlackTree.NIL)
            {
                if (!this.left.visited)
                {
                    this.left.visited = true;
                    return this.left;
                }
                else
                {
                    if (this.right != RedBlackTree.NIL)
                    {
                        if (!this.right.visited)
                        {
                            this.right.visited = true;
                            return this.right;
                        }
                    }
                }
            }
            else
            {
                if (this.right != RedBlackTree.NIL)
                {
                    if (!this.right.visited)
                    {
                        this.right.visited = true;
                        return this.right;
                    }
                }
            }
            return RedBlackTree.NIL;
        }
    }
}
