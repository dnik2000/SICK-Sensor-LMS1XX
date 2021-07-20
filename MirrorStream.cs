

using System;
using System.IO;

namespace BSICK.Sensors.LMS1xx
{
    public class MirrorStream : Stream
    {
        private Stream accumulator;
        private Stream baseStream;

        public MirrorStream(Stream stream, Stream mirrorStream)
        {
            baseStream = stream;
            accumulator = mirrorStream;
        }


        public override bool CanRead => baseStream.CanRead;

        public override bool CanSeek => baseStream.CanSeek;

        public override bool CanWrite => baseStream.CanWrite;

        public override long Length => baseStream.Length;

        public override long Position { get => baseStream.Position; set => baseStream.Position = value; }

        public override void Flush()
        {
            baseStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var cnt = baseStream.Read(buffer, offset, count);
            accumulator.Write(buffer, offset, cnt);
            return cnt;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return baseStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            baseStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            baseStream.Write(buffer, offset, count);
        }

        public override int ReadByte()
        {
            var b = baseStream.ReadByte();
            if (b >= 0)
                accumulator.WriteByte((byte)b);
            return b;
        }
    }

}
