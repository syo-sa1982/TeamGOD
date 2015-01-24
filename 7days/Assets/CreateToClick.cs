using UnityEngine;
using System.Collections;

public class CreateToClick : MonoBehaviour {

    private GameObject cursor;

    public GameObject drop_box;

	private GameRoot gameRoot;

	public static Vector3? convert_position( Vector3? pos )
	{
		float x = Mathf.FloorToInt(pos.Value.x / 1.0f + 1.0f / 2.0f) * 1.0f;
		float y = Mathf.FloorToInt(pos.Value.y / 1.0f + 1.0f / 2.0f) * 1.0f;
		float z = Mathf.FloorToInt(pos.Value.z / 1.0f + 1.0f / 2.0f) * 1.0f;

		return new Vector3 ( x , y , z );
	}


	// Use this for initialization
	void Start () {

		cursor = GameObject.Find ("cursor");
		gameRoot = GameObject.Find ("GameRoot").GetComponent<GameRoot> ();
	}
	
	// Update is called once per frame
	void Update () {

		var pos = get_mouse_vector();
		GameObject obj = cursor;

		if( obj != null )
		{
			if( pos != null )
			{	
				obj.SetActive(true);

				obj.transform.position = convert_position( pos ).Value + new Vector3(0,-1.5f,0);
			}
			else
			{
				obj.SetActive(false);
			}
		}

		if (Input.GetMouseButtonDown(0))
        {
			if (pos != null && !gameRoot.isMaxBlock)
			{
				createBox(pos);
			}
        }
		if (Input.GetMouseButtonDown (1))
		{
			if (pos != null)
			{
				deleteBox(pos);
			}
		}
	}
    private void createBox(Vector3? pos)
    {
		Vector3? cp = convert_position( pos );
		
        var obj = Instantiate(
                drop_box,
                new Vector3(cp.Value.x, 8.0f, cp.Value.z),
                Quaternion.identity);
    }
	private void deleteBox(Vector3? pos)
	{
		Vector3? cp = convert_position( pos );
		RaycastHit hitInfo;
		if(Physics.Linecast(new Vector3(cp.Value.x, 100.0f, cp.Value.z), cp.Value, out hitInfo) && (hitInfo.transform.tag == "block"))
		{
			Destroy(hitInfo.transform.gameObject);
		}
	}

    private Vector3? get_mouse_vector()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            return hit.point;
        }
        else
        {
            return null;
        }

    }

    public void setDropBox(int boxId)
    {
        Debug.Log (boxId);

        switch (boxId) {
        case 1:
            drop_box = (GameObject)Resources.Load ("Prefabs/block_red");
            break;
        case 2:
            drop_box = (GameObject)Resources.Load ("Prefabs/block_white");
            break;
        case 3:
            drop_box = (GameObject)Resources.Load ("Prefabs/block_bule");
            break;
        case 4:
            drop_box = (GameObject)Resources.Load ("Prefabs/block_green");
            break;
        case 5:
            drop_box = (GameObject)Resources.Load ("Prefabs/block_brown");
            break;
        }
    }

}
