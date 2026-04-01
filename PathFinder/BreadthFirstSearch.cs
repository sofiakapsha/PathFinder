using PathFinder.MapGeneration;

namespace PathFinder;

public class BreadthFirstSearch : IPathFinder
{
    public (List<Point>, int) FindPath(string[,] map, Point start, Point destination)
    {
        var queue = new Queue<Point>();
        var nextPoints = new Dictionary<Point, Point>();

        var visitedNodes = 0;

        queue.Enqueue(start);
        nextPoints[start] = start;

        while (queue.Count > 0)
        {
            var currentPoint = queue.Dequeue();
            visitedNodes++;
            
            if (currentPoint.Equals(destination))
            {
                return (CheckPath(start, destination, nextPoints), visitedNodes);
            }

            var neighbors = MapGenerator.GetNeighbours(currentPoint.Column, currentPoint.Row, map, 1, true);
            
            foreach (var point in neighbors)
            {
                if (!nextPoints.ContainsKey(point))
                {
                    queue.Enqueue(point);
                    nextPoints[point] = currentPoint;
                } 
                
            }
        }
        
        throw new Exception("No path found");

    }

    public List<Point> CheckPath(Point start, Point destination, Dictionary<Point, Point> dictionary)
    {
        var points = new List<Point>();
        
        var headPoint = destination;

        while (!headPoint.Equals(start))
        {
            points.Add(headPoint);
            headPoint = dictionary[headPoint];
        }
        
        points.Add(start);

        points.Reverse();

        return points;

    }
}