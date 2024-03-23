using System;
using System.Linq;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public struct InputFrame
    {
        public byte[] rawBytes;
        public string decimalString;
        public string hexString;
        public string binaryString;
    }
    
    public static class DeviceRawStateQuery
    {
        public static InputFrame StateForDevice(InputDevice inputDevice)
        {
            unsafe
            {
                // create a void* buffer of size inputDevice.valueSizeInBytes
                void* buffer = stackalloc byte[inputDevice.valueSizeInBytes];
                inputDevice.ReadValueIntoBuffer(buffer, inputDevice.valueSizeInBytes);
                
                byte[] rawBytes = new byte[inputDevice.valueSizeInBytes];
                System.Runtime.InteropServices.Marshal.Copy((System.IntPtr)buffer, rawBytes, 0,
                    inputDevice.valueSizeInBytes);
                
                var decimalString = string.Join(", ", rawBytes);
                string hexString = string.Join(" ", rawBytes.Select(b => b.ToString("X2")));
                string binaryString = string.Join(" ", rawBytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
                
                return new InputFrame()
                {
                    rawBytes = rawBytes,
                    decimalString = decimalString,
                    hexString = hexString,
                    binaryString = binaryString
                };
            }
        }
    }
}