﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section1 {
    class Program {
        static void Main1(string[] args) {
            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();

            Console.WriteLine("What is your age?");
            var age = Console.ReadLine();

            Console.WriteLine("What month were you born in?");
            var month = Console.ReadLine();

            Console.WriteLine("What is your favourite book?");
            var book = Console.ReadLine();

            Console.WriteLine("What country do you live in?");
            var country = Console.ReadLine();

            Console.WriteLine("Your name is: {0}", name);
            Console.WriteLine("Your age is: {0}", age);
            Console.WriteLine("Your birth month is: {0}", month);
            Console.WriteLine("Your favourite book is: {0}", book);
            Console.WriteLine("You live in this country: {0}", country);
        }
    }
}
