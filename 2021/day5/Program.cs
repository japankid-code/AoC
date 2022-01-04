// thanks to this, glancing at it helped refactoring https://github.com/DjordjeNedovic/Advent-of-Code/blob/main/Advent-of-Code-2021/day-05/Program.cs

var linesSmall = File.ReadLines(@"C:\Users\jrank\Documents\GitHub\japankid-code\AoC\2021\day5\inputSmall.txt").ToList();
var lines = File.ReadLines(@"C:\Users\jrank\Documents\GitHub\japankid-code\AoC\2021\day5\input.txt").ToList();

var diagramSmall = new Diagram(10, linesSmall);
var diagram = new Diagram(1000, lines);

Console.WriteLine("Part One: {0}\nPart Two: {1}", diagramSmall.Part1, diagramSmall.Part2); // 5, 12
Console.WriteLine("Part One: {0}\nPart Two: {1}", diagram.Part1, diagram.Part2); // 6311, 19929

class Diagram {
    public int[,,] Graph { get; set; }
    public List<Line> Lines { get; set; }
    public int Part1 { get; set; }
    public int Part2 { get; set; }

    public Diagram(int bounds, List<string> lines) {
        var stringsToLines = CreateLines(lines);
        Graph = new int[bounds,bounds,1];
        Lines = stringsToLines;
        Part1 = CheckOverlap(true, bounds, new int[bounds,bounds,1], stringsToLines);
        Part2 = CheckOverlap(false, bounds, new int[bounds,bounds,1], stringsToLines);
    }

    private static int CheckOverlap(bool nonDiag, int bounds, int[,,] graph, List<Line> lines) {
        foreach (var line in lines) {
            var coords = nonDiag ? line.CoordsOrtho : line.CoordsOrtho.Concat(line.CoordsDiag);
            foreach (var coord in coords) {
                graph[coord.X, coord.Y, 0] += 1;
            }
        }
        var count = 0;
        for (int x = 0; x < bounds; x++) {
            for (int y = 0; y < bounds; y++) {
                if (graph[x, y, 0] >= 2) {
                    count++;
                }
            };
        }
        return count;
    }

    private static List<Line> CreateLines(List<string> linesIn) {
        var linesOut = new List<Line>();
        foreach (var line in linesIn) {
            string[] lineVals = line.Replace(" ", "").Replace("-", "").Replace(">", ",").Split(",");
            int[] lineNums = Array.ConvertAll(lineVals, s => int.Parse(s));
            var start = new Point(lineNums[0], lineNums[1]);
            var end = new Point(lineNums[2], lineNums[3]);
            linesOut = linesOut
                .Append(new Line(start, end)).ToList();
        }


        return linesOut;
    }
}

class Line {
    public List<Point> CoordsOrtho { get; set;  } = new();
    public List<Point> CoordsDiag { get; set; } = new();
   
    public Line(Point start, Point end) {
        CreatePointsOrtho(start.X, end.X, start.Y, end.Y);
    }

    private void CreatePointsOrtho(int x1, int x2, int y1, int y2) {
        bool xAdds = x1 < x2;
        bool yAdds = y1 < y2;

        if (!xAdds) Switcharoo(x1, x2, out x1, out x2);
        if (!yAdds) Switcharoo(y1, y2, out y1, out y2);

        if (y1 == y2 || x1 == x2) {
            for (int deltaY = y1; deltaY <= y2; deltaY++) {
                for (int deltaX = x1; deltaX <= x2; deltaX++) {
                    CoordsOrtho = CoordsOrtho
                        .Append(new Point(deltaX, deltaY)).ToList();
                }
            }
        } else {
            var xPoints = new List<Point>().ToArray();
            var yPoints = new List<Point>().ToArray();
            for (int deltaY = y1; deltaY <= y2; deltaY++) yPoints = yPoints
                    .Append(new Point(0, deltaY)).ToArray();
            for (int deltaX = x1; deltaX <= x2; deltaX++) xPoints = xPoints
                    .Append(new Point(deltaX, 0)).ToArray();
            for (int n = 0; n < xPoints.Length; n++) {
                // check which direction 
                int iX = xAdds ? n : xPoints.Length - n - 1;
                int iY = yAdds ? n : yPoints.Length - n - 1;
                CoordsDiag = CoordsDiag
                    .Append(new Point(xPoints[iX].X, yPoints[iY].Y)).ToList();
            }
        }
    }

    static void Switcharoo(int i1, int i2, out int o1, out int o2) {
        o1 = i2; o2 = i1;
    } 
}

class Point {
    public int X;
    public int Y;
    public Point(int x, int y) {
        X = x; Y = y; 
    }
}