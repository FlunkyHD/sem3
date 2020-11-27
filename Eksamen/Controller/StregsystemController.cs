using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Eksamen.Core;
using Eksamen.UI;

namespace Eksamen.Controller
{
    public class StregsystemController
    {
        private readonly IStregsystem S;
        private readonly IStregsystemUI SUI;
        private readonly Dictionary<string, Action<string[]>> _adminCommands = new Dictionary<string, Action<string[]>>();

        public StregsystemController(IStregsystemUI sui, IStregsystem s)
        {
            S = s;
            SUI = sui;
            SUI.CommandEntered += Controller;
            AddAdminCommands();
        }

        //Handle most of the throws
        private void Controller(string command)
        {
            try
            {
                ParseCommand(command);
            }
            catch (NonExistingUserException e)
            {
                SUI.DisplayUserNotFound(e.Message);
            }
            catch (NonExistingProductException e)
            {
                SUI.DisplayProductNotFound(e.Message);
            }
            catch (InsufficientCreditsException e)
            {
                SUI.DisplayGeneralError(e.Message);
            }
            catch (NotActiveProductException e)
            {
                SUI.DisplayGeneralError(e.Message);
            }
            catch (FormatException e)
            {
                SUI.DisplayGeneralError(e.Message);
            }
            catch (IndexOutOfRangeException)
            {
                SUI.DisplayGeneralError($"Not enough arguments were entered");
            }
            catch (TooManyArgumentsException e)
            {
                SUI.DisplayTooManyArgumentsError(e.Message);
            }
            catch (Exception e)
            {
                SUI.DisplayGeneralError(e.Message);
            }
        }

        private void ParseCommand(string command)
        {
            string[] split = command.Split(' ');
            if (command.StartsWith(":"))
            {

                try
                {
                    _adminCommands[split[0]].Invoke(split);
                }
                catch (KeyNotFoundException)

                {
                    SUI.DisplayAdminCommandNotFoundMessage($"{split[0]}");
                }

            }
            else
            {
                if (split.Length == 3) //Multi BUY
                {
                    MultiBuyProduct(S.GetUserByUsername(split[0]), S.GetProductByID(Convert.ToInt32(split[1])), Convert.ToInt32(split[2]));
                }
                else if (split.Length == 2) //Normal
                {
                    BuyProduct(S.GetUserByUsername(split[0]), S.GetProductByID(Convert.ToInt32(split[1])));
                }
                else if (split.Length == 1) //User info
                {
                    TypedInUsername(S.GetUserByUsername(split[0]));
                }
                else if (split.Length > 3)
                {
                    throw new TooManyArgumentsException($"{split.Length} arguments entered, a maximum of 3 expected");
                }

            }

        }

        private void TestArgumentNumber(string[] command, int NumberOfArguments)
        {
            if (command.Length > NumberOfArguments)
            {
                throw new TooManyArgumentsException($"{command.Length} arguments entered, only {NumberOfArguments} excepted");
            }
        }

        private void TypedInUsername(User user)
        {
            SUI.DisplayUserInfo(user);
        }

        private void BuyProduct(User user, Product product)
        {
            if (!product.Active)
            {
                throw new NotActiveProductException($"This product is not active: {product.Name}");
            }
            if (user.Balance < product.Price && !product.CanBeBoughtOnCredit)
            {
                SUI.DisplayInsufficientCash(user, product, 1);
            }
            else
            {
                SUI.DisplayUserBuysProduct(S.BuyProduct(user, product));
            }
        }

        private void MultiBuyProduct(User user, Product product, int count)
        {
            if (!product.Active)
            {
                throw new NotActiveProductException($"This product is not active: {product.Name}");
            }
            if (count <= 0)
            {
                throw new InvalidDataException($"Amount has to be positive! typed: ({count})");
            }
            BuyTransaction bt = null;
            if (user.Balance < (product.Price * count) && !product.CanBeBoughtOnCredit)
            {
                SUI.DisplayInsufficientCash(user, product, count);
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    bt = S.BuyProduct(user, product);
                }
                SUI.DisplayUserBuysProduct(count, bt);
            }
            
        }

        private void AddAdminCommands()
        {
            _adminCommands.Add(":quit", (string[] command) =>
            {
                TestArgumentNumber(command, 1);
                SUI.Close();
            });
            _adminCommands.Add(":q", (string[] command) =>
            {
                TestArgumentNumber(command, 1);
                SUI.Close();
            });
            _adminCommands.Add(":activate", (string[] command) =>
            {
                TestArgumentNumber(command, 2);
                S.GetProductByID(Convert.ToInt32(command[1])).Active = true;
            });
            _adminCommands.Add(":deactivate", (string[] command) =>
            {
                TestArgumentNumber(command, 2);
                S.GetProductByID(Convert.ToInt32(command[1])).Active = false;
            });
            _adminCommands.Add(":crediton", (string[] command) =>
            {
                TestArgumentNumber(command, 2);
                S.GetProductByID(Convert.ToInt32(command[1])).CanBeBoughtOnCredit = true;
            });
            _adminCommands.Add(":creditoff", (string[] command) =>
            {
                TestArgumentNumber(command, 2);
                S.GetProductByID(Convert.ToInt32(command[1])).CanBeBoughtOnCredit = false;
            });
            _adminCommands.Add(":addcredits", (string[] command) =>
            {
                TestArgumentNumber(command, 3);
                SUI.DisplayInserCashTransation(S.AddCreditsToAccount(S.GetUserByUsername(command[1]),
                    Convert.ToInt32(command[2])));
            });
        }

    }
}
