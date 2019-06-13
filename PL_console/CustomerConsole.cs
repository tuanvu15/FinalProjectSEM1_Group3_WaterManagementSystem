using System;
using Persistence;
using BL;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ConsoleTables;
using System.Linq;

namespace PL_console
{
    public class CustomerConsole

    {
        // public CustomerConsole() {}
        Menu cusMenu = new Menu();

        CustomerBL csBL = new CustomerBL();
        CompanyBL comBL = new CompanyBL();
        MeterBL meterBl = new MeterBL();

        public bool CreateCustomer()
        {
            Console.Clear();
            Customer cus = new Customer();
            Meter meters = new Meter();
            bool result = false;
            // Meter meters =null;
            Company com = null;
            int id = 1;


            while (true)
            {
                Console.WriteLine("―――――――――――――――――――――――――――――――――――――――――――――――TẠO MỚI KHÁCH HÀNG―――――――――――――――――――――――――――――――――――――――――――――――――――――――――");
                Console.WriteLine();
                Console.WriteLine("Ⅰ.BÊN CUNG CẤP DỊCH VỤ:(gọi tắt bên A)");
                com = comBL.GetinfoBycompanyId(id);
                Console.WriteLine();
                Console.Write("\t-Tên đơn vị Cung cấp nước:" + com.CompanyName);
                Console.WriteLine("\t\tSố điện thoại:" + com.Phone);
                Console.WriteLine("\t-Đại diện ông:\t" + com.Represent);
                Console.WriteLine("\t-Chức vụ:" + com.Title);
                Console.WriteLine("\t-Trụ sở:" + com.HeadQuarters);
                Console.Write("\t-Tài khoản:" + com.AccountNumber);
                Console.WriteLine("\tMã số thuế:" + com.Tax);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("ⅠⅠ.KHÁCH HÀNG SỬ DỤNG NƯỚC:(gọi tắt là bên B)");
                Console.WriteLine();
                Console.Write("\t-Nhập họ và tên chủ hộ: ");
                cus.CustomerName = csBL.input(Console.ReadLine());
                Console.Write("\t-Nhập nơi thường trú: ");
                cus.CustomerAddress = input(Console.ReadLine());
                Console.Write("\t-Nhập số điện thoại: ");
                cus.PhoneNumber = csBL.Validate(Console.ReadLine());
                Console.Write("\t-Nhập số CMND:");
                cus.CMND = Validate(Console.ReadLine());
                Console.Write("\t-Mã công tơ: ");
                meters.MeterID =input( Console.ReadLine());
                while (meterBl.GetMeterbyID(meters.MeterID).MeterID != null)
                {
                    Console.Write("\tMã công tơ này đã được sử dụng, mời nhập lại: ");
                    meters.MeterID = Console.ReadLine();
                }
                Console.Write("\t-Công tơ đặt tại:");//
                meters.MeterPlace = input(Console.ReadLine());
                Console.Write("\t-Số công tơ ban đầu là:");
                meters.OldNumber = csBL.checkid();
                while(meters.OldNumber < 0)
                {
                    Console.Write("\t-Số không hợp lệ, mời nhập lại: ");
                     meters.OldNumber = csBL.checkid();
                }
                Console.WriteLine("\t-Mục đích sử dụng nước: 1.sinh hoạt");
                Console.WriteLine("\t                        2.sản xuất");
                Console.WriteLine("\t                        3.kinh doanh");
                Console.WriteLine("\t                        4.HCSN");
                Console.Write("\t-Lựa chọn mục đích sử dụng nước(1,2,3,4): ");
                int chon;
                chon = csBL.checkid();
                while (chon != 1 && chon != 2 && chon != 3 && chon != 4)
                {
                    Console.Write("\t-Lựa chọn nhập không đúng mời nhập lại: ");
                    chon = csBL.checkid();
                }
                if (chon == 1)
                {
                    meters.MeterType = "sinh hoạt";
                }
                else if (chon == 2)
                {
                    meters.MeterType = "sản xuất";
                }
                else if (chon == 3)
                {
                    meters.MeterType = "kinh doanh";
                }
                else
                {
                    meters.MeterType = "HCSN";
                }
                Console.WriteLine("\t-Mục đích sử dụng nước: " + meters.MeterType);
                Console.WriteLine("―――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――");

                Console.Write("Bạn có muốn thêm khách hàng này vào danh sách? (Y/N): ");
                int count = 0;
                for (int i = 1; i < 5000; i++)
                {
                    if (csBL.GetCustomerbyID(i) != null)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                string choice;
                choice = Console.ReadLine();
                while(choice != "y" && choice != "Y" && choice !="n" && choice != "N")
                {
                    Console.Write("Nhập sai!, Bạn chỉ được nhập(Y/N): ");
                    choice = Console.ReadLine();
                }
                if (choice == "y" || choice == "Y")
                {
                    meters.MeterStatus = "đang hoạt động";
                    meters.NewNumber = 0;

                    result = true;
                    csBL.InsertCustomer(cus.CustomerName, cus.CustomerAddress, cus.PhoneNumber, cus.CMND);
                    meterBl.InsertMeter(meters.MeterID, count + 1, meters.MeterStatus, meters.NewNumber, meters.OldNumber, meters.MeterType, meters.MeterPlace);
                    Console.WriteLine("thêm mới khách hàng thành công!");

                }
                else
                {
                    Console.WriteLine("khách hàng chưa được thêm mới !");
                }


                Console.Write("Bạn có muốn tiếp tục ?(Y/N): ");
                string choice1;
                choice1 = Console.ReadLine();
                 while(choice1 != "y" && choice1 != "Y" && choice1 !="n" && choice1 != "N")
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
                            cusMenu.CustomerMenu();
                            break;
                        }
                }
                break;

            }
            return result;

        }
        public string input(string str)
        {
            string strRegex =@"[a-zA-Z_ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ0-9]+$";
            Regex regex = new Regex(strRegex);
            
            MatchCollection matchCollection = regex.Matches(str);
            while ((!regex.IsMatch(str)) || (str == ""))
            {
                Console.Write("\t-Không được để trống, hoặc chứa ký tự đặc biệt, Mời nhập lại: ");
                str = Console.ReadLine();
                matchCollection = regex.Matches(str);
                
            }
            return str;
        }
        public string Validate(string str)
        {

            Regex isValidInput = new Regex(@"^\d{12,13}$");
            // string strPhone = Console.ReadLine();
            while (!isValidInput.IsMatch(str))
            {
                Console.WriteLine("\t-sai định dạng(0003219876531)");
                Console.Write("\t-nhập lại:");
                str = Console.ReadLine();
            }
            return str;
        }

