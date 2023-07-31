using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPs : MonoBehaviour
{
    [SerializeField] Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = tr.position;
    }
}
