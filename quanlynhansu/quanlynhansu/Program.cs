using quanlynhansu;
using System;
using System.Text;

namespace quanly
{
    class Program
    {
      
     
        static List<PhongBan> dsPB = new List<PhongBan>();
        static void Main (string[] args)
        {
            while (true)
            {
                Console.Clear();
                Menu();
            }
        }
        static void Menu()
        {
            string menu;
            menu = "[1] Them nhan vien\n";
            menu += "[2] Quan ly nhan vien\n";
            menu += "[3] Them Phong Ban\n";
            menu += "[4] Quan ly phong ban\n";
            Console.Write(menu);
            choose();
        }
        static void choose()
        {
            Console.Write("Nhap chuc nang: ");
            int menu = Convert.ToInt32(Console.ReadLine());
            function(menu);
        }

        static void function (int num)
        {
            switch (num)
            {
                case 1:
                    themnhanvien();
                    break;
                case 2:
                    quanlynhanvien();
                    break;
                case 3:
                    themphongban();
                    break;
                case 4:
                    quanlyphongban();
                    break;
                default:
                    Console.WriteLine("Khong ro rang ban chon!");
                    break;
            }
        }

        private static void quanlyphongban()
        {
            while (true)
            {
                Console.Clear();
                if (dsPB.Count == 0)
                {
                    Console.WriteLine("Khong co pho ban!");
                }
                else
                {
                    int a = 0;
                    foreach (PhongBan ds in dsPB)
                    {
                        a++;
                        Console.WriteLine("STT " + a + " | MaPB: " + ds.MaPhongBan + " | TenPB: " + ds.TenPhongBan + " | SoLuongTV: " + ds.getCountNv());
                    }
                }
                string menu;
                menu = "[1] Xoa phong ban\n";
                menu += "[2] Chinh ten phong ban\n";
                Console.WriteLine("Nhap 3 de thoat menu!");
                Console.Write(menu);
                Console.Write("Nhap chuc nang: ");
                int cn = Convert.ToInt32(Console.ReadLine());
                bool exit = false;
                switch (cn)
                {
                    case 1:
                        rmpb();
                        break;
                    case 2:
                        editpb();
                        break;
                    default:
                        Console.WriteLine("Dang quay ve menu chinh");
                        Console.Write("Khong ro chuc nang cua ban!");
                        exit = true;
                        Thread.Sleep(2000);
                        break;
                }
                if (exit)
                {
                    break;
                }
                Console.Write("Enter de tro ve menu!");
                Console.ReadLine();
            }


        }

        private static void editpb()
        {
            Console.Write("Nhap so de chinh sua: ");
            int editNV = Convert.ToInt32(Console.ReadLine()) - 1;
            try
            {
                string nameedit = dsPB[editNV].TenPhongBan;
                Console.WriteLine("Ban dang chinh sua [" + nameedit + "]");
                Console.Write("Nhap ten moi [oldName: " + nameedit + "]: ");
                dsPB[editNV].TenPhongBan = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Edit thanh cong!");
            } catch (Exception ex)
            {
                Console.WriteLine("Khong tim thay pho ban de chinh sau hoac loi");
            }
        }

        private static void rmpb()
        {
            Console.Write("Nhap so de xoa: ");
            int rmNV = Convert.ToInt32(Console.ReadLine()) - 1;
            try
            {
                string name = dsPB[rmNV].TenPhongBan;
                Console.Write("Ban chac muon xoa [" + name + "] chu? (y = yes || n = cancel)\n");
                Console.Write("Nhap lua chon: ");
                string check = Convert.ToString(Console.ReadLine());
                if (check.ToUpper() == "Y")
                {
                    Console.WriteLine("Xoa thanh cong [" + name + "]");
                    dsPB.RemoveAt(rmNV);
                } else
                {
                    Console.WriteLine("Da huy xoa thanh cong!");
                }
                
            } catch (Exception ex)
            {
                Console.WriteLine("Khong tim thay phong ban hoac loi");
            }
            
        }

