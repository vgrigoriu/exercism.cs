using System;

public class CircularBuffer<T>
{
    private readonly T[] buffer;

    // the index of the first element in the buffer
    private int startIndex = 0;

    // number of elements currently in the buffer
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

        var value = buffer[startIndex];
        Clear();
        return value;
    }

    public void Write(T value)
    {
        if (length == buffer.Length)
        {
            throw new InvalidOperationException("Can't write to full buffer");
        }

        buffer[(startIndex + length) % buffer.Length] = value;
        length += 1;
    }

    public void Overwrite(T value)
    {
        if (length == buffer.Length)
        {
            Clear();
        }
        Write(value);
    }

    // It's not clear if Clear should clear all elements or just one.
    public void Clear()
    {
        if (length == 0)
        {
            return;
        }

        startIndex = (startIndex + 1) % buffer.Length;
        length -= 1;
    }
}