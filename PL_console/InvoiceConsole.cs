using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BL;
using ConsoleTables;
using Persistence;

namespace PL_console
{
    public class InvoiceConsole
    {
        InvoiceDetailBL inv = new InvoiceDetailBL();
        Menu cus = new Menu();
        CustomerBL csBL = new CustomerBL();
        InvoiceBL inBL = new InvoiceBL();
        MonthBL monthBL = new MonthBL();
        Date dateCr = new Date();
        ReadMoney monney = new ReadMoney();
        int cusID;
        int unit_price = 5300;
        
        public void CreateInvoice()
        {
            // Console.WriteLine(inBL.GetInvoiceByID(1).DateCreate);
            while (true)
            {

               Customer cs = new Customer();
                int count = 0;
                DateTime date;
                Month month= null;
                Console.WriteLine("======= Tạo Mới Hóa Đơn =======");
                Console.Write("- Nhập id khách hàng:");
                cusID = Convert.ToInt32(Console.ReadLine());

                cs = csBL.GetCustomerbyID(cusID);
                Console.WriteLine("====Thông tin khách hàng bạn muốn tạo hóa đơn====");
                Console.WriteLine("Tên: " + cs.CustomerName);
                Console.WriteLine("Địa Chỉ: " + cs.CustomerAddress);
                Console.WriteLine("Số điện thoại: " + cs.PhoneNumber);
                Console.WriteLine();
                Console.WriteLine();
                
                if (inv.GetInvoiceByMonthAndCusID(cusID, DateTime.Now.Month) != null)
                {
                    int newNB = inv.GetInvoiceByMonthAndCusID(cusID, DateTime.Now.Month).NewNUmber;
                    int oldNB = inv.GetInvoiceByMonthAndCusID(cusID,  DateTime.Now.Month).OldNumber;
                    double tax1 = ((newNB - oldNB)*unit_price) * 0.05;
                    Console.WriteLine("Hóa đơn tháng {0} của khách hàng này đã được tạo", DateTime.Now.Month);
                    Console.WriteLine("Thời gian đã tạo hóa đơn: "+inBL.GetInvoiceByID(inv.GetInvoiceByMonthAndCusID(cusID, DateTime.Now.Month).InvoiceId).DateCreate);
                    count = (newNB - oldNB)*unit_price;
                    
                    month = monthBL.GetDateByMonthId(DateTime.Now.Month);
                    
                    Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("     CÔNG TY CỔ PHẦN CẤP THOÁT NƯỚC VTCA                     HÓA ĐƠN GIÁ TRỊ GIÁ GIA TĂNG");
                    Console.WriteLine("     ĐC:                                                             (THU TIỀN NƯỚC)");
                    Console.WriteLine("     Điện thoại: 0987654317");
                    
                    Console.WriteLine("                           Kì từ ngày: " + month.FromDate + "  đến ngày: " + month.ToDate);
                    Console.WriteLine("     Khách hàng: " + cs.CustomerName);
                    Console.WriteLine("     Địa chỉ: " + cs.CustomerAddress);
                    Console.WriteLine("     Số điện thoại: " +cs.PhoneNumber);
                    var table1 = new ConsoleTable("Chỉ số cũ", "Chỉ số mới", "Số tiêu thụ", "Đơn giá", "Thành tiền");
                    table1.AddRow(oldNB, newNB, newNB - oldNB, unit_price, count);
                    Console.WriteLine(table1);


                    Console.WriteLine("     Thuế GTGT: 5%");

                    Console.WriteLine("     Tổng tiền phải thanh toán: {0}                         ", count + tax1);
                    Console.WriteLine("      (Viết bằng chữ): "+monney.DocTienBangChu(count+tax1, " đồng") );

                    Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
                    Console.WriteLine("                                                            CÔNG TY CỔ PHẦN CẤP THOÁT NƯỚC VTCA");
                    Console.WriteLine("                                                                          GIÁM ĐỐC");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
                    continue;
                }
                else
                {
                    if (inv.GetInvoiceByMonthAndCusID(cusID, DateTime.Now.Month - 1) != null)
                    {
                        date = inBL.GetInvoiceByID(inv.GetInvoiceByMonthAndCusID(cusID, DateTime.Now.Month - 1).InvoiceId).DateCreate;
                        if (dateCr.DateDifference(date, DateTime.Now) >= 1)
                        {
                            MenuInvoice();
                        }
                        else
                        {
                            Console.WriteLine("Thời gian tạo hóa đơn phải đủ 30 ngày kể từ khi tạo hóa đơn tháng trước");
                        }
                    }
                    else
                    {
                        MenuInvoice();
                    }
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

        }

        public void MenuInvoice()
        {
            Customer cs =new Customer();
            Month month = new Month();
           
            Console.WriteLine(" -------Tạo hóa đơn tháng " + DateTime.Now.Month + "-------");

            int new_number;
            int old_Number;

            if (inv.GetInvoiceByMonthAndCusID(cusID, DateTime.Now.Month - 1) == null)
            {
                Console.Write("- Nhập chỉ số cũ: ");
                old_Number = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("- Chỉ số cũ: " + inv.GetInvoiceByMonthAndCusID(cusID, DateTime.Now.Month - 1).NewNUmber);
                old_Number = inv.GetInvoiceByMonthAndCusID(cusID, DateTime.Now.Month - 1).NewNUmber;

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

            // cs =csBL.GetCustomerbyID(cusID);
            // month=monthBL.GetDateByMonthId(cusID);
            
            // Console.WriteLine(count);
            // Console.WriteLine(inv.GetInvoiceByMonth(cusID, 2).NewNUmber);
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("     CÔNG TY CỔ PHẦN CẤP THOÁT NƯỚC VTCA                     HÓA ĐƠN GIÁ TRỊ GIÁ GIA TĂNG");
            Console.WriteLine("     ĐC:                                                             (THU TIỀN NƯỚC)");
            Console.WriteLine("     Điện thoại: 0987654317");
            Console.WriteLine();
            Console.WriteLine("                           Kì từ ngày: " + month.FromDate + "  đến ngày: " + month.ToDate);
            Console.WriteLine("     Khách hàng: " + cs.CustomerName);
            Console.WriteLine("     Địa chỉ: " + cs.CustomerAddress);
            Console.WriteLine("     Số điện thoại: " + cs.PhoneNumber);
            var table1 = new ConsoleTable("Chỉ số cũ", "Chỉ số mới", "Số tiêu thụ", "Đơn giá", "Thành tiền");
            table1.AddRow(old_Number, new_number, new_number - old_Number, unit_price, count1);
            Console.WriteLine(table1);


            Console.WriteLine("     Thuế GTGT: 5%");

            Console.WriteLine("     Tổng tiền phải thanh toán: {0}                         ", count1 + tax);
            Console.WriteLine("      (Viết bằng chữ): "+monney.DocTienBangChu(count1+tax, "đồng") );
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("                                                            CÔNG TY CỔ PHẦN CẤP THOÁT NƯỚC VTCA");
            Console.WriteLine("                                                                          GIÁM ĐỐC");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");

            string datetime = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            Console.WriteLine("Bạn có muốn lưu hóa đơn ?(Y/N)");
            string choice;
            choice = Console.ReadLine();
            if (choice == "y" || choice == "Y")
            {
                if (inv.GetInvoiceByMonthAndCusID(cusID, DateTime.Now.Month - 1) == null)
                {
                    inBL.InsertInvoice(datetime, unit_price);
                    inv.InsertInvoiceDetail(cusID, DateTime.Now.Month, new_number, old_Number);
                }
                else
                {
                    inBL.InsertInvoice(datetime, unit_price);
                    inv.InsertInvoiceDetail(cusID, DateTime.Now.Month, new_number, inv.GetInvoiceByMonthAndCusID(cusID, DateTime.Now.Month - 1).NewNUmber);
                }

            }
            else
            {
                Console.WriteLine("thông tin chưa được lưu");
            }
        }
    }
}
