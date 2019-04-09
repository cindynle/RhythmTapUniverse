using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public ParticleSystem HitParticleR;
    public ParticleSystem HitParticleG;
    public ParticleSystem HitParticleB;
    public ParticleSystem HitParticleY;

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
                if (this.name.Substring(0,1) == "L" )
                {
                    HitParticleR.Play();
                }else if (this.name.Substring(0, 1) == "U")
                {
                    HitParticleG.Play();
                }
                else if (this.name.Substring(0, 1) == "D")
                {
                    HitParticleB.Play();
                }
                else if (this.name.Substring(0, 1) == "R")
                {
                    HitParticleY.Play();
                }

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
