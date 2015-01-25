using System.Linq;
using Check3D;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Gui : MonoBehaviour {

	private Text dayText;
	private DayLabel dayLabel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject next_box;
    public GameObject TreeGameObject;
    public GameObject SeaGameObject;
    public GameObject RiverGameObject;
    public GameObject GreenGameObject;
    public GameObject HouseGameObject;
    public GameObject CasleGameObject;
    public GameObject MoutenGameObject;

    
    static readonly private string[, ,] PatternRiver = new string[2, 1, 1]
    {
        {
            { "block_bule" },
        },
        {
            { "block_bule" },
        }
    };
    static readonly public string[, ,] PatternTree = new string[1, 1, 2]
    {
        {
            { "block_brown", "block_green" },
        },
    };
    static readonly private string[, ,] PatternSea = new string[3, 3, 1]
    {
        {
            { "block_bule" },{ "block_bule" },{ "block_bule" }
        },
        {
            { "block_bule" },{ "block_bule" },{ "block_bule" }
        },
        {
            { "block_bule" },{ "block_bule" },{ "block_bule" }
        },
    };
    static readonly private string[, ,] PatternGreen = new string[2, 2, 1]
    {
        {
            { "block_green" },{ "block_green" }
        },
        {
            { "block_green" },{ "block_green" }
        },
    };

    static readonly private string[, ,] PatternHouse = new string[1, 1, 2]
    {
        {
            { "block_white", "block_red" },
        },
    };

    static readonly private string[, ,] PatternCastle = new string[3, 1, 2]
    {
        {
            { "block_white",  "block_white" },
        },
        {
            { "block_white",  "" },
        },
        {
            { "block_white",  "block_white" },
        }
    };
    static readonly private string[, ,] PatternMoutain = new string[3, 3, 2]
    {
        {
            { "block_brown","" },{ "block_brown","" },{ "block_brown","" }
        },
        {
            { "block_brown","" },{ "block_brown","block_brown" },{ "block_brown","" }
        },
        {
            { "block_brown","" },{ "block_brown","" },{ "block_brown","" }
        },
    };



    public class PatternData
    {
        public string name ;
        public string[, ,] PaternArray;
        public bool OneCheck;
        public int x, y, z;
        public GameObject nextObject;
    }

    public PatternData[] PatternDatas = new []
    {
        new PatternData()
        {
            name = "木",
            PaternArray = PatternTree,
            OneCheck = true,
            x = 1,
            y = 1,
            z = 2,
        },
        new PatternData()
        {
            name = "川",
            PaternArray = PatternRiver,
            OneCheck = false,
            x = 2,
            y = 1,
            z = 1,
        },
        new PatternData()
        {
            name = "海",
            PaternArray = PatternSea,
            OneCheck = true,
            x = 3,
            y = 3,
            z = 1,
        },
        new PatternData()
        {
            name = "草",
            PaternArray = PatternGreen,
            OneCheck = true,
            x = 2,
            y = 2,
            z = 1,
        },
        new PatternData()
        {
            name = "家",
            PaternArray = PatternHouse,
            OneCheck = true,
            x = 1,
            y = 1,
            z = 2,
        },
        new PatternData()
        {
            name = "城",
            PaternArray = PatternCastle,
            OneCheck = true,
            x = 3,
            y = 1,
            z = 2,
        },
        new PatternData()
        {
            name = "山",
            PaternArray = PatternMoutain,
            OneCheck = true,
            x = 3,
            y = 3,
            z = 2,
        },
    };




    public class AfterData
    {
        public string name;
        public Vector3 position;
    }


    public void combine()
	{
/*
*/

		dayText = GameObject.Find ("CurrentDayLabel/Text").GetComponent<Text> ();
		dayLabel = GameObject.Find ("CurrentDayLabel/Text").GetComponent<DayLabel> ();


		dayLabel.currentDay++;

		Debug.Log (dayLabel.currentDay);

		dayText.text = dayLabel.currentDay + "日目";

		Debug.Log (dayText.text);

		Debug.Log (dayLabel.currentDay);



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
            for (int i = 0; i < 40 * 40 * 10; i++)
            {
                AfterData after = new AfterData();
                after.name = "";
                groundList2.Add(after);
            }
            foreach (var patternData in PatternDatas)
            {
                if (patternData.name == "木")
                {
                    patternData.nextObject = TreeGameObject;
                }
                if (patternData.name == "川")
                {
                    patternData.nextObject = RiverGameObject;
                }
                if (patternData.name == "海")
                {
                    patternData.nextObject = SeaGameObject;
                }
                if (patternData.name == "草")
                {
                    patternData.nextObject = GreenGameObject;
                }
                if (patternData.name == "家")
                {
                    patternData.nextObject = HouseGameObject;
                }
                if (patternData.name == "城")
                {
                    patternData.nextObject = CasleGameObject;
                }
                if (patternData.name == "山")
                {
                    patternData.nextObject = MoutenGameObject;
                }
                
                rc.ChangeRubicCubePattern(groundList, 40, 40, 10, groundList2, 40, 40, 10, patternData);
                //作成
                for (int i = 0; i < groundList2.Count; i++)
                {
                    if (groundList2[i].name != "")
                    {
                        Instantiate(patternData.nextObject, groundList2[i].position, Quaternion.identity);
                    }
                }
                for (int i = 0; i < 40 * 40 * 10; i++)
                {
                    groundList2[i].name = "";
                }
            }
            //削除
            for (int i = 0; i < groundList.Count; i++)
            {
                if (groundList[i] != null)
                {
                    Destroy(groundList[i]);
                }
            }
        }


        //foreach( GameObject gm in GameObject.FindGameObjectsWithTag("block") )
        //{
        //    if( gm.activeSelf )
        //    {
        //        gm.GetComponent<EffectRange>().check_run_combine();
        //    }
        //}	
        //foreach (GameObject gm in GameObject.FindGameObjectsWithTag("block")) 
        //{
        //    Destroy(gm);
        //}
		
	}
}
