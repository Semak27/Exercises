// See https://aka.ms/new-console-template for more information


using ArrayDeque;

ArrayDeque<string> test = new ArrayDeque<string> ();

test.Offer ("a");
test.Poll();
Console.WriteLine(test.Size());