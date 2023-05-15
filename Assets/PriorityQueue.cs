/*
 * Fine... I'll do it myself
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PriorityQueue<TItem>
where TItem: IComparable<TItem>
{

    private SortedSet<TItem> queue;

    public PriorityQueue() {
        queue = new SortedSet<TItem>();
    }

    public void Enqueue(TItem item) {
        queue.Add(item);
    }

    public TItem Dequeue() {
        TItem item = queue.Max;
        queue.Remove(item);
        return item;
    }

    public int Count() {
        return queue.Count;
    }

    public bool IsEmpty() {
        return Count() == 0;
    }

    public void Clear() {
        queue = new SortedSet<TItem>();
    }

}
