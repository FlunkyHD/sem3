using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MiniProjekt
{
    class MenuItem : IMenuItem
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public MenuItem(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public void Action()
        {
            Console.WriteLine(Content);
        }


    }
}
