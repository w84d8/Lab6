class GraphicsEditor
{
    private List<GraphicPrimitive> graphics = new List<GraphicPrimitive>();

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        graphics.Add(primitive);
    }

    public void DrawAll()
    {
        foreach (var primitive in graphics)
        {
            primitive.Draw();
        }
    }

    public void MoveAll(int x, int y)
    {
        foreach (var primitive in graphics)
        {
            primitive.Move(x, y);
        }
    }

    public void ScaleAll(float factor)
    {
        foreach (var primitive in graphics)
        {
            primitive.Scale(factor);
        }
    }
}