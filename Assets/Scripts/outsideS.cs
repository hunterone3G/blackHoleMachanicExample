using UnityEngine;

public class outsideS : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("object") )
        {
            other.GetComponent<moveObj>().changeToDo(moveObj.ToDo.Run);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("object"))
        {
            other.GetComponent<moveObj>().changeToDo(moveObj.ToDo.Stay);
        }
    }
}
