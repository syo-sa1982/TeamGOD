using UnityEngine;
using System.Collections;

public class CreateToClick : MonoBehaviour {

	private Vector3? convert_position( Vector3? pos )
	{
		float x = Mathf.FloorToInt(pos.Value.x / 1.0f + 1.0f / 2.0f) * 1.0f;
		float y = Mathf.FloorToInt(pos.Value.y / 1.0f + 1.0f / 2.0f) * 1.0f;
		float z = Mathf.FloorToInt(pos.Value.z / 1.0f + 1.0f / 2.0f) * 1.0f;

		return new Vector3 ( x , y , z );
	}

	private GameObject cursor;

	public GameObject drop_box;
	// Use this for initialization
	void Start () {

		cursor = GameObject.Find ("cursor");
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
			if (pos != null)
			{
				createBox(pos);
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
    }

}
