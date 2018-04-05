using System;

namespace C_Taraba
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.WriteLine($"Hello  World!");
            Raznostranicni Trougao1 = new Raznostranicni(2,2,2);
            Trougao1.getData();
            Jednokraki Trougao2 = new Jednokraki(3,3);
            Trougao2.ObimJednako();
            Jednakostranicni Trougao3 = new Jednakostranicni(4);
            Trougao3.ObimJednakoStranicni();
            Console.ReadKey();
        }
    }

    class Raznostranicni
    {
        public int stranicaA{get; set;}
        public int stranicaB{get; set;}
        public int stranicaC{get; set;}

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
        public Jednokraki(int stranicaA, int stranicaB):base(stranicaA, stranicaB){}
        public Jednokraki(int stranicaA):base(stranicaA){}
        
        public void ObimJednako()
        {
            Console.WriteLine($"Obim2 je {2*stranicaB + stranicaA}");
        }

    }

    class Jednakostranicni: Jednokraki 
    {
        public Jednakostranicni(int stranicaA):base(stranicaA){}

        public void ObimJednakoStranicni()
        {
            Console.WriteLine($"Obim3 je {3*stranicaA}");
        }
        
    }

// ======================================================== zadatak 4

    interface Oblik 
    {
        void IzracunajObim();  
    }
    class Geometrija 
    {
        static void Ispis()
        {
            Console.WriteLine("Well Hello");
        }
    }

    class Pravougaonik : Oblik
    {
        private int stranicaA{get; set;}
        private int stranicaB{get; set;}

        public Pravougaonik(int stranicaA, int stranicaB)
        {
            this.stranicaA = stranicaA;
            this.stranicaB = stranicaB;
        }
        
        public void IzracunajObim()
        {
            throw new NotImplementedException();
        }
    }
    class Trougao : Oblik
    {
        private int stranicaA{get; set;}
        private int stranicaB{get; set;}
        private int stranicaC{get; set;}
        

        public Trougao(int stranicaA, int stranicaB, int stranicaC)
        {
            this.stranicaA = stranicaA;
            this.stranicaB = stranicaB;
            this.stranicaC = stranicaC;
        }
        public void IzracunajObim()
        {
            throw new NotImplementedException();
        }
    }

}


