class Car : Vehicle
{
    public Car()
    {
        Speed = 60;
        Capacity = 4;
    }

    public override void Move()
    {
        Console.WriteLine("Car is driving...");
    }
}