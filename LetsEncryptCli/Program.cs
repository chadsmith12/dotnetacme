// See https://aka.ms/new-console-template for more information

using LetsEncryptCli;

var subMenu = new Menu("Sub Menu");
subMenu.AddItem(new MenuItem("Say Sub Hello", () => Console.WriteLine("Sub Helo")));

var mainMenu = new Menu("Main Menu");
mainMenu.AddItem(new MenuItem("Say Hello", () => Console.WriteLine("Hello There!")));
mainMenu.AddItem(new MenuItem("Print a Sub Menu", subMenu));
mainMenu.AddItem(new MenuItem("Quit", () => Environment.Exit(0)));

mainMenu.ShowMenu();
