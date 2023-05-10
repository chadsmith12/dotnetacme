namespace LetsEncryptCli
{
    internal class Menu
    {
        struct ChoiceResult
        {
            public static ChoiceResult InvalidResult = new()
            {
                IsValid = false,
            };

            public ChoiceResult(int choice)
            {
                _choice = choice;
                IsValid = true;
            }

            private readonly int? _choice;
            public bool IsValid;

            /// <summary>
            /// Gets the value of the current ChoiceResult, if the choice is valid.
            /// Returns the underlying choice, otherwise throws InvalidOperationException if it's null;
            /// </summary>
            public int Choice
            {
                get
                {
                    if (_choice == null)
                    {
                        throw new InvalidOperationException($"{nameof(_choice)} is null");
                    }

                    return _choice.Value;
                }
            }
        }

        public Menu(string name) 
        {
            Name = name;
            MenuItems = new List<MenuItem>(3);
        }

        public Menu(string name, IReadOnlyCollection<MenuItem> menuItems)
        {
            Name = name;
            MenuItems = new List<MenuItem>(menuItems);
        }

        public void AddItem(MenuItem item)
        {
            MenuItems.Add(item);
        }

        public void ShowMenu()
        {
            ChoiceResult choiceResult;
            do
            {
                Console.WriteLine($"\n${Name}");
                for (var i = 0; i < MenuItems.Count; ++i)
                {
                    Console.WriteLine($"{i + 1}. {MenuItems[i].Name}");
                }
                Console.WriteLine("Enter Choice: ");
                var input = Console.ReadLine();
                choiceResult = GetChoice(input);

                if (choiceResult.IsValid)
                {
                    MenuItems[choiceResult.Choice - 1].PreformAction();
                }

            } while (!choiceResult.IsValid);
        }

        private ChoiceResult GetChoice(string? input)
        {
            var isValid = int.TryParse(input, out var choice);
            if (!isValid)
            {
                return ChoiceResult.InvalidResult;
            }

            if (choice < 1 || choice > MenuItems.Count)
            {
                return ChoiceResult.InvalidResult;
            }

            return new ChoiceResult(choice);
        }

        public string Name { get; private set; }
        public List<MenuItem> MenuItems { get; private set; }
    }
}
