using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTransperency : MonoBehaviour
{
    public Material NoteLine1;
    public Material NoteLine2;
    public Material NoteLine3;
    public Material NoteLine4;
    float alpha1 = 0.1f;
    float alpha2 = 0.1f;
    float alpha3 = 0.1f;
    float alpha4 = 0.1f;

    public void Update()
    {
        NoteLine1.color = new Color(1, 0, 0, alpha1);
        NoteLine2.color = new Color(0, 0.25f, 1, alpha2);
        NoteLine3.color = new Color(0.15f, 1, 0.15f, alpha3);
        NoteLine4.color = new Color(1, 1, 0, alpha4);

        if (GameManager.Hit == true && Input.GetKeyDown(KeyCode.LeftArrow) || GameManager.Hit == true && Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(LineHit(alpha1));
        }
        if (GameManager.Hit == true && Input.GetKeyDown(KeyCode.UpArrow) || GameManager.Hit == true && Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(LineHit(alpha2));
        }
        if (GameManager.Hit == true && Input.GetKeyDown(KeyCode.DownArrow) || GameManager.Hit == true && Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(LineHit(alpha3));
        }
        if (GameManager.Hit == true && Input.GetKeyDown(KeyCode.RightArrow) || GameManager.Hit == true && Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(LineHit(alpha4));
        }
    }

    IEnumerator LineHit(float alphaIE)
    {
        /*while (alphaIE < 0.6f)
        {
            alphaIE += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }

        while (alphaIE > 0.1f)
        {
            alphaIE -= 0.1f;
            yield return new WaitForSeconds(0.075f);
        }*/
        alphaIE = 1;
        yield return new WaitForSeconds(0.5f);
        alphaIE = 0;
    }
}
