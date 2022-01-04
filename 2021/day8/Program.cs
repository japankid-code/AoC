var input = File.ReadAllLines(@"..\..\..\input.txt").ToList();
var inputTest = File.ReadAllLines(@"..\..\..\inputTest.txt").ToList();

var scan = new OutputScan(input);
var part1 = scan.ValuePart1; // 390
var part2 = scan.ValuePart2; // 1011785

Console.WriteLine("Part One: {0}\nPart Two: {1}", part1, part2);

class OutputScan {
    public int ValuePart1 = 0;
    public int ValuePart2 = 0;

    public OutputScan(List<string> inputs) {
        ValuePart1 = Part2(inputs);
        ValuePart2 = Part2(inputs, false);
    }

    private int Part2(List<string> inputs, bool partOne = true) {
        var outputs = InputSelect(inputs);
        var signals = InputSelect(inputs, false);

        int count = 0;
        int sum = 0;
        for (int i = 0; i < inputs.Count; i++) {
            string[] nums = new string[10];
            nums[1] = signals[i].Where(s => s.Length == 2).First();
            nums[4] = signals[i].Where(s => s.Length == 4).First();
            nums[7] = signals[i].Where(s => s.Length == 3).First();
            nums[8] = signals[i].Where(s => s.Length == 7).First();
            nums[3] = signals[i]
                .Where(s => s.Length == 5 && nums[1].All(c => s.Contains(c))).First(); // 3 is the only length 5 containing all segments in 1
            nums[2] = signals[i]
                .Where(s => s.Length == 5 && nums[4].Intersect(s).Count() == 2).First(); // 2 is the only length 5 containing only 2 of the 4 elements in 4
            nums[5] = signals[i].Where(s => s.Length == 5 && s != nums[2] && s != nums[3]).First();
            nums[9] = signals[i]
                .Where(s => s.Length == 6 && nums[4].All(c => s.Contains(c))).First(); // 9 is length 6, contains all segments in 4
            nums[6] = signals[i]
                .Where(s => s.Length == 6 && nums[1].Intersect(s).Count() == 1).First(); // 6 is length 6, only one that doesn't contain both segments in 1
            nums[0] = signals[i].Where(s => s.Length == 6 && s != nums[6] && s != nums[9]).First();

            int output = 0;
            foreach (var s in outputs[i]) {
                int number = Array.FindIndex(nums, n => n.All(c => s.Contains(c)) && n.Length == s.Length);
                output = output * 10 + number;
                if (number == 1 || number == 4 || number == 7 || number == 8) count++;
            }
            sum += output;
        }
        return partOne ? count : sum;
    }

    private List<List<string>> InputSelect(List<string> inputs, bool isOutput = true) { 
        var outputs = inputs.Select(s => s.Split("|").Last()).Select(s => s.Split(" ").Where(s => s != "").ToList()).ToList();
        var signals = inputs.Select(s => s.Split("|").First()).Select(s => s.Split(" ").Where(s => s != "").ToList()).ToList();
        return isOutput ? outputs : signals;
    }
}
