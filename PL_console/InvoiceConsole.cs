using System;
using System.Collections.Generic;
using BL;
using ConsoleTables;
using Persistence;

namespace PL_console
{
    public class InvoiceConsole
    {
        public bool CreateInvoice()
        {
            InvoiceDetailBL inv = new InvoiceDetailBL();
            CustomerBL csBL = new CustomerBL();
            InvoiceBL inBL = new InvoiceBL();
            MonthBL monthBL = new MonthBL();
            Menu cus = new Menu();
            bool result =true;
            while (true)
            {
                int cusID;
                int month;
                int count = 0;

                Console.WriteLine("======= Tạo Mới Hóa Đơn =======");
                Console.Write("- Nhập id khách hàng:");
                cusID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(csBL.GetCustomerbyID(cusID).CustomerName);
                Console.WriteLine(csBL.GetCustomerbyID(cusID).CustomerAddress);
                Console.WriteLine(csBL.GetCustomerbyID(cusID).PhoneNumber);

                Console.WriteLine("====Thông tin khách hàng bạn muốn tạo hóa đơn====");
                Console.WriteLine("Tên: " + csBL.GetCustomerbyID(cusID).CustomerName);
                Console.WriteLine("Địa Chỉ: " + csBL.GetCustomerbyID(cusID).CustomerAddress);
                Console.WriteLine("Số điện thoại: " + csBL.GetCustomerbyID(cusID).PhoneNumber);
                Console.WriteLine();
                Console.WriteLine();
                List<InvoiceDetail> list = inv.GetInvoiceByCustomerID(cusID);
                for (int i = 1; i < 13; i++)
                {
                    if (inv.GetInvoiceByMonth(cusID, i) != null)
                    {
                        count++;
                    }

                }

                var table = new ConsoleTable("Tháng", "Chỉ số cũ", "Chỉ số mới", "Số tiêu thụ", "tổng tiền");
                foreach (InvoiceDetail ivnd in list)
                {
                    table.AddRow(ivnd.Month, ivnd.OldNumber, ivnd.NewNUmber, ivnd.NewNUmber - ivnd.OldNumber, (ivnd.NewNUmber - ivnd.OldNumber) * 5300 + ((ivnd.NewNUmber - ivnd.OldNumber) * 5300) * 0.05);
                }
                if (count > 0)
                {
                    Console.WriteLine("--- Thông tin tiêu thụ các tháng trước ---");
                    table.Write();
                    Console.WriteLine();
                }

                Console.Write("- Nhập tháng bạn muốn tạo hóa đơn: ");
                month = Convert.ToInt32(Console.ReadLine());

                while (inv.GetInvoiceByMonth(cusID, month) != null)
                {
                    Console.WriteLine("Hóa đơn tháng này đã được tạo, mời nhập lại");
                    Console.Write("- Nhập tháng: ");
                    month = Convert.ToInt32(Console.ReadLine());
                }
                while (month <= 0 || month > 12)
                {
                    Console.WriteLine("Tháng nhập không hợp lệ");
                    Console.Write("- Nhập tháng: ");
                    month = Convert.ToInt32(Console.ReadLine());
                }
                


                Console.WriteLine("- nhập thông tin hóa đơn tháng: {0}", month);
                int new_number;
                int old_Number;

                int unit_price = 5300;

                if (inv.GetInvoiceByMonth(cusID, count) == null)
                {
                    Console.Write("- Nhập chỉ số cũ: ");
                    old_Number = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("- Chỉ số cũ: " + inv.GetInvoiceByMonth(cusID, count).NewNUmber);
                    old_Number = inv.GetInvoiceByMonth(cusID, count).NewNUmber;

                }

                Console.Write("- Nhập chỉ số mới: ");
                new_number = Convert.ToInt32(Console.ReadLine());

                while (new_number < old_Number)
                {
                    Console.WriteLine("Chỉ số mới không được nhỏ hơn chỉ số cũ, mời nhập lại");
                    Console.Write("- Nhập chỉ số mới: ");
                    new_number = Convert.ToInt32(Console.ReadLine());
                    continue;
                }
                double count1 = ((new_number - old_Number) * unit_price);
                double tax = ((new_number - old_Number) * unit_price) * 0.05;


                // Console.WriteLine(count);
                // Console.WriteLine(inv.GetInvoiceByMonth(cusID, 2).NewNUmber);
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("     CÔNG TY CỔ PHẦN CẤP THOÁT NƯỚC VTCA                     HÓA ĐƠN GIÁ TRỊ GIÁ GIA TĂNG");
                Console.WriteLine("     ĐC:                                                             (THU TIỀN NƯỚC)");
                Console.WriteLine("     Điện thoại: 0987654317");
                Console.WriteLine();
                Console.WriteLine("                           Kì từ ngày: " + monthBL.GetDateByMonthId(month).FromDate + "  đến ngày: " + monthBL.GetDateByMonthId(month).ToDate);
                Console.WriteLine("     Khách hàng: " + csBL.GetCustomerbyID(cusID).CustomerName);
                Console.WriteLine("     Địa chỉ: " + csBL.GetCustomerbyID(cusID).CustomerAddress);
                Console.WriteLine("     Số điện thoại: " + csBL.GetCustomerbyID(cusID).PhoneNumber);
                var table1 = new ConsoleTable("Chỉ số cũ", "Chỉ số mới", "Số tiêu thụ", "Đơn giá", "Thành tiền");
                table1.AddRow(old_Number, new_number, new_number - old_Number, unit_price, count1);
                Console.WriteLine(table1);


                Console.WriteLine("     Thuế GTGT: 5%");

                Console.WriteLine("     Tổng tiền phải thanh toán: {0}                         (Viết bằng chữ):", count1 + tax);

                Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
                Console.WriteLine("                                                            CÔNG TY CỔ PHẦN CẤP THOÁT NƯỚC VTCA");
                Console.WriteLine("                                                                          GIÁM ĐỐC");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

                string date_create = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;

                Console.WriteLine("Bạn có muốn lưu hóa đơn ?(Y/N)");
                string choice;
                choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    if (month == 1)
                    {
                        inBL.InsertInvoice(date_create, unit_price);
                        inv.InsertInvoiceDetail(cusID, count + 1, new_number, old_Number);
                    }
                    else
                    {
                        inBL.InsertInvoice(date_create, unit_price);
                        inv.InsertInvoiceDetail(cusID, count + 1, new_number, inv.GetInvoiceByMonth(cusID, count).NewNUmber);
                    }

                }
                else
                {
                    Console.WriteLine("thông tin chưa được lưu");
                }
                string choice1;
                Console.Write("Bạn có muốn tiếp tục? (Y/N)");

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
                            cus.MainMenu();
                            break;
                        }
                    case "n":
                        {
                            cus.MainMenu();
                            break;
                        }
                    default:
                        {
                            cus.MainMenu();
                            break;
                        }
                }
                break;

            }
            return result;

        }
    }
}