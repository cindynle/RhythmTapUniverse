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
    public GameObject winText;
    //public AudioSource winAudio;
    public GameObject missedNote;
    public GameObject failText;
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
    private IEnumerator coroutine;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;

        instance = this;
       scoreText.text = "Score: 0";

        currentMulti = 1;
        multiText.text = "Multiplier: X" + currentMulti;
        failTracker = 0;
        coroutine = waitTwo();

    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if (Input.anyKeyDown) { 
            startPlaying = true;
            theBS.hasStarted = true;
            theMusic.Play();
            distMusic.Play();
            }
        }

       /*if (failTracker == 0)
        {
            theBS.failed = true;

            StartCoroutine(coroutine);
         
        }*/

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

       if ((failTracker < 10) && (timer >= 45))
        {
            Win = true;
            winText.SetActive(true);
            //winAudio.Play();
            theMusic.Stop();
            distMusic.Stop();
        }
        if (startPlaying)
        {
            timer += Time.deltaTime;
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
            multiTracker++;
        if (currentMulti - 1 < multiThresholds.Length)
        {

            if (multiThresholds[currentMulti - 1] <= multiTracker)
            {
                multiTracker = 0;
                currentMulti++;

            }
        }
        currentScore += scorePerNote * currentMulti;
            scoreText.text = "Score: " + currentScore;
            comboText.text = "Combo: " + combo;
            multiText.text = "Multiplier: X" + currentMulti;

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
        multiText.text = "Multiplier: X" + currentMulti;


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
