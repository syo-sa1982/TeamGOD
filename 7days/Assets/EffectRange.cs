using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EffectRange : MonoBehaviour
{
	public GameObject next_box1;
	public GameObject next_box3;

    public float range;
    private float effect_count = 2.0f;

    public float get_effect_count()
    {
        return effect_count;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void check_run_combine()
    {
        List<GameObject> gms = new List<GameObject>();

        foreach (var gm in GameObject.FindGameObjectsWithTag("block"))
        {
			if( gm.activeSelf )
			{
	            if ((gm.transform.position - this.transform.position).magnitude < range)
	            {
	                gms.Add(gm);
	            }
			}
        }
        if (gms.Count >= 3)
        {
			if( next_box3 != null )
			{
				List<GameObject> gms3 = new List<GameObject>();
				for( int i = 0; i < 3 ; i++ )
				{
					gms3.Add( gms[i] );
				}
	            combine(gms3,next_box3);
			}
        }
		if (gms.Count >= 1)
		{
			if( next_box1 != null )
			{
				List<GameObject> gms1 = new List<GameObject>();
				gms1.Add( gms[0] );

				combine(gms1,next_box1);
			}
		}
	}
	
	public void combine(List<GameObject> gms , GameObject next)
    {
        var mean = new Vector3(0, 0, 0);
        foreach (var gm in gms)
        {
            if (gm != null)
            {
                mean += gm.transform.position / gms.Count;

				Destroy(gm.gameObject);
				gm.SetActive(false);
				print(gm.name);
            }
        }

		Instantiate(next, CreateToClick.convert_position(mean).Value, next.transform.rotation);
		Instantiate(Resources.Load("Prefabs/Effects/CombineEffect"), this.transform.position, this.transform.rotation);

		Destroy(this.gameObject);
		this.gameObject.SetActive(false);

	}



}