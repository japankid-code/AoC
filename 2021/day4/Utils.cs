
using day4;

public class Utils {
    const StringSplitOptions RE = StringSplitOptions.RemoveEmptyEntries;
    public static List<Board> LinesToBoards(List<string> lines) {
        List<List<int[]>> boards = lines.Where(l => !l.Contains(',') && l.Length > 2)
            .Select((s, i) => new { s, i })
            .GroupBy(x => x.i / 5, x => Array.ConvertAll(x.s.Split(" ", RE), n => int.Parse(n)))
            .Select(b => b.ToList()).ToList();
        List<Board> boardsRows = new();
        foreach (var board in boards) {
            var newBoard = new Board();
            foreach (var r in board) newBoard.Rows.Add(new Row() {
                Cells = new List<Cell>() { 
                    new Cell () { Value = r[0]},
                    new Cell () { Value = r[1]},
                    new Cell () { Value = r[2]},
                    new Cell () { Value = r[3]},
                    new Cell () { Value = r[4]},
                }
            });
            for (int i = 0; i < 5; i++) newBoard.Columns.Add(new Row() {
                Cells = new List<Cell>() {
                    new Cell () { Value = newBoard.Rows[0].Cells[i].Value},
                    new Cell () { Value = newBoard.Rows[1].Cells[i].Value},
                    new Cell () { Value = newBoard.Rows[2].Cells[i].Value},
                    new Cell () { Value = newBoard.Rows[3].Cells[i].Value},
                    new Cell () { Value = newBoard.Rows[4].Cells[i].Value},
                }
            });
            boardsRows.Add(newBoard);
        }
        return boardsRows;
    }
}