        private static void themphongban()
        {
            Console.Write("Nhap ten phong ban: ");
            PhongBan PhongBan = new PhongBan();
            PhongBan.TenPhongBan = Convert.ToString(Console.ReadLine());
            PhongBan.MaPhongBan = PhongBan.genID();
            dsPB.Add(PhongBan);
            Console.Write("Them phong ban thanh cong, enter de quay ve menu!");
            Console.ReadLine();
        }

        private static void quanlynhanvien()
        {

            while (true)
            {
                Console.Clear();
                foreach (PhongBan ds in dsPB)
                {
                    Console.WriteLine("Khu vuc PB: "+ds.TenPhongBan);
                    ds.XuatToanBoNhanVien();

                }
                Console.WriteLine("Nhap 8 de quay ve menu");
                menuduyet();
                Console.Write("Nhap so chuc nang: ");
                int scn = Convert.ToInt32(Console.ReadLine());
                bool checkout = false;
                switch (scn)
                {
                    case 1:
                        string menufind;
                        menufind = "[1] Tim kiem all\n";
                        menufind += "[2] Tim kiem theo phong\n";
                        Console.Write(menufind);
                        Console.Write("Nhap so: ");
                        int menuz = Convert.ToInt32(Console.ReadLine());
                        switch (menuz)
                        {
                            case 1:
                                Console.Write("Nhap ma can tim: ");
                                int MaNV = Convert.ToInt32(Console.ReadLine());
                                findall(MaNV);
                                break;
                            case 2:
                                Console.WriteLine("Nhap phong can tim: ");
                                int a = 0;
                                foreach (PhongBan ds in dsPB)
                                {
                                    a++;
                                    Console.Write("STT: " + a + " | Ma: " + ds.MaPhongBan + " | TenPB: " + ds.TenPhongBan + "\n");
                                }
                                Console.Write("Nhap stt phong: ");
                                int stt = Convert.ToInt32(Console.ReadLine()) - 1;
                               
                                findcat(stt);
                                break;
                            default:
                                Console.Write("Khong tim thay chuc nang!");
                                Thread.Sleep(1000);
                                break;
                        }
                        break;
                    case 2:
                        string menubir;
                        menubir = "[1] Sort small to large\n";
                        menubir += "[2] Sort large to small\n";
                        menubir += "[3] Find Birthday\n";
                        Console.Write(menubir);
                        Console.Write("Nhap che do: ");
                        int check = Convert.ToInt32(Console.ReadLine());
                        switch (check)
                        {
                            case 1:
                                sortbirthdaysmalltolarge(1);
                                break;
                            case 2:
                                sortbirthdaysmalltolarge(2);
                                break;
                            case 3:
                                findbirthday();
                                break;
                            default:
                                Console.WriteLine("Khong ro, se tro ve menu chinh sau 2s\n");
                                Thread.Sleep(2000);
                                break;

                        }

                        break;
                    case 3:
                        string menu;
                        menu = "[1] Tinh luong all\n";
                        menu += "[2] Tinh luong theo pb\n";
                        Console.Write(menu);
                        Console.Write("Nhap cn: ");
                        int cn = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Nhap so luong muon tinh cua\n");
                        string menutl;
                        menutl = "Nhap [1t,2t..] tinh luong thang\n";
                        menutl += "Nhap [1f,2f..] tinh luong theo tuan\n";
                        menutl += "Nhap [1n,2n..] tinh luong theo ngay\n";
                        Console.Write(menutl);
                        Console.Write("Nhap: ");
                        string txtm = Convert.ToString(Console.ReadLine());

                        switch (cn)
                        {
                            case 1:
                                tinhluong(1,txtm);
                                break;
                            case 2:
                                tinhluong(2,txtm);
                                break;
                        }
                        break;
                    case 4:
                        Console.Write("Nhap ma nv muon chinh sua: ");
                        int maedit = Convert.ToInt32(Console.ReadLine());
                        editnv( maedit);
                        break;
                    case 5:
                        string hoi;
                        hoi = "[1] Sort all\n";
                        hoi += "[2] Sort theo pb\n";
                        Console.Write(hoi);
                        Console.Write("Nhap so: ");
                        int hoiz = Convert.ToInt32(Console.ReadLine());
                        if (hoiz == 1)
                        {
                            string hoi2;
                            hoi2 = "[1] Sort: small to large\n";
                            hoi2 += "[2] Sort: large to small\n";
                            Console.Write(hoi2);
                            Console.Write("Nhap so: ");
                            int nsne = Convert.ToInt32(Console.ReadLine());
                            switch (nsne)
                            {

                                case 1:
                                    sortlength(1);
                                    break;
                                case 2:
                                    sortlength(2);
                                    break;
                                default:
                                    Console.WriteLine("Khong ro ban muon nhap gi!");
                                    break;

                            }
                        } else if (hoiz == 2)
                        {
                            string hoi2;
                            hoi2 = "[1] Sort: small to large\n";
                            hoi2 += "[2] Sort: large to small\n";
                            Console.Write(hoi2);
                            Console.Write("Nhap so: ");
                            int nsne = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("List Phong Ban");
                            int a = 0;
                            foreach (PhongBan ds in dsPB)
                            {
                                a++;
                                Console.Write("STT: " + a + " | Ma: " + ds.MaPhongBan + " | TenPB: " + ds.TenPhongBan + "\n");
                            }
                            Console.Write("Nhap stt phong: ");
                            int stt = Convert.ToInt32(Console.ReadLine()) - 1;
                            switch (nsne)
                            {

                                case 1:
                                    sortlengpb(1, stt);
                                    break;
                                case 2:
                                    sortlengpb(2, stt);

                                    break;
                                default:
                                    Console.WriteLine("Khong ro ban muon nhap gi!");
                                    break;

                            }
                        } else
                        {
                            Console.WriteLine("Khong ro ban muon nhap gi!");
                        }
                        break;
                    case 6:
                        string menumn;
                        menumn = "[1] Sort money : small to large\n";
                        menumn += "[2] Sort money : large to small\n";
                        Console.Write(menumn);
                        Console.Write("Nhap: ");
                        int mn = Convert.ToInt32(Console.ReadLine());
                        string menuk;
                        menuk = "[1] Sort ALL\n";
                        menuk += "[2] Sort theo pb\n";
                        Console.Write(menuk);
                        Console.Write("Nhap: ");
                        int sortnow = Convert.ToInt32(Console.ReadLine());
                        switch (mn)
                        {
                            case 1:
                                sortmoney(1, sortnow);
                                break;
                            case 2:
                                sortmoney(2, sortnow);
                                break;
                            default:
                                Console.WriteLine("Khong ro ban nhap gi!");
                                break;
                        }
                        break;
                    case 7:
                        Console.Write("Nhap ma nhan vien muon chuyen pb: ");
                        int manv = Convert.ToInt32(Console.ReadLine());
                        changephongban(manv);
                        break;
                    case 8:
                        Console.Write("Nhap ma nhan vien muon xoa: ");
                        int manvz = Convert.ToInt32(Console.ReadLine());
                        removenv(manvz);
                        break;
                    default :
                        checkout = true;
                        break;
                }
                if (checkout)
                {
                    break;
                }
                Console.Write("Enter de tro ve menu quan ly!");
                Console.ReadLine();
      
            }

        }

