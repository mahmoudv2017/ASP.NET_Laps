namespace Day6Bonus.Models.Helpers
{
    public class ImageFilters
    {
        public int MaxSize { get; set; }
        public List<string> AllowedExtensions { get; set; }= new List<string>();
        public string FolderPath { get; set; }=string.Empty;

        public override string ToString()
        {
            return $"maxsize : {MaxSize} , AllowedExtensions : {AllowedExtensions} , FOlderPath : {FolderPath}";
        }
    }
}
