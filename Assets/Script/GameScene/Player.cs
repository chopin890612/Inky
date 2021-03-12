using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip[] myaudio;
    public GameObject ink;
    Touch touch;
    GameObject player;
    public bool inked = false;
    public GameObject inkCharger;
    public float chargeTime = 0.1f;
    Vector3 inputPosition;
    public float quickTapTime = 0.15f;
    public float quickTapPressTime = 0.3f;
    float beginTime;
    bool doubleTap = false;


    private void Start()
    {
        inkCharger = GameObject.Find("InkCharge");
        Input.multiTouchEnabled = false;
        player = gameObject;
        //data.Inital();
    }
    void Update()
    {
        #region Input
        if (GameController.gaming)
        {

            /*#region Touch Input
            if (Input.touchCount > 0)   
            {
                touch = Input.GetTouch(0);

                if(touch.phase == TouchPhase.Began)     //按下
                {
                    TouchBegin();
                }                    
                if(touch.phase == TouchPhase.Moved)     //按著
                {
                    TouchPress();
                }                   
            }
            else if (touch.phase == TouchPhase.Ended)   //放開
            {
                TouchEnd();               
            }
            #endregion*/

            #region MouseInput
            if (Input.GetMouseButtonDown(0))    //按下
            {
                MouseBegin();
            }
            else if (Input.GetMouseButton(0))   //按著
            {
                MousePress();
            }
            else if (Input.GetMouseButtonUp(0)) //放開
            {
                MouseEnd();
            }
            #endregion

        }
        #endregion

        InkCharge();
    }

    public virtual void Move(Vector2 inputPosition)
    {
        //player.transform.Translate(inputPosition * Time.deltaTime * 120);
        player.GetComponent<Rigidbody2D>().velocity = inputPosition * new Vector2(60f,60f) * GameManager.data.speedScale;
    }


    public virtual void QuickDoubleTap()
    {
        //Debug.Log("QuickTap!!!");
    }
    public virtual void QuickDoubleTapPress()
    {
        //Debug.Log("QuickTapPress!!!!!!!!");
    }


    public virtual void TouchBegin()
    {
        if (Time.time - beginTime < quickTapTime)
        {
            doubleTap = true;
            QuickDoubleTap();
        }
        beginTime = Time.time;
    }
    public virtual void TouchPress()
    {
        if (doubleTap)
        {
            if (Time.time - beginTime > quickTapPressTime)
            {
                QuickDoubleTapPress();
            }
        }

        Move(touch.deltaPosition.normalized * new Vector2(1/60f,1/60f));
    }
    public virtual void TouchEnd()
    {
        if (doubleTap)
            doubleTap = false;

        Move(Vector2.zero);
        GetComponent<Animator>().Play("Idle");
    }
    public virtual void MouseBegin()
    {
        if (Time.time - beginTime < quickTapTime)
        {
            doubleTap = true;
            QuickDoubleTap();
        }

        beginTime = Time.time;
        inputPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public virtual void MousePress()
    {
        if (doubleTap)
        {
            if (Time.time - beginTime > quickTapPressTime)
            {
                QuickDoubleTapPress();
            }
        }

        Move(Camera.main.ScreenToWorldPoint(Input.mousePosition) - inputPosition);
        inputPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public virtual void MouseEnd()
    {
        if (doubleTap)
            doubleTap = false;

        Move(Vector2.zero);
        GetComponent<Animator>().Play("Idle");
    }


    public virtual void SpreadInk()
    {
        GameObject temp = Instantiate(ink);
        temp.transform.position = player.transform.position;
        inkCharger.GetComponent<Image>().fillAmount = 0;
        inked = true;
    }
    public virtual void InkCharge()
    {
        if (inked)
        {
            inkCharger.GetComponent<Image>().fillAmount += chargeTime;
            if (inkCharger.GetComponent<Image>().fillAmount == 1)
                inked = false;
        }
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hook") && !inked)
            SpreadInk();
        else if(collision.gameObject.CompareTag("Hook"))
        {
            GetComponent<AudioSource>().clip = myaudio[1];
            GetComponent<AudioSource>().Play();
        } 
        if (collision.gameObject.CompareTag("Ink"))
        {
            player.GetComponent<CapsuleCollider2D>().enabled = false;
            Invoke("ColliderOn", 1f);
            GetComponent<AudioSource>().clip = myaudio[0];
            GetComponent<AudioSource>().Play();
        }
    }
    void ColliderOn()
    {
        player.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}