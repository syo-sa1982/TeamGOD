using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void combine()
	{
		foreach( GameObject gm in GameObject.FindGameObjectsWithTag("block") )
		{
			if( gm.activeSelf )
			{
				gm.GetComponent<EffectRange>().check_run_combine();
			}
		}	
		
	}}
