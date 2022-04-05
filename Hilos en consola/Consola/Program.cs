using System;
using System.Threading;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                try
                {
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("1. Revisar Ortografia");
                    Console.WriteLine("2. Imprimir");
                    Console.WriteLine("3. A donde ir de vacaciones? ");
                    Console.WriteLine("4. Escribiendo ");
                    Console.WriteLine("5. Operacion ");
                    Console.WriteLine("0. Salir");
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Elige una de las opciones");
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            RevisarOtografia ort = new RevisarOtografia();
                            ort.HilosOrtografia();
                            break;
                        case 2:
                            Akshay sss = new Akshay();
                            sss.Imprimir();
                            break;
                        case 3:
                            Vacaciones lugar = new Vacaciones();
                            lugar.Lugares();
                            break;
                        case 4:
                            Ejemplo asd = new Ejemplo();
                            asd.Ejercicio1();
                            break;
                        case 5:
                            Ejemplo1 ass = new Ejemplo1();
                            ass.Ejercicio2();
                            break;
                        case 0:
                            Console.WriteLine("Has elegido salir de la aplicación");
                            Environment.Exit(1);
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Elige una opcion entre 1 y 9");
                            break;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error al ingresar!!");
                }
            }

            
        }
    }
/*---------------------------------------------------------------------------------------*/
    public class RevisarOtografia
    {
        public void HilosOrtografia()
        {
            Mensajes msg = new Mensajes();
            Thread h1 = new Thread(new ThreadStart(msg.Ortografia));
            Thread h2 = new Thread(new ThreadStart(msg.Texto));

            h1.Start();
            h2.Start();

            h1.Join();
            h2.Join();
        }
    }
    public class Mensajes
    {
        public bool bien;
        public string texto;
        public void Texto()
        {
            for (int i = 0; i < 10; i++)
            {
                int num = new Random().Next(0, 2);
                if(num == 1)
                {
                    bien = false;
                    texto = "#$%#|°(=?$&$%/";
                    Console.WriteLine(texto);
                }else if(num == 0)
                {
                    bien = true;
                    texto = "hola";
                    Console.WriteLine(texto);
                }
                Thread.Sleep(1000);
            }
        }

        public void Ortografia()
        {
            for (int i = 0; i < 5; i++)
            {
                if(!bien)
                {
                    Console.WriteLine("Texto mal: "+ texto);
                }else
                {
                    Console.WriteLine("Texto bien: " + texto);
                }
                Thread.Sleep(2000);
            }
        }
    }
    /*---------------------------------------------------------------------------------------*/
    public class Vacaciones
    {
        public void Lugares()
        {
            Lugar lug = new Lugar();
            Thread l1 = new Thread(new ThreadStart(lug.cancun));
            Thread l2 = new Thread(new ThreadStart(lug.PlayaDelCarmen));
            Thread l3 = new Thread(new ThreadStart(lug.PuertoVallarta));

            l1.Start();
            l2.Start();
            l3.Start();

            l1.Join();
            l2.Join();
            l3.Join();
        }
    }

    public class Lugar
    {
        public void cancun()
        {
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("Cancún");
                Thread.Sleep(1000);
            }
        }

        public void PlayaDelCarmen()
        {
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("Playa Del Carmen");
                Thread.Sleep(1000);
            }
        }
        public void PuertoVallarta()
        {
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("Puerto Vallarta");
                Thread.Sleep(1000);
            }
        }
    }
    /*---------------------------------------------------------------------------------------*/
    public class Akshay
    {
        private static int Runs = 0;
        static Mutex mutex = new Mutex(false, "RunsMutex");
        public void CountUp()
        {
            while (Runs < 10)
            {
                // acquire the mutex  
                mutex.WaitOne();
                int Temp = Runs;
                Temp++;
                Console.WriteLine(Thread.CurrentThread.Name + " " + Temp);
                Thread.Sleep(800);
                Runs = Temp;
                // release the mutex  
                mutex.ReleaseMutex();
            }
        }
        public void Imprimir()
        {
            Thread t2 = new Thread(new ThreadStart(CountUp));
            t2.Name = "t2";
            Thread t3 = new Thread(new ThreadStart(CountUp));
            t3.Name = "t3";
            t2.Start();
            t3.Start();
            Console.Read();
        }
    }
    /*---------------------------------------------------------------------------------------*/
    public class Mensajes1
    {
        public void Mostrar1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(" Escribiendo desde ==> 1");
                Thread.Sleep(1000);
            }
        }

        public void Mostrar2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Escribiendo desde ==> 2");
                Thread.Sleep(1000);
            }
        }
    }

    public class Ejemplo
    {

        public void Ejercicio1()
        {
            Mensajes1 msg = new Mensajes1();

            Thread th1 = new Thread(new ThreadStart(msg.Mostrar1));
            Thread th2 = new Thread(new ThreadStart(msg.Mostrar2));

            th1.Start();
            th2.Start();

            th1.Join();
            th2.Join();
        }

    }
    /*---------------------------------------------------------------------------------------*/
    public class EjemploMates
    {

        public static int CalculoComplejo(int n)
        {
            // sumo uno y espero 5 segundos
            n = n + 1;
            Thread.Sleep(5000);
            return n;
        }

    }

    public class HiloParaMates
    {
        protected int n;
        protected MatesCallback callback = null;
        public HiloParaMates(int n, MatesCallback callback)
        {
            this.n = n;
            this.callback = callback;
        }
        public void CalculoComplejo()
        {
            int result = EjemploMates.CalculoComplejo(n);
            if (callback != null)
                callback(result);
        }
    }

    // creo un delegado con la firma necesaria para capturar
    // el valor devuelto por el método CalculoComplejo
    public delegate void MatesCallback(int n);

    public class Ejemplo1
    {

        public void Ejercicio2()
        {
            HiloParaMates hpm = new HiloParaMates(1000, new MatesCallback(ResultCallback));

            Thread th = new Thread(new ThreadStart(hpm.CalculoComplejo));

            th.Start();
            th.Join();

        }

        public static void ResultCallback(int n)
        {
            Console.WriteLine("Resultado de la operación: " + n);
        }
    }
    /*---------------------------------------------------------------------------------------*/
    //jhgagdhgsjhdjg
}




