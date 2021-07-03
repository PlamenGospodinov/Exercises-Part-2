class Human
{
    
    private int height;
    private int weight;
    
    public int Height
    {
        get
        {
            return height;
        }
        set
        {
            height = value;
        }
    }
    
    public int Weight
    {
        get
        {
            return weight;
        }
        set
        {
            weight = value;
        }
    }
    
    public Human(int height,int weight)
    {
        this.height = height;
        this.weight = weight;
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
        Ivan.Height = 186;
        Ivan.HumanProps();
    }
}