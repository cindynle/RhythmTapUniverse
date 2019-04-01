using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PauseButton : MonoBehaviour
{
    public AudioSource audio;
    public AudioSource audio2;
    public AudioSource audio3;
    public GameObject darkscreen;

    static public bool paused;
    static public bool GO = false;

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
    
        if (paused && !GO && !GameManager.Win)
        {
            Time.timeScale = 0;
            audio.Pause();
            audio2.Pause();
            //audio3.Pause();
            darkscreen.SetActive(true);


        }
        else if (!paused && !GO && !GameManager.Win)
        {
            Time.timeScale = 1;
            audio.Play();
            audio2.Play();
            //audio3.Play();
            darkscreen.SetActive(false);
        }
    }
}