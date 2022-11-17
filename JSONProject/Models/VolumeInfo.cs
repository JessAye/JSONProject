namespace JSONProject.Models;

internal class VolumeInfo
{
   public string Title { get; set; }
   public List<string> Authors { get; set; }
   public string Description { get; set; }

   public VolumeInfo(string title, List<string> authors, string description)
   {
      Title = title;
      Authors = authors;
      Description = description;
   }

}
