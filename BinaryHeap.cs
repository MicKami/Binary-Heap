namespace MicKami.BinaryHeap
{
    using System;
    public abstract class BinaryHeap<T> where T : IComparable<T>
    {
        private readonly T[] elements;    
        public int Count { get; private set; }        
        public int Capacity { get; private set; }
        public BinaryHeap(int capacity)
        {
            Capacity = capacity;
            elements = new T[capacity];
        }
        
        protected abstract bool Compare(T a, T b);
        public bool Contains(T element) => Array.Exists(elements, (x) =>
        {
            return (x != null && x.Equals(element));
        });

        private int LeftChildIndex(int index) => (index * 2) + 1;
        private int RightChildIndex(int index) => (index * 2) + 2;
        private int ParentIndex(int index) => (index - 1) / 2;


        private void MoveDown(int index)
        {
            int L = LeftChildIndex(index);
            int R = RightChildIndex(index);
            if (L < Count)
            {
                int minIndex = L;
                if ((R < Count) && !Compare(elements[L], elements[R]))
                {
                    minIndex = R;
                }
                if (!Compare(elements[index], elements[minIndex]))
                {
                    Swap(index, minIndex);
                    MoveDown(minIndex);
                }
            }
        }        
        private void MoveUp(int index)
        {
            int parentIndex = ParentIndex(index);
            if (Compare(elements[index], elements[parentIndex]))
            {
                Swap(index, parentIndex);
                MoveUp(parentIndex);
            }
        }


        public T Peek() => elements[0];
        
        public T Pop()
        {
            T first = elements[0];
            elements[0] = elements[Count - 1];
            Count--;
            MoveDown(0);
            return first;
        }
        
        public void Push(T element)
        {
            elements[Count] = element;
            MoveUp(Count);
            Count++;
        }
        
        private void Swap(int currentIndex, int target)
        {
            T temp = elements[target];
            elements[target] = elements[currentIndex];
            elements[currentIndex] = temp;
        }
    }
}
