using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3;
public class Part
{
    public int value { get; set; }
    public int row { get; set; }
    public int colStart { get; set; }
    public int colEnd
    {
        get
        {
            return colStart + value.ToString().Length-1;
        }
    }
    public bool isAdjacent { get; set; }

    public override string ToString()
    {
        return value + " " + isAdjacent + " r=" + row + " cs=" + colStart + " ce=" + colEnd;
    }
}
public class Symbol
{
    public char symbol { get; set; }
    public int row { get; set; }
    public int col { get; set; }
    
}