        private static void removenv(int manvz)
        {
            foreach (PhongBan ds in dsPB)
            {
                foreach (NhanVien nv in ds.getNv())
                {
                    if (nv.MaNhanVien == manvz)
                    {
                        Console.WriteLine("Xoa thanh cong nhan vien [" + nv.TenNhanVien + "]");
                        ds.remove(manvz);
                        break;
                    }
                }
            }
        }

        private static void changephongban(int manv)
        {
            bool checkne = false;
            NhanVien nvne = null;
            int az = 0;
            bool outz= false;
            foreach (PhongBan ds in dsPB)
            {
                foreach (NhanVien nv in ds.getNv())
                {
                    if (nv.MaNhanVien == manv)
                    {
                        checkne = true;
                        nvne = nv;
                        outz = true;
                        break;
                    }
                  
                }
                if (outz == true)
                {
                    break;
                }
                az++;
            }



            if (checkne == false)
            {
                Console.WriteLine("Khong tim thay nhan vien can chuyen!");
            }
            else
            {
                Console.WriteLine("Nhan vien [" + nvne.TenNhanVien + "] dang o pb [" + nvne.Phong + "]\n");
                
                Console.WriteLine("List Phong Ban");
                int a = 0;
                foreach (PhongBan ds in dsPB)
                {
                    a++;
                    Console.Write("STT: " + a + " | Ma: " + ds.MaPhongBan + " | TenPB: " + ds.TenPhongBan + "\n");
                }
                Console.Write("Nhap stt phong muon chuyen doi: ");
                int stt = Convert.ToInt32(Console.ReadLine()) - 1;
                nvne.Phong = dsPB[az].TenPhongBan;
                dsPB[az].remove(nvne.MaNhanVien);
                dsPB[stt].ThemNhanVien(nvne);
                Console.WriteLine("Da chuyen phong ban thanh cong!");
            } 
        }

