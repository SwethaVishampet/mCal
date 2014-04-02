using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace cs2103_project_UI_logic
{
    class Storage
    {
        private const string filename = "file.txt";
        
        public void write_to_file(List<string> contents)
        {
            StreamWriter fileobj = new StreamWriter(filename);
            fileobj.AutoFlush = true;
            while (contents.Count() != 0)
            {
                fileobj.WriteLine(contents[0]);
                contents.RemoveAt(0);
            }
        }
        public void read_from_file(ref List<string> contents)
        {
          //  List<string> contents = new List<string>();
            StreamReader fileobj = new StreamReader(filename);
            
            while (fileobj.Peek() != -1)
            {
                contents.Add(fileobj.ReadLine());
            }
           // return contents;
        }
    }
}
