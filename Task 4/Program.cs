class Program
{
    static void Main()
    {
        GraphicsEditor editor = new GraphicsEditor();

        Circle circle = new Circle { X = 10, Y = 20, Radius = 5 };
        Rectangle rectangle = new Rectangle { X = 30, Y = 40, Width = 8, Height = 6 };
        Triangle triangle = new Triangle { X = 50, Y = 60 };

        editor.AddPrimitive(circle);
        editor.AddPrimitive(rectangle);
        editor.AddPrimitive(triangle);

        Group group = new Group { X = 100, Y = 100 };
        group.AddPrimitive(circle);
        group.AddPrimitive(rectangle);

        editor.AddPrimitive(group);

        Console.WriteLine("Drawing all primitives:");
        editor.DrawAll();

        Console.WriteLine("\nMoving all primitives:");
        editor.MoveAll(5, 5);
        editor.DrawAll();

        Console.WriteLine("\nScaling all primitives:");
        editor.ScaleAll(1.5f);
        editor.DrawAll();
    }
}