        private static void sortmoney(int v, int sortnow)
        {
            List<NhanVien> nvne = new List<NhanVien>();
            List<long> nven = new List<long>();
            int stt = 0;
            if (sortnow == 1)
            {
                nvne = GetNhanVien();
                foreach (NhanVien nv in nvne)
                {
                    if (!nven.Contains(nv.TinhLuong))
                    {
                        nven.Add(nv.TinhLuong);
                    }
                }
            } else
            {
                Console.WriteLine("List Phong Ban");
                int a = 0;
                foreach (PhongBan ds in dsPB)
                {
                    a++;
                    Console.Write("STT: " + a + " | Ma: " + ds.MaPhongBan + " | TenPB: " + ds.TenPhongBan + "\n");
                }
                Console.Write("Nhap stt phong: ");
                stt = Convert.ToInt32(Console.ReadLine()) - 1;
                nvne = dsPB[stt].getNv();
                foreach (NhanVien nv in nvne)
                {
                    if (!nven.Contains(nv.TinhLuong))
                    {
                        nven.Add(nv.TinhLuong);
                    }
                }

            }

            if (v == 1)
            {
                nven.Sort();
            } else
            {
                nven.Sort();
                nven.Reverse();
            }

            foreach (long money in nven)
            {
                List<NhanVien> nvz = new List<NhanVien>();
                if (sortnow == 1)
                {
                    foreach (PhongBan ds in dsPB)
                    {
                        foreach (NhanVien nv in ds.getMoney(money))
                        {
                            Console.WriteLine(nv);
                        }
                    }
                } else
                {
                    foreach (NhanVien nv in dsPB[stt].getMoney(money))
                    {
                        Console.WriteLine(nv);
                    }
                }
            }

        }

        private static void sortlengpb(int type, int stt)
        {
            List<NhanVien> lnv = dsPB[stt].getNv();
            List<int> listint = new List<int>();
            foreach (NhanVien v in lnv)
            {
                int key = v.TenNhanVien.Length;
                if (!listint.Contains(key))
                {
                    listint.Add(key);
                }
            }
            if (type == 1)
            {
                listint.Sort();
            }
            else
            {
                listint.Sort();
                listint.Reverse();
            }

            foreach (int length in listint)
            {
                List<NhanVien> NVNE = dsPB[stt].getLengthName(length);
                foreach (NhanVien nv in NVNE)
                {
                    Console.WriteLine(nv);
                }
            }
        }

        private static void sortlength(int type)
        {
            List<NhanVien> lnv = GetNhanVien();
            List<int> listint = new List<int>();
            foreach (NhanVien v in lnv)
            {
                int key = v.TenNhanVien.Length;
                if (!listint.Contains(key))
                {
                    listint.Add(key);
                }
            }
            if (type == 1)
            {
                listint.Sort();
            } else
            {
                listint.Sort();
                listint.Reverse();
            }

            foreach (int length in listint)
            {
                foreach (PhongBan phongBan in dsPB)
                {
                    foreach (NhanVien v in phongBan.getLengthName(length))
                    {
                        Console.WriteLine(v);
                    }
                }
            }
        }

