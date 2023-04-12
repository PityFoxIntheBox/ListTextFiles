namespace ListTextFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[40];
            string path = "результаты соревнований.txt";
            arr = File.ReadAllLines(path);
            string[] sep = new string[6];
            List<Turniki> A = new List<Turniki>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    A.Add(new Turniki() { Name = arr[i], Results = arr[i+1] });
                    i++;
                }
            }
            List<Turniki2> B = new List<Turniki2>();
            for (int i = 0; i < arr.Length / 2; i++)
            {
                sep = A[i].Results.Split(' ');
                int am = 0;
                int nl = 0;
                for (int k = 0; k < sep.Length; k++)
                {
                    if (k % 2 == 0)
                    {
                        am += Convert.ToInt32(sep[k]);
                    }
                    else
                    {
                        nl += Convert.ToInt32(sep[k]);
                    }
                }
                B.Add(new Turniki2() { Name = A[i].Name, Amount = am,  Nails = nl});

            }

            foreach (Turniki2 b in B)
            {
                Console.WriteLine("Name: " + b.Name + " amount: " + b.Amount + " Nails: " + b.Nails);
            }

            int mint = B[0].Nails;
            int maxa;
            int o = 0;
            string path2 = "Отсортированный список.txt";
            int[] arrex = new int[B.Count];
            //List<int> arrex = new List<int>()
            List<Turniki2> C = new List<Turniki2>();
            bool flag;

            for (int i = 0; i < B.Count; i++)
            {
                maxa = 0;
                flag = false;
                for (int p = 0; p < B.Count; p++)
                {
                    
                    if (Array.IndexOf(arrex, p) == -1)
                    {
                        if (B[p].Nails > 10)
                        {
                            C.Add(new Turniki2 { Name = B[p].Name, Nails = B[p].Nails, Amount = B[p].Amount });
                            o = p;
                            flag = true;
                        }
                        else
                        {
                            if (B[p].Amount > maxa)
                            {
                                maxa = B[p].Amount;
                                mint = B[p].Nails;
                                o = p;
                            }
                            else if (B[p].Amount == maxa)
                            {
                                if (B[p].Nails > mint)
                                {
                                    maxa = B[p].Amount;
                                    mint = B[p].Nails;
                                    o = p;
                                }
                            }
                        }
                    }
                }
                arrex[i] = o;
                if (flag == true)
                {
                    continue;
                }
                File.AppendAllText(path2, "\n" + B[o].Name);
                File.AppendAllText(path2, " " + Convert.ToString(B[o].Amount));
                File.AppendAllText(path2, " " + Convert.ToString(B[o].Nails));
            }
            File.AppendAllText(path2, "\n Дисквалифицированные:");
            foreach (var per in C)
            {
                File.AppendAllText(path2, "\n" + per.Name);
                File.AppendAllText(path2, " " + Convert.ToString(per.Amount));
                File.AppendAllText(path2, " " + Convert.ToString(per.Nails));
            }
        }
    }

    public struct Turniki
    {
        public string Name;
        public string Results;
        public Turniki(string n, string r)
        {
            Name = n;
            Results = r;
        }
    }
    public struct Turniki2
    {
        public string Name;
        public int Amount;
        public int Nails;
    }
}