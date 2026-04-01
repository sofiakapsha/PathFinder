using PathFinder.MapGeneration;

namespace PathFinder;

public class AStarUnweighted: IPathFinder
{
    public (List<Point>, int) FindPath(string[,] map, Point start, Point destination)
    {
        var queue = new PriorityQueue();
        var costSoFar = new Dictionary<Point, int>();
        var pointNext = new Dictionary<Point, Point>();

        int counter = 0;
        queue.Enqueue(start, 0);
        costSoFar[start] = 0;
        pointNext[start] = start;

        while (queue.Count > 0 && queue.TryDequeue( out var currentPoint, out var priority))
        {
            counter++;
            
            if (currentPoint.Equals(destination))
            {
                return (CheckPath(start, destination, pointNext), counter);
            }

            var neighbors = MapGenerator.GetNeighbours(currentPoint.Column, currentPoint.Row, map, 1, true);
            
            foreach (var point in neighbors)
            {
                int pointWeight = costSoFar[currentPoint] + 1;
                
                if (!costSoFar.ContainsKey(point) || pointWeight < costSoFar[point])
                {
                    costSoFar[point] = pointWeight;
                    
                    int heuristic = Math.Abs(destination.Column - point.Column) + Math.Abs(destination.Row - point.Row);
                    int newcost = heuristic + pointWeight;
                    
                    queue.Enqueue(point, newcost);
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