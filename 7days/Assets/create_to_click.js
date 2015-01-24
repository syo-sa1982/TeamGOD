#pragma strict

var drop_box : GameObject;

function Start () {

}

function Update () {

	if( Input.GetMouseButtonDown(0) )
	{
		var pos = get_mouse_vector();
		
		print(pos);
		
		if( pos != null )createBox( pos );
	}
	
}

function createBox( pos : Vector3 )
{
	var obj = Instantiate( 
			drop_box , 
			Vector3( Mathf.FloorToInt( pos.x / 1 + 1.0/2.0 ) * 1 , 8 ,  Mathf.FloorToInt( pos.z / 1 + 1.0/2.0 ) * 1 ) , 
			Quaternion.identity );
}

function get_mouse_vector()
{
	var ray : Ray;
	var hit : RaycastHit;
	
	ray = Camera.main.ScreenPointToRay( Input.mousePosition );
	
	if( Physics.Raycast( ray , hit , 100 ) )
	{
		return hit.point;
	}
	else
	{
		return null;
	}
}