using System;
using Persistence;
using BL;
using System.Collections.Generic;
using ConsoleTables;


namespace PL_console
{
    public class CustomerConsole

    {
        public CustomerConsole() { }
        Menu cusMenu = new Menu();
        public bool CreateCustomer()
        {
            bool result = false;
            Customer cus = new Customer();
            CustomerBL csBL = new CustomerBL();

            while (true)
            {
                Console.WriteLine("===== TẠO MỚI KHÁCH HÀNG =====");

                Console.Write("- Nhập họ và tên: ");
                cus.CustomerName = csBL.input(Console.ReadLine());

                Console.Write("- Nhập địa chỉ: ");
                cus.CustomerAddress = csBL.input(Console.ReadLine());


                Console.Write("- Nhập số điện thoại: ");
                cus.PhoneNumber = csBL.Validate(Console.ReadLine());

                Console.WriteLine("=============================");

                Console.Write("Bạn có muốn thêm khách hàng này vào danh sách? (Y/N)");
                string choice;
                choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    Console.WriteLine("thêm mới khách hàng thành công!");
                    result = true;
                    csBL.InsertCustomer(cus.CustomerName, cus.CustomerAddress, cus.PhoneNumber);

                }


                Console.Write("Bạn có muốn tiếp tục? (Y/N)");
                string choice1;
                choice1 = Console.ReadLine();
                switch (choice1)
                {
                    case "Y":
                        {
                            Console.Clear();
                            continue;
                        }
                    case "y":
                        {
                            Console.Clear();
                            continue;
                        }
                    case "N":
                        {
                            cusMenu.CustomerMenu();
                            break;
                        }
                    case "n":
                        {
                            cusMenu.CustomerMenu();
                            break;
                        }
                    default:
                        {
                            continue;
                        }
                }
                break;

            }
            return result;

        }
        public void DisplayCustomer()
        {
            Console.Clear();
            CustomerBL DPcus = new CustomerBL();
            List<Customer> list = DPcus.GetCustomer();
            var table = new ConsoleTable("ID", "Tên khách hàng", "Địa chỉ", "Số điện thoại");
            foreach (Customer cus in list)
            {
                table.AddRow(cus.CustomerId, cus.CustomerName, cus.CustomerAddress, cus.PhoneNumber);
            }
            table.Write();
            Console.WriteLine();

            while (true)
            {
                Console.Write("Nhấn Enter để tiếp tục");
                string choice1;
                choice1 = Console.ReadLine();
                switch (choice1)
                {
                    case "":
                        {
                            cusMenu.CustomerMenu();
                            break;
                        }
                    default:
                        {
                            continue;
                        }
                }
                break;

            }


        }
        public bool UpdateCustomer()
        {
            bool result = false;
            Console.Clear();
            Customer cus = new Customer();
            CustomerBL csBL = new CustomerBL();
            while (true)
            {
                Console.WriteLine("===== CẬP NHẬT THÔNG TIN KHÁCH HÀNG =====");
                Console.Write("- Nhập ID: ");
                Customer cs = null;
                do
                {
                    cus.CustomerId = csBL.checkid();
                    cs = csBL.GetCustomerbyID(cus.CustomerId);
                    Console.WriteLine(cs);
                    if (cs == null)
                    {
                        Console.Write("Mã không tồn tại, mời bạn nhập lại:");
                    }
                } while (cs == null);
                //Console.Clear();
                Console.WriteLine("====== Thông tin khách hàng cần cập nhật======");
                Console.WriteLine("Họ và tên : " + cs.CustomerName);
                Console.WriteLine("Địa chỉ : " + cs.CustomerAddress);
                Console.WriteLine("Số điện thoại : " + cs.PhoneNumber);
                Console.WriteLine("==============================================");
                Console.WriteLine("==========Mời bạn cập nhật thông tin=============");
                Console.Write("- Cập nhât họ và tên: ");
                cus.CustomerName = csBL.input(Console.ReadLine());
                Console.Write("- Cập Nhập địa chỉ: ");
                cus.CustomerAddress = csBL.input(Console.ReadLine());
                Console.Write("- Cập nhật số điện thoại: ");
                cus.PhoneNumber = csBL.Validate(Console.ReadLine());
                Console.WriteLine("=================================================");
                Console.Write("Bạn có muốn cập nhật thông tin của khách hàng này? (Y/N)");
                string choice;
                choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    result = true;
                    Console.Write("thông tin đã được cập nhật");
                    csBL.UpdateCustomer(cus.CustomerId, cus.CustomerName, cus.CustomerAddress, cus.PhoneNumber);
                }
                else
                {
                    result = false;
                    Console.WriteLine("thông tin chưa được cập nhật!");
                }
                
                Console.Write("Bạn có muốn tiếp tục? (Y/N)");
                string choice1;
                choice1 = Console.ReadLine();
                switch (choice1)
                {
                    case "Y":
                        {
                            Console.Clear();
                            continue;
                        }
                    case "y":
                        {
                            Console.Clear();
                            continue;
                        }
                    case "N":
                        {
                            cusMenu.CustomerMenu();
                            break;
                        }
                    case "n":
                        {
                            cusMenu.CustomerMenu();
                            break;
                        }
                    default:
                        {
                            continue;
                        }
                }
                break;


            }
            return result;
        }
    }
}