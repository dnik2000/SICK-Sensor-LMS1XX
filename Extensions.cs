

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BSICK.Sensors.LMS1xx
{
    public static class StreamExtensions
    {
        public static char ReadChar(this Stream stream)
        {
            var c = stream.ReadByte();
            if (c >= 0)
                return (char)c;
            else 
            throw new EndOfStreamException();
        }

        public static string ReadStringUntil(this Stream stream, char splitter, int count = 1000)
        {
            var sb = new StringBuilder();
            while (--count > 0)
            {
                var b = stream.ReadChar();
                if (b == splitter)
                    break;

                sb.Append(b);
            }
            return sb.ToString();
        }

        public static string ReadWord(this Stream stream)
        {
            return ReadStringUntil(stream, ' ');
        }

        public static int ReadIntAsHex(this Stream stream)
        {
            var txt = ReadWord(stream);
            return int.Parse(txt, System.Globalization.NumberStyles.HexNumber);
        }

        public static uint ReadUIntAsHex(this Stream stream)
        {
            var txt = ReadWord(stream);
            return uint.Parse(txt, System.Globalization.NumberStyles.HexNumber);
        }

        public static int[] ReadIntArrayAsHex(this Stream stream, int count)
        {
            var result = new int[count];
            while (--count >= 0)
            {
                result[count] = stream.ReadIntAsHex();
            }
            return result;
        }

        public static List<int> ReadListOfIntAsHex(this Stream reader, int count)
        {
            var result = new List<int>(count);
            while (--count >= 0)
            {
                result.Add(reader.ReadIntAsHex());
            }
            return result;
        }

        public static List<T> ReadListAsHex<T>(this Stream stream, int count, Func<int, T> func)
        {
            var result = new List<T>(count);
            while (--count >= 0)
            {
                var x = stream.ReadIntAsHex();
                result.Add(func(x));
            }
            return result;
        }
    }


    //public static class Extensions
    //{
    //    public static string ReadStringUntil(this BinaryReader reader, char splitter, int count = 1000)
    //    {
    //        var sb = new StringBuilder();
    //        while (--count > 0)
    //        {
    //            var b = reader.ReadChar();
    //            if (b == splitter)
    //                break;
    //            sb.Append(b);
    //        }
    //        return sb.ToString();
    //    }

    //    public static string ReadWord(this BinaryReader reader)
    //    {
    //        return ReadStringUntil(reader, ' ');
    //    }

    //    public static int ReadIntAsHex(this BinaryReader reader)
    //    {
    //        var txt = ReadWord(reader);
    //        return int.Parse(txt, System.Globalization.NumberStyles.HexNumber);
    //    }

    //    public static uint ReadUIntAsHex(this BinaryReader reader)
    //    {
    //        var txt = ReadWord(reader);
    //        return uint.Parse(txt, System.Globalization.NumberStyles.HexNumber);
    //    }

    //    public static int[] ReadIntArrayAsHex(this BinaryReader reader, int count)
    //    {
    //        var result = new int[count];
    //        while (--count >=0)
    //        {
    //            result[count] = reader.ReadIntAsHex();
    //        }
    //        return result;
    //    }

    //    public static List<int> ReadListOfIntAsHex(this BinaryReader reader, int count)
    //    {
    //        var result = new List<int>(count);
    //        while (--count >= 0)
    //        {
    //            result.Add(reader.ReadIntAsHex());
    //        }
    //        return result;
    //    }

    //    public static List<T> ReadListAsHex<T>(this BinaryReader reader, int count, Func<int,T> func)
    //    {
    //        var result = new List<T>(count);
    //        while (--count >= 0)
    //        {
    //            var x = reader.ReadIntAsHex();
    //            result.Add(func(x));
    //        }
    //        return result;
    //    }
    //}

}
