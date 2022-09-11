// See https://aka.ms/new-console-template for more information
int srcNodeIndex;
int dstNodeIndex;

Person[] PersonArray = new Person[] {
new Person("John", "Doe", "Rabin", "Tel-Aviv"),
new Person("Louis", "Laine", "Herzel", "Haifa"),
new Person("Chris", "Fays", "Brener", "Netanya"),
new Person("Sarah", "Labor", "Rabin", "Tel-Aviv"),
new Person("Cary", "Fernandez", "Peres", "Herzliya"),
new Person("Chris", "Fays", "Herzel", "Haifa"),
new Person("Harold", "Woodman", "Gandi", "Tel-Aviv"),
new Person("Michael", "Moen", "brener", "Netanya"),
new Person("Cary", "Fernandez", "Gandi", "Tel-Aviv"),
new Person("Thomas", "Phillips", "Herzel", "Tel-aviv"),
new Person("John", "Doe", "Brener", "Netanya"),
new Person("Sarah", "Labor", "Peres", "Herzliya")
};
Graph graph = new Graph();
graph.Init(PersonArray);

Console.WriteLine($"Welcome!\nEnter 'x' for exit.\n");
runProgram(graph);

void runProgram(Graph graph)
{
    int listSize = PersonArray.Count();
    do
    {
        Console.WriteLine($"Please enter source person index (from 0 - {listSize - 1})");
        srcNodeIndex = InputToInt(Console.ReadLine());

        Console.WriteLine($"Please enter destination person index (from 0 - {listSize - 1})");
        dstNodeIndex = InputToInt(Console.ReadLine());

        //TODO: check if input is valid

        int distance = graph.FindMinRelationLevel(srcNodeIndex, dstNodeIndex);

        if (distance != -1)
        {
            Console.WriteLine("the distance is:" + distance);
        }
        else
        {
            Console.WriteLine("path not found! (-1)");
        }
    } while (true);
}

int InputToInt(string input)
{
    int inputAsInt;
    if (input == "x")
    {
        Environment.Exit(0);
    }
    if (Int32.TryParse(input, out inputAsInt))
    {
        return inputAsInt;
    }
    else
    {
        //print Error
        return -1;
    }
}
