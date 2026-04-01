namespace PathFinder.MapGeneration;

public class MapPrinter
{
    public void PrintForDijkstraWeighted(string[,] maze, List<Point> path, Point start, Point destination)
    {
        PrintTopLine(maze);
        for (var row = 0; row < maze.GetLength(1); row++)
        {
            Console.Write($"{row}\t");
            for (var column = 0; column < maze.GetLength(0); column++)
            {
                var point = new Point(column, row);
                if (path.Contains(point))
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    
                    if (point.Equals(start)) Console.Write("A");
                    else if (point.Equals(destination)) Console.Write("B");
                    else Console.Write(maze[column, row]);
                    
                    Console.ResetColor();
                }
                else Console.Write(maze[column, row]);
            }
            Console.WriteLine();
        }
    }
    public void PrintForAStarWeighted(string[,] maze, List<Point> visited, Point current, Point start, Point destination)
    {
        Console.SetCursorPosition(0, 0);
        Console.CursorVisible = false;
        
        PrintTopLine(maze);
        for (var row = 0; row < maze.GetLength(1); row++)
        {
            Console.Write($"{row}\t");
            for (var column = 0; column < maze.GetLength(0); column++)
            {
                var point = new Point(column, row);
                
                if (point.Equals(start))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("A");
                    Console.ResetColor();
                }
                
                else if (point.Equals(destination))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("B");
                    Console.ResetColor();
                }
                else if (point.Equals(current))
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("?");
                    Console.ResetColor();
                }

                else if (visited.Contains(point))
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.Black;
                    
                    Console.Write(maze[column, row]);
                    
                    Console.ResetColor();
                }
                else Console.Write(maze[column, row]);
            }
            Console.WriteLine();
        }
        Thread.Sleep(10);
    }
    
    public void PrintForUnweighted(string[,] maze, List<Point> path, Point start, Point destination)
    {
        PrintTopLine(maze);
        for (var row = 0; row < maze.GetLength(1); row++)
        {
            Console.Write($"{row}\t");
            for (var column = 0; column < maze.GetLength(0); column++)
            {
                var point = new Point(column, row);
                if (point.Equals(start)) Console.Write("A");
                else if (point.Equals(destination)) Console.Write("B");
                else if (path.Contains(point)) Console.Write(".");
                else Console.Write(maze[column, row]);
            }
            Console.WriteLine();
        }
    }
    
    private void PrintTopLine(string [,] maze)
    {
        Console.Write($" \t");
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            Console.Write(i % 10 == 0? i / 10 : " ");
        }
    
        Console.Write($"\n \t");
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            Console.Write(i % 10);
        }
    
        Console.WriteLine("\n");
    }
}