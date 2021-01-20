using System;
using System.Collections.Generic;
using System.Text;

namespace Inden_Eksamen_koks
{
    public abstract class Dane
    {
        public Dane(string name, int age)
        {
            Age = age;
            Name = name;
        }

        public int Age { get; set; }
        public string Name { get; set; }

        //Abstract metode
        public abstract void SayHello();

        //Virtual, da det er en abstract klasse kan metode også defineres, i modsætning til et interface
        public virtual void SayGoodbye()
        {
            Console.WriteLine("Farvel!");
        }
    }
}
