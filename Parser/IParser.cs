using System.Collections.Generic;

namespace MapEngine
{
    public interface IParser<T>
    {
        T Parse(string[] input);
    }
}
