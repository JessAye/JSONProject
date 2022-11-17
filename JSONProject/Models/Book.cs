namespace JSONProject.Models;
internal class Book
    //Stole some code from
//https://stackoverflow.com/questions/16921652/how-to-write-a-json-file-in-c
{
 
    public string Id { get; set; }
    public VolumeInfo VolumeInfo { get; set; }
    public string SelfLink { get; set; }

    public Book(string id, VolumeInfo volumeInfo, string selfLink)
    {
        Id = id;
        VolumeInfo = volumeInfo;
        
        SelfLink = selfLink;
    }
    
    public override string ToString()
    {
        string authors = "";
        foreach (var author in VolumeInfo.Authors)
        {
            authors += $"{author}, ";
        }
        string bookString = "";
        bookString += $"Id: {Id}\n";
        bookString += $"Title: {VolumeInfo.Title}\n";
       bookString += $"Authors: {authors}\n";
       bookString += $"Description: {VolumeInfo.Description}\n";
        bookString += $"SelfLink: {SelfLink}\n";
        
        return bookString;
    }
}