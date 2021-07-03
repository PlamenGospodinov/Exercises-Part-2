class Human
{
    public int Height;
    public int Weight;
    
    public Human(int height,int weight)
    {
        Height = height;
        Weight = weight;
    }
    
    public void HumanProps()
    {
        Console.WriteLine("This human is {} cms long and weights {1} kgs.",Height,Weight);
    }
}

class EntryPoint
{
    public void Main()
    {
        Human Ivan = new Human(182,85);
        Ivan.HumanProps();
    }
}