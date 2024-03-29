﻿using System;

namespace pha_Maker
{
    class Program
    {
        static string getRef(int x)
        {
            switch (x)
            {
                case 11:
                    return "11th";
                case 12:
                    return "12th";
                case 13:
                    return "13th";
            }
            int n = x % 10;
            if (n == 1)
            {
                return Convert.ToString(x) + "st";
            }
            else if (n == 2)
            {
                return Convert.ToString(x) + "nd";
            }
            else if (n == 3)
            {
                return Convert.ToString(x) + "rd";
            }

            return Convert.ToString(x) + "th";
        }

        static void Main(string[] args)
        {
            string man;
            string dev;
            string typ;
            string col;
            string par;
            decimal pri = -1;

            string name;
            string fname;

            Console.Write("Enter the name of the file, excluding \".pha\": ");
            name = Console.ReadLine();
            fname = name + ".pha";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fname))
            {
                file.WriteLine("Any changes to this file will render the output of the calculator invalid; do not edit this file if you intend to use the calculator. Changing the values in this file will not change the value of money you are required to pay us, Phone Avengers, for our services. Please note that the values contained in this file may change and it is essential that you get the most up to date version of this software in order for it to provide you with accurate information.");
                
                int num = -1;

                while (num < 0)
                {
                    try
                    {
                        Console.Write("Enter the number of data entries: ");
                        num = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception) { }
                }

                for (int i = num; i > 0; i--)
                {
                    Console.Write("Enter " + getRef(num - i + 1) + " manufacturer: ");
                    man = Console.ReadLine();
                    Console.Write("Enter " + getRef(num - i + 1) + " device name: ");
                    dev = Console.ReadLine();
                    Console.Write("Enter " + getRef(num - i + 1) + " device type: ");
                    typ = Console.ReadLine();
                    Console.Write("Enter " + getRef(num - i + 1) + " device colour: ");
                    col = Console.ReadLine();
                    Console.Write("Enter " + getRef(num - i + 1) + " replacement part: ");
                    par = Console.ReadLine();
                    Console.Write("Enter " + getRef(num - i + 1) + " price: ");
                    do
                    {
                        try
                        {
                            pri = Convert.ToDecimal(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.Write("Invalid input, enter price: ");
                            continue;
                        }
                    } while (pri < 1);

                    file.WriteLine(man);
                    file.WriteLine(dev);
                    file.WriteLine(typ);
                    file.WriteLine(col);
                    file.WriteLine(par);
                    file.WriteLine(Convert.ToString(pri));
                    pri = -1;
                }
            }

            Console.WriteLine("File created, and saved as " + fname + "\npress Enter to exit");
            Console.ReadLine();
        }
    }
}
