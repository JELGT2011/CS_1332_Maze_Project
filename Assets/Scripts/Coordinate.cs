using UnityEngine;
using System;
using System.Collections;

public class Coordinate : ScriptableObject
{

    public int x;

    public int y;

    public Coordinate(int x, int y)
    {
        this.y = y;
        this.x = x;
    }
}

