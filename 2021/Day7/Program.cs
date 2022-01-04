var crabs = Array.ConvertAll(File.ReadAllText(@"C:\Users\jrank\Documents\GitHub\japankid-code\AoC\2021\day7\input.txt").Split(","), x => int.Parse(x)).ToList();
var lilCrabs = (new int[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 }).ToList();

var optimalTest = new Treachery(lilCrabs, true).OptimalPosition;
var optimalPart1 = new Treachery(crabs).OptimalPosition;
var optimalPart2 = new Treachery(crabs, true).OptimalPosition;

Console.WriteLine("Test: {0}\nPart One: {1}\nPart Two: {2}", optimalTest, optimalPart1, optimalPart2);

class Treachery {
    public int OptimalPosition = 0;
    public Treachery(List<int> positions, bool part2 = false) {
        var max = positions.Max();

        var fuelScenarios = new List<int>(positions.Count);
        for (int end = 0; end < max; end++) {
            int fuel = 0;
            for (int c = 0; c < positions.Count; c++) { 
                int crabP = positions[c];
                int crabDiff = crabP >= end ? crabP - end : end - crabP;
                if (part2) {
                    for (int d = 0; d < crabDiff; d++) {
                        fuel += 1 + d;
                    }
                } else fuel += crabDiff;
            }
            fuelScenarios.Add(fuel);
        }

        OptimalPosition = fuelScenarios.Min();
    }
}
