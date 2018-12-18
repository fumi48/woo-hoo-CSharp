using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
       test01();
    }

    static void test01()
    {
        /*
        * IEnumerable<T> をわかった気になる
        * 実装するとforeach(var d in collection){ ... }ができる
        */
        MyEnum1 e1 = new MyEnum1();
        foreach(string p in e1) Console.WriteLine(p);
        Console.WriteLine("-----");
        foreach(string p in e1.OrderBy(e => e)) Console.WriteLine(p);
    }
    /*
     * IEnumerableを実装
     */
    class MyEnum1: IEnumerable<string>
    {
        //実装するメソッドは2つ
        public IEnumerator<string> GetEnumerator()
        {
            /*
            * イテレータ(yield)
            * yield return でIEnumeratorを返すことができる
            */
            yield return "Cathy";
            yield return "Alice";
            yield return "Bob";
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
