# Doodle Maps Path Finder — BFS, Dijkstra & A* (C#)

A console application for pathfinding on a procedurally generated 2D grid map, 
implementing and comparing several classic graph search algorithms.

## Features

- **Breadth-First Search (BFS)** — baseline shortest path search on an unweighted grid.
- **Dijkstra's Algorithm** — weighted and unweighted versions, accounting for 
  traffic-based edge costs.
- **A\* Algorithm** — weighted and unweighted versions, using Euclidean distance 
  heuristic with diagonal movement support.
- **Custom Priority Queue** — implemented from scratch using a min-heap.
- **Traffic simulation** — procedurally generated traffic zones affect travel speed 
  per cell (from 60 km/h down to 12 km/h); total trip time is calculated based on 
  the resulting path.
- **Path visualization** — custom map printer showing start (`A`), destination (`B`), 
  and the path between them, plus a live animation of the A* search process.
- **Diagonal movement support** with adjusted cost calculation for near-equal-cost cells.
- **Unit tests** covering all pathfinding implementations.

## Tech Stack

C#, .NET

## How to Run

```bash
dotnet run --project PathFinder
```

The program generates a random map and runs the selected algorithm, printing 
the resulting path, number of visited nodes, and total elapsed/travel time.

### Example map generation options (in code)

```csharp
var generator = new MapGenerator(new MapGeneratorOptions()
{
    Height = 35,
    Width = 90,
    Noise = 0.1f,
    AddTraffic = true,
    TrafficSeed = 1234
});
```

## Project Structure

- `MapGeneration/` — procedural map generator
- `BreadthFirstSearch.cs` — BFS implementation
- `DijkstraWeighted.cs` / `DijkstraUnweighted.cs` — Dijkstra's algorithm
- `AStarWeighted.cs` / `AStarUnweighted.cs` — A* algorithm
- `PriorityQueue.cs` — custom min-heap-based priority queue
- `MapPrinter.cs` — console visualization and animation
- `PathFinderTests/` — unit tests

## Author

Solo project completed as part of the CS210 Algorithms for Engineers course.
