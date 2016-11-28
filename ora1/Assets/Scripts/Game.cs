using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game{

    public static Game current = new Game();
    public int whichPosition = 0;
    public MyVector[] positions = new MyVector[2] { new MyVector(402.6f,-2.2f,106.7f), new MyVector(1364f,69.4f,106.7f) };
}
[System.Serializable]
public class MyVector
{
    public float x;
    public float y;
    public float z;
    public MyVector(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}
