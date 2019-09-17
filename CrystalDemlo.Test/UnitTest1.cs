using CrystalDemlo;
using System.IO;
using System.Text;
using Xunit;

namespace CrystalDemlo.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, "1\r\n")]
        [InlineData(2, " 1 \r\n121\r\n 1 \r\n")]
        [InlineData(3, "  1  \r\n 121 \r\n12321\r\n 121 \r\n  1  \r\n")]
        [InlineData(6, "     1     \r\n    121    \r\n   12321   \r\n  1234321  \r\n 123454321 \r\n12345654321\r\n 123454321 \r\n  1234321  \r\n   12321   \r\n    121    \r\n     1     \r\n")]
        public void Test1(int value, string expected)
        {
            var stream = new MemoryStream();
            var textWriter = new StreamWriter(stream);
            var crystalWriter = new CrystalDemloWriter(textWriter);

            crystalWriter.WriteCrystal(value);

            string result = Encoding.UTF8.GetString(stream.ToArray());
            Assert.Equal(expected, result);
        }
    }
}
