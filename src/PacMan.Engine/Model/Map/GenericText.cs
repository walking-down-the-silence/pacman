using System;

namespace PacMan
{
    public class GenericText : IText
    {
        public GenericText(string text, Offset offset, Color forecolor)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(text));

            Text = text;
            Position = offset;
            Forecolor = forecolor;
        }

        public char this[int index] => Text[index];

        public string Text { get; }

        public int Length => Text.Length;

        public Offset Position { get; }

        public Color Forecolor { get; }
    }
}
