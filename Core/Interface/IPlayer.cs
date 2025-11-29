using System.Xml.Linq;

namespace MapEngine
{
    interface IPlayer
    {
        string Name { get; }

        Chip Chip { get; }
    }
}
