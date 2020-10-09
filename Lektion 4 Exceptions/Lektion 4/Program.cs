using System;

namespace Lektion_4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Opgave 1
            //ReadInteger r = new ReadInteger();
            //Console.WriteLine(r.ReadInt());

            //Opgave 2
            // Ikke lavet og den foregår i miniprojektet

            //Opgave 3
            //BankAccount b = new BankAccount(10000);
            //try
            //{
            //    b.Withdraw(1000);
            //}
            //catch (InsufficientFundsException e)
            //{
            //    Console.WriteLine(e);
            //    //throw;
            //}

            //Opgave 4


            GearBox gearBox = new GearBox();

            try
            {
                gearBox.ChangeGear(2);
                gearBox.ChangeGear(3);
                gearBox.ChangeGear(1);
                gearBox.ChangeGear(5);

                gearBox.ChangeGear(-1);
            }
            catch (IllegalGearChangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
