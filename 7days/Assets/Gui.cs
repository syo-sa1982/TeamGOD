using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gui : MonoBehaviour {

	private Text dayText;
	private DayLabel dayLabel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void combine()
	{
<<<<<<< HEAD

		dayText = GameObject.Find ("CurrentDayLabel/Text").GetComponent<Text> ();
		dayLabel = GameObject.Find ("CurrentDayLabel/Text").GetComponent<DayLabel> ();


		dayLabel.currentDay++;

		Debug.Log (dayLabel.currentDay);

		dayText.text = dayLabel.currentDay + "日目";

		Debug.Log (dayText.text);

		Debug.Log (dayLabel.currentDay);

		foreach( GameObject gm  in GameObject.FindGameObjectsWithTag("block") )
=======
		foreach( GameObject gm in GameObject.FindGameObjectsWithTag("block") )
>>>>>>> 2e7521c0fca0fc08c82f9f5e3b897243b56bcb72
		{
			if( gm.activeSelf )
			{
				gm.GetComponent<EffectRange>().check_run_combine();
			}
		}
		
	}
}
