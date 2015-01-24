using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DayLabel : MonoBehaviour 
{
    public int currentDay = 1;
	private Text dayText;

	// Use this for initialization
	void Start () 
    {
		dayText = this.gameObject.GetComponent<Text> ();
		if (currentDay > 0) {
			dayText.text = currentDay + "日目";
		}
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	}
}
