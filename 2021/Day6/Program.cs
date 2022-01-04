var fish = Array.ConvertAll(File.ReadAllText(@"C:\Users\jrank\Documents\GitHub\japankid-code\AoC\2021\day6\input.txt").Split(","), x => int.Parse(x));
var fishSmall = new int[] { 3, 4, 3, 1, 2 };

//var depthsSmall = new Depths(fishSmall, 80);
long depthsPart1 = new Depths(fish, 80).Population.Sum();
long depthsPart2 = new Depths(fish, 256).Population.Sum();

//Console.WriteLine("Part One: {0}\n Part Two: {1}", depthsSmall.Population.Length, "");
Console.WriteLine("Part One: {0}\nPart Two: {1}", depthsPart1, depthsPart2);

class Depths {
    public long[] Population { get; set; }

    public Depths(int[] fish, int daysLater) {
        long[] fishGeneration = new long[9];
        foreach (int i in fish) {
            fishGeneration[i]++;
        }

        for (int iteration = 0; iteration < daysLater; iteration++) {
            long newOnes = fishGeneration[0];
            
            for (int i = 1; i < fishGeneration.Length; i++) {
                fishGeneration[i - 1] = fishGeneration[i];
            }

            fishGeneration[8] = newOnes;
            fishGeneration[6] += newOnes;
        }

        Population = fishGeneration;
    }
}