using UnityEngine;
using System.Collections;

public class CreateEffect : MonoBehaviour {

	bool createEffectFlag = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (createEffectFlag == false) {
			if (Physics.Raycast (this.transform.position, Vector3.down, 0.7f)) {
				Instantiate (Resources.Load ("Prefabs/Effects/CreateEffect"), this.transform.position, this.transform.rotation);
				createEffectFlag = true;
			}
		}
	}

}
