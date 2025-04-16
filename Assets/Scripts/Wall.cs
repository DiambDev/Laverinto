using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IPrototype<Wall>
{
    public Wall Clone()
    {
        return Instantiate(this);
    }
}