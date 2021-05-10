using System;
using System.Linq;

class Difference
{
    private int[] elements;
    public int maximumDifference;

    public Difference(int[] array)
    {
        elements = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            elements[i] = array[i];
        }
    }

    public int computeDifference()
    {
        maximumDifference = 0;
        for(int i = 0; i < elements.Length-1; i++)
        {
            for(int l = i + 1; l < elements.Length; l++)
            {
                int difference = Math.Abs(elements[i] - elements[l]);
                if(difference > maximumDifference)
                {
                    maximumDifference = difference;
                }
            }
        }
        return maximumDifference;
    }
	// Add your code here

} // End of Difference Class

class Solution
{
    static void Main(string[] args)
    {
        Convert.ToInt32(Console.ReadLine());

        int[] a = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

        Difference d = new Difference(a);

        d.computeDifference();

        Console.Write(d.maximumDifference);
    }
}