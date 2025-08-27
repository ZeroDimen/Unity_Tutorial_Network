using System;
using System.Text;

public class Packet
{
    public byte[] buffer { get; private set; }
    public int position { get; private set; }

    public Packet()
    {
        buffer = new byte[1024];
        position = Defines.HEADERSIZE;
    }

    public void RecordSize()
    {
        short bodySize = (short)(position - Defines.HEADERSIZE);
        byte[] header = BitConverter.GetBytes(bodySize);
        header.CopyTo(buffer, 0);
    }
    
    public void Push(string value)
    {
        byte[] data = Encoding.UTF8.GetBytes(value);
        data.CopyTo(buffer, position);
        position += data.Length;
    }
}