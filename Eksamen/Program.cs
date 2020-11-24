using System;
using System.Collections.Generic;

namespace Eksamen
{
    class Program
    {
        static void Main(string[] args)
        {
            IStregsystem stregsystem = new Stregsystem();
            IStregsystemUI ui = new StregsystemCLI(stregsystem); 
            StregsystemController sc = new StregsystemController(ui, stregsystem);
            //Console.WriteLine(stregsystem.GetUsers((user => user.ID == 1))); Virker POG
            ui.Start();

        }
    }
}
