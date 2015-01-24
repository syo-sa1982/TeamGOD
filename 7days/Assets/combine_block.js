#pragma strict

function Start () {

}

function Update () {

	get_effect_search();

}

function get_effect_search()
{
	var games = GameObject.FindGameObjectsWithTag( "effect_range" );
	
	for( var game in games )
	{
		if( game != null )
		{
			print(game);
			print(game.GetComponent( effect_range ).get_effect_count());
		}
	}	
}