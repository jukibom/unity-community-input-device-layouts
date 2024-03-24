namespace CommunityDeviceInspector
{
    public class BinaryByte : Byte
    {
        protected override void RefreshDigits()
        {
            // break byte into binary values
            for (int i = 0; i < _digits.Count; i++)
            {
                _digits[i].Value = ((_byteData >> i) & 1).ToString();
            }
        }
    }
}