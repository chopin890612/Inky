using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ink : MonoBehaviour
{
    public float keepTime = 3f;
    void Start()
    {
        Destroy(gameObject, keepTime);
    }
}
