#pragma strict

var next_box : GameObject;
var range : float;

private var effect_count = 2.0;

function get_effect_count()
{
	return effect_count;
}

function Start () {

}

function Update () {
}

function check_run_combine()
{
	var gms = new Array();
	
	for( var gm : GameObject in GameObject.FindGameObjectsWithTag("block") )
	{
		if( ( gm.transform.position - this.transform.position ).magnitude < range )
		{
			gms.Add(gm);
		}
	}
	
	if( gms.length >= 3 )
	{
		combine(gms);
	}
}

function combine( gms : Array )
{
	var mean : Vector3 = new Vector3(0,0,0);
	
	for( var gm : GameObject in gms )
	{
		if(gm != null)
		{
			mean += gm.transform.position / gms.length;
			Destroy( gm );
			
			print ( gm.name );
		}
	}
	
	Instantiate( next_box , mean , Quaternion.identity );

	Destroy(this);
}		
