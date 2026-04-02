using PathFinder.MapGeneration;

namespace PathFinder;

public class AStarWeighted: IPathFinderForWeighted
{
    public (List<Point>, double) FindPath(string[,] map, Point start, Point destination)
    {
        var queue = new PriorityQueue();
        var costSoFar = new Dictionary<Point, double>();
        var pointNext = new Dictionary<Point, Point>();
        var visited = new List<Point>();
        
        queue.Enqueue(start, 0);
        costSoFar[start] = 0;
        pointNext[start] = start;
        int counter = 0;

        while (queue.Count > 0 && queue.TryDequeue( out var currentPoint, out var priority))
        {
            if (currentPoint.Equals(destination))
            {
                return (CheckPath(start, destination, pointNext), costSoFar[destination]);
            }

            var neighbors = MapGenerator.GetNeighboursWithDiagonals(currentPoint.Column, currentPoint.Row, map, 1, true);
            
            foreach (var point in neighbors)
            {
                double pointWeight = GetTheTime(map[point.Column, point.Row]);
                
                double newWeight = costSoFar[currentPoint] + pointWeight;
                
                if (!costSoFar.ContainsKey(point) || newWeight < costSoFar[point])
                {
                    costSoFar[point] = newWeight;

                    double y = destination.Column - point.Column;
                    double x = destination.Row - point.Row;

                    double minTimeForOneCell = 1.0 / 60.0;
                    double distToFinih = Math.Sqrt(x * x + y * y) / Math.Sqrt(2);
                    var heuristic = distToFinih * minTimeForOneCell;
                    
                    double newCost = heuristic + newWeight;
                    
                    queue.Enqueue(point, newCost);
                    pointNext[point] = currentPoint;
                }
                
            }
            
            visited.Add(currentPoint);
            counter++;

            if (counter % 10 == 0)
            {
                try
                {
                    new MapPrinter().PrintForAStarWeighted(map, visited, currentPoint, start, destination);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error");
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