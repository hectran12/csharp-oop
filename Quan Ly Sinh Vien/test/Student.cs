using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Student
    {
        public string name { get; set; }
        public int age { get; set; }
        public string university { get; set; }
        public string job { get; set; }
        public string settype_sort { get; set; }
        static Dictionary<int, List<string>> students = new Dictionary<int, List<string>>();
        private List<string> newbie { get; set; }
        public string NewStudent()
        {
            List<string> newhs = new List<string>();
            newhs.Add(name);
            newhs.Add(Convert.ToString(age));
            newhs.Add(university);
            newhs.Add(job);
            newbie = newhs;
            return "Khoi tao thanh cong info student";
        }

        public void AllStudent()
        {
            if(students.Count() == 0)
            {
                Console.WriteLine("Khong co hoc sinh nao het!");
            }
            else
            {
                int a = 0;
                foreach (KeyValuePair<int, List<string>> hs in students)
                {
                    a++;
                    Console.Write("STT: " + a + " | Ma: " + hs.Key + " | ");
                    string[] tags = { "HoVaTen", "Age", "University", "Job" };
                    int tagsnum = 0;
                    foreach (string item in hs.Value)
                    {
                        Console.Write(tags[tagsnum] + ": " + ToUU(item) + " | ");
                        tagsnum++;
                    }
                    Console.WriteLine();
                }
            }

        
        }
        public void edit(int ma)
        {
            if (students.ContainsKey(ma))
            {
                string ten = students[ma][0];
                string age = students[ma][1];
                string uni = students[ma][2];
                string job = students[ma][3];
                Console.Write("Nhap ten moi (" + ten + "): ");
                students[ma][0] = Convert.ToString(Console.ReadLine());
                Console.Write("Nhap age moi (" + age + "): ");
                students[ma][1] = Convert.ToString(Console.ReadLine());
                Console.Write("Nhap university moi (" + uni + "): ");
                students[ma][2] = Convert.ToString(Console.ReadLine());
                Console.Write("Nhap job moi (" + job + "): ");
                students[ma][3] = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Doi thong tin thanh cong!");
            } else
            {
                Console.WriteLine("Khong co hoc sinh can tim!");
            }
        }
        public void rm (int ma)
        {
            if (students.ContainsKey(ma))
            {
                Console.WriteLine("Xoa thanh cong hoc sinh " + students[ma][0]);
                students.Remove(ma);
            } else
            {
                Console.WriteLine("Khong tim thay hoc sinh can xoa!");
            }

        }
        public void findstu (int ma)
        {
            if (!students.ContainsKey(ma))
            {
                Console.WriteLine("Khong co hoc sinh can tim!");
            } else
            {
                Console.Write("Ma: " + ma + " | ");
                string[] tags = { "HoVaTen", "Age", "University", "Job" };
                int tagsnum = 0;
                foreach (string item in students[ma])
                {
                    Console.Write(tags[tagsnum] + ": " + ToUU(item) + " | ");
                    tagsnum++;
                }
                Console.WriteLine();
            }

        }


        public void sortlm(int sr)
        {
            if (students.Count() == 0)
            {
                Console.WriteLine("Khong co sinh vien nao de lam viec nay!");
            }
            else
            {
                List<int> num = new List<int>();
                foreach (KeyValuePair<int, List<string>> hs in students)
                {
                    if (num.Contains(Convert.ToInt32(hs.Value[1])) == false)
                    {
                        num.Add(Convert.ToInt32(hs.Value[1]));
                    }

                }
                num.Sort();
                if (sr == 0)
                {
                    num.Reverse();
                }

                Dictionary<int, List<string>> liststudent = new Dictionary<int, List<string>>();
                foreach (int number in num)
                {
                    foreach (KeyValuePair<int, List<string>> hs in students)
                    {
                        if (Convert.ToInt32(hs.Value[1]) == number)
                        {
                            liststudent.Add(hs.Key, hs.Value);
                        }
                    }
                }


                int a = 0;
                foreach (KeyValuePair<int, List<string>> hs in liststudent)
                {
                    a++;
                    Console.Write("STT: " + a + " | Ma: " + hs.Key + " | ");
                    string[] tags = { "HoVaTen", "Age", "University", "Job" };
                    int tagsnum = 0;
                    foreach (string item in hs.Value)
                    {
                        Console.Write(tags[tagsnum] + ": " + ToUU(item) + " | ");
                        tagsnum++;
                    }
                    Console.WriteLine();
                }
            }
           
        }
        public void findname (string name)
        {
            Dictionary<int, List<string>> liststudent = new Dictionary<int, List<string>>();

            foreach (KeyValuePair<int, List<string>> hs in students)
            {
                if (hs.Value[0].IndexOf(name.ToLower()) > 0)
                {
                    liststudent.Add(hs.Key, hs.Value);
                }
            }
            if (liststudent.Count > 0)
            {
                int a = 0;
                foreach (KeyValuePair<int, List<string>> hs in liststudent)
                {
                    a++;
                    Console.Write("STT: " + a + " | Ma: " + hs.Key + " | ");
                    string[] tags = { "HoVaTen", "Age", "University", "Job" };
                    int tagsnum = 0;
                    foreach (string item in hs.Value)
                    {
                        Console.Write(tags[tagsnum] + ": " + ToUU(item) + " | ");
                        tagsnum++;
                    }
                    Console.WriteLine();
                }
            } else
            {
                Console.WriteLine("Khong co ten hoc sinh trong ds");
            }
  
        }
        public void findage(int number)
        {
            Dictionary<int, List<string>> liststudent = new Dictionary<int, List<string>>();
           
            foreach(KeyValuePair<int,List<string>> hs in students)
            {
                if (Convert.ToInt32(hs.Value[1]) == number)
                {
                    liststudent.Add(hs.Key,hs.Value);
                }
            }
            if(liststudent.Count > 0)
            {
                int a = 0;
                foreach (KeyValuePair<int, List<string>> hs in liststudent)
                {
                    a++;
                    Console.Write("STT: " + a + " | Ma: " + hs.Key + " | ");
                    string[] tags = { "HoVaTen", "Age", "University", "Job" };
                    int tagsnum = 0;
                    foreach (string item in hs.Value)
                    {
                        Console.Write(tags[tagsnum] + ": " + ToUU(item) + " | ");
                        tagsnum++;
                    }
                    Console.WriteLine();
                }
            } else
            {
                Console.WriteLine("Khong co so tuoi nay trong ds") ;
            }
            
        }
        public void finduni (string uni)
        {
            Dictionary<int, List<string>> liststudent = new Dictionary<int, List<string>>();

            foreach (KeyValuePair<int, List<string>> hs in students)
            {
              //  Console.WriteLine(hs.Value[2]);
                if (hs.Value[2] == uni.ToLower())
                {
                    liststudent.Add(hs.Key, hs.Value);
                }
            }
            if(liststudent.Count > 0)
            {
                int a = 0;
                foreach (KeyValuePair<int, List<string>> hs in liststudent)
                {
                    a++;
                    Console.Write("STT: " + a + " | Ma: " + hs.Key + " | ");
                    string[] tags = { "HoVaTen", "Age", "University", "Job" };
                    int tagsnum = 0;
                    foreach (string item in hs.Value)
                    {
                        Console.Write(tags[tagsnum] + ": " + ToUU(item) + " | ");
                        tagsnum++;
                    }
                    Console.WriteLine();
                }
            } else
            {
                Console.WriteLine("Khong tim thay truong hoc");
            }

        }
        private string ToUU(string ten)
        {
            string newt1 = ten.Trim();
            string[] newt2 = newt1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string newten = "";
            foreach (string pt in newt2)
            {
                string ptz = Convert.ToString(pt);
                ptz = ptz.ToLower();
                char[] giaikitu = ptz.ToCharArray();
                giaikitu[0] = char.ToUpper(giaikitu[0]);
                string newchar = new string(giaikitu);
                newten += newchar + " ";
            }
            string tenmoi = newten.Trim();
            return tenmoi;
        }
        public string GenID()
        {
            Random ran = new Random();
            while (true)
            {
                int ranew = ran.Next(10000000,99999999);
                if (students.ContainsKey(ranew) == false)
                { 
                    students.Add(ranew,newbie);
                    return "Khoi tao id cho hoc sinh " + name;
                    break;
                } else
                {
                    return "Khoi tao khong thanh cong";
                }
            }

        }
    }
}
