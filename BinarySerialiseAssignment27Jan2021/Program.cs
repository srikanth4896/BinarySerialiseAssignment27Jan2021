using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace BinarySerialiseAssignment27Jan2021
{
    [Serializable]
    class DateEx:IDeserializationCallback
    {
        public int Byear { get; set; }
        public int Pyear { get; set; }
       

        public void OnDeserialization(object sender)
        {
            Console.WriteLine();
            Console.WriteLine($"The Present Age is:{Pyear-Byear}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DateEx d = new DateEx();
            d.Pyear = DateTime.Now.Year;
            
            Console.WriteLine("Enter Your Year of Birth:");
            d.Byear = Convert.ToInt32(Console.ReadLine( ));
            FileStream fs = new FileStream(@"F:\Date.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fs, d);
            fs.Seek(0, SeekOrigin.Begin);
            DateEx d1 = (DateEx)b.Deserialize(fs);
            
        }
    }
}
