using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MiniProjekt
{
    class FileSystemMenu : Menu, IMenuItem
    {
        public DirectoryInfo Path;
        private DirectoryInfo[] Folders;
        public FileSystemMenu(string title, DirectoryInfo path)
        {
            Title = title;
            Path = path;
            Folders = Path.GetDirectories();
        }

        public new void Action()
        {
            foreach (DirectoryInfo Folder in Folders)
            {
                MenuPunkter.Add(new FileSystemMenu(Folder.Name, new DirectoryInfo(Folder.FullName)));
            }
            Console.Clear();
            Start();

        }


    }
}
