namespace MicKami.BinaryHeap
{
    using System;
    public class MinHeap<T> : BinaryHeap<T> where T : IComparable<T>
    {
        public MinHeap(int capacity) : base(capacity) { }
        protected override bool Compare(T a, T b) => a.CompareTo(b) < 0;
    }
}
