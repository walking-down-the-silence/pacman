namespace PacMan
{
    public static class VertexExtention
    {
        public static Offset ToOffset(this Vertex vertex)
        {
            return new Offset(vertex.X * 7, vertex.Y * 7);
        }
    }
}
