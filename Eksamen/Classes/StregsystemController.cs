using System;
using System.Collections.Generic;
using System.Text;

namespace Eksamen
{
    public class StregsystemController
    {
        private IStregsystem S;
        private IStregsystemUI SUI;
        private Dictionary<string, Action<int>> _adminCommands = new Dictionary<string, Action<int>>();

        public StregsystemController(IStregsystemUI sui, IStregsystem s)
        {
            S = s;
            SUI = sui;
            SUI.CommandEntered += ParseCommand;
            _adminCommands.Add(":quit", (int i) => SUI.Close());
            _adminCommands.Add(":q", (int i) => SUI.Close());
            _adminCommands.Add(":activate", (int  i) => S.GetProductByID(i).Active = true);
            _adminCommands.Add(":deactivate", (int i) => S.GetProductByID(i).Active = false);
            _adminCommands.Add(":crediton", (int i) => S.GetProductByID(i).CanBeBoughtOnCredit = true);
            _adminCommands.Add(":creditoff", (int i) => S.GetProductByID(i).CanBeBoughtOnCredit = false);
            //TODO _adminCommands.Add(":addcredits", (int i) => S.GetProductByID(i).Active = true);
        }


        public void ParseCommand(string command)
        {
            User user;
            Product product;
            if (command.StartsWith(":"))
            {
                //TODO ADMIN COMMANDS
            }
            else
            { //TODO MÅSKE EN STOR  TRY CATCH????
                string[] split = command.Split(' ');
                user = TestUser(split[0]);
                if (split.Length == 3) //QUICKBUY
                {
                    product = TestProduct(split[1]);
                    MultiBuyProduct(user, product, Convert.ToInt32(split[2]));
                }
                else if (split.Length == 2) //Normal
                {
                    product = TestProduct(split[1]);
                    BuyProduct(user, product);
                }
                else if (split.Length == 1)
                {
                    TypedInUsername(user);
                }
                else if (split.Length > 3)
                {
                    SUI.DisplayTooManyArgumentsError(command);
                }

            }

        }

        private User TestUser(string split)
        {
            User user;
            try
            {
                user = S.GetUserByUsername(split);
            }
            catch (NonExistingUserException e)
            {
                SUI.DisplayUserNotFound(split);
                throw;
            }

            return user;
        }

        private Product TestProduct(string productID)
        {
            Product product;
            try
            {
                product = S.GetProductByID(Convert.ToInt32(productID));
            }
            catch (NonExistingProductException e)
            {
                SUI.DisplayProductNotFound(productID);
                throw;
            }

            return product;
        }

        private void TypedInUsername(User user)
        {
            SUI.DisplayUserInfo(user);
        }

        private void BuyProduct(User user, Product product)
        {
            SUI.DisplayUserBuysProduct(S.BuyProduct(user, product));
        }

        private void MultiBuyProduct(User user, Product product, int count)
        {
            BuyTransaction bt = null;
            for (int i = 0; i < count; i++)
            {
                bt = S.BuyProduct(user, product);
            }
            SUI.DisplayUserBuysProduct(count, bt);
        }



    }
}
