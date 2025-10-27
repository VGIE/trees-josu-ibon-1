using Lists;
using System;
using System.Collections;

public class ListNode<T>
{
    public T Value;
    public ListNode<T> Next = null;

    public ListNode<T> Previous = null;
    

    public ListNode(T value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class List<T> : IList<T>
{
    ListNode<T> First = null;
    ListNode<T> Last = null;

    int m_numItems = 0;

    public override string ToString()
    {
        ListNode<T> node = First;
        string output = "[";

        while (node != null)
        {
            output += node.ToString() + ",";
            node = node.Next;
        }
        output = output.TrimEnd(',') + "] " + Count() + " elements";

        return output;
    }

    public int Count()
    {
        //TODO #1: return the number of elements on the list

        return m_numItems;

    }

    public T Get(int index)
    {
        //TODO #2: return the element on the index-th position. O if the position is out of bounds

        ListNode<T> node = First;
        int i = 0;
        if (index < 0)
        {
            return default;
        }
        while (node != null && index > i)
        {
            node = node.Next;
            i++;
        }
        if (index == i)
        {
            return node.Value;
        }

        return default;

    }

    public void Add(T value)
    {
        //TODO #3: add a new integer to the end of the list

        ListNode<T> node = First;
        if (node == null)
        {
            First = new ListNode<T>(value);
            Last = First;
            m_numItems++;
        }
        else
        {
            node = Last;
            node.Next = new ListNode<T>(value);
            ListNode<T> anterior = Last;
            Last = node.Next;
            Last.Previous = anterior;
            m_numItems++;
        }

    }

    public T Remove(int index)
    {
        //TODO #4: remove the element on the index-th position. Do nothing if position is out of bounds
        ListNode<T> node = First;
        T eliminado = default;
        if (node == null)
        {
            return eliminado;
        }

        if (index == 0)
        {
            eliminado = First.Value;
            First = First.Next;
            m_numItems--;
            if (First != null)
            {
                First.Previous = null;
            }
            return eliminado;


        }
        int i = 0;
                if (index == m_numItems - 1)
        {
            Last.Previous.Next = null;
            eliminado = Last.Value;
            Last = Last.Previous;
            m_numItems--;
        }

        else
        {
        while (node != null && index - 1 > i)
        {
            node = node.Next;
            i++;


        }

            if (node != null && node.Next != null && node.Next.Next != null)
            {
                eliminado = node.Next.Value;
                node.Next = node.Next.Next;
                m_numItems--;
                node.Next.Previous = node;
            }


        }
 return eliminado;

    }

    public void Clear()
    {
        //TODO #5: remove all the elements on the list
        First = null;
        m_numItems = 0;
         
        
    }

    public IEnumerator GetEnumerator()
    {
        //TODO #6 : Return an enumerator using "yield return" for each of the values in this list
            ListNode<T> node = First;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        
    }
}