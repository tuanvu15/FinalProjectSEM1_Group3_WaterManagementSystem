using System;
using System.Text;
using BL;
using Persistence;

namespace PL_console
{
    public class Menu
    {
        public void MenuChoice(string err)
        {
            Console.Clear();
            int choice;

            while (true)
            {
                Console.Clear();
                if (err != null)
                {
                    Console.WriteLine(err);
                }

                Console.WriteLine("╔══════════════════════════════════════════╗");
                Console.WriteLine("║    HỆ THỐNG QUẢN LÝ HÓA ĐƠN TIỀN NƯỚC    ║");
                Console.WriteLine("╠══════════════════════════════════════════╣");
                Console.WriteLine("║ 1.Đăng nhập                              ║");
                Console.WriteLine("║ 0.Thoát                                  ║");
                Console.WriteLine("╚══════════════════════════════════════════╝");
                Console.Write("Chọn: ");
                while (true)
                {
                    bool check = Int32.TryParse(Console.ReadLine(), out choice);
                    if (!check)
                    {
                        Console.Write("nhập lại:");
                    }
                    else
                    {
                        break;
                    }
                }

                switch (choice)
                {
                    case 1:
                        {
                            MenuLogin();
                            break;
                        }
                    case 0:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
                break;
            }



        }
        public void MenuLogin()
        {
            Managers manager = null;
            while (true)
            {
                string email = null;
                string pass = null;
                Console.Clear();
                Console.WriteLine("============ ĐĂNG NHẬP ============");
                Console.Write("USERNAME:");
                email = Console.ReadLine();
                Console.Write("PASSWORD:");
                pass = Password();
                Console.WriteLine("===================================");
                string choice;
                try
                {
                    ManagersBL magBL = new ManagersBL();
                    manager = magBL.Login(email, pass);
                }
                catch (System.NullReferenceException)
                {
                    Console.Write("Mất kết nối, bạn có muốn đăng nhập lại không? (Y/N)");
                    choice = Console.ReadLine().ToUpper();

                    while (true)
                    {
                        if (choice != "Y" && choice != "y")
                        {
                            Console.Write("Bạn chỉ được nhập (Y/N): ");
                            choice = Console.ReadLine().ToUpper();
                            continue;
                        }
                        break;
                    }

                    switch (choice)
                    {
                        case "Y":
                            continue;
                        case "y":
                            continue;
                        case "N":
                            MenuChoice(null);
                            break;
                        case "n":
                            MenuChoice(null);
                            break;
                        default:
                            continue;
                    }
                    
                }
                catch (MySql.Data.MySqlClient.MySqlException)
                {
                    Console.Write("Mất kết nối, bạn có muốn đăng nhập lại không? (Y/N)");
                    choice = Console.ReadLine().ToUpper();

                    while (true)
                    {
                        if (choice != "Y" && choice != "y")
                        {
                            Console.Write("Bạn chỉ được nhập (Y/N): ");
                            choice = Console.ReadLine().ToUpper();
                            continue;
                        }
                        break;
                    }

                    switch (choice)
                    {
                        case "Y":
                            continue;
                        case "y":
                            continue;
                        case "N":
                            MenuChoice(null);
                            break;
                        case "n":
                            MenuChoice(null);
                            break;
                        default:
                            continue;
                    }
                    
                }
                

                //kiểm tra tài khoản nhập vào có đúng hay không
                if (manager == null)
                {
                    Console.Write("Email hoặc mật khẩu không đúng, bạn có muốn tiếp tục(Y/N):");
                    choice = Console.ReadLine().ToUpper();
                    while (true)
                    {
                        if (choice != "Y" && choice != "y")
                        {
                            Console.Write("Bạn chỉ được nhập (Y/N): ");
                            choice = Console.ReadLine().ToUpper();
                            continue;
                        }
                        break;
                    }
                    switch (choice)
                    {
                        case "Y":
                            {
                                continue;
                            }
                        case "y":
                            {
                                continue;
                            }
                        case "N":
                            {
                                MenuChoice(null);
                                break;
                            }
                        case "n":
                            {
                                MenuChoice(null);
                                break;
                            }
                        default:
                            {
                                continue;
                            }
                    }
                    break;
                }
                else
                {
                    MainMenu();
                }
                break;
            }

        }
        public void MainMenu()
        {
            Console.Clear();
            int magChoice;
            InvoiceConsole inv = new InvoiceConsole();
            do
            {
                // Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════════╗");
                Console.WriteLine("║               MENU QUẢN LÝ               ║");
                Console.WriteLine("╠══════════════════════════════════════════╣");
                Console.WriteLine("║ 1.Quản lí khách hàng                     ║");
                Console.WriteLine("║ 2.Quản lí hóa đơn                        ║");
                Console.WriteLine("║ 0.Đăng xuất                              ║");
                Console.WriteLine("╚══════════════════════════════════════════╝");

                Console.Write("Chọn:");

                while (true)
                {
                    bool check = Int32.TryParse(Console.ReadLine(), out magChoice);
                    if (!check)
                    {
                        Console.Write("nhập lại:");
                    }
                    else
                    {
                        break;
                    }
                }

                switch (magChoice)
                {
                    case 0:
                        {
                            MenuChoice(null);
                            break;
                        }
                    case 1:
                        {
                            CustomerMenu();
                            break;
                        }
                    case 2:
                        {
                            inv.MenuInvoice();
                            break;
                        }
                    default:
                        {

                            continue;
                        }

                }
            } while (magChoice != 0);


        }
        public void CustomerMenu()
        {
            Console.Clear();
            int choice;
            do
            {
                CustomerConsole cusCS = new CustomerConsole();
                // Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════════╗");
                Console.WriteLine("║             QUẢN LÝ KHÁCH HÀNG           ║");
                Console.WriteLine("╠══════════════════════════════════════════╣");
                Console.WriteLine("║ 1.Tạo mới khách hàng                     ║");
                Console.WriteLine("║ 2.Xem danh sách khách hàng               ║");
                Console.WriteLine("║ 3.Cập nhật thông tin khách hàng          ║");
                Console.WriteLine("║ 0.Trở về menu chính                      ║");
                Console.WriteLine("╚══════════════════════════════════════════╝");

                Console.Write("chọn:");
                while (true)
                {
                    bool check = Int32.TryParse(Console.ReadLine(), out choice);
                    if (!check)
                    {
                        Console.Write("nhập lại:");
                    }
                    else
                    {
                        break;
                    }
                }

                switch (choice)
                {
                    case 0:
                        {

                            MainMenu();
                            break;
                        }
                    case 1:
                        {
                            try
                            {
                                // Console.Clear();
                                cusCS.CreateCustomer();
                            }
                            catch (System.NullReferenceException)
                            {
                                MenuChoice("MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI!");
                            }
                            catch (MySql.Data.MySqlClient.MySqlException)
                            {
                                MenuChoice("MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI!");
                            }

                            break;


                        }
                    case 2:
                        {
                            try
                            {
                                //  Console.Clear();
                                cusCS.DisplayCustomer();
                            }
                            catch (System.NullReferenceException)
                            {
                                MenuChoice("MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI!");
                            }
                            catch (MySql.Data.MySqlClient.MySqlException)
                            {
                                MenuChoice("MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI!");
                            }

                            break;

                        }
                    case 3:
                        {
                            
                            
                            try
                            {
                                //  Console.Clear();
                                cusCS.UpdateCustomer();
                            }
                            catch (System.NullReferenceException)
                            {
                                MenuChoice("MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI!");
                            }
                            catch (MySql.Data.MySqlClient.MySqlException)
                            {
                                MenuChoice("MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI!");
                            }
                            break;

                        }
                    default:
                        {
                            continue;
                        }
                }
            } while (choice != 0);

        }

        public string Password()
        {
            //hiển thị pass thành dấu "*"
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        sb.Length--;
                    }
                    continue;
                }
                Console.Write('*');

                sb.Append(cki.KeyChar);
            }
            return sb.ToString();
        }
    }
}