using PathFinder;
using PathFinder.MapGeneration;

var optionsToGenerateForWeighted = new MapGeneratorOptions()
{
    Height = 35,
    Width = 90,
    Noise = .1f,
    AddTraffic = true,
    TrafficSeed = 1234
};

var generatorWeighted = new MapGenerator(optionsToGenerateForWeighted);
string[,]? mapWeighted = generatorWeighted.Generate();

var startWeighted = new Point(0, 0);
var destinationWeighted = new Point(88, 20);

var aStarWeighted = new AStarWeighted();
var pathAWeighted = aStarWeighted.FindPath(mapWeighted, startWeighted, destinationWeighted);
Console.WriteLine();
Console.WriteLine($"Time needed for path is {pathAWeighted.Item2} hours");
Console.WriteLine();
new MapPrinter().PrintForDijkstraWeighted(mapWeighted, pathAWeighted.Item1, startWeighted, destinationWeighted);

var dijkstraWeighted = new DjikstraWeighted();
var pathDijkstraweighted = dijkstraWeighted.FindPath(mapWeighted, startWeighted, destinationWeighted);
Console.WriteLine();
Console.WriteLine($"Time needed for path is {pathDijkstraweighted.Item2} hours");
Console.WriteLine();
new MapPrinter().PrintForDijkstraWeighted(mapWeighted, pathDijkstraweighted.Item1, startWeighted, destinationWeighted);


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
var pathBFS = BFS.FindPath(mapUnweighted, startUnweighted, destinationUnweighted);
new MapPrinter().PrintForUnweighted(mapUnweighted, pathBFS.Item1, startUnweighted, destinationUnweighted);

var dijktstra = new DjikstraUnweighted();
var pathDijkstraUn = dijktstra.FindPath(mapUnweighted, startUnweighted, destinationUnweighted);
new MapPrinter().PrintForUnweighted(mapUnweighted, pathDijkstraUn.Item1, startUnweighted, destinationUnweighted);

var AstarUnweighted = new AStarUnweighted();
var pathAUn = AstarUnweighted.FindPath(mapUnweighted, startUnweighted, destinationUnweighted);
new MapPrinter().PrintForUnweighted(mapUnweighted, pathAUn.Item1, startUnweighted, destinationUnweighted);
