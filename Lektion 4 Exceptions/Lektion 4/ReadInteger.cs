using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion_4
{
    class ReadInteger
    {
        public int Input;
        public int ReadInt()
        {
            try
            {
                Console.WriteLine("Skriv en int tak :)");
                Input = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Du skal skrive en int din klovn!!! ");
                ReadInt();
                //throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Den er helt galt nu " + e);
            }

            return Input;
        }


    }
}
