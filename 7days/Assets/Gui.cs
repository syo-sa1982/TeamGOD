using System.Linq;
using Assets.moririring;
using Check3D;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Assets;

public class Gui : MonoBehaviour {

	private Text dayText;
	private DayLabel dayLabel;

    public GameObject TreeGameObject;
    public GameObject SeaGameObject;
    public GameObject RiverGameObject;
    public GameObject GreenGameObject;
    public GameObject HouseGameObject;
    public GameObject CasleGameObject;
    public GameObject MoutenGameObject;
   
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public class AfterData
    {
        public string name;
        public Vector3 position;
    }


    public void combine()
	{
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
            foreach (var patternData in PatternDataRom.PatternDatas)
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
                
                rc.ChangeRubicCubePattern(groundList, 40, 40, 10, groundList2, patternData);
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
	}
}
