using System.IO.Pipes;


class Zerbitzaria
{
    static void Main(string[] args)
    {
        Console.WriteLine("Konexioaren zain...");
        var server = new NamedPipeServerStream("PipeGeo");
        server.WaitForConnection();
        Console.WriteLine("Zerbitzaria konektatuta dago...");

        StreamWriter sw = new StreamWriter(server);
        StreamReader sr = new StreamReader(server);
        Console.WriteLine("Datuen zain");
        sw.AutoFlush = true;


        while (true)
        {

            var aukera = sr.ReadLine();

            switch (aukera)
            {
                case "1":
                    var r = sr.ReadLine();
                    var azaleraZ = (Math.PI * Math.Pow(double.Parse(r), 2));
                    Console.WriteLine("Zirkuluaren azalera: " + azaleraZ);
                    sw.WriteLine(azaleraZ);
                    break;
                case "2":
                    var oinarriaT =  sr.ReadLine();
                    var altueraT = sr.ReadLine();
                    var azaleraT = (0.5 * double.Parse(oinarriaT) * double.Parse(altueraT));
                    Console.WriteLine("Triangeluaren azalera: " + azaleraT);
                    sw.WriteLine(azaleraT);

                    break;
                case "3":
                    var oinarriaL = sr.ReadLine();
                    var altueraL = sr.ReadLine();
                    var azaleraL = (double.Parse(oinarriaL) * double.Parse(altueraL));
                    sw.WriteLine(azaleraL);
                    Console.WriteLine("Laukizuzenaren azalera: " + azaleraL);
                    break;
                case "4":
                    var aldeaP = sr.ReadLine();
                    var apotemaP = sr.ReadLine();
                    var azaleraP = ((5 * double.Parse(aldeaP) * double.Parse( apotemaP)) / 2);
                    sw.WriteLine(azaleraP);
                    Console.WriteLine("Pentagonoaren azalera: " + azaleraP);
                    break;
                case "-1":
                    server.Close();
                    break;

                default:
                    Console.WriteLine("Aukera okerra");
                    break;
            }
        }
           
        }
    
}