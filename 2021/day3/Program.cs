// See https://aka.ms/new-console-template for more information

string[] lines = File.ReadAllLines(@"C:\Users\jrank\Documents\GitHub\japankid-code\AoC\2021\day3\input.txt");

char BitOne = char.Parse("1");
char BitZero = char.Parse("0");

#region Part 1
var columns = new Dictionary<int, KeyValuePair<int, int>>() { };
foreach ( var line in lines ) {
    for ( int col = 0; col < line.Length; col++ ) {
        int addOne = Convert.ToInt32(line[col] == '1');
        int addZero = Convert.ToInt32(line[col] == '0');
        if ( !columns.ContainsKey(col) ) columns.Add(col, new KeyValuePair<int, int>(addOne, addZero));
        var totalOnes = columns[col].Key + addOne;
        var totalZeros = columns[col].Value + addZero;
        columns[col] = new KeyValuePair<int, int>(totalOnes, totalZeros);
    }
}
string gr = "";
string er = "";
foreach ( var column in columns ) {
    int nOfOnes = column.Value.Key;
    int nOfZeros = column.Value.Value;
    Console.WriteLine($"{column.Key}, {nOfOnes}, {nOfZeros}");
    gr = nOfOnes > nOfZeros ? gr += "1" : gr += "0";
    er = nOfOnes < nOfZeros ? er += "1" : er += "0";
}
int g = Convert.ToInt32(gr, 2);
int e = Convert.ToInt32(er, 2);
Console.WriteLine($"gamma rate: {g}");
Console.WriteLine($"epsilon rate: {e}");
Console.WriteLine($"power consumption: {g * e}\n\n\n");
#endregion

#region Part 2
int ogr = 0;
int csr = 0;
string[] linesForOxygen = lines;
string[] linesForCo2 = lines;
for ( int col = 0; col < 12; col++ ) {
    linesForOxygen = Selector(linesForOxygen, col, true);
    if (linesForOxygen.Length == 1) {
        var finalLeft = linesForOxygen.FirstOrDefault();
        ogr = Convert.ToInt32(finalLeft, 2);
    }

    linesForCo2 = Selector(linesForCo2, col, false);
    if (linesForCo2.Length == 1) {
        var finalRight = linesForCo2.FirstOrDefault();
        csr = Convert.ToInt32(finalRight, 2);
    }
}

string[] Selector(string[] remaining, int col, bool defaultVal) {
    var resultRight = remaining.Where(line => line[col].Equals(BitOne)).ToArray();
    var resultLeft = remaining.Where(line => line[col].Equals(BitZero)).ToArray();

    if (resultRight.Length != resultLeft.Length) {
        // return the more common for osr
        if (defaultVal) return resultRight.Length > resultLeft.Length ? resultRight : resultLeft;
        // return the less common for csr
        return resultRight.Length > resultLeft.Length ? resultLeft : resultRight;
    } else return defaultVal ? resultRight : resultLeft;
}

Console.WriteLine($"oxygen generator rating: {ogr}");
Console.WriteLine($"Co2 scrubber rating: {csr}");
Console.WriteLine($"life support rating: {ogr * csr}\n\n\n");
#endregion