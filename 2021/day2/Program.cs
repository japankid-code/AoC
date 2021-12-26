// See https://aka.ms/new-console-template for more information
using System.Linq;

Console.WriteLine("Hello, World!");
var lines = File.ReadAllLines(@"C:\Users\jrank\Documents\GitHub\japankid-code\AoC\2021\day2\input.txt").ToList();

#region Part 1
    Dictionary<string, int> pairs = new ();
    var lkv = lines.Select(l => new { k = l.Split(' ')[0], v = int.Parse(l.Split(' ')[1]) });
    foreach (var kv in lkv) {
        if (pairs.ContainsKey(kv.k)) pairs[kv.k] = pairs[kv.k] + kv.v;
        else pairs.Add(kv.k, kv.v);
    }

    var h = pairs["forward"];
    var v = pairs["down"] - pairs["up"];

    foreach (var pair in pairs) Console.WriteLine($"{pair.Key} : {pair.Value}");

    var hxv = h * v;
    Console.WriteLine($"part 1 = {hxv}\n\n\n");
#endregion

#region Part 2
    var aim = 0;
    var depth = 0;
    var horizontal = 0;
    foreach (var kv in lkv) {
        if (kv.k == "down") aim += kv.v;
        else if (kv.k == "up") aim -= kv.v;
        else if (kv.k == "forward") {
            depth += kv.v * aim;
            horizontal += kv.v;
        }
    }
    Console.WriteLine($"horizontal x depth = {horizontal * depth}");
#endregion