// special thanks to @Virenbar!! although I was close, this one was too hard to get without help XD https://github.com/Virenbar/AdventOfCode/blob/master/AdventOfCode2021/AdventOfCode2021/Days/Day09.cs
var input = File.ReadAllLines(@"..\..\..\input.txt").ToList();
var inputTest = File.ReadAllLines(@"..\..\..\inputTest.txt").ToList();

var scan = new SmokeBasin(input);
var part1 = scan.RiskLevels; // test: 15, actual: 562
var part2 = scan.TopBasinsResult; //test: 1134, actual: 1076922

Console.WriteLine("Part One: {0}\nPart Two: {1}", part1, part2);

internal class SmokeBasin {
	private readonly List<HashSet<Point>> Basins = new();
    private readonly Dictionary<Point, int> LowPoints = new ();
    private readonly Dictionary<Point, int> Points = new ();

    private record Point(int X, int Y);
	private int this[Point P] {
		get => Points.ContainsKey(P) ? Points[P] : 10;
		set => Points[P] = value;
	}
	private static List<Point> GetSurroundings(Point p) => new() {
		new Point(p.X + 1, p.Y),
		new Point(p.X - 1, p.Y),
		new Point(p.X, p.Y + 1),
		new Point(p.X, p.Y - 1)
	};

	public SmokeBasin(List<string> heightmap) {
        for (int Y = 0; Y < heightmap.Count; Y++) {
			for (int X = 0; X < heightmap[Y].Length; X++) {
				this[new Point(X, Y)] = int.Parse(heightmap[Y][X].ToString());
			}
		}
		FindLowPoints();
		FindBasins();
    }
	public int RiskLevels => LowPoints.Sum(p => p.Value + 1);
	public int TopBasinsResult => Basins
		.OrderByDescending(basin => basin.Count)
		.Take(3)
		.Aggregate(1, (prev, basin) => prev * basin.Count);

	public void FindBasins() {
		foreach (var (key, val) in LowPoints) {
			if (Basins.Any(b => b.Contains(key))) { continue; }
			HashSet<Point> basin = new();
			List<Point> newPoints = new() { key };
			while (newPoints.Count > 0) {
				newPoints.ForEach(point => basin.Add(point));
				var adjacent = newPoints
					.SelectMany(newPoint => GetSurroundings(newPoint))
					.Distinct()
					.Where(point => !basin.Contains(point) && this[point] < 9)
					.ToList();
				newPoints.Clear();
				newPoints.AddRange(adjacent);
			}
			Basins.Add(basin);
		}
	}

	public void FindLowPoints() {
		foreach (var (point, height) in Points) {
			var adjacent = GetSurroundings(point);
			var isLow = adjacent.All(p => this[p] > height);
			if (isLow) { LowPoints[point] = height; }
		}
	}
}