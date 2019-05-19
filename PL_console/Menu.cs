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
            if (err != null)
            {
                Console.WriteLine(err);
            }
            int choice;
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║1.Đăng nhập                   ║");
            Console.WriteLine("║╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌║");
            Console.WriteLine("║0.thoát                       ║");
            Console.WriteLine("╚══════════════════════════════╝");
            Console.Write("Chọn: ");
            // choice = Convert.ToInt32(Console.ReadLine());
              while(true)
                {
                    bool check = Int32.TryParse(Console.ReadLine(), out choice);
                    if (!check)
                    {
                        Console.Write("Nhập lại: ");
                        
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
            
           
            
            
        }
        public void MenuLogin()
        {
            while (true)
            {
                ManagersBL magBL = new ManagersBL();
                Managers manager = null;
                string email = null;
                string pass = null;
                Console.WriteLine("══════════════════════════════");
                Console.WriteLine("┄┄┄┄┄┄┄┄┄┄┄ĐĂNG NHẬP┄┄┄┄┄┄┄┄┄┄");
                    Console.Write("✉  EMAIL:");
                email = Console.ReadLine();
                    Console.Write("✎  PASSWORD:");
                pass = Password();
                Console.WriteLine("══════════════════════════════");
                string choice;
                
                manager = magBL.Login(email, pass);

                //kiểm tra tài khoản nhập vào có đúng hay không
                if (manager == null)
                {
                    Console.Write("↺ Email hoặc mật khẩu không đúng, bạn có muốn tiếp tục(Y/N):");
                    choice = Console.ReadLine();

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
                    try
                    {
                        manager = magBL.Login(email, pass);
                    }
                    catch (System.NullReferenceException)
                    {
                        Console.Write("⚠ Mất kết nối, bạn có muốn đăng nhập lại không? (Y/N)");
                        choice = Console.ReadLine().ToUpper();

                        while (true)
                        {
                            if (choice != "C" && choice != "K")
                            {
                                Console.Write("Bạn chỉ được nhập (Y/N): ");
                                choice = Console.ReadLine().ToUpper();
                                continue;
                            }
                            break;
                        }

                        switch (choice)
                        {
                            case "C":
                                continue;
                            case "c":
                                continue;
                            case "K":
                                MenuChoice(null);
                                break;
                            case "k":
                                MenuChoice(null);
                                break;
                            default:
                                continue;
                        }
                    }

                }
                break;
            }
            MainMenu();
        }
        public void MainMenu()
        {
            int magChoice;
            do
            {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════╗");
            Console.WriteLine("╠══════════ MENU QUẢN LÝ ══════════╣");
            Console.WriteLine("║1.Quản lý khách hàng              ║");
            Console.WriteLine("║2.Tạo hóa đơn                     ║");
            Console.WriteLine("║0.Đăng xuất                       ║");
            Console.WriteLine("╚══════════════════════════════════╝");
            Console.Write("Chọn:");
            
            // magChoice = Convert.ToInt32(Console.ReadLine());
            while(true)
                {
                    bool check = Int32.TryParse(Console.ReadLine(), out magChoice);
                    if (!check)
                    {
                        Console.Write("Nhập lại: ");
                        
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
                        MenuLogin();
                        break;
                    }
                case 1:
                    {
                        CustomerMenu();
                        break;
                    }
                case 2:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }

            }
            } while (magChoice!=0);
           

        }
        public void CustomerMenu()
        {

            CustomerConsole cusCS = new CustomerConsole();
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════╗");
            Console.WriteLine("╠====== QUẢN LÝ KHÁCH HÀNG ======  ╣");
            Console.WriteLine("║1.Tạo mới khách hàng              ║");
            Console.WriteLine("║2.Xem danh sách khách hàng        ║");
            Console.WriteLine("║3.Cập nhật thông tin khách hàng   ║");
            Console.WriteLine("║0.trở về menu chính               ║");
            Console.WriteLine("╚══════════════════════════════════╝");
            int choice;
            Console.Write("chọn:");
            // choice = Convert.ToInt32(Console.ReadLine());
            while(true)
                {
                    bool check = Int32.TryParse(Console.ReadLine(), out choice);
                    if (!check)
                    {
                        Console.Write("Nhập lại: ");
                        
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
                            cusCS.CreateCustomer();
                        }
                        catch (System.NullReferenceException)
                        {
                            MenuChoice("⚠ MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI !!!");
                        }
                        catch (MySql.Data.MySqlClient.MySqlException)
                        {
                            MenuChoice("⚠ MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI !!!");
                        }
                        break;


                    }
                case 2:
                    {
                        try
                        {
                            cusCS.DisplayCustomer();
                        }
                        catch (System.NullReferenceException)
                        {
                            MenuChoice("⚠ MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI !!!");
                        }
                        catch (MySql.Data.MySqlClient.MySqlException)
                        {
                            MenuChoice("⚠ MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI !!!");
                        }
                        break;

                    }
                case 3:
                    {
                        cusCS.UpdateCustomer();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        public void InvoiceManager()
        {

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
         public bool validate(string str)
        {
            Regex regex = new Regex("[a-zA-Z0-9_]");
            MatchCollection matchCollectionstr = regex.Matches(str);
            // Console.WriteLine(matchCollectionstr.Count);
            if (matchCollectionstr.Count < str.Length)
            {
                return false;
            }
            return true;

        }
       
    }
}