namespace EvenMultiples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String Entry;
            String[] RawNumbers;
            int StartingNumber, EndingNumber, Index;
            List<int> Multiples;

            while (true)
            {
                Console.Write("Enter two positive numbers, separated by a space, and then press Enter (Q to quit): ");

                Entry = Console.ReadLine();
                if (Entry.Equals("Q", StringComparison.CurrentCultureIgnoreCase)) { break; }

                // TODO: Validate the entry:
                //  *) Make there are two numbers
                //  *) Make sure the numbers are both positive integers

                // Numbers can be entered in either order, so figure out which one is smaller (that's our StartingNumber)
                RawNumbers = Entry.Split(' ');
                if (int.Parse(RawNumbers[0]) < int.Parse(RawNumbers[1]))
                {
                    StartingNumber = int.Parse(RawNumbers[0]);
                    EndingNumber = int.Parse(RawNumbers[1]);
                }
                else
                {
                    StartingNumber = int.Parse(RawNumbers[1]);
                    EndingNumber = int.Parse(RawNumbers[0]);
                }


                // Set the starting point to the first even number in the range [StartingNumber, EndingNumber].  It needs to be the lowest even.
                Index = (StartingNumber % 2 == 0 ? StartingNumber : StartingNumber + 1);

                Multiples = new List<int>();

                // Walk through the range by 2s, looking for numbers that are both even and are a multiple of StartingNumber.
                // At this point in the program, we are guaranteed to be starting with an even, and if we increment by 2
                // every time, we will only ever be evaluating evens.  As a result, the conditional in the loop doesn't need
                // to check for evens; it only needs to check for multiples of StartingNumber.
                for (; Index <= EndingNumber; Index = Index + 2)
                {
                    if (Index % StartingNumber == 0) { Multiples.Add(Index); }
                }

                Console.Write($"Here are all even multiples of {StartingNumber} in the range [{StartingNumber}, {EndingNumber}]: ");
                Console.WriteLine(String.Join(',', Multiples.ToArray()));
                Console.WriteLine();
                Console.WriteLine();
            }

        }
    }
}
