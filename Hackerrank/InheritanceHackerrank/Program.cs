using System;
using System.Linq;

class Person
{
	protected string firstName;
	protected string lastName;
	protected int id;

	public Person() { }
	public Person(string firstName, string lastName, int identification)
	{
		this.firstName = firstName;
		this.lastName = lastName;
		this.id = identification;
	}
	public void printPerson()
	{
		Console.WriteLine("Name: " + lastName + ", " + firstName + "\nID: " + id);
	}
}

class Student : Person
{
	private int[] testScores;

	public Student(string firstName,string lastName,int id,int[] scores)
    {
		this.firstName = firstName;
		this.lastName = lastName;
		this.id = id;
		this.testScores = scores;
    }

	public char Calculate()
    {
		double sum = 0;
		int n = 0;
		foreach(int number in testScores)
        {
			sum += number;
			n++;
        }
		double result = sum / n;
		if(result >= 90 && result <= 100)
        {
			return 'O';
        }
		else if (result >= 80 && result < 90)
		{
			return 'E';
		}
		else if (result >=70  && result < 80)
		{
			return 'A';
		}
		else if (result >= 55 && result < 70)
		{
			return 'P';
		}
		else if (result >= 40 && result < 55)
		{
			return 'D';
		}
		else if (result < 40)
		{
			return 'T';
		}
        else
        {
			return 'T';
        }
	}
    

	/*	
    *   Class Constructor
    *   
    *   Parameters: 
    *   firstName - A string denoting the Person's first name.
    *   lastName - A string denoting the Person's last name.
    *   id - An integer denoting the Person's ID number.
    *   scores - An array of integers denoting the Person's test scores.
    */
	// Write your constructor here

	/*	
    *   Method Name: Calculate
    *   Return: A character denoting the grade.
    */
	// Write your method here
}

class Solution
{
	static void Main()
	{
		string[] inputs = Console.ReadLine().Split();
		string firstName = inputs[0];
		string lastName = inputs[1];
		int id = Convert.ToInt32(inputs[2]);
		int numScores = Convert.ToInt32(Console.ReadLine());
		inputs = Console.ReadLine().Split();
		int[] scores = new int[numScores];
		for (int i = 0; i < numScores; i++)
		{
			scores[i] = Convert.ToInt32(inputs[i]);
		}

		Student s = new Student(firstName, lastName, id, scores);
		s.printPerson();
		Console.WriteLine("Grade: " + s.Calculate() + "\n");
	}
}