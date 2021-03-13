using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shielder : Player
{
    public Vector2 classSpeed = new Vector2(0.5f, 0.3f);
    public override void Move(Vector2 inputPosition)
    {
        base.Move(inputPosition * classSpeed);
    }
}
