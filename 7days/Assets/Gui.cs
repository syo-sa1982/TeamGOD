using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if( GUI.Button( new Rect( 10 , 10 , 100 , 50 ) , "Button" ) )
		{
			combine();		
		}
	}


	void combine()
	{
		foreach( GameObject gm  in GameObject.FindGameObjectsWithTag("block") )
		{
			if( gm != null )
			{
				gm.GetComponent<EffectRange>().check_run_combine();
			}
		}	
		
	}}
