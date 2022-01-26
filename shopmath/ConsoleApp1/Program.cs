using ConsoleApp1;
using System;
using System.Text;

namespace caculator
{
    class Program
    {

        static mathbasic cn1 = new mathbasic();
        static session session = new session();
        static History lichsu = new History();
        static CanBac2 CanBac2 = new CanBac2();
        static ptrinhbac1 ptrinhbac1 = new ptrinhbac1();
        static LamTron LamTron = new LamTron();
        static LuongGiac LuongGiac = new LuongGiac();
        static LuyThua luythuaz = new LuyThua();
        static void Main (string[] args)
        {
            Console.Write("Nhap username cua ban: ");
            string name = Convert.ToString(Console.ReadLine());
            Console.Write("Nhap coins muon thiet lap: ");
            int coins = Convert.ToInt32 (Console.ReadLine());
            user createuser = new user(name);
            createuser.blance("set", 1);
            createuser.blance("add",coins);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("ka ku lay to v1");
                Console.WriteLine("User: " + createuser.getName());
                Console.WriteLine("Money: " + createuser.blance());
                session.sessionint = createuser.blance();
                string moneytract = Menu();
                string[] spt = moneytract.Split('|');
                createuser.blance(spt[0],Convert.ToInt32(spt[1]));
            }
        }
        static string Menu()
        {
            
            string menu;
            menu = "[1] Cong , Tru , Nhan , Chia (5 coins / 1 luot)\n";
            menu += "[2] Tinh can bac 2 (10 coins / luot)\n";
            menu += "[3] Tinh Luong Giac (15 coins / luot)\n";
            menu += "[4] Lam tron so (1 coins / luot)\n";
            menu += "[5] Tinh Luy Thua (2 coins / luot)\n";
            menu += "[6] phuong trinh bac 1 (10 coins / luot)\n";
            menu += "[7] Lich su tinh toan\n";
            menu += "[8] Hack Money :))\n";
            Console.Write(menu);
            Console.Write("Nhap so chuc nang: ");
            int cmenu = Convert.ToInt32(Console.ReadLine());
            return choose(cmenu);
        }
        static string choose(int cmenu)
        {
            string moneytru = "";
            switch (cmenu)
            {
                case 1:
                    moneytru = mathbasi();
                    break;
                case 2:
                    moneytru = canbac2();
                    break;
                case 3:
                    moneytru = luonggiac();
                    break;
                case 4:
                    moneytru = tronso();
                    break;
                case 5:
                    moneytru = luythua();
                    break;
                case 6:
                    moneytru = canbac1();
                    break;
                case 7:
                    moneytru = history();
                    break;
                case 8:
                    moneytru = hackMoney();
                    break;
                default:
                    Console.WriteLine("Chuc nang ban su dung khong ro!");
                    Thread.Sleep(1000);
                    moneytru = "tract|0";
                    break;
            }
            return moneytru;
        }

        static string hackMoney()
        {
            Console.Write("Nhap money muon hack: ");
            string hack = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Hack thanh cong " + hack + " money");
            lichsu.txt = "Them thanh cong " + hack + " money";
            lichsu.add();
            Thread.Sleep(2000);
            return "add|" + hack;
        }

        static string mathbasi()
        {
            int moneyam = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter neu khong tinh toan nua");
                if (moneyam > session.sessionint || moneyam == session.sessionint || session.sessionint - moneyam < 5)
                { 
                    Console.Write("Ban khong du tien, se tu quay ve menu sau 2s");
                    Thread.Sleep(2000);
                    break;
                } else
                {
                    Console.Write("Nhap phep tinh: ");
                    string input = Convert.ToString(Console.ReadLine());
                    if (input == "")
                    {
                        break;
                    }
                    else
                    {
                        try
                        {
                            cn1.input = input;
                            Console.WriteLine("Ket qua: " + cn1.tinhtoan());
                            lichsu.txt = "Ban da bi tru 5 coins vi tinh " + input + " = " + cn1.tinhtoan();
                            lichsu.add();
                            moneyam += 5;
                        } catch (Exception ex)
                        {
                           Console.WriteLine(ex.Message);
                        }


                        Console.Write("Enter de tiep tuc!");
                        Console.ReadLine();
                    }
                }


            }

