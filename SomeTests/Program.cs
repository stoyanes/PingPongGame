using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeTests
{
    class A
    {
        public virtual void Print()
        {
            Console.WriteLine("A::Print()");
        }
    }

    class B : A
    {
        public override void Print()
        {
            Console.WriteLine("B::Print()");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            a.Print();

            B b = new B();
            b.Print();
        }
    }
}
