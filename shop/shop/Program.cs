using System;
using System.Text;

namespace shop
{
    class Program
    {
        static TaiKhoan log = new TaiKhoan();
        static Money Dollar = new Money();
        static AddCart Cart = new AddCart();
        static History History = new History();
        static YouItem youitem = new YouItem();
        static void Main (string[] args)
        {
            Console.Write("Nhap tai khoan: ");
            string tk = Convert.ToString(Console.ReadLine());
            Console.Write("Nhap mat khau: ");
            string mk = Convert.ToString(Console.ReadLine());   
            log.setAcc(tk, mk);
            log.checklogin();
            bool checklog = log.GetStatus();
            Thread.Sleep(1000);
            Console.Clear();
            if(checklog == true)
            {
                Dollar.createEnvMoney();
                Console.Write("Dang nhap thanh cong\n");
                Thread.Sleep(1000);
                Console.Clear();
                while (true)
                {
                    Console.Clear();
                    Menu();
                }
                
            }
            else
            {
                Console.Write("Dang nhap sai cau truc");
            }
        }
        static void Menu()
        {
            string menu = "";
            menu += "[1] Them don hang\n";
            menu += "[2] Quan ly chi tieu\n";
            menu += "[3] Mua hang\n";
            menu += "[4] Nap tien\n";
            menu += "[5] Xem hang da mua\n";
            menu += "[6] Chinh sua mon hang\n";
            Console.WriteLine("Xin chao: " + log.getUser());
            Console.WriteLine("So tien hien dai: " + Money());
            Console.Write (menu);
            Choose_Menu();
        }
        static int Money()
        {
            return Dollar.GetMoney();
        }
        static void Choose_Menu()
        {
            Console.Write("Nhap chuc nang ban muon sai: ");
            int cmenu = Convert.ToInt32(Console.ReadLine());
            switch (cmenu)
            {
                case 1:
                    ThemHang();
                    break;
                case 2:
                    QuanLyChiTieu();
                    break;
                case 3:
                    BuyCart();
                    break;
                case 4:
                    Naptien();
                    break;
                case 5:
                    KhoHang();
                    break;
                case 6:
                    EditCart();
                    break;
                default:
                    Console.Write("Khong co trong muc lua chon!");
                    break;
            }
        }
        static void ThemHang()
        {
            Console.Write("Nhap ten mon hang: ");
            string name = Convert.ToString(Console.ReadLine());
            Console.Write("Nhap gia mon hang: ");
            int cost = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap so luong: ");
            int soluong = Convert.ToInt32(Console.ReadLine());
            Cart.aCart(name, cost, soluong);
            
        }
        static void QuanLyChiTieu()
        {
            History.view();
            Console.Write("Nhap rm de xoa log || nhap rmall de xoa all log: ");
            string catv = Convert.ToString(Console.ReadLine());
            if(catv == "rm")
            {
                Console.Write("Nhap stt ban muon xoa: ");
                int stt = Convert.ToInt32(Console.ReadLine());
                History.remove(stt);
                Console.WriteLine("Xoa log thanh cong!");
                Thread.Sleep(1000);
            } else if (catv == "rmall")
            {
                History.rmall();
                Console.Write("Xoa het log thanh cong!");
                Thread.Sleep(1000);
            }
        }
        static void BuyCart()
        {
            bool view = Cart.viewCart();
            if (view == true)
            {
                Console.Write("Nhap so muon mua: ");
                int id = Convert.ToInt32(Console.ReadLine());
                List<string> mua = Cart.GetItem(id);
                Console.Write("Ban muon mua {0} bao nhieu: ", mua[0]);
                int soluongmua = Convert.ToInt32(Console.ReadLine());
                if (soluongmua < Convert.ToInt32(mua[2]) || soluongmua == Convert.ToInt32(mua[2])) 
                {
                    int tongtien = Convert.ToInt32(mua[1]) * soluongmua;
                    Console.Write("{0} {1} co tong tien la {2} enter de xac nhan mua: ", soluongmua, mua[0], tongtien);
                    Console.ReadLine();

                    if (Money() > tongtien || Money() == tongtien)
                    {
                        Dollar.amMoney(tongtien);
                        Cart.amCount(soluongmua);
                        History.add("Ban da mua " + soluongmua + " " + mua[0] + " voi gia " + tongtien + " va con lai " + Money());
                        string date = string.Format("{0:dd/MM/yyyy HH:mm:ss} ", DateTime.Now);
                        youitem.AddItem(mua[0], date, Convert.ToString(soluongmua), mua[1]);
                        Console.Write("Mua hang con mon hang, xem hang trong kho!");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.Write("So du trong tai khoan , khong du vui long nap them!\n");
                        Thread.Sleep(2000);
                    }
                } else
                {
                    Console.Write("Vuot so luong hien co cua don hang!");
                    Thread.Sleep(2000);
                }
               
            } else
            {
                Console.WriteLine("Khong co mon hang nao o day ca!");
                Console.Write("Tu quay ve menu sau 2 giay");
                Thread.Sleep(2000);
            }

            
           
            
            
        }
        static void Naptien()
        {
            Console.Write("Nhap tien muon nap: ");
            int moneyadd = Convert.ToInt32(Console.ReadLine());
            Dollar.AddMoney(moneyadd);
            Console.WriteLine("Enter de tro ve menu");
            Console.Write("Ban vua nap {0} vao tai khoan: ", Money());
            History.add("Vua them " + moneyadd + " vao tai khoan");

            Console.ReadLine();
        }

        static void KhoHang()
        {
            youitem.viewall();
            Console.Write("Nhap rm de xoa hang || nhap rs de resell: ");
            string chmenu = Convert.ToString(Console.ReadLine());
            if(chmenu == "rm")
            {
                Console.Write("Nhap name resell de xoa: ");
                string namesell = Convert.ToString(Console.ReadLine());
                youitem.ItemRM(namesell);
                Console.Write("Xoa thanh cong "+namesell);
                Thread.Sleep(2000);
            } else if(chmenu == "resell")
            {
                Console.Write("Ban muon resell muon hang nao (nhap name resell de resell): ");
                string resell = Convert.ToString(Console.ReadLine());
                Console.Write("Ban muon resell bao nhieu cai: ");
                string amban = Convert.ToString(Console.ReadLine());
                int checksell = youitem.resellItem(resell, amban);
                if (checksell != 0)
                {
                    Dollar.AddMoney(checksell);
                    History.add("Ban da giao dich ban " + amban + " " + resell + " va nhan duoc " + checksell);
                    Console.Write("Giao dich thanh cong nhan duoc " + checksell);
                    Thread.Sleep(2000);
                } else
                {
                    Console.Write("Giao dich khong thanh cong");
                    Thread.Sleep(2000);
                }
            } else
            {
                Console.Write("Ban khong co lua chon dung");
                Thread.Sleep(1000);
            }

        }
        static void EditCart()
        {
            bool view = Cart.viewCart();
            if(view == true)
            {
                Console.Write("Nhap id muon chinh sua: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Cart.EditCart(id);
           
            } else
            {
                Console.Write("Khong co don hang nao de chinh sua");
                Thread.Sleep(1000);
            }
        }
    }
}