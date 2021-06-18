using System;

namespace Budget
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            AmountService amountService = new AmountService();
            actionService = Initialize(actionService);

            Console.WriteLine("Welcome to Home budget app!!!");
            while (true)
            {

           
                Console.WriteLine("\r\nPlease let me know what you want to do: ");
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                for (int i = 0;i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id }. { mainMenu[i].Name }");
                }

                var operation = Console.ReadKey();
                    switch (operation.KeyChar)
                    {
                        case '1':
                            var keyinfo = amountService.AddNewAmountView(actionService);
                            var id = amountService.AddNewAmount(keyinfo.KeyChar);
                            break;
                        case '2':
                            var removeId = amountService.RemoveAmountView();
                            amountService.RemoveAmount(removeId);
                            break;
                        case '3':
                            var detailId = amountService.AmountDetailSelectionView();
                            amountService.AmountDetailView(detailId);
                            break;
                        case '4':
                            var typeId = amountService.AmountTypeSelectionView();
                            amountService.AmountByTypeId(typeId);
                            break;
                        case '5':
                            amountService.Calculation();
                            break;
                        default:
                            Console.WriteLine("Action you entered does not exist");
                            break;
                        
                    }
            }

        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Add Amount", "Main");
            actionService.AddNewAction(2, "Remove Amount", "Main");
            actionService.AddNewAction(3, "Show details", "Main");
            actionService.AddNewAction(4, "List of Amounts", "Main");
            actionService.AddNewAction(5, "Calculate current budget", "Main");
            
            actionService.AddNewAction(1, "Income", "AddNewAmountMenu");
            actionService.AddNewAction(2, "Expense", "AddNewAmountMenu");
            

            return actionService;
        }


    }
}
