using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caster : Player
{
    public float usingTime = 0.01f;
    public GameObject origin;
    Vector2 originPoint;
    bool skill = false;
    public Vector2 classSpeed = new Vector2(1f, 1f);
    GameObject temp;
    public override void Move(Vector2 inputPosition)
    {
        base.Move(inputPosition * classSpeed);
    }
    public override void QuickDoubleTap()
    {
        originPoint = transform.position;
        skill = true;
        temp = Instantiate(origin);
        temp.transform.position = transform.position;
        GetComponent<AudioSource>().clip = myaudio[0];
        GetComponent<AudioSource>().Play();
    }
    public override void QuickDoubleTapPress()
    {
        if(skill)
        {
            SpreadInk();
        }
    }
    public override void MouseEnd()
    {
        base.MouseEnd();
        if (skill)
        {
            transform.position = originPoint;
            Destroy(temp);
            skill = false;
        }
    }
    public override void InkCharge()
    {
        if(!skill)
            inkCharger.GetComponent<Image>().fillAmount += chargeTime;
    }
    public override void SpreadInk()
    {
        if (inkCharger.GetComponent<Image>().fillAmount != 0f)
            inkCharger.GetComponent<Image>().fillAmount -= usingTime;
        else if (inkCharger.GetComponent<Image>().fillAmount == 0f)
        {
            transform.position = originPoint;
            Destroy(temp);
            skill = false;
        }
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Hook"))
        {
            GetComponent<AudioSource>().clip = myaudio[1];
            GetComponent<AudioSource>().Play();
        } 
    }
}
