using PathFinder.MapGeneration;

namespace PathFinder;

public interface IPathFinder
{
    public (List<Point>, int) FindPath(string[,] map, Point start, Point destination);
    
}

public interface IPathFinderForWeighted
{
    public (List<Point>, double) FindPath(string[,] map, Point start, Point destination);
}