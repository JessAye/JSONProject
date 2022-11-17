namespace JSONProject.Models;

internal class VolumeInfo
{
    public VolumeInfo(string title, List<string> authors, string description)
    {
        Title = title;
        Authors = authors;
        Description = description;
    }

    public string Title { get; set; }
    public List<string> Authors { get; set; }
    public string Description { get; set; }
}
