using UnityEngine;
using System.Collections;

public class CreateToClick : MonoBehaviour {

	public GameObject drop_box;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = get_mouse_vector();
			if (pos != null)
			{
				print(pos);
				createBox(pos);
			}
        }

	}
    private void createBox(Vector3? pos)
    {
		float x = (pos.Value.x / 1.0f + 1.0f / 2.0f) * 1.0f;
		float z = (pos.Value.z / 1.0f + 1.0f / 2.0f) * 1.0f;
        var obj = Instantiate(
                drop_box,
                new Vector3(x, 8.0f, z),
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
