using System;
using System.IO;
using System.Collections.Generic;

namespace Document_Merger1
{
    class Program
    {
        static void Main(string[] args)
        {
            string doconename = "";
            string doctwoname = "";
            string mergedname = "";
            int charcount = 0;
            string path = (Directory.GetCurrentDirectory() + "/");
            string response = "";

            //so the scope of a try-catch really confused me at first
            //but i think i understand it now!
            //granted this program does what it needs very simply without any exceptions

            Console.WriteLine("Document Merger\n");
            
            do
            {
            Console.WriteLine("Name your first file:  ");
            doconename = GetDocumentName();
            StreamWriter sw1 = new StreamWriter(doconename);
            Console.WriteLine("What should this file say? ");
            sw1.WriteLine(Console.ReadLine());

            Console.WriteLine("Okay! Name the second file:  ");
            doctwoname = GetDocumentName();
            StreamWriter sw2 = new StreamWriter(doctwoname);
            Console.WriteLine("What should this file say? ");
            sw2.WriteLine(Console.ReadLine());

            List<string> files = new List<string>(); //i don't think i even need this?
            files.Add(doconename);
            files.Add(doctwoname);

            sw1.Close();
            sw2.Close();
            Console.WriteLine("What should the merged file be named? ");
            mergedname = GetDocumentName();
            Console.WriteLine("\nMerging files...");
            Console.WriteLine();
            
            StreamReader sr1 = new StreamReader(doconename); //haha "do cone"
            StreamReader sr2 = new StreamReader(doctwoname);
            string doconecontents = sr1.ReadLine(); //.ReadToEnd()? maybe?
            string doctwocontents = sr2.ReadLine();
            sr1.Close();
            sr2.Close();
         
            StreamWriter sw3 = new StreamWriter(mergedname);
            sw3.WriteLine(doconecontents + doctwocontents);
            sw3.Close();
            StreamReader sr3 = new StreamReader(mergedname);
            string mergedcontents = sr3.ReadLine();
            charcount = mergedcontents.Length;

            Console.WriteLine(mergedname + " was successfully saved! The document contains " + charcount + " characters.");
            Console.WriteLine("\nWould you like to save another file? y/n: ");
            response = Console.ReadLine();
            if(response.ToLower() != "y")
                return;
            }while(response.ToLower() == "y");
            
        }
        static string GetDocumentName() //gets file name and path
        {   
            string path = (Directory.GetCurrentDirectory() + "/");
            string document = "";
            document = (path + Console.ReadLine());
            if(document.Contains(".txt") == false)
            {
               document = document + ".txt";
            }
            return document;
        }

    }
}
