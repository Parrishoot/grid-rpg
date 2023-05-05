using System;
using UnityEngine;
 
 [Serializable]
 public class SerializableMatrix<T>
 {
    [SerializeField]
    private int width;

    [SerializeField]
    private int height;

    [SerializeField]
    private T[] values;

    public int Width { get { return width; } }
    
    public int Height { get { return height; } }
 
    public SerializableMatrix(int width, int height)
    {
        this.width = width;
        this.height = height;

        values = new T[width * height];
    }

    public SerializableMatrix(int width, int height, T defaultValue) : this(width, height)
    {
        for(int i = 0; i < width * height; i++) {
            values[i] = defaultValue;
        }
    }

    public T this[int x, int y]
    {
        get { return values[y * width + x]; }
        set { values[y * width + x] = value; }
    }

    public T this[int i]
    {
        get { return values[i]; }
        set { values[i] = value; }
    }

    public SerializableMatrix<T> Clone() {

        SerializableMatrix<T> newMatrix = new SerializableMatrix<T>(width, height);
        newMatrix.values = (T[]) values.Clone();

        return newMatrix;
    }

    public T[] GetValues() {
        return values;
    }

    public void SetValues(T[] values) {
        this.values = values;
    }
 }