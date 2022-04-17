using System;
using System.Collections.Generic;

namespace Binary_Tree_Right_Side_View
{
  //
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
  }

  public class TreeNode
  {
    public int val { get; set; }
    public TreeNode left { get; set; }
    public TreeNode right { get; set; }
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
      this.val = val;
      this.left = left;
      this.right = right;
    }
  }

  public class Solution
  {
    public IList<int> RightSideView_Using_LevelOrder(TreeNode root)
    {
      var result = new List<int>();
      if (root == null) return result;
      Queue<TreeNode> q = new Queue<TreeNode>();
      q.Enqueue(root);
      // start level order
      while (q.Count > 0)
      {
        int size = q.Count;
        // when size = 0 , i.e we are at the last element in any level.
        while (size-- > 0)
        {
          var node = q.Dequeue();
          if (size == 0) result.Add(node.val);

          if (node.left != null) q.Enqueue(node.left);
          if (node.right != null) q.Enqueue(node.right);
        }
      }

      return result;
    }

    public IList<int> RightSideView_Using_Depth(TreeNode root)
    {
      var result = new List<int>();
      if (root == null) return result;
      // we have started with the depth 0 which is root node itself.
      RightSideViewHelper(root, result, 0);
      return result;
    }

    private void RightSideViewHelper(TreeNode root, List<int> result, int currentDepth)
    {
      if (root == null) return;
      // at each depth we will add one node.
      if (currentDepth == result.Count) result.Add(root.val);
      // as we need to show the right view so we have started traversing from right node.
      RightSideViewHelper(root.right, result, currentDepth + 1);
      // at any depth if the right most node is missing it will consider left node also for the rigtt view
      RightSideViewHelper(root.left, result, currentDepth + 1);
    }
  }
}
