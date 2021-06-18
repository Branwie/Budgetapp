using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget
{
    class AmountService
    {
        public List<Amount> Amounts { get; set; }

        public AmountService()
        {
            Amounts = new List<Amount>();
        }

        public ConsoleKeyInfo AddNewAmountView(MenuActionService actionService)
        {
            var addNewAmountMenu = actionService.GetMenuActionsByMenuName("AddNewAmountMenu");
            Console.WriteLine("\r\nPlease select type:");
            for (int i = 0; i < addNewAmountMenu.Count; i++)
            {
                Console.WriteLine($"{addNewAmountMenu[i].Id }. { addNewAmountMenu[i].Name }");
            }

            var operation = Console.ReadKey();
            return operation;
        }

        public int AddNewAmount(char amountType)
        {
            int amountTypeId;
            Int32.TryParse(amountType.ToString(), out amountTypeId);
            Amount amount = new Amount();
            amount.TypeId = amountTypeId;
            Console.WriteLine("\r\nPlease enter id for new amount:");
            var id = Console.ReadLine();
            int amountId;
            Int32.TryParse(id, out amountId);
            Console.WriteLine("\r\nPlease enter name for new amount:");
            var name = Console.ReadLine();
            Console.WriteLine("\r\nPlease enter value for new amount: ");
            var value = Console.ReadLine();
            int amountValue;
            Int32.TryParse(value, out amountValue);


            amount.Id = amountId;
            amount.Name = name;
            amount.Value = amountValue;
            


            Amounts.Add(amount);
            return amountId;
        }

        public int RemoveAmountView()
        {
            Console.WriteLine("\r\nPlease enter id for amount to remove:");
            var amountId = Console.ReadKey();
            int id;
            Int32.TryParse(amountId.KeyChar.ToString(), out id);

            return id;
        }


        public void RemoveAmount(int removeId)
        {
            Amount amountToRemove = new Amount();
            foreach(var amount in Amounts)
            {
                if(amount.Id == removeId)
                {
                    amountToRemove = amount;
                    Amounts.Remove(amountToRemove);
                    break;
                }
                
            }
        }

        public int AmountDetailSelectionView()
        {
            Console.WriteLine("\r\nPlease enter id for amount to show:");
            var amountId = Console.ReadKey();
            int id;
            Int32.TryParse(amountId.KeyChar.ToString(), out id);

            return id;
        }

        public void AmountDetailView(int detailId)
        {
            Amount amountToShow = new Amount();
            foreach (var amount in Amounts)
            {
                if (amount.Id == detailId)
                {
                    amountToShow = amount;
                    break;
                }
            }
            Console.WriteLine($"---------------------------");
            Console.WriteLine($"Amount id: {amountToShow.Id}");
            Console.WriteLine($"Amount name: {amountToShow.Name}");
            Console.WriteLine($"Amount Type Id: {amountToShow.TypeId}");
            Console.WriteLine($"Amount Value: {amountToShow.Value}");
            Console.WriteLine($"---------------------------");
        }

        public int AmountTypeSelectionView()
        {
            Console.WriteLine("\r\nPlease enter 1 to show incomes or 2 to show expenses:");
            var amountId = Console.ReadKey();
            int id;
            Int32.TryParse(amountId.KeyChar.ToString(), out id);

            return id;
        }

        public void AmountByTypeId(int typeId)
        {
            List<Amount> toShow = new List<Amount>();
            foreach(var amount in Amounts)
            {

                if (amount.TypeId == typeId)
                {
                    Console.WriteLine($"---------------------------");
                    Console.WriteLine("Amount information:");
                    Console.WriteLine($"Amount id: {amount.Id}");
                    Console.WriteLine($"Amount name: {amount.Name}");
                    Console.WriteLine($"Amount Value: {amount.Value}");
                    Console.WriteLine($"---------------------------");
                }
            }
        }

        public void Calculation()
        {
            int currentBudget = 0;
            int income = 0;
            int expense = 0;
            List<Amount> toCalculate = new List<Amount>();
            foreach(var amount in Amounts)
            {
                if(amount.TypeId == 1)
                {
                    income = income + amount.Value;
                }

                else if (amount.TypeId == 2)
                {
                    expense = expense + amount.Value;
                }

                currentBudget = income - expense;


            }
            Console.WriteLine($"---------------------------");
            Console.WriteLine($"Your current budget: {currentBudget}");
            Console.WriteLine($"---------------------------");
        }
    }
}
