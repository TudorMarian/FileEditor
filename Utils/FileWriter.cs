using System.IO;

namespace Utils
{
    public class FileWriter
    {
        public void Write(string filePath, string fileContent)
        {
            File.WriteAllText(filePath, fileContent);
        }
    }
}
