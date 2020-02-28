namespace MicKami.BinaryHeap
{
    using System;
    public class MaxHeap<T> : BinaryHeap<T> where T : IComparable<T>
    {
        public MaxHeap(int capacity) : base(capacity) { }
        protected override bool Compare(T a, T b) => a.CompareTo(b) > 0;
    }
}
