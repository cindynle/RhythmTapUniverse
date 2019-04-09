using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteLines : MonoBehaviour
{
    public ParticleSystem HitParticleR;
    public ParticleSystem HitParticleG;
    public ParticleSystem HitParticleB;
    public ParticleSystem HitParticleY;

    void Update()
    {
        if(GameManager.Hit == true && Input.GetKeyDown(KeyCode.LeftArrow) || GameManager.Hit == true && Input.GetKeyDown(KeyCode.A))
        {
            HitParticleR.Play();
        }
        if (GameManager.Hit == true && Input.GetKeyDown(KeyCode.UpArrow) || GameManager.Hit == true && Input.GetKeyDown(KeyCode.W))
        {
            HitParticleG.Play();
        }
        if (GameManager.Hit == true && Input.GetKeyDown(KeyCode.DownArrow) || GameManager.Hit == true && Input.GetKeyDown(KeyCode.S))
        {
            HitParticleB.Play();
        }
        if (GameManager.Hit == true && Input.GetKeyDown(KeyCode.RightArrow) || GameManager.Hit == true && Input.GetKeyDown(KeyCode.D))
        {
            HitParticleY.Play();
        }
    }
}
