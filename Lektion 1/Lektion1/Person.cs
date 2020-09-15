using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Lektion1
{
    class Person
    {
        private string _fornavn;
        private string _efternavn;
        private int _alder;

        private static int idCounter = 0;
        private int _id = ++idCounter;

        public int Id
        {
            get { return Id; }
        }

        public Person(int alder, string fornavn, string efternavn) : this(alder, fornavn, efternavn, null, null)
        {
        }

        public Person(int alder, string fornavn, string efternavn, Person far, Person mor)
        {
            Alder = alder;
            Fornavn = fornavn;
            Efternavn = efternavn;
            Far = far;
            Mor = mor;
        }
        public string Fornavn
        {
            get { return _fornavn;}
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(Fornavn)} cannot be null or empty");
                }
                _fornavn = value;
            }
        }

        public string Efternavn
        {
            get { return _efternavn; }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(Efternavn)} cannot be null");
                }
                _efternavn = value;
            }
        }

        public int Alder
        {
            get { return _alder; } 
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Alder should be greater than 0");
                }
                _alder = value;
            }
        }

        public Person Mor { get; set; }
        public Person Far { get; set; }
    }
}
