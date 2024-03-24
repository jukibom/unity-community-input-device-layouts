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

    public enum Endian
    {
        Little,
        Big
    }
    
    public static class DeviceRawStateQuery
    {
        public static InputFrame StateForDevice(InputDevice inputDevice, Endian endian = Endian.Big)
        {
            unsafe
            {
                // create a void* buffer of size inputDevice.valueSizeInBytes
                void* buffer = stackalloc byte[inputDevice.valueSizeInBytes];
                inputDevice.ReadValueIntoBuffer(buffer, inputDevice.valueSizeInBytes);
                
                byte[] rawBytes = new byte[inputDevice.valueSizeInBytes];
                System.Runtime.InteropServices.Marshal.Copy((IntPtr)buffer, rawBytes, 0,
                    inputDevice.valueSizeInBytes);
                
                // Pretty sure this always comes in at Big Endian ... I hope
                if (endian == Endian.Little) Array.Reverse(rawBytes);
                
                // Simplified representations for sanity
                // TODO: maybe shunt these to helper functions?
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