        private static void editnv(int manv)
        {
           foreach (PhongBan ds in dsPB)
           {
                ds.edit(manv);
           }
        }

        private static void tinhluong(int t,string luong)
        {
            int stt = 0;
            if (t == 2)
            {
                Console.WriteLine("Nhap phong can tinh: ");
                int a = 0;
                foreach (PhongBan ds in dsPB)
                {
                    a++;
                    Console.Write("STT: " + a + " | Ma: " + ds.MaPhongBan + " | TenPB: " + ds.TenPhongBan + "\n");
                }
                Console.Write("Nhap stt phong: ");
                stt = Convert.ToInt32(Console.ReadLine()) - 1;
            }
            if (luong.Contains("t"))
            {
               
                string[] lne = luong.Split("t");
                long luongall = 0;
                if (t == 1)
                {
                    foreach (PhongBan ds in dsPB)
                    {
                        foreach (NhanVien nv in ds.getNv())
                        {
                            luongall += nv.TinhLuong;
                        }
                    }
                } else
                {
                    List<NhanVien> nv = dsPB[stt].getNv();
                    foreach (NhanVien z in nv)
                    {
                        luongall += z.TinhLuong;
                    }
                    Console.WriteLine("Luong cua phong ban [" + dsPB[stt].TenPhongBan + "]");
                }

                luongall *= Convert.ToInt32(lne[0]);
                Console.WriteLine("Luong tong cong la: " + luongall);
            } else if (luong.Contains("f"))
            {
              
                string[] lne = luong.Split("f");
                double luongall = 0;
                if (t == 1)
                {
                    foreach (PhongBan ds in dsPB)
                    {
                        foreach (NhanVien nv in ds.getNv())
                        {
                            luongall += nv.TinhLuong / 4;
                        }
                    }
                }
                else
                {
                    List<NhanVien> nv = dsPB[stt].getNv();
                    foreach (NhanVien z in nv)
                    {
                        luongall += z.TinhLuong / 4;
                    }
                    Console.WriteLine("Luong cua phong ban [" + dsPB[stt].TenPhongBan + "]");
                }

                luongall *= Convert.ToInt32(lne[0]);
                Console.WriteLine("Luong tong cong la: " + luongall);
            } else
            {
                Console.Write("Mac dinh 1 thang la 30 ngay\n");
                string[] lne = luong.Split("n");
                double luongall = 0;
                if (t == 1)
                {
                    foreach (PhongBan ds in dsPB)
                    {
                        foreach (NhanVien nv in ds.getNv())
                        {
                            luongall += nv.TinhLuong / 30;
                        }
                    }
                }
                else
                {
                    List<NhanVien> nv = dsPB[stt].getNv();
                    foreach (NhanVien z in nv)
                    {
                        luongall += z.TinhLuong / 30;
                    }
                    Console.WriteLine("Luong cua phong ban [" + dsPB[stt].TenPhongBan + "]");
                }

                luongall *= Convert.ToInt32(lne[0]);
                Console.WriteLine("Luong tong cong la: " + luongall + " ( gia tri sap si 98% )");
            }

        }

        private static void findbirthday()
        {
            string menu;
            menu = "[1] Find all\n";
            menu += "[2] Find theo Phong Ban\n";
            Console.Write(menu);
            Console.Write("Nhap so tuong ung voi cn: ");
            int cs = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap ngay thang muon tim (d/m/Y): ");
            string ngaysinh = Convert.ToString(Console.ReadLine());
            string[] nssplit = ngaysinh.Split("/");
            DateTime dateTime = new DateTime(Convert.ToInt32(nssplit[2]), Convert.ToInt32(nssplit[1]), Convert.ToInt32(nssplit[0]));
            switch (cs)
            {
                case 1:
                    
                    findbd(dateTime);
                    break;
                case 2:
                    findbdpb(dateTime);
                    break;
                default:
                    Console.Write("Khong ro ban nhap gi\n");
                    break;

            }
        }

