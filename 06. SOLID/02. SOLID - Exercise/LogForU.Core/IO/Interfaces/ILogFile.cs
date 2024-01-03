namespace LogForU.Core.IO.Interfaces
{
    public interface ILogFile
    {
        public string Name { get; }
        public string Extension { get; }
        public string Path { get; }
        public string FullPath { get; }
        public string Content { get; }
        public int Size { get; }

        public void WriteLine(string text);
    }
}
