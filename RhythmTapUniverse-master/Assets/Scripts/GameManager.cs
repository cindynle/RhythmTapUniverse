using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public AudioSource theMusic;
    public AudioSource distMusic;
    public bool startPlaying;

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
        instance = this;
       scoreText.text = "Score: 0";

        currentMulti = 1;
        multiText.text = "Multiplier: X" + currentMulti;
        failTracker = 5;
        coroutine = waitTwo(2.0f);

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

       if (failTracker == 0)
        {
            theBS.failed = true;

            StartCoroutine(coroutine);
         
        }

        if (startPlaying)
        {
            timer += Time.deltaTime;
        }

        

      

    }
    public void NoteHit()
    {
        Debug.Log("Hit On Time");

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
        currentMulti = 1;
        multiTracker = 0;

        combo = 0;
        failTracker--;
        distMusic.volume = 0.75f;
        comboText.text = "Combo: " + combo;
        multiText.text = "Multiplier: X" + currentMulti;


    }

    IEnumerator waitTwo(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        theMusic.Stop();
        distMusic.Stop();

    }
}