        private static void findbdpb(DateTime time)
        {
            Console.WriteLine("Nhap phong can tim: ");
            int a = 0;
            foreach (PhongBan ds in dsPB)
            {
                a++;
                Console.Write("STT: " + a + " | Ma: " + ds.MaPhongBan + " | TenPB: " + ds.TenPhongBan + "\n");
            }
            Console.Write("Nhap stt phong: ");
            int stt = Convert.ToInt32(Console.ReadLine()) - 1;

            List<NhanVien> nv = dsPB[stt].getNv();
            int b = 0;
            foreach (NhanVien nv2 in nv)
            {
                if (nv2.NgaySinh == time)
                {
                    b++;
                    Console.WriteLine(nv2);
                } 
                
            }
            if (b == 0)
            {
                Console.WriteLine("Khong tim thay nhan vien nao ca!");
            } else
            {
                Console.WriteLine("Co " + b + " nhan vien cung ngay sinh");
            }

        }

        private static void findbd(DateTime time)
        {

           //ist<NhanVien> nv = new List<NhanVien>();
            int a = 0;
            foreach (PhongBan ds in dsPB)
            {
                foreach (NhanVien n in ds.getNv())
                {
                    if(n.NgaySinh == time)
                    {
                        Console.WriteLine(n);
                    }
                }
            }
            if (a == 0)
            {
                Console.WriteLine("Khong tim thay nhan vien nao ca!");
            } else
            {
                Console.WriteLine("Da tim thay " + a + " co cung ngay sinh nhat");
            }
        }

        private static void sortbirthdaysmalltolarge(int type)
        {
            string menu;
            menu = "[1] Check theo phong ban\n";
            menu += "[2] Check all\n";
            Console.Write(menu);
            Console.Write("Nhap so: ");
            int so = Convert.ToInt32(Console.ReadLine());
            switch (so)
            {
                case 1:
                    Console.WriteLine("List Phong Ban");
                    int a = 0;
                    foreach (PhongBan ds in dsPB)
                    {
                        a++;
                        Console.Write("STT: " + a + " | Ma: " + ds.MaPhongBan + " | TenPB: " + ds.TenPhongBan + "\n");
                    }
                    Console.Write("Nhap stt phong: ");
                    int stt = Convert.ToInt32(Console.ReadLine()) - 1;
                    checkbirthdaytheophongban(stt,type);
                    break;
                case 2:
                    checkallbirthdaysmtolg(type);
                    break;
                default:
                    Console.WriteLine("Khong ro ban nhap gi!");
                    break;
            }
        }
       
        private static void checkallbirthdaysmtolg(int type)
        {
            Console.WriteLine("Sort result:");
            List<NhanVien> getMenber = GetNhanVien();
            List<DateTime> datetime = new List<DateTime>();
            foreach (NhanVien nv in getMenber)
            {
                if (!datetime.Contains(nv.NgaySinh))
                {
                    datetime.Add(nv.NgaySinh);
                } 
            }
            if (type == 1)
            {
                datetime.Sort();
            } else
            {
                datetime.Sort();
                datetime.Reverse();
            }
           
            foreach (DateTime dt in datetime)
            {
                foreach (PhongBan ds in dsPB)
                {
                    foreach (NhanVien d in ds.getBirthday(dt))
                    {
                        Console.WriteLine(d);
                    }
                }
            }
        }

        

        private static List<NhanVien> GetNhanVien()
        {
            List<NhanVien> listnvall = new List<NhanVien>();
            foreach (PhongBan ds in dsPB)
            {
                foreach (NhanVien nv in ds.getNv())
                {
                    listnvall.Add(nv);
                }
            }
            return listnvall;
        }

        private static void checkbirthdaytheophongban(int stt,int type)
        {
            try
            {
                Console.WriteLine("Phong ban: " + dsPB[stt].TenPhongBan);
                List<NhanVien> nv = dsPB[stt].getNv();
                List<DateTime> time = new List<DateTime>();
                foreach (NhanVien d in nv)
                {
                    time.Add(d.NgaySinh);
                }
                List<DateTime> tg = new List<DateTime>();
                foreach (DateTime t in time)
                {
                    if (!tg.Contains(t))
                    {
                        tg.Add(t);
                    }
                }
                if (type == 1)
                {
                    tg.Sort();
                } else
                {
                    tg.Sort();
                    tg.Reverse();
                }
                
                foreach (DateTime dt in tg)
                {
                    foreach (NhanVien nvz in dsPB[stt].getBirthday(dt))
                    {
                        Console.WriteLine(nvz);
                    }
                }


            } catch (Exception ex)
            {
                Console.WriteLine("Khong tim thay phong ban hoac loi");
            }
        }

