using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PauseButton : MonoBehaviour
{
    public AudioSource audio;
    public AudioSource audio2;
    public AudioSource audio3;
    public GameObject darkscreen;
    public Button Pause;
    public GameObject Popup;

    static public bool paused;
    static public bool GO = false;

    void Start()
    {
        paused = false;


    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pause.onClick.Invoke();
        }
    }
    public void TogglePause()
    {
        paused = !paused;
    
        if (paused && !GO && !GameManager.Win)
        {
            if (Popup.activeInHierarchy == false)
            {
                Time.timeScale = 0;
                audio.Pause();
                audio2.Pause();
                //audio3.Pause();
                darkscreen.SetActive(true);
            }
        }
        else if (!paused && !GO && !GameManager.Win)
        {
            if (Popup.activeInHierarchy == false)
            {
                Time.timeScale = 1;
                audio.Play();
                audio2.Play();
                //audio3.Play();
            }

            darkscreen.SetActive(false);
        }
    }
}