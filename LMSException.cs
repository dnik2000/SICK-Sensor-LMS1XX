
using System;

namespace BSICK.Sensors.LMS1xx
{
    public class LMSException : Exception
    {
        public LMSException() : base()
        { }
        public LMSException(string message) : base(message)
        { }
    }

    public class LMSBadDataException : LMSException
    {
        public LMSBadDataException() : base()
        { }

        public LMSBadDataException(string message) : base(message)
        { }
    }
}
