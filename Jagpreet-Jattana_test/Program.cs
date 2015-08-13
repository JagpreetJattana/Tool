using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Linq;

namespace Jagpreet_Jattana_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Shelter sht = new Shelter(10);
            Console.Write("Currently there are " + sht.bookedShelter + " shelter bookings are to be cancelled");
            Booth bthA = new Booth("A", sht);
            Booth bthB = new Booth("B", sht);

            Thread t1 = new Thread(new ThreadStart(bthA.performCancelation));
            Thread t2 = new Thread(new ThreadStart(bthB.performCancelation));

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            Console.WriteLine("\n\rCancellations made by Booth A = "+bthA.getNoOfCancellations());
            Console.WriteLine("Cancellations made by Booth B = " + bthB.getNoOfCancellations());

            XDocument myDocument = XmlDataClass.createData();
            Console.WriteLine(myDocument.ToString());
            Console.ReadKey();


             
            XmlDataClass.SaveDataToFile("booking_cancelation.xml");

            Console.ReadKey();




        }
    }

    class Shelter {

       public int bookedShelter;

          

            public Shelter(int bs)
            {
                this.bookedShelter = bs;
            }
            public void cancelBooking()
            {
                lock (this)
                {
                    this.bookedShelter--;
                    Monitor.Pulse(this);
                }
            }
          
    
    
    
    }

    class Booth {
        Shelter shlt;
        String bothName;
        int noCancelbyBoth;
        String list;

        public Booth(String bothname,Shelter shelter)
        {
            this.shlt = shelter;
            this.bothName = bothname;
        }

        public int getNoOfCancellations()
        {
            return this.noCancelbyBoth;
        }

        public void performCancelation() {

            while (this.shlt.bookedShelter > 0)
            {
                this.shlt.cancelBooking();
                this.noCancelbyBoth++;
                this.list += shlt.bookedShelter+" ";
                Console.WriteLine("\n\rBooth "+this.bothName +  " cancelled a booking. The current number of bookings to cancel - " + shlt.bookedShelter);
                Console.WriteLine("\n\rBooth "+this.bothName+" have cancelled "+this.noCancelbyBoth+" shelter bookings so far");
                Console.WriteLine("These are "+this.list);
                Console.WriteLine("\n\rEnd of cancellation by booth " + this.bothName);
                Thread.Sleep(1000);
            }
        }
    
    }

}
