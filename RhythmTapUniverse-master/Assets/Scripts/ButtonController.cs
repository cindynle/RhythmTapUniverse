using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private MeshRenderer theMR;
    public Material defaultImage;
    public Material pressedImage;
    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        theMR = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        { theMR.material = pressedImage; }

        if (Input.GetKeyUp(keyToPress))
        { theMR.material = defaultImage; }
    }
}
