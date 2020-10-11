using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace PacMan
{
    public class MapLoader : IMapLoader<ITilemap>
    {
        private const int SpriteSize = 7;

        public ICollection<ITilemap> Load(string path, string searchPattern)
        {
            return Directory.GetFiles(path, searchPattern)
                .Select(filename => LoadSingle(filename))
                .ToList();
        }

        private static ITilemap LoadSingle(string filename)
        {
            var map = Deserialize<Map>(File.ReadAllText(filename));

            Size size = new(map.Grid.Width, map.Grid.Height);
            Tilemap field = new(size);

            field.All.Add(CreatePacMan(map.Pacman));
            map.Ghosts.Ghost.ForEach(sprite => field.All.Add(CreateGhost(sprite)));

            foreach (var gridCell in map.Grid.Cell.Where(cell => cell != null))
            {
                var cell = CreateCell(gridCell);
                field[cell.Row, cell.Column] = cell;

                if (cell.Value != null) field.All.Add(cell.Value);
            }

            return field;
        }

        private static Direction GetDirection(DirectionValue direction)
        {
            return direction switch
            {
                DirectionValue.Left => Direction.Left,
                DirectionValue.Up => Direction.Up,
                DirectionValue.Right => Direction.Right,
                DirectionValue.Down => Direction.Down,
                _ => Direction.None,
            };
        }

        private static ISprite CreateSprite(Offset position, object sprite)
        {
            return sprite switch
            {
                BrickCell => new Brick(position),
                PelletCell { Class: PelletType.Normal } => new Pellet(position),
                PelletCell { Class: PelletType.Power } => new PowerPellet(position),
                RespawnCell => new GhostRespawn(position),
                GateCell => null,
                _ => throw new ArgumentOutOfRangeException(nameof(sprite)),
            };
        }

        private static Tile CreateCell(object parameter)
        {
            if (parameter is Cell cell)
            {
                int column = cell.Column - 1;
                int row = cell.Row - 1;
                Offset position = new(column * SpriteSize, row * SpriteSize);

                var sprite = cell.GetAtomicValues()
                    .Where(x => x != null)
                    .Select(x => CreateSprite(position, x))
                    .SingleOrDefault(x => x != null);

                return new(row, column, sprite, cell.Checkpoint, GetDirection(cell.Restriction));
            }

            return null;
        }

        private static IPacMan CreatePacMan(PacManCell sprite)
        {
            Offset position = new((sprite.Column - 1) * SpriteSize, (sprite.Row - 1) * SpriteSize);
            return new PacMan(position);
        }

        private static IGhost CreateGhost(GhostCell sprite)
        {
            Offset position = new((sprite.Column - 1) * SpriteSize, (sprite.Row - 1) * SpriteSize);

            return sprite switch
            {
                { Class: GhostType.Shadow } => new ShadowGhost(position),
                { Class: GhostType.Speedy } => new SpeedyGhost(position),
                { Class: GhostType.Bashful } => new BashfulGhost(position),
                { Class: GhostType.Pokey } => new PokeyGhost(position),
                _ => throw new ArgumentOutOfRangeException(nameof(sprite)),
            };
        }

        #region Serialization

        public static T Deserialize<T>(string toDeserialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringReader textReader = new StringReader(toDeserialize);
            return (T)xmlSerializer.Deserialize(textReader);
        }

        public static string Serialize<T>(T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, toSerialize);
            return textWriter.ToString();
        }

        #endregion

        #region Srializable Types

        [XmlRoot(ElementName = "respawn")]
        public class RespawnCell
        {
        }

        [XmlRoot(ElementName = "brick")]
        public class BrickCell
        {
        }

        [XmlRoot(ElementName = "gate")]
        public class GateCell
        {
        }

        public enum PelletType
        {
            [XmlEnum("normal")]
            Normal,
            [XmlEnum("power")]
            Power
        }

        [XmlRoot(ElementName = "pellet")]
        public class PelletCell
        {
            [XmlAttribute(AttributeName = "class")]
            public PelletType Class { get; set; }
        }

        [XmlRoot(ElementName = "ghosts")]
        public class Ghosts
        {
            [XmlElement(ElementName = "ghost")]
            public List<GhostCell> Ghost { get; set; }
        }

        [XmlRoot(ElementName = "checkpoints")]
        public class Сheckpoints
        {
            [XmlElement(ElementName = "checkpoint")]
            public List<CheckpointCell> Сheckpoint { get; set; }
        }

        [XmlRoot(ElementName = "checkpoint")]
        public class CheckpointCell
        {
            [XmlAttribute(AttributeName = "order")]
            public int Order { get; set; }

            [XmlAttribute(AttributeName = "row")]
            public int Row { get; set; }

            [XmlAttribute(AttributeName = "column")]
            public int Column { get; set; }

            [XmlAttribute(AttributeName = "restriction")]
            public DirectionValue Restriction { get; set; }
        }

        public enum DirectionValue
        {
            [XmlEnum("none")]
            None,
            [XmlEnum("left")]
            Left,
            [XmlEnum("up")]
            Up,
            [XmlEnum("right")]
            Right,
            [XmlEnum("down")]
            Down
        }

        public enum GhostType
        {
            [XmlEnum("shadow")]
            Shadow,
            [XmlEnum("speedy")]
            Speedy,
            [XmlEnum("bashful")]
            Bashful,
            [XmlEnum("pokey")]
            Pokey
        }

        [XmlRoot(ElementName = "ghost")]
        public class GhostCell
        {
            [XmlAttribute(AttributeName = "class")]
            public GhostType Class { get; set; }

            [XmlAttribute(AttributeName = "row")]
            public int Row { get; set; }

            [XmlAttribute(AttributeName = "column")]
            public int Column { get; set; }

            [XmlElement(ElementName = "checkpoint")]
            public List<CheckpointCell> Checkpoint { get; set; }
        }

        [XmlRoot(ElementName = "pacman")]
        public class PacManCell
        {
            [XmlAttribute(AttributeName = "row")]
            public int Row { get; set; }

            [XmlAttribute(AttributeName = "column")]
            public int Column { get; set; }
        }

        [XmlRoot(ElementName = "grid")]
        public class Grid
        {
            [XmlElement(ElementName = "cell")]
            public List<Cell> Cell { get; set; }

            [XmlAttribute(AttributeName = "height")]
            public int Height { get; set; }

            [XmlAttribute(AttributeName = "width")]
            public int Width { get; set; }
        }

        [XmlRoot(ElementName = "cell")]
        public class Cell
        {
            [XmlAttribute(AttributeName = "row")]
            public int Row { get; set; }

            [XmlAttribute(AttributeName = "column")]
            public int Column { get; set; }

            [XmlElement(ElementName = "brick")]
            public BrickCell Brick { get; set; }

            [XmlElement(ElementName = "gate")]
            public GateCell Gate { get; set; }

            [XmlElement(ElementName = "pellet")]
            public PelletCell Pellet { get; set; }

            [XmlElement(ElementName = "respawn")]
            public RespawnCell Respawn { get; set; }

            [XmlAttribute(AttributeName = "checkpoint")]
            public bool Checkpoint { get; set; }

            [XmlAttribute(AttributeName = "restriction")]
            public DirectionValue Restriction { get; set; }

            public object[] GetAtomicValues() => new object[]
                { Brick, Gate, Pellet, Respawn };
        }

        [XmlRoot(ElementName = "map")]
        public class Map
        {
            [XmlElement(ElementName = "grid")]
            public Grid Grid { get; set; }

            [XmlElement(ElementName = "ghosts")]
            public Ghosts Ghosts { get; set; }

            [XmlElement(ElementName = "pacman")]
            public PacManCell Pacman { get; set; }

            [XmlElement(ElementName = "checkpoints")]
            public Сheckpoints Сheckpoints { get; set; }

            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }

            [XmlAttribute(AttributeName = "version")]
            public string Version { get; set; }
        }

        #endregion
    }
}
