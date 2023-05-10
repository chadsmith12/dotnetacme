using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsEncryptCli
{
    internal class MenuItem
    {
        public MenuItem(string name, Action action)
        {
            Name = name;
            Action = action;
        }

        public MenuItem(string name, Menu subMenu)
        {
            Name = name;
            Menu = subMenu;
        }

        public void PreformAction()
        {
            if (Action != null)
            {
                Action();
                return;
            }

            Menu?.ShowMenu();
        }

        public string Name { get; private set; }
        public Action? Action { get; private set; }
        public Menu? Menu { get; private set; }
    }
}
