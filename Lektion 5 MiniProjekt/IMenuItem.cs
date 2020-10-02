using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProjekt
{
    interface IMenuItem
    {
        public string Title { get; set; }

        public void Action();
    }
}
