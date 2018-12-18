using System;

class Program
{
    static void Main(string[] args)
    {
       test01();
    }

    static void test01()
    {
        /*
        * delegateをわかった気になる
        */    
        Delegate1 d1 = new Delegate1(Sum); //古い
        d1(1, 2); 
        Delegate1 d2 = Sum; //C# 2.0から
        d2(3, 4);

        Delegate2 d3 = new Delegate2(delegate (int n) { 
                Console.WriteLine("{0} * {0} = {1}", n, n*n ); 
            });
        d3(5);

        Delegate3 d4 = (a, b) => { //C# 3.0から
            Console.WriteLine("{0} - {1} = {2}", a, b, a-b);
        };
        d4(6, 7);

    }
    delegate void Delegate1(int a, int b);
    delegate void Delegate2(int a);
    delegate void Delegate3(int a, int b);
    static void Sum(int a, int b)
    {
        Console.WriteLine("{0} + {1} = {2}", a, b, (a + b) );
    }
}   
