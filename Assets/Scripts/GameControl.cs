﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameControl : MonoBehaviour {

	public static GameControl instance;
	public GameObject gameOverText;
	public Text scoreText;
	public bool gameOver = false;
	public float scrollSpeed = -1.5f;
	private int score = 0;

	// Use this for initialization
	void Awake () 
	{
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if(instance != this)
            //...destroy this one because it is a duplicate.
            Destroy (gameObject);
    }

	
	// Update is called once per frame
	void Update () 
	{
		if (gameOver == true && Input.GetMouseButtonDown (0))
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

	public void BirdScored()
	{
		if (gameOver)
		{
			return;
		}
		score++;
		scoreText.text = "Score " + score.ToString ();
			
	}

	public void BirdDied()
	{
		gameOverText.SetActive (true);
		gameOver = true;
	}
}