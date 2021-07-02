<Query Kind="Program" />

void Main()
{
	Cat kitty = new Cat();
	kitty.Name = "Tonny";
	kitty.Color = "orange";
	kitty.SayMeow();
	
	Cat kitty2 = new Cat("Garfield","orange");
	kitty2.SayMeow();
	Console.WriteLine("Cat {0} is {1}.",kitty2.Name,kitty2.Color);
}

// Define other methods and classes here

public class Cat
{
	private string name;
	private string color;
	
	public string Name
	{
		get
		{
			return this.name;
		}
		set
		{
			this.name = value;
		}
	}
	
	public string Color
	{
		get
		{
			return this.color;
		}
		set
		{
			this.color = value;
		}
	}
	
	public Cat()
	{
		this.name = "Henderson";
		this.color = "grey";
	}
	
	public Cat(string name,string color)
	{
		this.name = name;
		this.color = color;
	}
	
	public void SayMeow()
	{
		Console.WriteLine("Cat {0} said meow.",name);
	}
}