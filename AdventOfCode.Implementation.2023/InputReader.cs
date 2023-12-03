namespace AdventOfCode.Implementation._2023
{
    public class InputReader : IInputReader
    {
        public IEnumerable<string> ReadFile(string fileName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "InputFiles", fileName);
            return File.ReadLines(path);
        }
    }
}
