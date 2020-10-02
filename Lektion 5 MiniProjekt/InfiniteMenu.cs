using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MiniProjekt
{
    class InfiniteMenu : Menu, IMenuItem
    {
        public InfiniteMenu(string title)
        {
            Title = title;
        }

        public new void Action()
        {
            for (int i = 0; i < 6; i++)
            {
                MenuPunkter.Add(new InfiniteMenu("Uendelig menu"));
            }
            Console.Clear();
            Start();

        }

    }
}
