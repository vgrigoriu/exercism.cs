using System;

public class CircularBuffer<T>
{
    private readonly T[] buffer;

    // the index of the first element in the buffer
    private int begin = 0;

    private int length = 0;

    public CircularBuffer(int capacity)
    {
        buffer = new T[capacity];
    }

    public T Read()
    {
        if (length == 0)
        {
            throw new InvalidOperationException("Can't read from empty buffer");
        }

        var value = buffer[begin];
        Clear();
        return value;
    }

    public void Write(T value)
    {
        if (length == buffer.Length)
        {
            throw new InvalidOperationException("Can't write to full buffer");
        }

        buffer[(begin + length) % buffer.Length] = value;
        length += 1;
    }

    public void Overwrite(T value)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public void Clear()
    {
        begin = (begin + 1) % buffer.Length;
        length -= 1;
    }
}