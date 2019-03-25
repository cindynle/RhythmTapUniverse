using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float beatTempo;
    public bool failed;

    public bool hasStarted;
    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown) { 
            hasStarted = true;
            }

        }
        else if (hasStarted)

        {
            transform.position -= new Vector3(0f, .0073f, beatTempo * Time.deltaTime);
        } 
    
        if (failed)
        {
            gameObject.SetActive(false);
        }

    }
}
