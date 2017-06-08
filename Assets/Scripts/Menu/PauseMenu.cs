using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public Transform canvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {		
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}

	public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
			Cursor.lockState = CursorLockMode.None;
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
		{
			Cursor.lockState = CursorLockMode.Locked;
            canvas.gameObject.SetActive(false);
			Time.timeScale = 1;
        }
    }
}
