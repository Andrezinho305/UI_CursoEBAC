using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomManager : MonoBehaviour
{

    public List<GameObject> objs;
    public GameObject gameObject;

    [NaughtyAttributes.Button]
    void Start()
    {
        SpawnRandom();
    }


    public void SpawnRandom()
    {
        Instantiate(objs.GetRandom());
    }

}
