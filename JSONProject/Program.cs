using System.Text.Json;
using System.Net;
using JSONProject.Models;
using ConsoleTables;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

//Stole some code from
//https://stackoverflow.com/questions/16921652/how-to-write-a-json-file-in-c
// and your github example 
namespace JSONProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            // set up path to the JSON file(s)
            var root = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            var dataPath = root + $"{Path.DirectorySeparatorChar}Data";
            // create options JSONSerializer must follow
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var listOfBooks = new List<Book>();
            foreach (string fileName in Directory.GetFiles(dataPath))
            {
                // set JSON string to empty and set up streamreader based on data file's path
                string jsonString = string.Empty;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    jsonString = sr.ReadToEnd();
                }

                // deserialize (read) JSON and create object(s) based on its information
                var book = JsonSerializer.Deserialize<Book>(jsonString, options);
                Console.WriteLine(book.ToString());
                listOfBooks.Add(book);
                
            }
                //json writing code Stolen from:
                //https://stackoverflow.com/questions/16921652/how-to-write-a-json-file-in-c
                Console.WriteLine("Add new book\n");
                List<Book> _book = new List<Book>();
                Console.WriteLine("Id:");
                string setID = Console.ReadLine();
                Console.WriteLine("Title");
                string setTitle = Console.ReadLine();
                List<string> setAuthors;
                Console.WriteLine("Author(s)? (to add multiple seperate by '',''");
                setAuthors = Console.ReadLine().Split(',').ToList();
                Console.WriteLine("Description: ");
                string setDesc= Console.ReadLine();
                Console.WriteLine("SelfLink: ");
                string setSelfLink = Console.ReadLine();
                _book.Add(new Book( setID,new VolumeInfo(setTitle,setAuthors, setDesc), setSelfLink ));
               
                
          
                Console.WriteLine("FileName: ");
                string customFileName = Console.ReadLine();
                
                //serialization w/o Newtonsoft
                
                // string json = JsonSerializer.Serialize(_book);
                //File.WriteAllText(dataPath + '/' + customFileName +".json", json);
            
                //Serialization with Newtonsoft
                string jsonNewton = JsonConvert.SerializeObject(_book.ToArray());
                System.IO.File.WriteAllText(dataPath + '/' + customFileName +".json", jsonNewton);



        }

        
    }
    
}