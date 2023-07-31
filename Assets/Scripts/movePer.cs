using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

public class movePer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private FloatingJoystick joystick;
    [SerializeField]
    float speed = 2f;
    public delegate void MoveDelegate();
    public MoveDelegate moveDelegate;
    private Vector3 moveVector;
    int pointCount = 0;
    public int size = 1;
    [SerializeField]
    GameObject te;
    [SerializeField]
    GameObject totalT;

    [SerializeField]
    GameObject button1;
    [SerializeField]
    GameObject button2;
    [SerializeField]
    GameObject joy;


    void Awake()
    {
        moveDelegate = move;
    }

    // Update is called once per frame
    void Update()
    {
        moveDelegate();
    }

    public void move()
    {
        moveVector = Vector3.zero;
        moveVector.x = joystick.Horizontal * speed* Time.deltaTime;
        moveVector.z = joystick.Vertical * speed* Time.deltaTime;
        

        if(joystick.Horizontal != 0|| joystick.Vertical != 0)
        {
            transform.position += moveVector;
        }
    }

    public void idle()
    {

    }

    public void startTheGame()
    {
        
        button1.SetActive(false);
        joy.SetActive(true);

    }

    public void restart()
    {
        joy.SetActive(true);
        button2.SetActive(false);
        size = 1;
        pointCount = 0;
        Vector3 targetScale = transform.localScale / (1.15f* 1.15f*1.15f);
        transform.localScale = targetScale;
        totalT.GetComponent<Text>().text = pointCount.ToString();
    }
    public void addPoints(int points)
    {
        
        pointCount+=points;
        totalT.GetComponent<Text>().text = pointCount.ToString();
        GameObject test = te;
        test.GetComponent<TextMesh>().text = points.ToString();
        Instantiate(test, Vector3.zero, Quaternion.identity);
        
        if(pointCount >=20&& pointCount < 50&& size ==1)
        {
            changeSize();
        }
        else if(pointCount >= 50 && pointCount < 100 && size == 2)
        {
            changeSize();
        }
        else if (pointCount >= 100 && pointCount < 200 && size == 3)
        {
            changeSize();
        }
        else if (pointCount >= 200)
        {
            win();
        }
    }

    public void changeSize()
    {
        size++;
        StartCoroutine(courChangeSize());
    }

    public void checkPos()
    {
        if (transform.position.x > 105)
        {
            Vector3 t = transform.position;
            t.x = -100;
            transform.position = t;
        }
        else if(transform.position.x < 100)
        {
            Vector3 t = transform.position;
            t.x = 105;
            transform.position = t;
        }
        else if (transform.position.z >90 )
        {
            Vector3 t = transform.position;
            t.z = -114;
            transform.position = t;
        }
        else if (transform.position.z < -114)
        {
            Vector3 t = transform.position;
            t.z = 90;
            transform.position = t;
        }
    }

    IEnumerator courChangeSize()
    {
        Vector3 targetScale = transform.localScale * 1.15f; 
        Vector3 tt = transform.localScale;
        float timePassed = 0f; 
        float duration = 2f; 

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;

            transform.localScale = Vector3.Lerp(tt, targetScale, timePassed / duration);

            yield return null;
        }

        
        transform.localScale = targetScale;
    }
    public void win()
    {
        button2.SetActive(true);
        joy.SetActive(false);
    }



}
