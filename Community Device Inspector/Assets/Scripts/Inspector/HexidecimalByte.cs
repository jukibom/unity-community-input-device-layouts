using System.Linq;

namespace CommunityDeviceInspector
{
    public class HexidecimalByte : Byte
    {
        protected override void RefreshDigits()
        {
            // break byte into hex values
            for (var i = 0; i < _digits.Count; i++)
            {
                _digits[i].Value = _byteData.ToString("X2").ToList()[i].ToString();
            }
        }
    }
}