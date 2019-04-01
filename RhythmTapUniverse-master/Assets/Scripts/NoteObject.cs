using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{

    public bool canBePressed;
    public KeyCode keyToPress;
    public KeyCode keyToPress2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canBePressed) 
        {
            if ((Input.GetKeyDown(keyToPress)) || (Input.GetKeyDown(keyToPress2)))
            {
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();

            }
        }

        if(GameManager.Win == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            GameManager.instance.NoteMissed();
        }
    }
}
