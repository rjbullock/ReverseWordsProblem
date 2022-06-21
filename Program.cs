using System.Collections.Generic;
using System.Linq;

List<string> lines = new List<string>();

string tmpCount = "";
int count = 0;

do
{
    Console.WriteLine("How many lines total?");
    tmpCount = Console.ReadLine();
}
while (!int.TryParse(tmpCount, out count));

Console.WriteLine("Enter your lines next, separating each word with a space. No more than 5 words per line.");

for(int i = 0; i < count; i++)
{
    var counter = i + 1;
    
    Console.WriteLine("Enter Line " + counter + ", separting each word with a space. No more than 5 ");
    
    var tmpLine = Console.ReadLine();

    if (!String.IsNullOrEmpty(tmpLine) && tmpLine.Split(" ").Count() <= 5)
    {
        lines.Add(tmpLine);
    }
    else
    {
        Console.WriteLine("That line was not valid. Try again.");
        i--;
    }
}

foreach(var line in lines)
{
    var tmpLine = line.Split(" ").Reverse().ToArray();
    foreach(var word in tmpLine)
    {
        Console.Write(word + " ");
    }
    Console.WriteLine();
}

Console.WriteLine(tmpCount);
