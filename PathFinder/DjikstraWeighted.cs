using PathFinder.MapGeneration;

namespace PathFinder;

public class DjikstraWeighted: IPathFinderForWeighted
{
    public (List<Point>, double) FindPath(string[,] map, Point start, Point destination)
    {
        var queue = new PriorityQueue();
        var pointWeight = new Dictionary<Point, double>();
        var pointNext = new Dictionary<Point, Point>();
        
        queue.Enqueue(start, 0);
        pointWeight[start] = 0;
        pointNext[start] = start;

        while (queue.Count > 0 && queue.TryDequeue( out var currentPoint, out var priority))
        {
            if (pointWeight[currentPoint] < priority) continue;
            
            if (currentPoint.Equals(destination))
            {
                return (CheckPath(start, destination, pointNext), pointWeight[destination]);
            }

            var neighbors = MapGenerator.GetNeighbours(currentPoint.Column, currentPoint.Row, map, 1, true);
            
            foreach (var point in neighbors)
            {
                double weightAtPoint = GetTheTime(map[point.Column, point.Row]);
                
                var newWeight = pointWeight[currentPoint] + weightAtPoint;
                
                if (!pointWeight.ContainsKey(point) || newWeight < pointWeight[point])
                {
                    pointWeight[point] = newWeight;
                    queue.Enqueue(point, pointWeight[point]);
                    pointNext[point] = currentPoint;
                }
                
            }
        }
        
        throw new Exception("No path found");

    }
    
    private double GetTheTime(string weightInCase)
    {
        int pointWeight = int.TryParse(weightInCase, out int weight) ? weight : 1;
        double v = 60 - (pointWeight - 1) * 6;

        return 1.0 / v;
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