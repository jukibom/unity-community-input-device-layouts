namespace CommunityDeviceInspector
{
    public class DecimalByte : Byte
    {
        protected override void RefreshDigits()
        {
            // convert byte to decimal value, padded with 0s
            _digits[0].Value = (_byteData / 100).ToString();
            _digits[1].Value = ((_byteData / 10) % 10).ToString();
            _digits[2].Value = (_byteData % 10).ToString();
        }
    }
}