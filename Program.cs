// See https://aka.ms/new-console-template for more information

using HL_DynArray;

IHLContainer container = new DynArray();

Random rng = new Random();

// Add Head
Console.WriteLine("Adding Head (0-9):\n");


for (int i = 0; i < 10; i++)
{
    container.AddHead(i);
    container.Print();
}

// Remove
Console.WriteLine("\nRemoving by search (0-9):\n");

for (int i = 0; i < 10; i++)
{
    container.Remove(i);
    container.Print();
}

// Add Tail
Console.WriteLine("\nAdding to tail (random between 0 - 1000):\n");

for (int i = 0; i < 10; i++)
{
    container.AddTail(rng.Next() % 1000);
    container.Print();
}

// Remove At
Console.WriteLine("\nRemoving by index (9-0):\n");

for (int i = 9; i >= 0; i--)
{
    container.RemoveAt(i);
    container.Print();
}

// Insert At
Console.WriteLine("\nInserting by index (0-9):\n");

for (int i = 0; i < 10; i++)
{
    container.InsertAtPos(rng.Next() % 1000, i);
    container.Print();
}

// Remove Head
Console.WriteLine("\nRemoving head (10 times):\n");

for (int i = 0; i < 10; i++)
{
    container.RemoveHead();
    container.Print();
}

for (int i = 0; i < 10; i++)
    container.InsertAtPos(i, i);

// Remove Tail
Console.WriteLine("\nRemoving tail (10 times):\n");

for (int i = 0; i < 10; i++)
{
    container.RemoveTail();
    container.Print();
}

for (int i = 0; i < 10; i++)
    container.InsertAtPos(i, i);

// Find
Console.WriteLine("\nFinding in {0,1,2,3,4,5,6,7,8,9}:\n");

Console.WriteLine("Find 3: " + container.Find(3, Comparer<int>.Default));
Console.WriteLine("Find 8: " + container.Find(8, Comparer<int>.Default));
Console.WriteLine("Find 12: " + container.Find(12, Comparer<int>.Default));

// First
Console.WriteLine("\nCalling First:\n");

object o = container.First();

Console.WriteLine("First: " + o);
container.Print();

// Next
Console.WriteLine("\nCalling Next while it isnt null:\n");

while ((o = container.Next()) != null)
{
    Console.WriteLine("Next: " + o);
    container.Print();
}