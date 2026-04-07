using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NganHang
{
    internal class Program
    {

        static string[] listFunctions =
        {
            "Them tai khoan",
            "Hien thi danh sach tai khoan",
            "Tim tai khoan theo so tai khoan",
            "Nap tien",
            "Rut tien",
            "Chuyen khoan",
            "Xoa tai khoan",
            "Sap xep theo so du giam dan",
            "Tim tai khoan co so du lon nhat",
            "Thong ke theo loai tai khoan",
            "Thoat"
        };

        static string[] listTypeTaiKhoan =
        {
            "Thanh toan",
            "Tiet kiem co ky han",
            "Tiet kiem khong ky han",
            "Doanh nghiep",
            "The tin dung",
            "Tai khoan vip"
        };

        static QuanLyNganHang dsNganHang = new QuanLyNganHang();



        #region Func for help print
        static void showBar(int amount)
        {
            for (int i = 0; i < amount; i++) Console.Write("=");
            Console.WriteLine();
        }

        static void showTitleChucNang (string title)
        {
            Console.Clear();
            showBar(70);
            Console.WriteLine("\t\t\t{0}", title);
            showBar(70);
        }
        #endregion


        #region function for load data fast test
        static void loadBaseCustomer ()
        {
            for(int i = 0; i < 10; i++)
            {
                KhachHang kH = new KhachHang(
                    dsNganHang.LayMaKHMoi(),
                    "Nguyen phuc nhan hoa",
                    "123456789111",
                    "0794294817"
                );
                TaiKhoanNganHang tkNh = new TaiKhoanNganHang(
                    dsNganHang.LaySoTaiKhoanMoi(),
                    kH,
                    new Random().Next(100000, 9999999),
                    LoaiTaiKhoan.TAI_KHOAN_VIP
                );

                dsNganHang.ThemTaiKhoanMoi(tkNh);
            }

            Console.WriteLine("[+] Customer for testing aplication loaded!");


        }
        #endregion

        #region main Function
        static void HienThiDanhSachMenu()
        {
            for (int i = 0; i < listFunctions.Length; i++)
            {
                if (i == listFunctions.Length - 1) Console.WriteLine("0. " + listFunctions[i]);
                else Console.WriteLine("{0}. {1}", (i + 1), listFunctions[i]);
            }
        }

        static void HienThiDanhSachLoaiTaiKhoan ()
        {
            for (int i = 0; i < listTypeTaiKhoan.Length; i++)
            {
                Console.WriteLine("{0}. {1}", (i + 1), listTypeTaiKhoan[i]);
            }
        }

        static int ChonLoaiTaiKhoan ()
        {
            int choice = 0;
            while (true)
            {
                try
                {
                    HienThiDanhSachLoaiTaiKhoan();
                    Console.Write("Nhap so de chon loai tai khoan: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice < 1 || choice > listTypeTaiKhoan.Length)
                    {
                        Console.WriteLine("Khong duoc nhap nho hon 1 hoac vuot qua so loai tai khoan.");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Vui long nhap chinh xac so loai tai khoan");
                    continue;
                }
            }


            return choice;
        }
        static int ChonChucNang ()
        {
            int choice = 0;
            while (true)
            {
                try
                {
                    HienThiDanhSachMenu();
                    Console.Write("Nhap so de chon thuc hien chuc nang: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice < 1 || choice > listFunctions.Length)
                    {
                        Console.WriteLine("Khong duoc nhap nho hon 1 hoac vuot qua so chuc nang.");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Vui long nhap chinh xac so chuc nang");
                    continue;
                }
            }


            return choice;
        }

        static void ThemTaiKhoan ()
        {
            showTitleChucNang("Them tai khoan");
            KhachHang kH = new KhachHang();


            string MaKh, HoTen, SoCCCD, SoDienThoai;
            MaKh = dsNganHang.LayMaKHMoi();
            Console.WriteLine("Ma KH (moi): {0}", MaKh);
            while (true)
            {
                Console.Write("Nhap ten khach hang: ");
                HoTen = Console.ReadLine();
                if (String.IsNullOrEmpty(HoTen))
                {
                    Console.WriteLine("Vui long khong de trong phan nhap nay!");
                    continue;
                }
                if (HoTen.Split(' ').Length < 2)
                {
                    Console.WriteLine("Ho ten khach hang phai co toi thieu 2 chu");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.Write("Nhap so CCCD: ");
                SoCCCD = Console.ReadLine();
                if (String.IsNullOrEmpty(HoTen))
                {
                    Console.WriteLine("Vui long khong de trong phan nhap nay!");
                    continue;
                }
                if (Utils.checkValidCCCD(SoCCCD) == false)
                {
                    Console.WriteLine("So CCCD phai co 12 ki tu");
                    continue;
                }
                break;
            }



            while (true)
            {
                Console.Write("Nhap So Dien Thoai: ");
                SoDienThoai = Console.ReadLine();
                if (String.IsNullOrEmpty(HoTen))
                {
                    Console.WriteLine("Vui long khong de trong phan nhap nay!");
                    continue;
                }
                if (Utils.checkValidPhoneNumber(SoDienThoai) == false)
                {
                    Console.WriteLine("So Dien Thoai phai co 10 chu so");
                    continue;
                }
                break;

            }

            if (kH.setThongTin(MaKh, HoTen, SoCCCD, SoDienThoai) == false)
            {
                Console.WriteLine("Them khach hang that bai!");
                return;
            }


            int chonLoaiTk = ChonLoaiTaiKhoan();
            LoaiTaiKhoan loaiTk = chonLoaiTk == 1 ? LoaiTaiKhoan.THANH_TOAN :
                chonLoaiTk == 2 ? LoaiTaiKhoan.TIET_KIEM_CO_KY_HAN :
                chonLoaiTk == 3 ? LoaiTaiKhoan.TIET_KIEM_KHONG_KY_HAN :
                chonLoaiTk == 4 ? LoaiTaiKhoan.DOANH_NGHIEP :
                chonLoaiTk == 5 ? LoaiTaiKhoan.THE_TIN_DUNG :
                chonLoaiTk == 6 ? LoaiTaiKhoan.TAI_KHOAN_VIP : LoaiTaiKhoan.THANH_TOAN;
       
            TaiKhoanNganHang taiKhoan = new TaiKhoanNganHang(dsNganHang.LaySoTaiKhoanMoi(), kH, 0, loaiTk);
            dsNganHang.ThemTaiKhoanMoi(taiKhoan);
            Console.WriteLine("Them tai khoan ngan hang thanh cong!");
        }

        static void HienThiDanhSachTaiKhoan ()
        {
            showTitleChucNang("Hien thi danh sach tai khoan");
            dsNganHang.HienThiToanBoDanhSachTaiKhoan();
        }

        static TaiKhoanNganHang YeuCauNhapSoTaiKhoanRoiTim (string customMessage = "Nhap so tai khoan muon tim: ")
        {
            string soTaiKhoan;
            do
            {
                Console.WriteLine(customMessage);
                soTaiKhoan = Console.ReadLine();
            } while (String.IsNullOrEmpty(soTaiKhoan));
            TaiKhoanNganHang tkNh = dsNganHang.TimTaiKhoanTheoSoTaiKhoan(soTaiKhoan);
            return tkNh;
        }

        static void TimTaiKhoanTheoSoTaiKhoan ()
        {
            showTitleChucNang("Tim tai khoan theo so tai khoan");
            TaiKhoanNganHang tkNh = YeuCauNhapSoTaiKhoanRoiTim ();
            
            if (tkNh == null)
            {
                Console.WriteLine("Khong tim thay tai khoan nao khop voi so tai khoan nay!");
                return;
            }

            Console.WriteLine("Thong tin tai khoan ngan hang da tim duoc:\n{0}", tkNh.ToString());
            
        }



        static void NapTien ()
        {
            showTitleChucNang("Nap tien theo so tai khoan");
            TaiKhoanNganHang tkNh = YeuCauNhapSoTaiKhoanRoiTim();

            if (tkNh == null)
            {
                Console.WriteLine("Khong tim thay tai khoan nao khop voi so tai khoan nay!");
                return;
            }

            long soTienMuonNap;
            while (true)
            {
                try
                {
                    Console.Write("Nhap so tien muon nap: ");
                    soTienMuonNap = long.Parse(Console.ReadLine());
                    if (soTienMuonNap <= 0)
                    {
                        Console.WriteLine("So tien muon nap khong duoc nho hoac bang khong!");
                        continue;
                    }
                    break;
                } catch
                {
                    Console.WriteLine("Nhap khong hop le vui long nhap lai");
                }
            }

            if (tkNh.NapTien(soTienMuonNap) == false)
                Console.WriteLine("Nap {0} khong thanh cong cho so tai khoan {1}", soTienMuonNap, tkNh.SoTaiKhoan);
            else
                Console.WriteLine("Da nap thanh cong {0} cho so tai khoan {1}", soTienMuonNap, tkNh.SoTaiKhoan);
        }

        static void RutTien()
        {
            showTitleChucNang("Rut tien theo so tai khoan");
            TaiKhoanNganHang tkNh = YeuCauNhapSoTaiKhoanRoiTim();

            if (tkNh == null)
            {
                Console.WriteLine("Khong tim thay tai khoan nao khop voi so tai khoan nay!");
                return;
            }

            long soTienMuonRut;
            while (true)
            {
                try
                {
                    Console.Write("Nhap so tien muon rut: ");
                    soTienMuonRut = long.Parse(Console.ReadLine());
                    if (soTienMuonRut <= 0)
                    {
                        Console.WriteLine("So tien muon rut khong duoc nho hoac bang khong!");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Nhap khong hop le vui long nhap lai");
                }
            }

            if (tkNh.RutTien(soTienMuonRut) == false)
                Console.WriteLine("Rut tien {0} khong thanh cong cho so tai khoan {1}, co the so du ko du", soTienMuonRut, tkNh.SoTaiKhoan);
            else
                Console.WriteLine("Rut tien thanh cong {0} cho so tai khoan {1}", soTienMuonRut, tkNh.SoTaiKhoan);
        }

        static void ChuyenKhoan ()
        {
            showTitleChucNang("Chuyen tien tu tai khoan nay den tai khoan no");
            TaiKhoanNganHang tkNh = YeuCauNhapSoTaiKhoanRoiTim("Nhap so tai khoan (tu): ");
            if (tkNh == null)
            {
                Console.WriteLine("So tai khoan tu khong ton tai!");
                return;
            }

            showTitleChucNang("Thong tin so tai " + tkNh.SoTaiKhoan);
            Console.WriteLine("Chu tai khoan: {0}", tkNh.ChuTaiKhoan.HoTen);
            Console.WriteLine("So du hien tai: {0}", tkNh.SoDu);
            Console.WriteLine("Loai tai khoan: {0}", tkNh.LoaiTaiKhoan);

            TaiKhoanNganHang tkNhDen = YeuCauNhapSoTaiKhoanRoiTim("Nhap so tai khoan (muon gui den): ");
            if (tkNhDen == null)
            {
                Console.WriteLine("So tai khoan den khong ton tai!");
                return;
            }


            long soTienMuonChuyen;

            while (true)
            {
                try
                {
                    Console.Write("Nhap so tien muon chuyen: ");
                    soTienMuonChuyen = long.Parse(Console.ReadLine());
                    if (soTienMuonChuyen < 0)
                    {
                        Console.WriteLine("So tien chueyn khong dc nho hon khong!");

                    }
                    break;
                } catch
                {
                    Console.WriteLine("So tien ban nhap khong hop le!");
                }
                

            }
            
            if (tkNh.ChuyenKhoan(soTienMuonChuyen, tkNhDen))
            {
                Console.WriteLine("Chuyen khoan thanh cong!");
            } else
            {
                Console.WriteLine("Chuyen khoan that bai!");
            }



        }

        static void XoaTaiKhoan ()
        {
            showTitleChucNang("Xoa tai khoan theo so tai khoan");
            TaiKhoanNganHang tkNh = YeuCauNhapSoTaiKhoanRoiTim("Nhap so tai khoan muon xoa: ");
            if (tkNh == null)
            {
                Console.WriteLine("So tai khong muon xoa khong hop le!");
                return;
            }

            if(dsNganHang.XoaTaiKhoanTheoSoTaiKhoan(tkNh.SoTaiKhoan))
            {
                Console.WriteLine("Xoa tai khoan thanh cong!");
                return;
            }
            Console.WriteLine("Xoa tai khoan that bai!");

        }

        static void SapXepGiamDan ()
        {
            showTitleChucNang("Sap xep lai danh sach ngan hang giam dan theo so du");
            dsNganHang.SapXepGiamDanTheoSoDu();
            dsNganHang.HienThiToanBoDanhSachTaiKhoan();
        }
       
        static void TaiKhoanCoSoDuLonNhat ()
        {
            showTitleChucNang("Thong tin tai khoan co so du lon nhat");
            TaiKhoanNganHang tkNh = dsNganHang.TimTaiKhoanCoSoDuLonNhat();
            if (tkNh == null)
            {
                Console.WriteLine("Khong co tai khoan nao de tim tai khoan co so du lon nhat");
                return;
            }
            Console.WriteLine("Thong tin so tai khoan: {0}", tkNh.SoTaiKhoan);
            Console.WriteLine("Ho va ten chu the: {0}", tkNh.ChuTaiKhoan.HoTen);
            Console.WriteLine("So du: {0}", tkNh.SoDu);

        }
        
        static void ThongKeTheoLoai ()
        {
            showTitleChucNang("Thong ke theo loai");
            Dictionary<LoaiTaiKhoan, List<TaiKhoanNganHang>> result = dsNganHang.ThongKeTheoLoai();
            foreach (KeyValuePair<LoaiTaiKhoan, List<TaiKhoanNganHang>> item in  result)
            {
                Console.WriteLine("====" + item.Key + "=====");
                foreach (TaiKhoanNganHang tkNh in item.Value)
                {
                    Console.WriteLine(tkNh.ToString());
                }
               
            }
        }
        static void Main(string[] args)
        {
            loadBaseCustomer();
            while (true)
            {
                int choice = ChonChucNang();
                switch (choice)
                {
                    case 0:
                        return;
                    case 1:
                        ThemTaiKhoan();
                        break;
                    case 2:
                        HienThiDanhSachTaiKhoan();
                        break;
                    case 3:
                        TimTaiKhoanTheoSoTaiKhoan();
                        break;
                    case 4:
                        NapTien();
                        break;
                    case 5:
                        RutTien();
                        break;
                    case 6:
                        ChuyenKhoan();
                        break;
                    case 7:
                        XoaTaiKhoan();
                        break;
                    case 8:
                        SapXepGiamDan();
                        break;
                    case 9:
                        TaiKhoanCoSoDuLonNhat();
                        break;
                    case 10:
                        ThongKeTheoLoai();
                        break;
                    default:
                        break;

                }
                Console.WriteLine("Enter de tiep tuc: ");
                Console.ReadLine();
                Console.Clear();
            }
           
        }
        #endregion
    }
}
