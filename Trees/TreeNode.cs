
using System;
using Lists;

namespace Trees
{
    public class TreeNode<T>
    {
        private T Value;
        //TODO #1: Declare a member variable called "Children" as a list of TreeNode<T> objects
        private List<TreeNode<T>> Children;

        public TreeNode(T value)
        {
            //TODO #2: Initialize member variables/attributes
            Value = value;
            Children = new List<TreeNode<T>>();


        }

        public string ToString(int depth, int index)
        {
            //TODO #3: Uncomment the code below
            
            string output = null;
            string leftSpace = null;
            for (int i = 0; i < depth; i++) leftSpace += " ";
            if (leftSpace != null) leftSpace += "->";

            output += $"{leftSpace}[{Value}]\n";

            for (int childIndex = 0; childIndex < Children.Count(); childIndex++)
            {
                TreeNode<T> child = Children.Get(childIndex);
                output += child.ToString(depth + 1, childIndex);
            }
            return output;
            
                  }

        public TreeNode<T> Add(T value)
        {
            //TODO #4: Add a new instance of class GenericTreeNode<T> with Value=value. Return the instance we just created
            TreeNode<T> child = new TreeNode<T>(value);
            Children.Add(child);
            return child;

            
            
            
        }

        public int Count()
        {
            //TODO #5: Return the total number of elements in this tree
            if (this == null)
            {
                return 0;
            }
            int numero = 1;
            TreeNode<T> child = null;
            for (int i = 0; i < Children.Count(); i++)
            {
                child = Children.Get(i);
                numero += child.Count();
            }
            return numero;
            
        }

        public int Height()
        {
            //TODO #6: Return the height of this tree
            if (Children.Count() == 0)
            {
                return -1;
            }
            
             if (Children.Count() == 1)
    {
          return 0; 
    }

      

            TreeNode<T> child = null;
            int height = 0;
            for (int i = 0; i < Children.Count(); i++)
            {
                if (Children.Get(i).Height() > height)
                {
                    height = Children.Get(i).Height();
                }
                child = Children.Get(i);

            }
               return  1+ height;
            
        }

        

        
        public void Remove(T value)
        {
            //TODO #7: Remove the child node that has Value=value. Apply recursively
            for (int i = 0; i < Children.Count(); i++)
            {
                if (Children.Get(i).Value.Equals(value))
                {
                    Children.Remove(i);
                }
                else
                {
                    Children.Get(i).Remove(value);
                }

                
            }
        }

        public TreeNode<T> Find(T value)
        {
            //TODO #8: Return the node that contains this value (it might be this node or a child). Apply recursively
            if (Value.Equals(value))
            {
                return this;
            }
            for (int i = 0; i < Children.Count(); i++)
            {
                if (Children.Get(i).Value.Equals(value))
                {
                    return Children.Get(i);
                }
                else
                {   
         
            TreeNode<T> eliminado = Children.Get(i).Find(value); 
                if (eliminado != null)
                {
                return eliminado; 
                }

                }


            }
            return null;

        }


        public void Remove(TreeNode<T> node)
        {
            //TODO #9: Same as #6, but this method is given the specific node to remove, not the value
            for (int i = 0; i < Children.Count(); i++)
            {
                if (Children.Get(i).Equals(node))
                {
                    Children.Remove(i);
                }
                else
                {
                    Children.Get(i).Remove(node);
                }

                
            }
        }
    }
}