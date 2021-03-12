using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Confirm : MonoBehaviour
{
    public UnityAction unlockConfirm;
    public bool confirming = false;

    private void Start()
    {
        unlockConfirm = Confirmmm;
    }
    public void Confirmmm()
    {
        gameObject.transform.localPosition = new Vector2(0,0);
        confirming = false;
        Debug.Log("ACTION!!!");
    }
    public void YesBuy()
    {
        confirming = true;
        gameObject.transform.localPosition = new Vector2(0, 2300);
    }
    public void NoBuy()
    {
        gameObject.transform.localPosition = new Vector2(0, 2300);
    }
}
