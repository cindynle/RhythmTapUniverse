﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Image Instructions;
    public AudioSource theMusic;
    public AudioSource distMusic;
    public AudioSource NoteMiss;
    public AudioSource Gomusic;
    //public AudioSource Combo1;
    //public AudioSource Combo2;
    //public AudioSource Combo3;
    public GameObject winText;
    //public AudioSource winAudio;
    public GameObject missedNote;
    public GameObject failText;
    public ParticleSystem Loops;
    public ParticleSystem Glow;
    public bool startPlaying;
    static public bool Win = false;
    static public bool Hit = false;

    public BeatScroller theBS;
    public static GameManager instance;
    public int currentScore;
    public int scorePerNote = 100;
    public int currentMulti;
    public int combo = 0;
    public int failTracker;
    public int[] multiThresholds;
    public int multiTracker;
    public Text scoreText;
    public Text comboText;
    public Text multiText;
    public float timer;
    public GameObject Popup;
    private IEnumerator coroutine;

    public GameObject indicator1;
    public GameObject indicator2;
    public GameObject indicator3;
    public GameObject indicator4;
    public GameObject indicator5;
    public GameObject indicator6;
    public GameObject indicator7;
    public GameObject indicator8;
    public GameObject indicator9;
    public GameObject indicator10;



    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;

        instance = this;
       scoreText.text = "Score: 0";

        currentMulti = 1;
        multiText.text = "Multi: X" + currentMulti;
        comboText.text = "Combo: 0";
        failTracker = 0;
        coroutine = waitTwo();

    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if (Popup.activeInHierarchy == false) { 
            startPlaying = true;
            theBS.hasStarted = true;
            theMusic.Play();
            distMusic.Play();
            }
        } else
        { if (!theMusic.isPlaying && !winText.activeInHierarchy && Time.timeScale != 0 && Time.time >= 90)
            {
                winText.SetActive(true);
            }

                    }

      

        if (failTracker >= 10)
        {
          
            theBS.failed = true;
            PauseButton.GO = true;
            theMusic.pitch = 0.75f;
            theMusic.volume = 0.35f;
            distMusic.volume = 0.35f;
            if (Gomusic.isPlaying == false)
            {
                Gomusic.Play();
            }
            failText.SetActive(true);
            StartCoroutine("waitTwo");
            startPlaying = false;
        }

        if (failTracker == 1) { 
            indicator1.gameObject.SetActive(false);

    }
     if (failTracker == 2) {
            indicator2.gameObject.SetActive(false);
       
        }
 if (failTracker == 3) {
            indicator3.gameObject.SetActive(false);
       
        }
     if (failTracker == 4){
            indicator4.gameObject.SetActive(false);
       
        }
     if (failTracker == 5){
            indicator5.gameObject.SetActive(false);
       
        }
     if (failTracker == 6){
            indicator6.gameObject.SetActive(false);
       
        }
     if (failTracker == 7){
            indicator7.gameObject.SetActive(false);
       
        }
     if (failTracker == 8){
            indicator8.gameObject.SetActive(false);
       
        }
     if (failTracker == 9){
            indicator9.gameObject.SetActive(false);
       
        }
     if (failTracker == 10){
            indicator10.gameObject.SetActive(false);
       
        }
     
        }






public void NoteHit()
    {
        Debug.Log("Hit On Time");
        missedNote.SetActive(false);
        Hit = true;
        StartCoroutine(HitTimer());

        currentScore += scorePerNote * currentMulti;

            combo++;
            Glow.Play();
            multiTracker++;
        if (currentMulti - 1 < multiThresholds.Length)
        {

            if (multiThresholds[currentMulti - 1] <= multiTracker)
            {
                multiTracker = 0;
                currentMulti++;
                Loops.Play();

                /*if(currentMulti == 2)
                {
                    Combo1.Play();
                }else if(currentMulti == 3)
                {
                    Combo2.Play();
                }else if(currentMulti == 4)
                {
                    Combo3.Play();
                }*/
            }
        }
        currentScore += scorePerNote * currentMulti;
            scoreText.text = "Score: " + currentScore;
            comboText.text = "Combo: " + combo;
            multiText.text = "Multi: X" + currentMulti;
        

        distMusic.volume = 0;
            
        }


    public void NoteMissed()
    {

        Debug.Log("Missed Note");
        NoteMiss.Play();
        currentMulti = 1;
        multiTracker = 0;

        missedNote.SetActive(true);
        Hit = false;
        combo = 0;
        failTracker++;
        distMusic.volume = 0.75f;
        comboText.text = "Combo: " + combo;
        multiText.text = "Multi: X" + currentMulti;


    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    IEnumerator waitTwo()
    {
        yield return new WaitForSeconds(0.85f);
        theMusic.Stop();
        distMusic.Stop();
    }

    IEnumerator HitTimer()
    {
        yield return new WaitForSeconds(0.2f);
        Hit = false;
    }
}
