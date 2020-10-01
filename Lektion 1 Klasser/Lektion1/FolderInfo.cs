using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lektion1
{
    class FolderInfo
    {
        public static string FolderToPrint = @"c:\Programs";
        public string[] Directories = Directory.GetDirectories(FolderToPrint);
        public string[] Files = Directory.GetFiles(FolderToPrint);

        public void PrintFolderInfo()
        {
            foreach (string directory in Directories)
            {
                string[] dirInfo = Directory.GetDirectories(directory);
                string[] fileInfo = Directory.GetFiles(directory);
                Console.WriteLine(directory + " indeholder " + dirInfo.Length + " mapper og " + fileInfo.Length + " filer.");
            }
        }

        public void PrintFilesSize()
        {
            foreach (string file in Files)
            {
                Console.WriteLine(file + " is " + file.Length + " bytes long.");
            }

        }
    }
}