        public void DisplayCustomer()
        {
            Console.Clear();
            CustomerBL DPcus = new CustomerBL();
            MeterBL mtBL = new MeterBL();
            List<Customer> lcus = DPcus.GetCustomer();
            List<Meter> ListMeter = mtBL.GetMeter();
            var table = new ConsoleTable("ID", "Tên khách hàng", "Địa chỉ", "Số điện thoại", "CMND", "Mã công tơ", "Mục đích sử dụng nước");
            foreach ( Customer cus in lcus)
            {
                
                foreach(Meter mt in ListMeter )
                {
                    if(meterBl.GetMeterbyCusID(cus.CustomerId).MeterID == mt.MeterID)
                    {
                         table.AddRow(cus.CustomerId, cus.CustomerName, cus.CustomerAddress, cus.PhoneNumber, cus.CMND, mt.MeterID, mt.MeterType);
                    }
                   
                }
                   
            }
            table.Write();
            Console.WriteLine();

            while (true)
            {
                Console.Write("Nhấn Enter để tiếp tục...");
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
            Console.Clear();
            bool result = false;


            CustomerBL csBL = new CustomerBL();
            Meter meter = new Meter();
            MeterBL mBL = new MeterBL();
            while (true)
            {
                Console.Clear();
                int cusID;

                Customer cs = null;
                Meter met = null;

                Console.WriteLine("===== CẬP NHẬT THÔNG TIN KHÁCH HÀNG =====");
                Console.Write("- Nhập ID: ");
                cusID = csBL.checkid();

                while (csBL.GetCustomerbyID(cusID) == null)
                {
                    Console.Write("Mã không tồn tại, mời bạn nhập lại:");
                    cusID = csBL.checkid();
                };
                cs = csBL.GetCustomerbyID(cusID);
                met = meterBl.GetMeterbyCusID(cusID);


                Console.WriteLine("====== Thông tin khách hàng cần cập nhật======");
                Console.WriteLine("-Họ và tên : " + cs.CustomerName);
                Console.WriteLine("-Địa chỉ : " + cs.CustomerAddress);
                Console.WriteLine("-Số điện thoại : " + cs.PhoneNumber);
                Console.WriteLine("-CMND : " + cs.CMND);
                Console.WriteLine("-Công tơ đặt tại:" + met.MeterPlace);
                Console.WriteLine("-Số Công tơ ban đầu:" + met.OldNumber);
                Console.WriteLine("-Mục đích sử dụng nước:" + met.MeterType);
                Console.WriteLine("==============================================");
                Console.WriteLine("==========Mời bạn cập nhật thông tin=============");
                Console.Write("-Cập nhât họ và tên: ");
                cs.CustomerName = csBL.input(Console.ReadLine());
                Console.Write("-Cập Nhập địa chỉ: ");
                cs.CustomerAddress =input(Console.ReadLine());
                Console.Write("-Cập nhật số điện thoại: ");
                cs.PhoneNumber = csBL.Validate(Console.ReadLine());
                Console.Write("-Cập nhập số CMND:");
                cs.CMND = Validate(Console.ReadLine());
                Console.WriteLine("-Mã công tơ: "+met.MeterID);
                // while (meterBl.GetMeterbyID(meter.MeterID).MeterID != null)
                // {
                //     Console.Write("\t-Mã công tơ này đã được sử dụng, mời nhập lại: ");
                //     meter.MeterID = Console.ReadLine();
                // }
                Console.WriteLine("-Cập nhật công tơ đặt tại: "+met.MeterPlace);
                // Console.Write("-Cập nhật số công tơ ban đầu:");
                // meter.OldNumber = csBL.checkid();
                // while(meter.OldNumber < 0)
                // {
                //     Console.Write("\t-Số không hợp lệ, mời nhập lại: ");
                //      meter.OldNumber = csBL.checkid();
                // }
                Console.WriteLine("-Cập nhật cục đích sử dụng nước: 1.sinh hoạt");
                Console.WriteLine("                                 2.sản xuất");
                Console.WriteLine("                                 3.kinh doanh");
                Console.WriteLine("                                 4.HCSN");
                Console.Write("-Lựa chọn mục đích sử dụng nước(1,2,3,4): ");
                int chon;
                chon = csBL.checkid();
                while (chon != 1 && chon != 2 && chon != 3 && chon != 4)
                {
                    Console.Write("\t-Lựa chọn nhập không đúng mời nhập lại: ");
                    chon = csBL.checkid();
                }
                if (chon == 1)
                {
                    meter.MeterType = "sinh hoạt";
                }
                else if (chon == 2)
                {
                    meter.MeterType = "sản xuất";
                }
                else if (chon == 3)
                {
                    meter.MeterType = "kinh doanh";
                }
                else
                {
                    meter.MeterType = "HCSN";
                }
                Console.WriteLine("-Mục đích sử dụng nước: " + meter.MeterType);
                Console.WriteLine("=================================================");
                Console.Write("Bạn có muốn cập nhật thông tin của khách hàng này? (Y/N):");
                string choice;
                choice = Console.ReadLine();
                 while(choice != "y" && choice != "Y" && choice !="n" && choice != "N")
                {
                    Console.Write("Nhập sai!, Bạn chỉ được nhập(Y/N): ");
                    choice = Console.ReadLine();
                }
                if (choice == "y" || choice == "Y")
                {
                    
                    result = true;
                    met.NewNumber = 0;
                    meter.MeterStatus = "đang hoạt động";
                    csBL.UpdateCustomer(cusID, cs.CustomerName, cs.CustomerAddress, cs.PhoneNumber, cs.CMND);
                    mBL.UpdateMeter(cusID, meter.MeterID, meter.MeterStatus, meter.OldNumber, meter.NewNumber, meter.MeterType, meter.MeterPlace);
                    Console.WriteLine("thông tin đã được cập nhật!");
                }

                else
                {
                    result = false;
                    Console.WriteLine("thông tin chưa được cập nhật!");
                }

                Console.Write("Bạn có muốn tiếp tục? (Y/N): ");
                string choice4;
                choice4 = Console.ReadLine();
                while(choice4 != "y" && choice4 != "Y" && choice4 !="n" && choice4 != "N")
                {
                    Console.Write("Nhập sai!, Bạn chỉ được nhập(Y/N): ");
                    choice4 = Console.ReadLine();
                }
                switch (choice4)
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
                            break;
                        }
                }
                break;


            }
            return result;
        }
    }
}