using day4;

var lines = File.ReadLines(@"C:\Users\jrank\Documents\GitHub\japankid-code\AoC\2021\day4\input.txt").ToList();
int[] marks = Array.ConvertAll(lines.First().Split(','), l => int.Parse(l));

var boards = Utils.LinesToBoards(lines).ToArray();

int part1 = 0;
int part2 = 0;
int[] marked = Array.Empty<int>();
int i = 0;
foreach (var mark in marks) {
    i++;
    marked = marked.Append(mark).ToArray();
    var winners = new List<Board>().ToArray();
    foreach (var board in boards) {
        var score = board.FindScore(mark, marked);
        board.Score = score;
        if (board.HasWinner(marked)) {
            if (part1 == 0) {
                part1 = score;
            }
            winners = winners.Append(board).ToArray();
            boards = boards.Where(b => !b.Equals(board)).ToArray();
        }
        if (boards.Length == 0 && part2 == 0) {
            part2 = winners.Last().FindScore(mark, marked);
        }
    }
}

Console.WriteLine($"part 1: {part1}\npart 2: {part2}");