namespace day4 {
    public class Board {
        public List<Row> Rows { get; set; } = new List<Row>();
        public List<Row> Columns { get; set; } = new List<Row>();
        public int Score { get; set; } = 0;

        public int[] AllNumbers() {
            int[] numbers = Array.Empty<int>();
            Rows.ForEach(row => row.Cells.ForEach(cell => numbers = numbers.Append(cell.Value).ToArray()));
            return numbers;
        }

        public bool HasWinner(int[] marked) {
            foreach (var row in Rows.Concat(Columns)) {
                if (row.IsWinning(marked)) return true;
            }
            return false;
        }

        public int FindScore(int mark, int[] marked) {
            int[] unmarked = AllNumbers().Where(n => !marked.Contains(n)).ToArray();
            return unmarked.Sum() * mark;
        }
    }
}