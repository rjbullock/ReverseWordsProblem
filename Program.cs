using System.Collections.Generic;
using System.Linq;

List<string> lines = new List<string>();

string tmplineCount = "";
int lineCount = 0;
int maxWords = 5;
int maxCharsPerWord = 10;

do
{
    Console.WriteLine("How many lines total?");
    tmplineCount = Console.ReadLine();

    if(!int.TryParse(tmplineCount, out lineCount))
    {
        Console.WriteLine("That is not an integer. Please enter a digit.");
    }
}
while (!int.TryParse(tmplineCount, out lineCount));

Console.WriteLine("Enter your lines next, separating each word with a space. No more than " + maxWords + " words per line and no more than " + maxCharsPerWord + " letters per word.");

for(int i = 0; i < lineCount; i++)
{
    var counter = i + 1;
    
    Console.WriteLine("Enter Line " + counter);
    
    var tmpLine = Console.ReadLine();

    if (!String.IsNullOrEmpty(tmpLine))
    {
        var tmpLineArray = tmpLine.Split(" ");

        //Don't exceed maximum words per line.
        if (tmpLineArray.Count() <= maxWords) {

            var wordsTooLong = tmpLineArray.Where(l => l.Length > maxCharsPerWord).ToList();
            
            //Don't exceed maximum characters.
            if(wordsTooLong.Count > 0)
            {
                Console.WriteLine("Too many letters in these words: '{0}' Please try again.", String.Join<string>(" ", wordsTooLong));
                i--;
            }
            else
            {
                lines.Add(tmpLine);
            }
        }
        else
        {
            Console.WriteLine("Too many words were entered! Try again.");
            i--;
        }
        
    }
    else
    {
        Console.WriteLine("Please no empty lines.");
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
