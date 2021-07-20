/*
 * A C#.NET class to communicate with SICK SENSOR LMS1xx
 * 
 * Author : beolabs.io / Benjamin Oms
 * Update : 12/06/2017
 * Github : https://github.com/beolabs-io/SICK-Sensor-LMS1XX
 * 
 * --- MIT LICENCE ---
 * 
 * Copyright (c) 2017 beolabs.io
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 * 
 */

using System.Text;

namespace BSICK.Sensors.LMS1xx
{
    public static class CmdExtension
    {
        public const char STX = (char)0x02;
        public const char ETX = (char)0x03;
        public const char SPC = (char)0x20;
        public static byte[] GetCmdBytes(this string cmd)
        {
            return Encoding.ASCII.GetBytes(STX + cmd + ETX);
        }
    }
    public static class Cmd
    {
        //private static readonly string ReadByNameType = "sRN";
        //private static readonly string WriteByNameType = "sWN";
        //private static readonly string MethodType = "sMN";
        //private static readonly string EventType = "sEN";

        public static readonly string StartString = "sMN LMCstartmeas";
        public static readonly string StopString = "sMN LMCstopmeas";
        public static readonly string SetAccessModeString = "sMN SetAccessMode 3 F4724744";
        public static readonly string ScanDataString = "sRN LMDscandata";
        public static readonly string StartContinuousString = "sEN LMDscandata 1";
        public static readonly string StopContinuousString = "sEN LMDscandata 0";
        public static readonly string RunString = "sMN Run";
        public static readonly string QueryStatusString = "sRN STlms";
        public static readonly string StandByString = "sMN LMCstandby";
        public static readonly string RebootString = "sMN mSCreboot";

        public static readonly byte[] Start = StartString.GetCmdBytes();
        public static readonly byte[] Stop = StopString.GetCmdBytes();
        public static readonly byte[] SetAccessMode = SetAccessModeString.GetCmdBytes();
        public static readonly byte[] ScanData = ScanDataString.GetCmdBytes();
        public static readonly byte[] StartContinuous = StartContinuousString.GetCmdBytes();
        public static readonly byte[] StopContinuous = StopContinuousString.GetCmdBytes();
        public static readonly byte[] Run = RunString.GetCmdBytes();
        public static readonly byte[] QueryStatus = QueryStatusString.GetCmdBytes();
        public static readonly byte[] StandBy = StandByString.GetCmdBytes();
        public static readonly byte[] Reboot = RebootString.GetCmdBytes();
    }
}
