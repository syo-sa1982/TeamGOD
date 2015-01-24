using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EffectRange : MonoBehaviour
{
    public GameObject next_box;
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
            if ((gm.transform.position - this.transform.position).magnitude < range)
            {
                gms.Add(gm);
            }

        }
        if (gms.Count >= 3)
        {
            combine(gms);
        }
    }

    public void combine(List<GameObject> gms)
    {
        var mean = new Vector3(0, 0, 0);
        foreach (var gm in gms)
        {
            if (gm != null)
            {
                mean += gm.transform.position / gms.Count;
                Destroy(gm);
                print(gm.name);
            }
            Instantiate(next_box, mean, Quaternion.identity);
            Destroy(this);

        }
    }



}