            return "tract|" + moneyam;
        }



        static string history()
        {
            if(lichsu.list.Count == 0)
            {
                Console.WriteLine("Khong co lich su nao o day!");
            } else
            {
                lichsu.view();
                Console.Write("Nhap 1 de xoa log theo stt || nhap 2 de xoa all log: ");
                int num = Convert.ToInt32(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        Console.Write("Nhap stt muon xoa log: ");
                        int numlog = Convert.ToInt32(Console.ReadLine());
                        lichsu.rmnum = numlog;
                        lichsu.rmcontrol();
                        Console.WriteLine("Xoa thanh cong log");
                        break;
                    case 2:
                        lichsu.clear();
                        break;
                    case 3:
                        break;
                }
            }
           
            Console.Write("Enter de tro ve menu");
            Console.ReadLine();
            return "normal|0";
        }
        static string canbac1()
        {
            int moneyam = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter neu khong tinh toan nua");
                if (moneyam > session.sessionint || moneyam == session.sessionint || session.sessionint - moneyam < 10)
                {
                    Console.Write("Ban khong du tien, se tu quay ve menu sau 2s");
                    Thread.Sleep(2000);
                    break;
                }
                else
                {
                    Console.Write("Nhap so thu nhat: ");
                    string s1fake = Convert.ToString(Console.ReadLine());
                    Console.Write("Nhap so thu hai: ");
                    string s2fake = Convert.ToString(Console.ReadLine());
                    

                    if (s1fake == "" || s2fake == "")
                    {
                        break;
                    } else
                    {
                        try
                        {
                            double s1 = Convert.ToDouble(s1fake);
                            double s2 = Convert.ToDouble(s2fake);
                            ptrinhbac1.a = s1;
                            ptrinhbac1.b = s2;
                            Console.WriteLine("Ket qua: " + ptrinhbac1.tinh());
                            moneyam += 10;
                            lichsu.txt = "Ban da bi tru 10 coins vi tinh ptrinhbac1 cua " + s1 + " va " + s2 + " = " + ptrinhbac1.tinh();
                            lichsu.add();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    Console.Write("Enter de tiep tuc");
                    Console.ReadLine();
                }
            }
            return "tract|" + moneyam;
        }

        static string luythua()
        {
            int moneyam = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter neu khong tinh toan nua");
                if (moneyam > session.sessionint || moneyam == session.sessionint || session.sessionint - moneyam < 2)
                {
                    Console.Write("Ban khong du tien, se tu quay ve menu sau 2s");
                    Thread.Sleep(2000);
                    break;
                }
                else
                {
    
                    try
                    {
                        Console.Write("Nhap so a: ");
                        string a = Convert.ToString(Console.ReadLine());
                        Console.Write("Nhap so b: ");
                        string b = Convert.ToString(Console.ReadLine());
                        if (a == "" || b == "")
                        {
                            break;
                        } else
                        {
                            luythuaz.A = Convert.ToInt32(a);
                            luythuaz.B = Convert.ToInt32(b);
                            Console.WriteLine("Ket qua: " + luythuaz.tinh());
                            moneyam += 2;
                            lichsu.txt = "Ban da bi tru 2 coins vi tinh luy thua cua " + a + " va " + b + " = " + luythuaz.tinh();
                            lichsu.add();
                        }

                    } catch (Exception ex)
                    {
                        Console.WriteLine (ex.Message);
                    }
                    Console.Write("Enter de tiep tuc");
                    Console.ReadLine();
                }
            }
            return "tract|" + moneyam;
        }

        static string tronso()
        {
            int moneyam = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter neu khong tinh toan nua");
                if (moneyam > session.sessionint || moneyam == session.sessionint || session.sessionint - moneyam < 1)
                {
                    Console.Write("Ban khong du tien, se tu quay ve menu sau 2s");
                    Thread.Sleep(2000);
                    break;
                }
                else
                {
                    Console.WriteLine("Tong so tien se tru: "+moneyam);
                    Console.Write("Nhap day so can lam tron (ex: 1.43432434 2.54556556 3.545545543 6.65654654645 ): ");
                    string text = Convert.ToString(Console.ReadLine());
                    if(text == "")
                    {
                        break;
                    } else
                    {
                        string[] sp = text.Split(' ');
                        LamTron.solamtron = sp;
                        Console.Write("Nhap gioi han so xuat: ");
                        try
                        {
                            int soxuat = Convert.ToInt32(Console.ReadLine());
                            LamTron.gioihan = soxuat;
                            //      LamTron.convert();
                            List<double> list = LamTron.action();
                            int a = 0;
                            foreach (double item in list)
                            {
                                if (moneyam > session.sessionint || moneyam == session.sessionint || session.sessionint < 1)
                                {
                                    Console.WriteLine("Nap vip de xem tiep");
                                    break;
                                } else
                                {
                                    a++;
                                    Console.WriteLine("[" + a + "] ket qua => " + item);
                                    moneyam += 1;
                                    lichsu.txt = "Ban da bi tru 1 coin vi lam tron "+sp[a-1]+" ket qua "+item;
                                    lichsu.add();
                                }


                            }
                        } catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                     

 
                    
                    }
                    Console.Write("Enter de tiep tuc!");
                    Console.ReadLine();

               
                }
            }
            return "tract|" + moneyam;
        }

        static string luonggiac()
        {
            int moneyam = 0;
            while (true)
            {

                Console.Clear();
                Console.WriteLine("Enter neu khong tinh toan nua");
          
                if (moneyam > session.sessionint || moneyam == session.sessionint || session.sessionint - moneyam < 15)
                {
                    Console.Write("Ban khong du tien, se tu quay ve menu sau 2s");
                    Thread.Sleep(2000);
                    break;
                }
                else
                {
                    Console.Write("Nhap vao mot goc: ");
                    string gcfake = Convert.ToString(Console.ReadLine());
                    if(gcfake == "")
                    {
                        break;
                    }else
                    {
                        try
                        {
                            LuongGiac.goc = Convert.ToInt32(gcfake);
                            LuongGiac.tinh();
                            moneyam += 15;
                            lichsu.txt = "Ban da bi tru 15 coins do tinh luong giac cua " + gcfake;
                            lichsu.add();
                        } catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    Console.Write("Enter de tiep tuc");
                    Console.ReadLine();
                }
            }
            return "tract|" + moneyam;
        }

        static string canbac2()
        {
            int moneyam = 0;
            while (true)
            {

                Console.Clear();
                Console.WriteLine("Enter neu khong tinh toan nua");
                if (moneyam > session.sessionint || moneyam == session.sessionint || session.sessionint - moneyam < 10)
                {
                    Console.Write("Ban khong du tien, se tu quay ve menu sau 2s");
                    Thread.Sleep(2000);
                    break;
                }
                else
                {
                    try
                    {
                        Console.Write("Nhap so can tinh can bac 2: ");
                        string cb2 = Convert.ToString(Console.ReadLine());
                        if (cb2 == "")
                        {
                            break;
                        } else
                        {
                            int num = Convert.ToInt32(cb2);
                            CanBac2.number = num;
                            Console.WriteLine("Can bac 2 cua so {0} la {1}", num, CanBac2.canbac2());
                            moneyam += 10;
                            lichsu.txt = "Ban da bi tru 10 coins vi tinh can bac 2 cua " + num + " = " + CanBac2.canbac2();
                            lichsu.add();
                        }
 
                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }

                    Console.Write("Enter de tiep tuc");
                    Console.ReadLine();
                }
            }
            return "tract|" + moneyam;
        }

      
    }
}