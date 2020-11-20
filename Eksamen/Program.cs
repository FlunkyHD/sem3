using System;

namespace Eksamen
{
    class Program
    {
        static void Main(string[] args)
        {
            IStregsystem stregsystem = new Stregsystem(); 
            IStregsystemUI ui = new StregsystemCLI(stregsystem); 
            StregsystemController sc = new StregsystemController(ui, stregsystem);
            ui.Start();
        }
    }
}
