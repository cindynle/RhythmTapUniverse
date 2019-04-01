using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkScreen : MonoBehaviour
{
    public Image darkscreen;

    void Start()
    {
        var alphacolor = darkscreen.color;
        alphacolor.a = 0.5f;
        darkscreen.color = alphacolor;
    }
}
