class Bus : Vehicle
{
    public Bus()
    {
        Speed = 40;
        Capacity = 20;
    }

    public override void Move()
    {
        Console.WriteLine("Bus is moving...");
    }
}