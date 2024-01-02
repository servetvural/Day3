using Day3;

StreamReader reader = new StreamReader("input.txt");

List<Part> parts = new List<Part>();
List<Symbol> symbols = new List<Symbol>();
int r = 0;
while (true)
{
    String line = reader.ReadLine();
    if (line == null)
        break;

    string numberAsString = "";
    int colStart = 0;
    for (int i = 0; i< line.Length; i++)
    {
        if (Char.IsDigit(line[i]))
        {
            //either found a first digit of a number or continuation of a number
            if (numberAsString.Length > 0)
            {   //it is continuation of a number so add
                numberAsString += line[i];
            } else
            {   //it is first digit of a new number
                numberAsString = line[i].ToString();
                //this is the beginning of column
                colStart = i;
            }
        } else
        {   //something found but not a digit
            //either you reached the end of number or not even started
            if (numberAsString.Length > 0)
            {
                //there is a number already in process so finish the number
                parts.Add(new Part() { 
                    value = int.Parse(numberAsString),
                    row = r,
                    colStart = colStart
                });
                colStart = 0;
                numberAsString = "";
            } 
            //process the symbol
            if (line[i] == '.')
            {
                //nothing to do, it is a dot
            } else
            {
                symbols.Add(new Symbol() { symbol= line[i], row = r, col = i });
            }
            
        }

    }
    //increment row number        
    r++;
}


bool test = Char.IsDigit('+');
test = Char.IsDigit('=');
test = Char.IsDigit('-');

int total = 0;
bool blnFound = false;
int index = 0;
foreach (Part part1 in parts)
{
    if (
       //if there is a symbol on the same row and has column number 1 less than colstart or 1 more than colEnd of the part => there is a contact
       symbols.Where(s => (s.row == part1.row && (s.col == part1.colStart - 1 || s.col == part1.colEnd + 1))  ||
           //if there is a symbol on the previous row and has column number start from part col-1 to part col + 1
           ( s.row == part1.row - 1 && s.col >= part1.colStart - 1 && s.col <= part1.colEnd + 1)    ||
           //if there is a symbol on the next row and has column number start from part col-1 to part col + 1
           ( s.row == part1.row + 1 && s.col >= part1.colStart - 1 && s.col <= part1.colEnd + 1))
           .Any())
    {
        part1.isAdjacent = true;
    }

   // Console.WriteLine( part1.value + " " + blnFound + " i=" + index + " r=" + part1.row + " cs=" + part1.colStart + " ce=" + part1.colEnd);
    index++;
}

Console.WriteLine(parts.Where(x => x.isAdjacent).Sum(x => x.value));
/*
foreach (Part part in parts) 
    Console.WriteLine(part.value);

foreach (Symbol symbol in symbols)
    Console.WriteLine(symbol.symbol + " r=" + symbol.row + " c=" + symbol.col);
*/



Console.ReadLine();




