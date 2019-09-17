using System;
using System.IO;

namespace CrystalDemlo
{
    public class CrystalDemloWriter
    {
        private TextWriter _writer;

        public CrystalDemloWriter(TextWriter writer)
        {
            _writer = writer;
        }

        public void WriteCrystal(int value)
        {
            if (value < 0 || value > 9)
            {
                throw new InvalidOperationException($"Value {value} is out of [0..9]");
            }

            var lineLength = value * 2 - 1;
            var colonneLength = lineLength;

            for (int index = 1; index <= colonneLength; index++)
            {
                int maxValueLine = value - Math.Abs(value - index);
                var whiteSpaceCount =  Math.Abs(value - index);

                _writer.Write(new string(' ', whiteSpaceCount));
                for (var instantValue = 1; instantValue <= maxValueLine; instantValue++)
                {
                    _writer.Write(instantValue);
                }
                for (var instantValue = maxValueLine - 1; instantValue > 0; instantValue--)
                {
                    _writer.Write(instantValue);
                }
                _writer.Write(new string(' ', whiteSpaceCount));
                _writer.Write("\r\n");
            }
            _writer.Flush();
        }
    }
}