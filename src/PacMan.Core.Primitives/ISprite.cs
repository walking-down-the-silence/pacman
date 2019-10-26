namespace PacMan
{
    /// <summary>
    /// REpresents the basic sprite in game.
    /// </summary>
    public interface ISprite
    {
        /// <summary>
        /// Gets the color of sprite cell.
        /// </summary>
        /// <param name="y"> The y coordinate. </param>
        /// <param name="x"> The x coordinate. </param>
        /// <returns></returns>
        Color this[int y, int x] { get; }

        /// <summary>
        /// Gets the position of the sprite.
        /// </summary>
        Offset Position { get; }

        /// <summary>
        /// Gets the size of the sprite.
        /// </summary>
        Size Size { get; }
    }
}
