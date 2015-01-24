#pragma strict

function Start () {

}

function Update () {

}

function OnGUI()
{
	if( GUI.Button( Rect( 10 , 10 , 100 , 50 ) , "Button" ) )
	{
		combine();		
	}
}

function combine()
{
	for( var gm : GameObject in GameObject.FindGameObjectsWithTag("block") )
	{
		if( gm != null )
		{
			gm.GetComponent( effect_range ).check_run_combine();
		}
	}	
	
}