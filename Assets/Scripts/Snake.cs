using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector3 direction;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position);

        Time.timeScale = speed; //0.3倍速


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W");
            direction = Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S");
            direction = Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
            direction = Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D");
            direction = Vector3.right;
        }
    }
    //FixedUpdate 每秒更新50次
    private void FixedUpdate()
    {
        transform.Translate(direction * speed);
    }
}
