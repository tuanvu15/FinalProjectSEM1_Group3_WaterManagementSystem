using System;
using Persistence;
using BL;
using DAL;

namespace PL_console
{
    public class CustomerConsole
    {
        Menu cusMenu = new Menu();
        public void CreateCustomer()
        {
            Customer cus = new Customer();
            CustomerBL csBL = new CustomerBL();
            
            Console.Clear();
            Console.WriteLine("===== TẠO MỚI KHÁCH HÀNG =====");
            Console.Write("- Nhập ID: ");
            cus.CustomerId = Convert.ToInt16(Console.ReadLine());

            //kiểm tra xem id nhập vào có bị trùng hay không

            while (true)
            {
                while (csBL.GetCustomerbyID(cus.CustomerId) != null)
                {
                    Console.WriteLine("===== TẠO MỚI KHÁCH HÀNG =====");
                    Console.Write("- Nhập ID: ");
                    cus.CustomerId = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Mã đã tồn tại, bạn có muốn tiếp tục?(Y/N)");
                    string choice1;
                    choice1 = Console.ReadLine();
                    switch (choice1)
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
                                cusMenu.CustomerMenu();
                                break;
                            }
                        case "n":
                            {
                                cusMenu.CustomerMenu();
                                break;
                            }
                    }
                }

                Console.Write("- Nhập họ và tên: ");
                cus.CustomerName = Console.ReadLine();
                Console.Write("- Nhập địa chỉ: ");
                cus.CustomerAddress = Console.ReadLine();
                Console.Write("- Nhập số điện thoại: ");
                cus.PhoneNumber = Console.ReadLine();
                Console.WriteLine("=============================");

                Console.Write("Bạn có muốn thêm khách hàng này vào danh sách? (Y/N)");
                string choice;
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "Y":
                        {
                            csBL.InsertCustomer(cus.CustomerId, cus.CustomerName, cus.CustomerAddress, cus.PhoneNumber);
                            break;
                        }
                    case "y":
                        {
                            csBL.InsertCustomer(cus.CustomerId, cus.CustomerName, cus.CustomerAddress, cus.PhoneNumber);
                            break;
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
                }

                string choice2;
                Console.Write("Bạn có muốn tiếp tục ?(Y/N):");
                    choice2 = Console.ReadLine();

                    switch (choice2)
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
            }

        }
        public void DisplayCustomer()
        {
            CustomerBL DPcus = new CustomerBL();
            Customer cs = new Customer();
            cs = DPcus.GetCustomer();
            Console.WriteLine("===========================");
            Console.WriteLine("- id: " + cs.CustomerId);
            Console.WriteLine("- Tên: " + cs.CustomerName);
            Console.WriteLine("- Địa chỉ: " + cs.CustomerAddress);
            Console.WriteLine("- Sdt: " + cs.PhoneNumber);

            cusMenu.CustomerMenu();
        }
    }
}