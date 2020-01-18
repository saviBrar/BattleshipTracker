using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BattleshipTracker
{
    public class BoardSerializer
    {
        public static byte[] SerializeObject(IBoard board)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, board);
                return ms.ToArray();
            }
        }

        public static IBoard DeSerializeObject(byte[] boardArray)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(boardArray))
            {
                return (IBoard)formatter.Deserialize(ms);
            }
        }
    }
}
