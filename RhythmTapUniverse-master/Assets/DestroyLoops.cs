using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLoops : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        Destroy(gameObject);
    }
}
