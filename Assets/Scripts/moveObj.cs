using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObj : MonoBehaviour
{
    [SerializeField]
    private ToDo currentToDo = ToDo.Stay;
    GameObject player;

    private movePer mp;

    [SerializeReference]
    public int size = 1;
    [SerializeField]
    int points = 10;
    
    [SerializeField]
    float fSpeed = 2f;
    [SerializeField]
    float sSpeed = 3f;
    [SerializeField]
    float persent = 0.99f;

    [SerializeField]
    float maxTime = 30f;
    float time = 0;
    public enum ToDo
    {
        Run,
        Stay,
        Finish,
    }
    public delegate void whatToDo();
    private whatToDo whatToDoFunction;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        mp = player.GetComponent<movePer>();

        whatToDoFunction = nothing;

    }

    // Update is called once per frame
    void Update()
    {
        whatToDoFunction();
    }
    public void changeToDo(ToDo t)
    {
        if(mp.size >= size)
        {
            if (t == ToDo.Stay && currentToDo != ToDo.Finish)
            {
                whatToDoFunction = nothing;
                currentToDo = ToDo.Stay;
            }
            else if (t == ToDo.Run)
            {
                whatToDoFunction = Run;
                currentToDo = ToDo.Run;
            }
            else
            {

                whatToDoFunction = Finish;
                currentToDo = ToDo.Finish;
                GetComponent<BoxCollider>().enabled = false;
                gameObject.layer = LayerMask.NameToLayer("dont");
            }
        }
        

    }
    
    private void nothing()
    {

    }
    private void Run()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        Vector3 nDir = new Vector3(direction.x, 0, direction.z);
        transform.position += nDir * fSpeed * Time.deltaTime;
    }
    private void Finish()
    {
        if (time > maxTime)
        {
            mp.addPoints(points);
            Destroy(gameObject);
        }
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        Vector3 nDir = new Vector3(direction.x, 0, direction.z);
        transform.position += nDir * sSpeed * Time.deltaTime;
        Vector3 currentScale = transform.localScale;
        Vector3 newScale = currentScale * persent;
        transform.localScale = newScale;
        time+=Time.deltaTime;
        
    }
    

}
