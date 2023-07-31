using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insideS : MonoBehaviour
{
    

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("object") )
        {
            other.GetComponent<moveObj>().changeToDo(moveObj.ToDo.Finish);
        }
    }
}
