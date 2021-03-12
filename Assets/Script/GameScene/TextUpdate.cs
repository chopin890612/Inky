using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = gameObject.GetComponent<Slider>().value.ToString();
    }
}
