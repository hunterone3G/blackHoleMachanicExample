using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    List<GameObject> spawnList = new List<GameObject>();
    int obCount = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(obCount < 300)
        {
            int r = Random.Range(0, spawnList.Count);
            Vector3 pos = new Vector3(Random.Range(-98, 103), 2, Random.Range(-112, 88));
            Instantiate(spawnList[r], pos, Quaternion.identity);
            obCount++;
        }
    }
}
