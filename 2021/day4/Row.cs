namespace day4 {
    public class Row {
        public List<Cell> Cells { get; set; } = new List<Cell>();

        public bool IsWinning(int[] marked) => Cells.Where(c => marked.Contains(c.Value)).ToArray().Length == 5;
    }
}