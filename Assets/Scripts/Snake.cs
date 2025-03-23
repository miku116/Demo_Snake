using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameUI gameUI; //��ȡ��ϷUI
    Vector3 direction;
    public float speed;
    //����ڵ�Ԥ����
    public Transform bodyPrefab;
    //��List���洢����ĸ����ڵ�
    public List<Transform> bodies = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(transform.position);

        Time.timeScale = speed; //0.3����
        //��ʼ����ͷ
        Resetstage();


    }

    // Update is called once per frame
    void Update()
    {
        // ��ǰ�ƶ�����ķ�����
        Vector3 forbiddenDirection = Vector3.zero;
        if (bodies.Count > 1)
        {
            forbiddenDirection = -direction; // ���㵱ǰ������෴����
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Debug.Log("W");
            if (bodies.Count == 1 || forbiddenDirection != Vector3.up)
                direction = Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Debug.Log("S");
            if (bodies.Count == 1 || forbiddenDirection != Vector3.down)
                direction = Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("A");
            if (bodies.Count == 1 || forbiddenDirection != Vector3.left)
                direction = Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("D");
            if (bodies.Count == 1 || forbiddenDirection != Vector3.right)
                direction = Vector3.right;
        }
    }
    //FixedUpdate ÿ�����50��
    private void FixedUpdate()
    {
        for(int i = bodies.Count-1; i > 0; i--)
        {
            bodies[i].position = bodies[i-1].position;
        }

        transform.Translate(direction);
    }

    //��ײ��⣬����ɫ���������壨tagΪ"Food"�����壩������ײʱ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            //Instantiate(bodyPrefab);
            bodies.Add(Instantiate(bodyPrefab, transform.position, 
                                   Quaternion.identity));
            gameUI.AddScore();
        }
        //����ɫ��ǽ�ڷ�����ײʱ����
        if (collision.CompareTag("Obstacle"))
        {
            //Debug.Log("Game Over");
            Resetstage();
        }
        
    }
    
    void Resetstage()
        {
        direction = Vector3.zero;
        transform.position = Vector3.zero;

        //ɾ������ڵ�,��������ͷ
        for (int i = 1; i < bodies.Count; i++)
        {
            Destroy(bodies[i].gameObject);
        }
        //��������б�
        bodies.Clear();
        //�ٴδ洢�����ͷ
        bodies.Add(transform);

        gameUI.ResetScore();
    }
}
