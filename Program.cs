using System;
using System.Collections.Generic;

namespace C_Taraba
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            --- zadatak 1
            Console.WriteLine($"Hello  World!");
            Raznostranicni Trougao1 = new Raznostranicni(2,2,2);
            Trougao1.getData();
            Jednokraki Trougao2 = new Jednokraki(3,3);
            Trougao2.ObimJednako();
            Jednakostranicni Trougao3 = new Jednakostranicni(4);
            Trougao3.ObimJednakoStranicni();
            */

            /*
            --- zadatak2
            Pravougaonik2 pravo1 = new Pravougaonik2(2, 2);
            Trougao2 tro1 = new Trougao2(2, 2, 2);
            Geometrija2.Ispis(pravo1.IzracunajObim());
            Geometrija2.Ispis(tro1.IzracunajObim());
            */

            /*
            ---- zadatak3
            Pravougaonik3 p = new Pravougaonik3(2, 3);
            Kvadrat3 k = new Kvadrat3(5);
            Krug3 kk = new Krug3(10);

            List<object> stuff = new List<object>();
            stuff.Add(p);
            stuff.Add(k);
            stuff.Add(kk);

            foreach (object item in stuff)
            {
                Console.WriteLine(item);
            }
            stuff.Insert(3, new Krug3(11));
            Console.WriteLine(stuff.Contains(p));
            Console.WriteLine(stuff.Count);
            */

        /*
            Stack<int> intStack = new Stack<int>(10);
            for(int i = 0;i<10; i++)
            {
                intStack.Push(i*5);
            }
            for(int i=0;i<10;i++)
            {
                Console.Write(intStack.Pop()+" ");
            }
        */
        }
    }

    class Raznostranicni
    {
        public int stranicaA { get; set; }
        public int stranicaB { get; set; }
        public int stranicaC { get; set; }

        public Raznostranicni(int stranicaA, int stranicaB, int stranicaC)
        {
            this.stranicaA = stranicaA;
            this.stranicaB = stranicaB;
            this.stranicaC = stranicaC;
            Console.WriteLine("Raznostranicni kreiran");
        }
        public Raznostranicni(int stranicaA, int stranicaB)
        {
            this.stranicaA = stranicaA;
            this.stranicaB = stranicaB;
            Console.WriteLine("Raznostranicni kreiran");
        }
        public Raznostranicni(int stranicaA)
        {
            this.stranicaA = stranicaA;
            Console.WriteLine("Raznostranicni kreiran");
        }

        public void getData()
        {
            Console.WriteLine($"stranice su {stranicaA}, {stranicaB}, {stranicaC}");
        }
    }

    class Jednokraki : Raznostranicni
    {
        public Jednokraki(int stranicaA, int stranicaB) : base(stranicaA, stranicaB) { }
        public Jednokraki(int stranicaA) : base(stranicaA) { }

        public void ObimJednako()
        {
            Console.WriteLine($"Obim2 je {2 * stranicaB + stranicaA}");
        }

    }

    class Jednakostranicni : Jednokraki
    {
        public Jednakostranicni(int stranicaA) : base(stranicaA) { }

        public void ObimJednakoStranicni()
        {
            Console.WriteLine($"Obim3 je {3 * stranicaA}");
        }

    }

    // ======================================================== zadatak 2

    interface Oblik2
    {
        int IzracunajObim();
    }
    class Geometrija2
    {
        public static void Ispis(int rezultat)
        {
            Console.WriteLine($"Well Hello je {rezultat}");
        }
    }

    class Pravougaonik2 : Oblik2
    {
        private int stranicaA { get; set; }
        private int stranicaB { get; set; }

        public Pravougaonik2(int stranicaA, int stranicaB)
        {
            this.stranicaA = stranicaA;
            this.stranicaB = stranicaB;
        }

        public int IzracunajObim()
        {
            return 2 * (stranicaA + stranicaB);
        }
    }
    class Trougao2 : Oblik2
    {
        private int stranicaA { get; set; }
        private int stranicaB { get; set; }
        private int stranicaC { get; set; }


        public Trougao2(int stranicaA, int stranicaB, int stranicaC)
        {
            this.stranicaA = stranicaA;
            this.stranicaB = stranicaB;
            this.stranicaC = stranicaC;
        }
        public int IzracunajObim()
        {
            return stranicaA + stranicaB + stranicaC;
        }
    }
    // =============================================== zadatak 3
    public abstract class Oblik3
    {
        public int a;
        public int b;
    }
    class Pravougaonik3 : Oblik3
    {
        public Pravougaonik3(int a, int b)
        {
            this.a = a;
            this.b = b;
            Console.WriteLine(this.a);

        }
        public Pravougaonik3(int a)
        {
            this.a = a;
        }
    }
    class Kvadrat3 : Pravougaonik3
    {
        public Kvadrat3(int a) : base(a)
        {
            this.a = a;
            Console.WriteLine(this.a);

        }
    }
    class Krug3 : Oblik3
    {
        public Krug3(int a)
        {
            this.a = a;
            Console.WriteLine(this.a);
        }
    }

//========================= zadatak genericke Stack stuff

    public class Stack<T>
    {
        int size;
        int index = 0;
        T[] array;

    public Stack(int size)
    {
        this.size = size;
        array = new T[this.size];
    }
    public void Push (T item)
    {
        if (index >= size) {
            throw new StackOverflowException();
        }
        array[index] = item;
        index++;
    }

    public T Pop(){
        index--;
        if (index >= 0)
        {
            return array[index];
        }
        index = 0;
        throw new InvalidOperationException("Errror");

    }
    } 

//=================================================== genericki zadatak sa vise parametara


}



