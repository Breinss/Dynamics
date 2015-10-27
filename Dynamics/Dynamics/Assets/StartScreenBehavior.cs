using UnityEngine;
using System.Collections;

public class StartScreenBehavior : MonoBehaviour
{

    private GameObject textUi;
    private bool textUiVisible;
	// Use this for initialization
	void Start ()
	{
	    textUiVisible = true;
        textUi = GameObject.Find("Text");
	    Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if (textUiVisible)
	    {
	        if (Input.GetKeyDown(KeyCode.Space))
	        {
	            textUi.active = false;
	            Time.timeScale = 1;
	            textUiVisible = false;
	        }
	    }
	}
}
