using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlynhansu
{
    internal class PhongBan
    {
        List<NhanVien> dsNv = new List<NhanVien>();
        public int MaPhongBan { get; set; }
        public string TenPhongBan { get; set; }
        public bool ThemNhanVien(NhanVien nv)
        {
            bool kq = false;
            foreach (NhanVien people in dsNv)
            {
                if (people.MaNhanVien == nv.MaNhanVien)
                {
                    kq = true;
                }
            }
            if (kq)
            {
                return false;
            } else
            {
                dsNv.Add(nv);
                return true;
            }
      
        }
        
        public void remove(int ma)
        {
            for (int v = 0; v < dsNv.Count; v++)
            {
                if (dsNv[v].MaNhanVien == ma)
                {
                    dsNv.RemoveAt(v);
                }
            }
        }


        public List<NhanVien> getLengthName (int length)
        {
            List<NhanVien> ouput = new List<NhanVien> ();
            foreach (NhanVien nv in dsNv)
            {
                if (nv.TenNhanVien.Length == length)
                {
                    ouput.Add(nv);
                }
            }
            return ouput;
        }
       
        public List<NhanVien> getMoney (long money)
        {
            List<NhanVien> moneyne = new List<NhanVien>();
            foreach (NhanVien v in dsNv)
            {
               if(v.TinhLuong == money)
                {
                    moneyne.Add(v);
                }
            }
            return moneyne;
        }


        public List<NhanVien> getBirthday (DateTime time)
        {
            List<NhanVien> nv = new List<NhanVien> ();
            foreach (NhanVien p in dsNv)
            {
                if (p.NgaySinh == time)
                {
                    nv.Add(p);
                }
            }
            return nv;
        }
      
        public void edit(int manv)
        {
            int a = 0;
            foreach (NhanVien p in dsNv)
            {
                if (dsNv[a].MaNhanVien == manv)
                {
                    string menu;
                    menu = "[1] Chinh sua ten\n";
                    menu += "[2] Chinh sua ngay\n";
                    menu += "[3] Chinh sua chuc phu\n";
                    menu += "Nhap theo so + so ( 1+2+3 )\n";
                    Console.Write(menu);
                    Console.Write("Nhap so: ");
                    string cne = Convert.ToString(Console.ReadLine());
                    string[] mang = new string[1];
                    if (cne.Contains("+"))
                    {
                        mang = cne.Split("+");
                    } else
                    {
                        mang[0] = cne;
                    }
                    foreach (string so in mang)
                    {
                        int vc = Convert.ToInt32(so);
                        if (vc == 1)
                        {
                            Console.Write("Nhap ten moi [Old: " + dsNv[a].TenNhanVien + "]: ");
                            dsNv[a].TenNhanVien = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Chinh sua ten thanh cong!");
                        }
                        else if (vc == 2)
                        {
                            Console.Write("Nhap ngay sinh moi {Old: " + dsNv[a].NgaySinh + "]: ");
                            string ngaysinh = Convert.ToString(Console.ReadLine());
                            string[] nssplit = ngaysinh.Split("/");
                            dsNv[a].NgaySinh = new DateTime(Convert.ToInt32(nssplit[2]), Convert.ToInt32(nssplit[1]), Convert.ToInt32(nssplit[0]));
                            Console.WriteLine("Chinh sua thanh cong voi ngay sinh\n");
                        }
                        else if (vc == 3)
                        {
                            Console.WriteLine("Nhap chuc vu moi [" + dsNv[a].ChucVu + "]: ");
                            string cvmenu;
                            cvmenu = "[1] GIAM_DOC\n";
                            cvmenu += "[2] TRUONG_PHONG\n";
                            cvmenu += "[3] PHO_PHONG\n";
                            cvmenu += "[4] NHAN_VIEN\n";
                            Console.Write(cvmenu);
                            Console.Write("Nhap so: ");
                            int c = Convert.ToInt32(Console.ReadLine());
                            switch (c)
                            {
                                case 1:
                                    dsNv[a].ChucVu = LoaiChucVu.GIAM_DOC;
                                    break;
                                case 2:
                                    dsNv[a].ChucVu = LoaiChucVu.TRUONG_PHONG;
                                    break;
                                case 3:
                                    dsNv[a].ChucVu = LoaiChucVu.PHO_PHONG;
                                    break;
                                case 4:
                                    dsNv[a].ChucVu = LoaiChucVu.NHAN_VIEN;
                                    break;
                                default:
                                    dsNv[a].ChucVu = LoaiChucVu.NHAN_VIEN;
                                    break;
                            }
                            Console.WriteLine("Chinh sua thanh cong chuc vu\n");
                        } else
                        {
                            Console.WriteLine("Khong ro chuc nang thu " + vc + "\n");
                        }
                    }
                    break;
                            
                           
                            


                          

                    }

                a++;
            }
                
        }
        
        public int getCountNv()
        {
            return dsNv.Count;
        }


        public NhanVien TimNhanVien(int MaFind)
        {
            foreach (NhanVien nv in dsNv)
            {
                if (nv.MaNhanVien == MaFind)
                {
                    return nv;
                }
            }
            return null;
        }

        public void XuatToanBoNhanVien()
        {
            foreach (NhanVien nv in dsNv)
            {
                Console.WriteLine(nv);
            }
        }

        public List<NhanVien> getNv()
        {
            return dsNv;
        }


        public int genID()
        {
            Random rd = new Random();
            return rd.Next(10000000, 99999999);
        }

        
    }
}
