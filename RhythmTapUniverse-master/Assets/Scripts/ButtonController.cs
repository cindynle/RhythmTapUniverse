using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private MeshRenderer theMR;
    public Material defaultImage;
    public Material pressedImage;
    public KeyCode keyToPress;
    public KeyCode keyToPress2;
    // Start is called before the first frame update
    void Start()
    {
        theMR = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(keyToPress))||(Input.GetKeyDown(keyToPress2)))
        { theMR.material = pressedImage; }

        if ((Input.GetKeyUp(keyToPress)) || (Input.GetKeyUp(keyToPress2)))
        { theMR.material = defaultImage; }
    }
}
