using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Inden_Eksamen_koks
{
    public class Person : Dane
    {
        //Arver fra base, kan bygges videre på
        public Person(string name, int age, City borI) : base(name, age)
        {
            BorI = borI;
        }

        public City BorI { get; set; }

        public event BabyBornEvent ChildBorn;
        public event Action ChildBBorn;
        public Action HEJJ;
        public EventHandler<DiedEventArgs> PersonDied;

        public Person PopChildOut(string name)
        {
            Person Child = new Person(name, 0, BorI);
            ChildBorn?.Invoke(Child);
            ChildBBorn?.Invoke();
            HEJJ?.Invoke();
            return Child;
        }

        public void PersonDies()
        {
            PersonDied?.Invoke(this, new DiedEventArgs());
        }

        public override void SayHello()
        {
            Console.WriteLine("Davs manner!");
        }

        //Man kan override og bygge videre på en metode med base, men man kan også erstate den
        public override void SayGoodbye()
        {
            base.SayGoodbye();
            Console.WriteLine("med dig");
        }


    }

    public class DiedEventArgs : EventArgs
    {
        public DiedEventArgs()
        {
            TimeOfDeath = DateTime.Now;
        }

        public DateTime TimeOfDeath;
    }

}
