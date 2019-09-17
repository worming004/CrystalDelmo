using System;
using System.IO;
using System.Text;

namespace CrystalDemlo
{
    class Program
    {
        static void Main(string[] args)
        {
            var stream = new MemoryStream();
            var textWriter = new StreamWriter(stream);
            var crystalWriter = new CrystalDemloWriter(Console.Out);

            crystalWriter.WriteCrystal(3);

            string result = Encoding.UTF8.GetString(stream.ToArray());

        }
    }
}
