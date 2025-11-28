using System;
using System.Collections.Generic;

class MinHeap
{
    private List<int> heap;

    public MinHeap()
    {
        heap = new List<int>();
    }

    public MinHeap(List<int> val)
    {
        heap = val;
        heapify();
    }

    public void print()
    {
        for (int i = 0; i < heap.Count; i++)
        {
            Console.WriteLine(heap[i]);
        }
    }

    private void heapify()
    {
        for (int i = getLastNonLeafNodeIndex(heap.Count); i > -1; i--)
        {
            if (!isIndexOutOfRange(getLeftChildIndex(i)) && !isIndexOutOfRange(getRightChildIndex(i)))
            {
                int left = heap[getLeftChildIndex(i)];
                int right = heap[getRightChildIndex(i)];
                int parent = heap[i];

                if (left <= right)
                {
                    if (left <= parent)
                    {
                        heap[getLeftChildIndex(i)] = parent;
                        heap[i] = left;
                        siftDown(getLeftChildIndex(i));
                    }
                }
                else
                {
                    if (right <= parent)
                    {
                        heap[getRightChildIndex(i)] = parent;
                        heap[i] = right;
                        siftDown(getRightChildIndex(i));
                    }
                }
            }
            else if (!isIndexOutOfRange(getLeftChildIndex(i)))
            {
                int left = heap[getLeftChildIndex(i)];
                int parent = heap[i];

                if (left <= parent)
                {
                    heap[getLeftChildIndex(i)] = parent;
                    heap[i] = left;
                    siftDown(getLeftChildIndex(i));
                }
            }
        }
    }

    public int extractMin()
    {
        int result = heap[0];
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);
        siftDown(0);

        return result;
    }

    private void siftDown(int i)
    {
        if (isIndexOutOfRange(i))
        {
            return;
        }

        if (isIndexOutOfRange(getLeftChildIndex(i)) && isIndexOutOfRange(getRightChildIndex(i)))
        {
            return;
        }

        if (!isIndexOutOfRange(getLeftChildIndex(i)) && !isIndexOutOfRange(getRightChildIndex(i)))
        {
            int left = heap[getLeftChildIndex(i)];
            int right = heap[getRightChildIndex(i)];
            int parent = heap[i];

            if (left <= right)
            {
                if (left <= parent)
                {
                    heap[getLeftChildIndex(i)] = parent;
                    heap[i] = left;
                    siftDown(getLeftChildIndex(i));
                }
            }
            else
            {
                if (right <= parent)
                {
                    heap[getRightChildIndex(i)] = parent;
                    heap[i] = right;
                    siftDown(getRightChildIndex(i));
                }
            }
        }
        else if (!isIndexOutOfRange(getLeftChildIndex(i)))
        {
            int left = heap[getLeftChildIndex(i)];
            int parent = heap[i];

            if (left <= parent)
            {
                heap[getLeftChildIndex(i)] = parent;
                heap[i] = left;
                siftDown(getLeftChildIndex(i));
            }
        }
        return;
    }

    private int getLeftChildIndex(int i)
    {
        return 2 * i + 1;
    }

    private int getRightChildIndex(int i)
    {
        return 2 * i + 2;
    }

    private int getLastNonLeafNodeIndex(int len)
    {
        return (len / 2) - 1;
    }

    private bool isIndexOutOfRange(int i)
    {
        if (i >= 0 && i < heap.Count)
        {
            return false;
        }

        return true;
    }

    public int size()
    {
        return heap.Count;
    }
}