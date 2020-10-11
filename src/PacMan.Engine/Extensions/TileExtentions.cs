namespace PacMan
{
    public static class TileExtentions
    {
        public static Tile ToTile(this Offset offset)
        {
            return new (offset.Top / Tile.SIZE, offset.Left / Tile.SIZE, false, Direction.None);
        }
    }
}
