using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColor : MonoBehaviour
{
    public enum Color
    {
        Red, Orange, Yellow, Green, Blue, Purple, Pink
    }

    public Color color;

    public Color GetColor
    {
        get => color;
        set => color = value;
    }
}
