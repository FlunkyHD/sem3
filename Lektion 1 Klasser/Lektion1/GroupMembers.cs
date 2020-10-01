using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion1
{
    class GroupMembers
    {
        public void Control()
        {
            Console.Write("Please enter the number of members in your group: ");
            string input = Console.ReadLine();
            int memberNum = int.Parse(input);
            string[] members = new string[memberNum];
            for (int i = 0; i < memberNum; i++)
            {
                members[i] = AskMember(i + 1);
            }

            PrintMember(members);
        }

        private void PrintMember(string[] members)
        {
            foreach (string member in members)
            {
                Console.WriteLine(member + "\n");
            }
        }

        private string AskMember(int iteNumber)
        {
            Console.Write("Type the name of group member #" + iteNumber + ": ");
            return Console.ReadLine();
        }

        public void SmartControl()
        {
            List<string> memberList = new List<string>();

            Console.WriteLine("Plese type all the names of your group members sperated by commas: ");
            string input = Console.ReadLine();
            string[] memList = input.Split(", ");

            foreach (string member in memList)
            {
                Console.WriteLine(member + "");
            }
        }

    }
}
