﻿using System.Text.Json;
using JSONProject.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

//Stole some code from
//https://stackoverflow.com/questions/16921652/how-to-write-a-json-file-in-c
// and your github example 
namespace JSONProject;

public class Program
{
    private static void Main(string[] args)
    {
        // set up path to the JSON file(s)
        var root = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
        var dataPath = root + $"{Path.DirectorySeparatorChar}Data";
        // create options JSONSerializer must follow
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var listOfBooks = new List<Book>();
        
        foreach (var fileName in Directory.GetFiles(dataPath))
        {
            // set JSON string to empty and set up streamreader based on data file's path
            var jsonString = string.Empty;
            using (var sr = new StreamReader(fileName))
            {
                jsonString = sr.ReadToEnd();
            }

            // deserialize (read) JSON and create object(s) based on its information
            //var book = JsonSerializer.Deserialize<Book>(jsonString, options);
            
            //with newton
            var book = JsonConvert.DeserializeObject<Book>(jsonString);
            
            Console.WriteLine(book.ToString());
            listOfBooks.Add(book);
        }
        
        //json writing code Stolen from:
        //https://stackoverflow.com/questions/16921652/how-to-write-a-json-file-in-c
        Console.WriteLine("Add new book");
        var _book = new List<Book>();
        Console.WriteLine("Id:");
        var setID = Console.ReadLine();
        
        Console.WriteLine("Title");
        var setTitle = Console.ReadLine();
        
        List<string> setAuthors;
        Console.WriteLine("Author(s)? (to add multiple seperate by '',''");
        setAuthors = Console.ReadLine().Split(',').ToList();
        
        Console.WriteLine("Description: ");
        var setDesc = Console.ReadLine();
        
        Console.WriteLine("SelfLink: ");
        var setSelfLink = Console.ReadLine();
        
        _book.Add(new Book(setID, new VolumeInfo(setTitle, setAuthors, setDesc), setSelfLink));


        Console.WriteLine("FileName: ");
        var customFileName = Console.ReadLine();

        //serialization w/o Newtonsoft
        // string json = JsonSerializer.Serialize(_book);
        //Serialization with Newtonsoft
        var jsonNewton = JsonConvert.SerializeObject(_book.ToArray());
        
        //throws error if you dont remove the [] the array has around it so these remove them:
        jsonNewton = jsonNewton.Remove(0, 1);
        jsonNewton = jsonNewton.Remove(jsonNewton.Length - 1, 1);
        
        //creates the file with the book object created
        File.WriteAllText(dataPath + '/' + customFileName + ".json", jsonNewton);
    }
}