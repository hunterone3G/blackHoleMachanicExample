using UnityEngine;

public class textSc : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float x = 0;
    [SerializeField]
    float speed = 0.5f;
    [SerializeField]
    float speedN = 1f;
    private GameObject player;
    TextMesh textMesh;
    private void Awake()
    {
        player = GameObject.FindWithTag("textP");
        textMesh = GetComponent<TextMesh>();

    }


    void Update()
    {
        if (textMesh.color.a == 0)
        {
            Destroy(gameObject);
        }
        Vector3 vector3 = player.transform.position;
        x += Time.deltaTime;
        vector3.z += x;
        transform.position = vector3;
        Color color = textMesh.color;
        color.a = textMesh.color.a - 0.01f;
        textMesh.color = color;

    }

    public void changeText(string t)
    {
        textMesh.text = t;
    }
}
