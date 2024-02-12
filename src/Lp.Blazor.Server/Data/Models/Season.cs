namespace Lp.Blazor.Server.Data.Models
{
    public class Season
    {
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
