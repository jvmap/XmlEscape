using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlEscape
{
    class XmlEscaper
    {
        public static void Escape(Stream input, TextWriter output)
        {
            Encoding encoding = GetEncoding(input);
            using var reader = new StreamReader(input, encoding);
            string unescaped = reader.ReadToEnd();
            string escaped = SecurityElement.Escape(unescaped);
            output.Write(escaped);
        }

        private static Encoding GetEncoding(Stream input)
        {
            var reader = new XmlTextReader(input);
            reader.MoveToContent();
            input.Position = 0;
            return reader.Encoding;
            // don't Dispose the reader, because doing so closes the input stream.
        }
    }
}
