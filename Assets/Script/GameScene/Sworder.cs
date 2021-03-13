using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sworder : Player
{
    public Vector2 classSpeed = new Vector2(0.8f, 1.3f);
    public override void Move(Vector2 inputPosition)
    {
        base.Move(inputPosition * classSpeed);
    }
}
