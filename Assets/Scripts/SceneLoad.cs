using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void OnClick()
	{
		 SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
