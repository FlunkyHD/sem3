using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Eksamen.Core;
using Eksamen.UI;

namespace Eksamen.Controller
{
    public class StregsystemController
    {
        private IStregsystem S;
        private IStregsystemUI SUI;
        private Dictionary<string, Action<string[]>> _adminCommands = new Dictionary<string, Action<string[]>>();

        public StregsystemController(IStregsystemUI sui, IStregsystem s)
        {
            S = s;
            SUI = sui;
            SUI.CommandEntered += Controller;
            _adminCommands.Add(":quit", (string[] command) =>
            {
                TestArgumentNumber(command, 1); 
                SUI.Close();
            });
            _adminCommands.Add(":q", (string[] command) => 
                { TestArgumentNumber(command, 1); 
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
                SUI.DisplayInserCashTransation(S.AddCreditsToAccount(s.GetUserByUsername(command[1]),
                        Convert.ToInt32(command[2])));
            });
        }

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
                //SUI.DisplayInsufficientCash();
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

        }

        private void ParseCommand(string command)
        {
            User user;
            Product product;
            if (command.StartsWith(":"))
            {
                string[] adminSplit = command.Split(' ');

                foreach (KeyValuePair<string, Action<string[]>> commandAction in _adminCommands)
                {
                    if (adminSplit[0] == commandAction.Key)
                    {
                        commandAction.Value?.Invoke((adminSplit));
                        break;
                    }

                    if (commandAction.Equals(_adminCommands.Last()))
                    {
                        SUI.DisplayAdminCommandNotFoundMessage($"{adminSplit[0]}");
                    }

                }

            }
            else
            {
                string[] split = command.Split(' ');
                if (split.Length == 3) //QUICKBUY
                {
                    MultiBuyProduct(S.GetUserByUsername(split[0]), S.GetProductByID(Convert.ToInt32(split[1])), Convert.ToInt32(split[2]));
                }
                else if (split.Length == 2) //Normal
                {
                    BuyProduct(S.GetUserByUsername(split[0]), S.GetProductByID(Convert.ToInt32(split[1])));
                }
                else if (split.Length == 1)
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
            SUI.DisplayUserBuysProduct(S.BuyProduct(user, product));
        }

        private void MultiBuyProduct(User user, Product product, int count)
        {
            BuyTransaction bt = null;
            if (user.Balance - (product.Price * count) < 0)
            {
                throw new InsufficientCreditsException($"User: {user} did not have enough balance to buy {count}x {product.Name}");
            }
            for (int i = 0; i < count; i++)
            {
                bt = S.BuyProduct(user, product);
            }
            SUI.DisplayUserBuysProduct(count, bt);

        }

    }
}
