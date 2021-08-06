

using System;
using System.IO;

namespace BSICK.Sensors.LMS1xx
{
    public class MirrorStream : Stream
    {
        private bool isDisposed;
        private readonly Stream mirrorStream;
        private readonly Stream baseStream;
        private readonly bool needDisposeMirrorStrem;

        public MirrorStream(Stream stream, Stream mirrorStream)
        {
            baseStream = stream;
            this.mirrorStream = mirrorStream;
        }

        public MirrorStream(Stream stream, string fileName)
        {
            baseStream = stream;
            mirrorStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            needDisposeMirrorStrem = true;
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
            mirrorStream.Write(buffer, offset, cnt);
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
                mirrorStream.WriteByte((byte)b);
            return b;
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposing)
                return;
            if (isDisposed)
                return;
            isDisposed = true;
            mirrorStream?.Flush();
            if (needDisposeMirrorStrem)
                mirrorStream.Dispose();
        }


    }

}
