using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PauseButton : MonoBehaviour
{
    public AudioSource audio;
    public AudioSource audio2;
    public AudioSource audio3;

    public bool paused;
    void Start()
    {
        paused = false;
    


    }

    void Update ()
    {
       
    }
    public void TogglePause()
    {
        paused = !paused;
    
        if (paused)
        {
            Time.timeScale = 0;
            audio.Pause();
            audio2.Pause();
            audio3.Pause();


        }
        else if (!paused)
        {
            Time.timeScale = 1;
        audio.Play();
            audio2.Play();
            audio3.Play();

        }
    }
}