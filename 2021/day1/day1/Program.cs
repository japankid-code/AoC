string[] lines = File.ReadAllLines(@"C:\Users\jrank\Documents\GitHub\japankid-code\AoC\2021\day1\day1\input.txt");
int[] ints = Array.ConvertAll(lines, s => int.Parse(s));

#region Part 1
    var counter = 0;
    foreach (var (line, i) in lines.Select((value, i) => (value, i)))
    {
        var a = int.Parse(lines[i > 0 ? i - 1 : i]);
        var b = int.Parse(line);

        bool increase = b > a;
        if (increase) counter++;
    }
    Console.WriteLine($"Counter = {counter}");
#endregion

#region Part 2
    counter = 0;
    foreach (var (a, i) in ints.Select((value, i) => (value, i))) {
        bool tooFar = i + 3 < ints.Count();
        if (!tooFar) {
            var b = ints[i + 1];
            var c = ints[i + 2];
            var d = ints[i + 3];

            bool increase = (a + b + c) < (b + c + d);
            if (increase) counter++;
        }
    }
#endregion

Console.WriteLine($"Counter = {counter}");

Console.WriteLine("Press any key to exit.");
Console.ReadKey();
