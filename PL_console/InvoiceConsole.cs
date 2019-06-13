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


        CustomerBL csBL = new CustomerBL();
        CompanyBL comBL = new CompanyBL();
        Menu menu = new Menu();
        ReadMoney monney = new ReadMoney();
        MeterBL meterBL = new MeterBL();
        MeterLogsBL meterLogsBL = new MeterLogsBL();
        // int cusID;


        public void MenuInvoice()
        {
            Console.Clear();
            int magChoice;

            while (true)
            {
                // Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════════╗");
                Console.WriteLine("║         MENU QUẢN LÝ HÓA ĐƠN             ║");
                Console.WriteLine("╠══════════════════════════════════════════╣");
                Console.WriteLine("║ 1.Xuất hóa đơn                           ║");
                Console.WriteLine("║ 2.Thống kê hóa đơn                       ║");
                Console.WriteLine("║ 3.Nhập số công tơ theo tháng             ║");
                Console.WriteLine("║ 0.Trở về menu chính                      ║");
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
                            menu.MainMenu();
                            break;
                        }
                    case 1:
                        {
                            try
                            {
                                // Console.Clear();
                                ShowInvoice();
                            }
                            catch (System.NullReferenceException)
                            {
                                menu.MenuChoice("MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI!");
                            }
                            catch (MySql.Data.MySqlClient.MySqlException)
                            {
                                Console.WriteLine("MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI!");
                            }
                            break;
                        }
                    case 2:
                        {

                            try
                            {
                                // Console.Clear();
                                InvoiceStatistics();
                            }
                            catch (System.NullReferenceException)
                            {
                                menu.MenuChoice("MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI!");
                            }
                            catch (MySql.Data.MySqlClient.MySqlException)
                            {
                                menu.MenuChoice("MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI!");
                            }
                            break;
                        }
                    case 3:
                        {

                            try
                            {
                                // Console.Clear();
                                NumberOfMeter();
                            }
                            catch (System.NullReferenceException)
                            {
                                menu.MenuChoice("MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI!");
                            }
                            catch (MySql.Data.MySqlClient.MySqlException)
                            {
                                menu.MenuChoice("MẤT KẾT NỐI, MỜI BẠN ĐĂNG NHẬP LẠI!");
                            }
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
        public void ShowInvoice()
        {
            Console.Clear();
            // Console.WriteLine("-------------------------- Xuất Hóa đơn Tháng {0} của khách hàng----------------------", DateTime.Now.Month);
            Company com = comBL.GetinfoBycompanyId(1);
            while (true)
            {

                int customerId;
                Customer customer = null;
                Meter mt = null;
                Console.WriteLine("-------------------------- Xuất Hóa đơn Tháng {0} của khách hàng----------------------", DateTime.Now.Month);
                

                Console.Write("- Nhập ID khách hàng cần xuất hóa đơn: ");
                customerId = csBL.checkid();
                while (csBL.GetCustomerbyID(customerId) == null)
                {
                    Console.WriteLine("Mã Khách hàng không tồn tại !");
                    customerId = csBL.checkid();
                }

                customer = csBL.GetCustomerbyID(customerId);
                mt = meterBL.GetMeterbyCusID(customerId);
                if (meterLogsBL.GetMeterLogsByMonth(mt.MeterID, DateTime.Now.Month + "/" + DateTime.Now.Year) != null)
                {

                    int unit_price = 0;
                    int oldNumber = 0;
                    MeterLogs mtLogs = meterLogsBL.GetMeterLogsByMonth(mt.MeterID, DateTime.Now.Month + "/" + DateTime.Now.Year);
                    if(meterLogsBL.GetMeterLogsByMonth(mt.MeterID, (DateTime.Now.Month -1) + "/" + DateTime.Now.Year) != null)
                    {
                        oldNumber = meterLogsBL.GetMeterLogsByMonth(mt.MeterID, (DateTime.Now.Month -1) + "/" + DateTime.Now.Year).NewNumber;
                    }
                    else
                    {
                        oldNumber = 0;
                    }
                    

                    if (mtLogs.MeterType == "sinh hoạt")
                    {
                        unit_price = 5900;
                    }
                    else if (mtLogs.MeterType == "sản xuất")
                    {
                        unit_price = 11000;
                    }
                    else if (mtLogs.MeterType == "kinh doanh")
                    {
                        unit_price = 22000;
                    }
                    else if (mtLogs.MeterType == "HCSN")
                    {
                        unit_price = 9900;
                    }
                    // else
                    // {

                    // }
                    double count = (mtLogs.NewNumber - oldNumber) * unit_price;
                    double tax1 = count * 0.05;
                    double tax2 = count * 0.1;

                    Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("                                     HÓA ĐƠN GIÁ TRỊ GIÁ GIA TĂNG");
                    Console.WriteLine("                                          (THU TIỀN NƯỚC)");
                    Console.WriteLine("    {0}", com.CompanyName);
                    Console.WriteLine("    ĐC:{0}\t    ", com.HeadQuarters);
                    Console.WriteLine("    Điện thoại:{0}", com.Phone);
                    Console.WriteLine("    MST: " + com.Tax);
                    Console.WriteLine(); Console.WriteLine();
                    Console.WriteLine("    Hóa đơn nước tháng " + DateTime.Now.Month + "/" + DateTime.Now.Year);
                    Console.WriteLine("    Khách hàng: " + customer.CustomerName + "                                MHD: {0}", (10000 + mtLogs.MeterLogID));
                    Console.WriteLine("    Địa chỉ: " + customer.CustomerAddress);
                    Console.WriteLine("    CMND: " + customer.CMND);
                    Console.WriteLine("    SĐT: " + customer.PhoneNumber);
                    var table1 = new ConsoleTable("Chỉ số cũ", "Chỉ số mới", "Số tiêu thụ", "Đơn giá", "Thành tiền");
                    table1.AddRow(oldNumber, mtLogs.NewNumber, mtLogs.NewNumber - oldNumber, unit_price, count);
                    Console.WriteLine(table1);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();

                    Console.WriteLine("   Thuế GTGT 5% :                                    {0}", tax1);
                    Console.WriteLine("   Thuế BVMT 10% :                                   {0}", tax2);
                    Console.WriteLine("   Tổng tiền phải thanh toán:                        {0}", (count + tax1 + tax2));
                    Console.WriteLine("   (Viết bằng chữ): " + monney.DocTienBangChu((count + tax1 + tax2), " VNĐ"));
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("                                                              " + com.CompanyName);
                    Console.WriteLine("                                                                          GIÁM ĐỐC");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════════════╝");

                    if (mtLogs.PayStatus == "Chưa thanh toán")
                    {
                        Console.Write("Thanh toán hóa đơn này ?(1.Thanh toán , 2.Tạm hoãn thanh toán): ");
                        int choice6;
                        choice6 = csBL.checkid();
                        if (choice6 == 1)
                        {
                            meterLogsBL.UpdatePayStatusMeterLogs(mt.MeterID, mtLogs.MeterLogsMonth);
                            Console.WriteLine("Thanh toán thành công!");
                        }
                        else if (choice6 == 2)
                        {
                            Console.WriteLine("Hóa đơn chưa được thanh toán!");
                        }
                        else if (choice6 != 1 || choice6 != 2)
                        {
                            Console.Write("Bạn chỉ được phép nhập (1,2): ");
                            choice6 = csBL.checkid();
                            Console.WriteLine("Hóa đơn chưa được thanh toán!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Hóa đơn đã được thanh toán !");
                    }


                }
                else
                {
                    Console.WriteLine("Không có dữ liệu tháng {0} để xuất hóa đơn cho khách hàng này", DateTime.Now.Month);
                }
                string choice2;
                Console.Write("Bạn có muốn tiếp tục? (Y/N): ");
                choice2 = Console.ReadLine();
                while (choice2 != "y" && choice2 != "Y" && choice2 != "n" && choice2 != "N")
                {
                    Console.Write("Nhập sai!, Bạn chỉ được nhập(Y/N): ");
                    choice2 = Console.ReadLine();
                }
                switch (choice2)
                {
                    case "Y":
                        {
                            Console.Clear();
                            continue;
                        }
                    case "y":
                        {
                            Console.Clear();
                            continue; ;
                        }
                    case "N":
                        {
                            MenuInvoice();
                            break;
                        }
                    case "n":
                        {
                            MenuInvoice();
                            break;
                        }
                    default:
                        {
                            MenuInvoice();
                            break;
                        }
                }
                break;

            }


        }
        // public Invoice StatisticInvoice(){
        //     return ;
        // }
        public void NumberOfMeter()
        {
            Console.Clear();

            while (true)
            {
                Customer cs = null;
                Meter meter = null;
                Console.WriteLine("----------------- Cập nhật chỉ số đồng hồ tháng {0} ----------------", DateTime.Now.Month);
                int cusID;
                int new_number;

                Console.Write("- Nhập Id khách hàng: ");
                cusID = csBL.checkid();
                while (csBL.GetCustomerbyID(cusID) == null)
                {
                    Console.WriteLine("Mã Khách hàng không tồn tại !");
                    cusID = csBL.checkid();
                }

                cs = csBL.GetCustomerbyID(cusID);
                meter = meterBL.GetMeterbyCusID(cusID);
                if (meterLogsBL.GetMeterLogsByMonth(meter.MeterID, DateTime.Now.Month + "/" + DateTime.Now.Year) == null)
                {
                    if (DateTime.Now.Day > 10)
                    {
                        int newNum = 0;
                        if(meterLogsBL. GetMeterLogsByMonth(meter.MeterID, (DateTime.Now.Month -1) + "/" + DateTime.Now.Year)!=null)
                        {
                            newNum = meterLogsBL. GetMeterLogsByMonth(meter.MeterID, (DateTime.Now.Month -1) + "/" + DateTime.Now.Year).NewNumber;
                        }
                        Console.WriteLine("- Họ và tên khách hàng: " + cs.CustomerName);
                        Console.WriteLine("- Địa chỉ : " + cs.CustomerAddress);
                        Console.WriteLine("- Số điện thoại : " + cs.PhoneNumber);
                        Console.WriteLine("- CMND : " + cs.CMND);
                        Console.WriteLine("- Mã công tơ :" + meter.MeterID);
                        Console.WriteLine("- Công tơ đặt tại: " + meter.MeterPlace);
                        Console.WriteLine("- Chỉ số cũ (tháng {0}): " + newNum , DateTime.Now.Month - 1);

                        Console.Write("- Nhập chỉ số mới(tháng {0}): ", DateTime.Now.Month);
                        new_number = csBL.checkid();
                        while (new_number < newNum)
                        {
                            Console.Write("- Chỉ số mới phải lớn hơn chỉ số cũ, mời nhập lại:");
                            new_number = Convert.ToInt32(Console.ReadLine());
                        };
                        Console.WriteLine("---------------------------------------------------------------------");

                        string choice;
                        Console.Write("Bạn có muốn cập nhật ?(Y/N): ");
                        choice = Console.ReadLine();
                        while (choice != "y" && choice != "Y" && choice != "n" && choice != "N")
                        {
                            Console.Write("Nhập sai!, Bạn chỉ được nhập(Y/N): ");
                            choice = Console.ReadLine();
                        }
                        if (choice == "y" || choice == "Y")
                        {
                            string mlStatus = "đang hoạt động";
                            string pay = "Chưa thanh toán";
                            string datetime = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                            meterBL.UpdateMeter(cusID, meter.MeterID, mlStatus, meter.NewNumber, new_number, meter.MeterType, meter.MeterPlace);
                            meterLogsBL.InsertMeterLogs(meter.MeterID, mlStatus, DateTime.Now.Month + "/" + DateTime.Now.Year, meter.NewNumber, new_number, datetime, meter.MeterType, meter.MeterPlace, pay);
                            Console.WriteLine("Cập nhật thành công!");
                        }
                    }
                    else
                    {
                        Console.WriteLine(" Chưa đến ngày cập nhật chỉ số đồng hồ!");
                    }

                }
                else
                {
                    Console.WriteLine("Chỉ số đồng hồ tháng {0} của khách hàng này đã được cập nhật, mời bạn quay lại vào tháng sau!", DateTime.Now.Month);
                }


                string choice1;
                Console.Write("Bạn có muốn tiếp tục? (Y/N): ");
                choice1 = Console.ReadLine();

                while (choice1 != "y" && choice1 != "Y" && choice1 != "n" && choice1 != "N")
                {
                    Console.Write("Nhập sai!, Bạn chỉ được nhập(Y/N): ");
                    choice1 = Console.ReadLine();
                }
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
                            MenuInvoice();
                            break;
                        }
                    case "n":
                        {
                            MenuInvoice();
                            break;
                        }
                    default:
                        {
                            MenuInvoice();
                            break;
                        }
                }
                break;
            }


        }
        public void InvoiceStatistics()
        {
            Console.Clear();

            while (true)
            {
                Console.WriteLine("------------------------Thống kê hóa đơn---------------------------");
                List<Customer> listCs = csBL.GetCustomer();
                int csCount = listCs.Count;

                Meter mt = null;
                MeterLogs mtl = null;
                int month;
                int year;
                int count1 = 0;
                int count4 = 0;
                int index = 0;
                double count2 = 0;

                Console.Write("- Nhập tháng bạn muốn thống kê :");
                month = csBL.checkid();
                while (1 > month || month > 12)
                {
                    Console.Write("Tháng nhập không hợp lệ, mời nhập lại: ");
                    month = csBL.checkid();
                }
                Console.Write("- Nhập năm: ");
                year = csBL.checkid();
                while (0 > year)
                {
                    Console.Write("năm nhập không hợp lệ, mời nhập lại: ");
                    year = csBL.checkid();
                }

                List<MeterLogs> listMeterLogs = meterLogsBL.GetListMeterLogsByMonth(month + "/" + year);


                var table1 = new ConsoleTable("ID khách hàng", "Tên Khách hàng", "Mã Công tơ", "Mục Đích sử dụng", "chỉ số mới", "chỉ số cũ", "Tổng tiền", "thanh toán");

                foreach (Customer cs in listCs)
                {
                    mt = meterBL.GetMeterbyCusID(cs.CustomerId);
                    
                    foreach (MeterLogs ML in listMeterLogs)
                    {

                        if (mt.MeterID == ML.MeterID)
                        {
                            mtl = meterLogsBL.GetMeterLogsByMonth(mt.MeterID,( DateTime.Now.Month -1)+"/"+DateTime.Now.Year);
                            int price = 0;
                            double count = 0;
                            double tax3 = 0;
                            double tax4 = 0;
                            if (ML.MeterType == "sinh hoạt")
                            {
                                price = 5900;
                            }
                            else if (ML.MeterType == "sản xuất")
                            {
                                price = 11000;
                            }
                            else if (ML.MeterType == "kinh doanh")
                            {
                                price = 22000;
                            }
                            else if (ML.MeterType == "HCSN")
                            {
                                price = 9900;
                            }
                            count = (ML.NewNumber - ML.OldNumber) * price;
                            tax3 = ((ML.NewNumber - ML.OldNumber) * price) * 0.05;
                            tax4 = ((ML.NewNumber - ML.OldNumber) * price) * 0.1;
                            table1.AddRow(cs.CustomerId, cs.CustomerName, ML.MeterID, ML.MeterType, ML.NewNumber, ML.OldNumber, (count + tax3 + tax4), ML.PayStatus);

                            index++;
                            if (meterLogsBL.GetMeterLogsByMonth(mt.MeterID, month + "/" + year).PayStatus == "Đã thanh toán")
                            {

                                double count3 = (ML.NewNumber - ML.OldNumber) * price;
                                double tax5 = count3 * 0.05;
                                double tax6 = count3 * 0.1;
                                count2 += (count3 + tax5 + tax6);
                                count1++;
                            }
                            else
                            {
                                count4++;
                            }
                        }

                    }
                    if (meterLogsBL.GetMeterLogsByMonth(mt.MeterID, month + "/" + year) == null)
                    {
                        table1.AddRow(cs.CustomerId, cs.CustomerName, mt.MeterID, mt.MeterType, "Không có số liệu ", "Không có số liệu", "Không có số liệu ", " chưa tạo hóa đơn");
                    }
                }

                if (index != 0)
                {
                    Console.WriteLine("-------------------------------------------------------- Thống kê hóa đơn tháng {0} năm {1} ---------------------------------------------------------", month, year);
                    table1.Write();
                    Console.WriteLine();
                    Console.WriteLine("- Tổng số khách hàng {0}", csCount);
                    Console.WriteLine("- Số Khách Hàng đã thanh toán: {0}", count1);
                    Console.WriteLine("- Số khách hàng chưa thanh toán {0}", count4);
                    Console.WriteLine("- Số khách hàng chưa có dữ liệu: {0}", csCount - (count1 + count4));
                    Console.WriteLine("- Doanh thu: {0}VNĐ", count2);
                    Console.WriteLine("  (Viết bằng chữ): " + monney.DocTienBangChu(count2, " đồng"));
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("Tháng {0} năm {1} không có dữ liệu", month, year);
                }

                string choice3;
                Console.Write("Bạn có muốn tiếp tục? (Y/N)");
                choice3 = Console.ReadLine();
                while (choice3 != "y" && choice3 != "Y" && choice3 != "n" && choice3 != "N")
                {
                    Console.Write("Nhập sai!, Bạn chỉ được nhập(Y/N): ");
                    choice3 = Console.ReadLine();
                }
                switch (choice3)
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
                            MenuInvoice();
                            break;
                        }
                    case "n":
                        {
                            MenuInvoice();
                            break;
                        }
                    default:
                        {
                            MenuInvoice();
                            break;
                        }
                }
                break;


            }


        }

    }
}
