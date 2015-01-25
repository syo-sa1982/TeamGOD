using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using UnityEngine.UI;

public class EffectRange : MonoBehaviour
{
	public GameObject next_box1;
	public GameObject next_box3;
	public GameObject next_box6;
	public GameObject next_box9;

	public GameObject next_box_other_1_target;
	public GameObject next_box_other_1;
	public int next_box_other_1_count;
	public float next_box_other_1_range = 4.0f;

	public float range;
    private float effect_count = 2.0f;

	private Text scoreText;
	private GameRoot gameRoot;


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
			if( gm.activeSelf && gm.name == this.name )
			{
	            if ((gm.transform.position - this.transform.position).magnitude < range)
	            {
	                gms.Add(gm);
	            }
			}
        }

		if (combine_use_count_tag (next_box_other_1_target, next_box_other_1, next_box_other_1_count, next_box_other_1_range))return;
		if (combine_use_count (gms, next_box9, 9))return; 
		if (combine_use_count (gms, next_box6, 6))return; 
		if (combine_use_count (gms, next_box3, 3))return; 
		if (combine_use_count (gms, next_box1, 1))return; 
	}

	public bool combine_use_count( List<GameObject> gms , GameObject next , int count )
	{
		if (gms.Count >= count)
		{
			if( next != null )
			{
				List<GameObject> gmsn = new List<GameObject>();
				for( int i = 0; i < count ; i++ )
				{
					gmsn.Add( gms[i] );
				}
				combine(gmsn,next);

				return true;
			}
		}
		return false;
	}

	public bool combine_use_count_tag( GameObject tag , GameObject next , int count , float s_range )
	{
		if (next != null && tag != null) 
		{
			GameObject[] tag_gms = GameObject.FindGameObjectsWithTag (tag.tag);

			List<GameObject> gms = new List<GameObject> ();

			foreach (GameObject gm in tag_gms) {
					if (gm.activeSelf) {
							if ((gm.transform.position - this.transform.position).magnitude < s_range) {
									gms.Add (gm);
							}
					}
			}

			return combine_use_count (gms, next, count);
		}

		return false;
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
		Debug.Log (next.GetComponent<ScoreManager>().Score);


		gameRoot = GameObject.Find ("GameRoot").GetComponent<GameRoot> ();
		scoreText = GameObject.Find ("ScoreArea/Score").GetComponent<Text> ();

		// 総合得点
		gameRoot.totalScore += next.GetComponent<ScoreManager> ().Score;

		Debug.Log (gameRoot.totalScore);

		scoreText.text = gameRoot.totalScore.ToString();


		Instantiate(next, CreateToClick.convert_position(mean).Value, next.transform.rotation);
		Instantiate(Resources.Load("Prefabs/Effects/CombineEffect"), this.transform.position, this.transform.rotation);

		Destroy(this.gameObject);
		this.gameObject.SetActive(false);

	}



}