class Train : Vehicle
{
    public Train()
    {
        Speed = 80;
        Capacity = 100;
    }

    public override void Move()
    {
        Console.WriteLine("Train is moving...");
    }
}

class Route
{
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }

    public Route(string startPoint, string endPoint)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
    }
}