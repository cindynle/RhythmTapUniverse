﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	// Use this for initialization
 public void LoadSceneOnClick(int level)
      { 
         SceneManager.LoadScene(level);
       }
	}
