using PathFinder.MapGeneration;

namespace PathFinder;

public class DjikstraUnweighted: IPathFinder
{
    public (List<Point>, int) FindPath(string[,] map, Point start, Point destination)
    {
        var queue = new PriorityQueue();
        var pointWeight = new Dictionary<Point, int>();
        var pointNext = new Dictionary<Point, Point>();
        
        queue.Enqueue(start, 0);
        pointWeight[start] = 0;
        pointNext[start] = start;

        while (queue.Count > 0)
        {
            var currentPoint = queue.Dequeue().Item1;
            
            if (currentPoint.Equals(destination))
            {
                return (CheckPath(start, destination, pointNext), pointWeight[destination]);
            }

            var neighbors = MapGenerator.GetNeighbours(currentPoint.Column, currentPoint.Row, map, 1, true);
            
            foreach (var point in neighbors)
            {
                if (!pointWeight.ContainsKey(point))
                {
                    pointWeight[point] = pointWeight[currentPoint] + 1;
                    queue.Enqueue(point, pointWeight[point]);
                    pointNext[point] = currentPoint;
                } 
                
            }
        }
        
        throw new Exception("No path found");

    }

    public List<Point> CheckPath(Point start, Point destination, Dictionary<Point, Point> dictionary)
    {
        var points = new List<Point>();
        
        var headpoint = destination;

        while (!headpoint.Equals(start))
        {
            points.Add(headpoint);
            headpoint = dictionary[headpoint];
        }
        
        points.Add(start);

        points.Reverse();

        return points;

    }
}