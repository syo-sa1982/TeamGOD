using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour 
{
	public int cubeNumber = 0;

	public GameObject lightPrefab;
	public GameObject cubePrefab;

	private Vector3 prePosition;
	private Quaternion preRotation;

	public void CreateObjects()
	{
		Debug.Log ("Clicked!");

		switch(cubeNumber) {
		case 0:
			prePosition = lightPrefab.transform.position;
			preRotation = lightPrefab.transform.rotation;
			Instantiate (lightPrefab, prePosition, preRotation);

			Destroy (this.gameObject);
			break;
		case 1:
			prePosition = cubePrefab.transform.position;
			preRotation = cubePrefab.transform.rotation;

			cubePrefab.renderer.material.color = Color.blue;

			Instantiate (cubePrefab,prePosition,preRotation);
			break;

		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
