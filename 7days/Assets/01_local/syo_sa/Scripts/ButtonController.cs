using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour 
{
	public GameObject blockPrefab;

	public void SendBlockPrefab()
	{
		Debug.Log ("Clicked!");
		Debug.Log (blockPrefab);


	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
