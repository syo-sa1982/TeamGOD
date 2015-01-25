using System.Linq;
using Check3D;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gui : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject next_box;

    
    private string[, ,] PatternRiver = new string[2, 1, 1]
    {
        {
            { "block" },
        },
        {
            { "block" },
        }
    };
    private string[, ,] PatternTree = new string[1, 1, 2]
    {
        {
            { "block", "block" },
        },
    };
    private string[, ,] PatternSea = new string[3, 3, 1]
    {
        {
            { "block" },{ "block" },{ "block" }
        },
        {
            { "block" },{ "block" },{ "block" }
        },
        {
            { "block" },{ "block" },{ "block" }
        },
    };

    public class PatternData
    {
        public string[, ,] PaternArray;
        public bool OneCheck;
        public int x, y, z;
    }





    public class AfterData
    {
        public string name;
        public Vector3 position;
    }


    public void combine()
	{
        //foreach( GameObject gm  in GameObject.FindGameObjectsWithTag("block") )
        //{
        //    if( gm != null )
        //    {
        //        gm.GetComponent<EffectRange>().check_run_combine();
        //    }
        //}	
	    RubicCube rc = new RubicCube();

        var gm = GameObject.Find("flor");
        if (gm != null)
        {
            gm.GetComponent<ground>().search_ground_object();
            var groundArray = gm.GetComponent<ground>().get_block_array();
            var groundList = rc.GetListFromArray3(groundArray);



            //stringではなくて、位置情報なども必要なので、クラスで。
            //縦にブロック２つで木1本なのでそういう処理が必要。多分一番下。
            var groundList2 = new List<AfterData>();
            for (int i = 0; i < 40*40*10; i++)
            {
                AfterData after = new AfterData();
                after.name = "";
                groundList2.Add(after);
            }

            PatternData tree = new PatternData();
            tree.PaternArray = PatternTree;
            tree.OneCheck = true;
            tree.x = 1;
            tree.y = 1;
            tree.z = 2;

            //kawa rc.ChangeRubicCubePattern(groundList, 40, 40, 10, groundList2, 40, 40, 10, PatternRiver, 2, 1, 1);
            rc.ChangeRubicCubePattern(groundList, 40, 40, 10, groundList2, 40, 40, 10, tree);

            //削除
            for (int i = 0; i < groundList.Count; i++)
            {
                if (groundList[i] != null)
                {
                    Destroy(groundList[i]);
                }
            }
            //作成
            for (int i = 0; i < groundList2.Count; i++)
            {
                if (groundList2[i].name != "")
                {
                    Instantiate(next_box, groundList2[i].position, Quaternion.identity);
                }
            }
        }




	}
}
