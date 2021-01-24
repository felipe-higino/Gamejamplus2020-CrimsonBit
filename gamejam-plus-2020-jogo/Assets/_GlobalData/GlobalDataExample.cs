using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GlobalData.Example
{
    //--------------------------------------------------- enum -> other data
    public enum MyData
    {
        D1,
        D2
    }

    static public class MyDataExtensions
    {
        static public IEnumerable<string> GetStringIterable(this MyData data)
        {
            yield return "string D1";
            yield return "string D2";
        }

        static public string GetString(this MyData data)
        {
            return data
                .GetStringIterable()
                .ElementAtOrDefault((int)data);
        }
    }
    //--------------------------------------------------- constants
    public static class Constants
    {
        public const int c1 = 3;
        public const float c2 = 8.7f;
    }
}