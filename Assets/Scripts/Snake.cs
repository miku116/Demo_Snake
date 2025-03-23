using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameUI gameUI; //获取游戏UI
    Vector3 direction;
    public float speed;
    //蛇身节点预制体
    public Transform bodyPrefab;
    //用List来存储蛇身的各个节点
    public List<Transform> bodies = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(transform.position);

        Time.timeScale = speed; //0.3倍速
        //初始化蛇头
        Resetstage();


    }

    // Update is called once per frame
    void Update()
    {
        // 当前移动方向的反方向
        Vector3 forbiddenDirection = Vector3.zero;
        if (bodies.Count > 1)
        {
            forbiddenDirection = -direction; // 计算当前方向的相反方向
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
    //FixedUpdate 每秒更新50次
    private void FixedUpdate()
    {
        for(int i = bodies.Count-1; i > 0; i--)
        {
            bodies[i].position = bodies[i-1].position;
        }

        transform.Translate(direction);
    }

    //碰撞检测，当角色与其他物体（tag为"Food"的物体）发生碰撞时触发
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            //Instantiate(bodyPrefab);
            bodies.Add(Instantiate(bodyPrefab, transform.position, 
                                   Quaternion.identity));
            gameUI.AddScore();
        }
        //当角色与墙壁发生碰撞时触发
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

        //删除蛇身节点,但保留蛇头
        for (int i = 1; i < bodies.Count; i++)
        {
            Destroy(bodies[i].gameObject);
        }
        //清空蛇身列表
        bodies.Clear();
        //再次存储添加蛇头
        bodies.Add(transform);

        gameUI.ResetScore();
    }
}
