using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProjekt
{
    class Menu : IMenuItem
    {
        public string Title { get; set; }
        private bool _running;
        private int _index = 0;
        public List<IMenuItem> MenuPunkter = new List<IMenuItem>();

        public Menu()
        {
            
        }

        public Menu(string title)
        {
            Title = title;
        }

        public Menu(string title, MenuItem x, MenuItem y) //UNSCUFF PÅ ET TIDSPUNKT
        {
            Title = title;
            MenuPunkter.Add(x);
            MenuPunkter.Add(y);

        }


        public void Add(MenuItem x)
        {
            MenuPunkter.Add(x);
        }

        public void Add(Menu x)
        {
            MenuPunkter.Add(x);
        }

        public void Start()
        {
            _running = true;
            do
            {
                DrawMenu();
                HandleInput();
            } while (_running);
        }

        private void DrawMenu()
        {

            for (int i = 0; i < MenuPunkter.Count; i++)
            {
                if (i == _index)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(MenuPunkter[i].Title, Console.ForegroundColor);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(MenuPunkter[i].Title, Console.ForegroundColor);
                }

            }

        }

        private void HandleInput()
        {
            ConsoleKeyInfo cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.Backspace:
                case ConsoleKey.Escape:
                    _running = false;
                    Console.Clear();
                    break;
                case ConsoleKey.UpArrow:
                    MoveMenuUp();
                    Console.Clear();
                    break;
                case ConsoleKey.DownArrow:
                    MoveMenuDown();
                    Console.Clear();
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    SelectMenu();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }

        private void MoveMenuUp()
        {
            if (_index > 0)
            {
                _index--;
            }
            
        }

        private void MoveMenuDown()
        {
            if (_index < (MenuPunkter.Count - 1))
            {
                _index++;
            }
        }

        private void SelectMenu()
        {
            MenuPunkter[_index].Action();
        }

        public void Action()
        {
            Console.Clear();
            Start();
        }

    }
}
