using System;
using System.Collections.Generic;
using Latihan.Data;

namespace LatihanUKSW
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount ba = new BankAccount("Gadael", 5000M);
            Console.WriteLine($"Account {ba.Number} dibuat untuk {ba.Owner} dengan saldo awal {ba.Balance}.");
            ba.MakeDeposit(700M, DateTime.Now, "uang dari ngasdos");
            ba.MakeWithdrawal(7000M, DateTime.Now, "uang dari ngasdos");
            System.Console.WriteLine($"Saldo akhir : {ba.Balance}");
    
            DataAccess da = new DataAccess();
            string makanan = da.AmbilMakan();
            System.Console.WriteLine($"makanannya adalah : {makanan}");

            // BankAccount ba2 = new BankAccount("David", 1000M);
            // Console.WriteLine($"Account {ba2.Number} dibuat untuk {ba2.Owner} dengan saldo awal {ba2.Balance}.");
            
            //Console.WriteLine("Selamat pagi Gadael..");
            // string name = "Mr. Tony Hawk.";
            // //Console.WriteLine($"Selamat makan {name}");
            // string[] names = name.Split('.');
            // Console.WriteLine(names.Length);
            // System.Console.WriteLine(names[2]);
            // System.Console.WriteLine(names[1]);
            // System.Console.WriteLine(names[0]);

            // string gelar1 = name.Substring(4, 4);
            // string gelar2 = name.Substring(6, 4);
            // string gelar3 = name.Substring(4, 5);
            // System.Console.WriteLine($"kel. 1 : 4,4 = {gelar1}");
            // System.Console.WriteLine($"kel. 2 : 6,4 = {gelar2}");
            // System.Console.WriteLine($"kel. 3 : 4,5 = {gelar3}");


            // ///
            // /// NUMBERS
            // ///        
            // int a = 2;
            // int b = 2;
            // int c = a * b;
            // // int c  = a+ b; 
            // // int c  = a- b; 
            // // int c  = a/ b; 
            // System.Console.WriteLine($"c adalah {c}");

            // double d = 2.1;
            // double e = 2.2;
            // double f = d - e;
            // System.Console.WriteLine($"f adalah {f}");

            // decimal saldo = 10000M;
            // decimal setor = 500M;
            // saldo = saldo + setor;
            // decimal tarik = 20000M;
            // saldo = saldo - tarik;
            // System.Console.WriteLine($"saldo is {saldo:C}");
            // System.Console.WriteLine($"saldo is Rp.{saldo:N}");
            // System.Console.WriteLine($"saldo is {saldo:F}");

            // //branches
            // System.Console.WriteLine("==========BRANCHES ============");
            // int usia = 27;
            // if (usia > 30)
            // {
            //     System.Console.WriteLine("Anda sudah tua.");
            // }
            // else if (usia > 20 && usia < 26)
            // {
            //     System.Console.WriteLine("Anda sudah hampir tua.");
            // }
            // else if (usia < 20)
            // {
            //     System.Console.WriteLine("Anda masih muda.");
            // }
            // else
            // {
            //     System.Console.WriteLine("Anda beruntung.");
            // }

            // switch (usia)
            // {
            //     case 22:
            //         Console.WriteLine("Usia anda adalah 22");
            //         break;
            //     case 24:
            //         Console.WriteLine("Usia anda adalah 24");
            //         break;
            //     default:
            //         Console.WriteLine("Usia anda tidak jelas");
            //         break;
            // }
            // // Console.WriteLine($"Usia : {usia}");
            // // System.Console.WriteLine( "==========LOOPS ============");
            // // for (int i = 0; i < names.Length; i++)
            // // {
            // //     System.Console.WriteLine($"Name {i} : {names[i]} -> {names[i].Length}");
            // // }

            // // int i = 0;
            // // do
            // // {
            // //     System.Console.WriteLine($"Name {i} : {names[i]} -> {names[i].Length}");
            // //     i++;
            // // } while (i<names.Length);
            // // i=0;
            // // while (i<names.Length)
            // // {
            // //     System.Console.WriteLine(name);
            // //     i++;
            // // }

            // System.Console.WriteLine("====== COLLECTIONS ========");
            // int[] ukuransepatu = new int[] { 40, 41, 42, 43, 46 };
            // System.Console.WriteLine("Ukuran sepatu(s) :");
            // for (int i = 0; i < ukuransepatu.Length; i++)
            // {
            //     System.Console.WriteLine(ukuransepatu[i]);
            // }

            // string[] ukuranbaju = new string[] { "XXXL", "XS", "L", "S", "M", "XL", "XXS" };
            // int j = 0;
            // do
            // {
            //     System.Console.WriteLine(ukuranbaju[j]);
            //     j++;
            // } while (j < ukuranbaju.Length);


            // List<int> tinggibadan = new List<int>(){
            //     5,6,2,3,8,1
            // };
            // List<string> merksepatu = new List<string>(){
            //     "Nike","Addidas","Skecher",
            //     "Cibaduyut"
            // };
            // tinggibadan.Sort();
            // merksepatu.Sort();

            // foreach (var item in merksepatu)
            // {
            //     System.Console.WriteLine(item);
            // }

        }
    }
}
