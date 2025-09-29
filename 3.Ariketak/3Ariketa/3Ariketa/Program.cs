// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using System.IO.Pipes;

class Bezeroa
{
    public static void Main(string[] args)
    {
        

        var server = new NamedPipeClientStream("PipeGeo");
        server.Connect();
        Console.WriteLine("Zerbitzariarekin konektatuta");

        StreamWriter sw = new StreamWriter(server);
        StreamReader sr = new StreamReader(server);
        sw.AutoFlush = true;

        while (true)
        {
            Console.WriteLine("Irudi geometrikoa aukeratu ");
            Console.WriteLine("1- Zirkulua");
            Console.WriteLine("2- Triangelua");
            Console.WriteLine("3- Laukizuzena");
            Console.WriteLine("4- Pentagonoa");
            Console.WriteLine("( -1 ) Irten");

            var aukera = Console.ReadLine();
           
                sw.WriteLine(aukera);
                switch (aukera)
                {
                    case "1":
                        Console.WriteLine("Sartu zirukuaren erradioa: ");
                        var r = Console.ReadLine();
                        sw.WriteLine(r);
                        var azaleraZ = sr.ReadLine();
                        Console.WriteLine("Zirkuluaren azalera: " + azaleraZ);
                        break;
                    case "2":
                        Console.WriteLine("Sartu triangeluaren oinarria: ");
                        var oinarriaT = Console.ReadLine();
                        sw.WriteLine(oinarriaT);
                        Console.WriteLine("Sartu triangeluaren altuera: ");
                        var altueraT = Console.ReadLine();
                        sw.WriteLine(altueraT);
                        var azaleraT = sr.ReadLine();
                        Console.WriteLine("Triangeluaren azalera: " + azaleraT);
                        break;
                    case "3":
                        Console.WriteLine("Sartu laukizuzenaren oinarria: ");
                        var oinarriaL = Console.ReadLine();
                        sw.WriteLine(oinarriaL);
                        Console.WriteLine("Sartu laukizuzenaren altuera: ");
                        var altueraL = Console.ReadLine();
                        sw.WriteLine(altueraL);
                        var azaleraL = sr.ReadLine();
                        Console.WriteLine("Laukizuzenaren azalera: " + azaleraL);
                        break;
                    case "4":
                        Console.WriteLine("Sartu pentagonoaren aldea: ");
                        var aldeaP = Console.ReadLine();
                        sw.WriteLine(aldeaP);
                        Console.WriteLine("Sartu pentagonoaren apotema:");
                        var apotemaP = Console.ReadLine();
                        sw.WriteLine(apotemaP);
                        var azaleraP = sr.ReadLine();
                        Console.WriteLine("Pentagonoaren azalera: " + azaleraP);
                        break;
                    case "-1":
                        server.Close();
                        return;
                }

            }
        }
    
    
}