        private static void findcat(int mapb)
        {
            Console.WriteLine("Toan bo nhan vien trong phong ban [" + dsPB[mapb].TenPhongBan + "]");
            dsPB[mapb].XuatToanBoNhanVien();
            Console.Write("Nhap ma nhan vien: ");
            int maNV = Convert.ToInt32(Console.ReadLine());
            NhanVien find = dsPB[mapb].TimNhanVien(maNV);
            if (find == null)
            {
                Console.WriteLine("Khong tim thay nhan vien nay!");
            } else
            {
                Console.WriteLine(find);
            }
           
        }

        private static void findall(int MaNV)
        {
            bool check = false;
            foreach (PhongBan ds in dsPB)
            {
                NhanVien find = ds.TimNhanVien(MaNV);
                if (find != null)
                {
                    Console.WriteLine(find);
                    check = true;
                    break;
                }
            }
            if (check == false)
            {
                Console.WriteLine("Khong tim thay nhan vien nay!");
            }
        }

        private static void menuduyet()
        {
            string menu;
            menu = "[1] Tim kim thanh vien\n";
            menu += "[2] Birthday Mode\n";
            menu += "[3] Tinh Luong\n";
            menu += "[4] Chinh sua nhan vien\n";
            menu += "Tinh Nang Phu: 5. Sort theo do dai ten || 6. Sort theo muc luong || 7. Chuyen Nhan Vien Sang Phong Ban Moi\n";
            menu += "Tinh Nang Cao: 8. Xoa Nhan Vien\n";
            Console.Write(menu);
        }

        private static void themnhanvien()
        {
            NhanVien user = new NhanVien();
            user.MaNhanVien = user.genID();
            Console.Write("Nhap ten nhan vien: ");
            user.TenNhanVien = Convert.ToString(Console.ReadLine());
            Console.Write("Nhap ngay sinh: ");
            string ngaysinh = Convert.ToString(Console.ReadLine());
            string[] nssplit = ngaysinh.Split("/");
            user.NgaySinh = new DateTime(Convert.ToInt32(nssplit[2]),Convert.ToInt32(nssplit[1]),Convert.ToInt32(nssplit[0]));
            Console.WriteLine("Nhap Chuc Vu");
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
                    user.ChucVu = LoaiChucVu.GIAM_DOC;
                    break;
                case 2:
                    user.ChucVu = LoaiChucVu.TRUONG_PHONG;
                    break;
                case 3:
                    user.ChucVu = LoaiChucVu.PHO_PHONG;
                    break;
                case 4:
                    user.ChucVu = LoaiChucVu.NHAN_VIEN;
                    break;
                default:
                    user.ChucVu = LoaiChucVu.NHAN_VIEN;
                    break;
            }
            Console.WriteLine("Phong Ban hien tai: ");
            if (dsPB.Count == 0)
            {
                Console.WriteLine("Khong co phong ban nao, khong the them");
            } else
            {
                int a = 0;
                foreach (PhongBan ds in dsPB)
                {
                    a++;
                    Console.Write("STT: " + a + " | Ma: " + ds.MaPhongBan + " | TenPB: " + ds.TenPhongBan + "\n");
                }
                Console.Write("Nhap stt muon them nhan vien vao phong: ");
                int stt = Convert.ToInt32(Console.ReadLine()) - 1;
                user.Phong = dsPB[stt].TenPhongBan;
                dsPB[stt].ThemNhanVien(user);
                Console.Write("Them thanh cong nhan vien, enter de tiep tuc!");

            }

            Console.ReadLine();
 
            
        }

     
    }
}