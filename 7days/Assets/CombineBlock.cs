using UnityEngine;
using System.Collections;

public class CombineBlock : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get_effect_search();
    }
    private void get_effect_search()
    {
        var games = GameObject.FindGameObjectsWithTag("EffectRange");
        foreach (var game in games)
        {
            if (game != null)
            {
                print(game);
                print(game.GetComponent<EffectRange>().get_effect_count());
            }
        }
    }
}
