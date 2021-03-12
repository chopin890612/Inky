using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookLine : MonoBehaviour
{
    LineRenderer line;
    Vector3 start,end;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        start = GameObject.Find("Hook").transform.position;
        line.SetPosition(0, start);
        end = transform.position;
        line.SetPosition(1, end);

    }

    // Update is called once per frame
    void Update()
    {
        end = transform.position;
        line.SetPosition(1, end);
    }
}
