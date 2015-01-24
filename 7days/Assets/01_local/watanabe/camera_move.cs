using UnityEngine;
using System.Collections;

public class camera_move : MonoBehaviour {

	public float speed = 2.0f;

	private Vector3 rotation;
	private Quaternion qstart;

	// Use this for initialization
	void Start () {	
		rotation = new Vector3 ();
		qstart = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.rotation = qstart;

		rotation.y += Input.GetAxis( "Vertical" ) * speed;
		rotation.x += Input.GetAxis( "Horizontal" ) * speed;

		if( rotation.y < -10 )rotation.y = -10;
		if( rotation.y > 60 )rotation.y = 60;

		this.transform.Rotate ( new Vector3( 0 , -rotation.x , 0 ) );
		this.transform.Rotate ( new Vector3( rotation.y ,0 , 0 ) );

		print ("" + rotation.y + "," + rotation.x);

	}
}
