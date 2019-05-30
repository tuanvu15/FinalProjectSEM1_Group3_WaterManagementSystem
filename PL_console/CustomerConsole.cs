using System;
using Persistence;
using BL;
using System.Collections.Generic;
using ConsoleTables;
using System.Linq;

namespace PL_console
{
    public class CustomerConsole
    {
        Menu cusMenu = new Menu();
        public Customer CreateCustomer()
        {
            Customer cus = new Customer();
            CustomerBL csBL = new CustomerBL();

            while (true)
            {
                Console.WriteLine("===== TẠO MỚI KHÁCH HÀNG =====");
                // Console.Write("- Nhập ID: ");
                // while (true)
                // {
                //     //id chỉ đc nhập số 
                //     try
                //     {
                //         cus.CustomerId = Convert.ToInt16(Console.ReadLine());
                //     }
                //     catch (System.Exception)
                //     {
                //         Console.WriteLine("ID chỉ được nhập số, mời bạn nhập lại:");

                //         continue;
                //     }
                //     break;
                // }


                //kiểm tra xem id nhập vào có bị trùng hay không
                // while (csBL.GetCustomerbyID(cus.CustomerId) != null)
                // {

                //     Console.Write("Mã đã tồn tại, mời bạn nhập lại:");
                //     cus.CustomerId = Convert.ToInt16(Console.ReadLine());
                // }
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
                    csBL.InsertCustomer( cus.CustomerName, cus.CustomerAddress, cus.PhoneNumber);
                }
                else if(choice == "n" || choice == "N")
                {
                    cus=null;
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
            return cus;

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

        public void UpdateCustomer()
        {
            Console.Clear();
            while (true)
            {
                CustomerBL csBL = new CustomerBL();
                Customer cus = new Customer();
                int flag ;
                Console.WriteLine("===== CẬP NHẬT THÔNG TIN KHÁCH HÀNG =====");
                do
                {
                    flag=1;
                  Console.Write("- Nhập ID: ");
                  cus.CustomerId = Convert.ToInt32(Console.ReadLine());
                if(csBL.GetCustomerbyID(cus.CustomerId) == null)
                {
                    flag =-1;
                    Console.Write("Mã không tồn tại, mời bạn nhập lại:");
                    continue;
                }  
                } while (flag ==-1);
                
                
                Console.Clear();
               
                Console.WriteLine("====== Thông tin khách hàng cần cập nhật======");
                Console.WriteLine("Họ và tên : " + csBL.GetCustomerbyID(cus.CustomerId).CustomerName);
                Console.WriteLine("Địa chỉ : " + csBL.GetCustomerbyID(cus.CustomerId).CustomerAddress);
                Console.WriteLine("Số điện thoại : " + csBL.GetCustomerbyID(cus.CustomerId).PhoneNumber);
                Console.WriteLine("==============================================");

                Console.WriteLine("==========Mời bạn cập nhật thông tin=============");
                Console.Write("- Cập nhât họ và tên: ");
                cus.CustomerName = csBL.input(Console.ReadLine());
                


                Console.Write("- Cập Nhập địa chỉ: ");
                cus.CustomerAddress =csBL.input(Console.ReadLine());
                
                Console.Write("- Cập nhật số điện thoại: ");
                cus.PhoneNumber = csBL.Validate(Console.ReadLine());

                Console.WriteLine("=================================================");

                Console.Write("Bạn có muốn cập nhật thông tin của khách hàng này? (Y/N)");
                string choice;
                choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    csBL.UpdateCustomer(cus.CustomerId, cus.CustomerName, cus.CustomerAddress, cus.PhoneNumber);
                }
                else
                {
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
        }
    }
}