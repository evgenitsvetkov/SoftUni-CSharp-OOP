namespace P01.Stream_Progress
{
    public class File
    {
        //Constructor
        public File(string name,int length, int bytesSent)
        {
            this.Name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        //Properties
        public string Name { get; }

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
