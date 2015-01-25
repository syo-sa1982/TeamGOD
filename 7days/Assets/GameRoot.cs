using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameRoot : MonoBehaviour {

	public int maxBlockNum = 10;
	private GameObject[] blocks;

	private Text blockText;

	public int totalScore;


	public bool isMaxBlock = false;

	// Use this for initialization
	void Start () {

		blockText = GameObject.Find ("Image/Text").GetComponent<Text> ();

		blockText.text = "あと" + maxBlockNum + "個";

		if (blocks == null) {
			blocks = GameObject.FindGameObjectsWithTag("block");
		}


	}
	
	// Update is called once per frame
	void Update () {

		blocks = GameObject.FindGameObjectsWithTag("block");


		blockText = GameObject.Find ("Image/Text").GetComponent<Text> ();

		blockText.text = "あと" + (maxBlockNum - blocks.Length) + "個";

		if (blocks.Length < maxBlockNum) {
			isMaxBlock = false;
		} else {
			isMaxBlock = true;
		}
	}
}
