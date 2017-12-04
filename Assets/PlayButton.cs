﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;


public class PlayButton : MonoBehaviour {

	// Use this for initialization
	public void PlayGame()
	{
		EditorSceneManager.LoadScene (EditorSceneManager.GetActiveScene().buildIndex + 1);
	}
}
