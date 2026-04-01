namespace PathFinder.MapGeneration;

public class PriorityQueue
{
    private List<(Point, double)> _points = new List<(Point, double)>();

    public int Count => _points.Count;

    public bool TryDequeue(out Point point, out double priority)
    {
        point = default;
        priority = default;
        if (Count <= 0) return false;

        var pair = Dequeue();
        point = pair.Item1;
        priority = pair.Item2;
        return true;
    }

    public void Enqueue(Point point, double priority)
    {
        _points.Add((point, priority));

        int index = Count - 1;

        while (index > 0)
        {
            int parent = (index - 1) / 2;
            if(_points[index].Item2 >= _points[parent].Item2) break;
            
            Swap(index, parent);
            index = parent;
        }
       
    }

    public (Point, double) Dequeue()
    {
        var head = _points[0];

        _points[0] = _points[Count - 1];
        _points.RemoveAt(Count - 1);
        
        if(Count > 0) Heapify(0);

        return head;
    }

    private void Heapify(int index)
    {
        while (true)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int smallest = index;

            if (left < Count && _points[left].Item2 < _points[smallest].Item2)
            {
                smallest = left;
            }
            if (right < Count && _points[right].Item2 < _points[smallest].Item2)
            {
                smallest = right;
            }
            if (smallest == index) break;
            
            Swap(index, smallest);
            index = smallest;
        }
    }

    private void Swap(int i, int j)
    {
        var point = _points[i];
        _points[i] = _points[j];
        _points[j] = point;
    }


}