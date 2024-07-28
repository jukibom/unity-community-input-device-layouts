using System;

namespace CommunityDeviceInspector
{
    public class BinaryByte : Byte
    {
        protected override void RefreshDigits()
        {
            // break byte into binary values
            for (var i = 0; i < _digits.Count; i++)
            {
                _digits[i].Value = Convert
                    .ToString(_byteData, 2)
                    .PadLeft(8, '0')[i]
                    .ToString();
            }
        }
    }
}