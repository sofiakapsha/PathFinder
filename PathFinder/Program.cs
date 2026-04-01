using PathFinder;
using PathFinder.MapGeneration;

var optionsToGenerateForWeighted = new MapGeneratorOptions()
{
    Height = 20,
    Width = 60,
    Noise = .1f,
    AddTraffic = true,
    TrafficSeed = 1234
};

var generatorWeighted = new MapGenerator(optionsToGenerateForWeighted);
string[,]? mapWeighted = generatorWeighted.Generate();

var startWeighted = new Point(0, 0);
var destinationWeighted = new Point(48, 18);

var aStarWeighted = new AStarWeighted();
try
{
    var pathAWeighted = aStarWeighted.FindPath(mapWeighted, startWeighted, destinationWeighted);
    Console.WriteLine();
    Console.WriteLine($"Time needed for path is {pathAWeighted.Item2} hours with A Star");
    Console.WriteLine();
    new MapPrinter().PrintForDijkstraWeighted(mapWeighted, pathAWeighted.Item1, startWeighted, destinationWeighted);
}
catch (Exception exception)
{
    Console.WriteLine($"Error - {exception}");
}

var dijkstraWeighted = new DjikstraWeighted();
try
{
    var pathDijkstraweighted = dijkstraWeighted.FindPath(mapWeighted, startWeighted, destinationWeighted);
    Console.WriteLine();
    Console.WriteLine($"Time needed for path is {pathDijkstraweighted.Item2} hours with Dijkstra");
    Console.WriteLine();
    new MapPrinter().PrintForDijkstraWeighted(mapWeighted, pathDijkstraweighted.Item1, startWeighted,
        destinationWeighted);
}
catch (Exception exception)
{
    Console.WriteLine($"Error - {exception}");
}


var optionsToGenerateForUnweighted = new MapGeneratorOptions()
{
    Height = 10,
    Width = 100,
    AddTraffic = false
};

var generator = new MapGenerator(optionsToGenerateForUnweighted);
string[,]? mapUnweighted = generator.Generate();

var startUnweighted = new Point(0, 0);
var destinationUnweighted = new Point(88, 8);

var BFS = new BreadthFirstSearch();
try
{
    var pathBFS = BFS.FindPath(mapUnweighted, startUnweighted, destinationUnweighted);
    Console.WriteLine();
    Console.WriteLine("BFS");
    Console.WriteLine();
    new MapPrinter().PrintForUnweighted(mapUnweighted, pathBFS.Item1, startUnweighted, destinationUnweighted);
}
catch (Exception exception)
{
    Console.WriteLine($"Error - {exception}");
}

var dijktstra = new DjikstraUnweighted();
try
{
    var pathDijkstraUn = dijktstra.FindPath(mapUnweighted, startUnweighted, destinationUnweighted);
    Console.WriteLine();
    Console.WriteLine("Dijkstra");
    Console.WriteLine();
    new MapPrinter().PrintForUnweighted(mapUnweighted, pathDijkstraUn.Item1, startUnweighted, destinationUnweighted);
}
catch (Exception exception)
{
    Console.WriteLine($"Error - {exception}");
}

var AstarUnweighted = new AStarUnweighted();
try
{
    var pathAUn = AstarUnweighted.FindPath(mapUnweighted, startUnweighted, destinationUnweighted);
    Console.WriteLine();
    Console.WriteLine($"A Star");
    Console.WriteLine();
    new MapPrinter().PrintForUnweighted(mapUnweighted, pathAUn.Item1, startUnweighted, destinationUnweighted);
}
catch (Exception exception)
{
    Console.WriteLine($"Error - {exception}");
}
