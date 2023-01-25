using System.IO;

namespace Utils
{
    public class FileReader
    {
        public string Read (string filePath)
        {
            string text = File.ReadAllText(filePath);
            return text;
        }
    }
}
