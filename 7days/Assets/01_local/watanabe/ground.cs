using UnityEngine;
using System.Collections;
using System.Linq;

[System.Serializable]
public class ground : MonoBehaviour {

	//グランドオブジェクト
	public GameObject m_ground_object;
	//おおきさのターゲットとなるオブジェクト
	public GameObject m_target_object;

	//ｙ軸の高さ
	public int height = 10;

	private GameObject[,,] m_ground_gama_object;
	private Vector3? m_ground_start_potision = new Vector3?();
	private Vector3? m_ground_step = new Vector3?();

	public GameObject[,,] get_block_array()
	{
		return m_ground_gama_object;
	}

	// Use this for initialization
	public void Start () {
			
		//起点取得
		m_ground_start_potision = m_ground_object.transform.position - m_ground_object.transform.lossyScale;

		//ステップ幅の取得
		m_ground_step = m_target_object.transform.lossyScale;

		int map_x = (int)((Mathf.Abs (m_ground_start_potision.Value.x) * 2 / m_target_object.transform.lossyScale.x));
		int map_y = height;
		int map_z = (int)((Mathf.Abs (m_ground_start_potision.Value.z) * 2 / m_target_object.transform.lossyScale.z));

		m_ground_gama_object = new GameObject[map_x,map_y,map_z];

	}
	
	// Update is called once per frame
	public void Update () {
	
	}

	//位置からインデックスに終了
	public Vector3? convert_index( Vector3? pos )
	{
		Vector3? index = new Vector3(
			(int)((pos.Value.x - m_ground_start_potision.Value.x) / m_ground_step.Value.x) * m_ground_step.Value.x,
			(int)((pos.Value.y - m_ground_start_potision.Value.y) / m_ground_step.Value.y) * m_ground_step.Value.y,
			(int)((pos.Value.z - m_ground_start_potision.Value.z) / m_ground_step.Value.z) * m_ground_step.Value.z);

		return index;
	}

	//配列の取得
	public void search_ground_object()
	{

		for (int i = 0; i < m_ground_gama_object.GetLength(0); i++)
		{
			for (int j = 0; j < m_ground_gama_object.GetLength(1); j++)
			{
				for (int k = 0; k < m_ground_gama_object.GetLength(2); k++)
				{
					m_ground_gama_object[i,j,k] = null;
				}
			}
		}

		foreach (GameObject go in GameObject.FindGameObjectsWithTag("block")) 
		{
			Vector3? index = convert_index( go.transform.position );

			m_ground_gama_object[(int)index.Value.x,(int)index.Value.y,(int)index.Value.z] = go;
		}
	}
}
