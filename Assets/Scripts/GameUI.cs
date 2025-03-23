using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    int score = 0; // 记录分数

    public TMP_Text scoreText; // 记录分数的文本框
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString(); // 显示初始分数
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScore() // 重置分数
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void AddScore() // 增加分数
    {
        score++;
        scoreText.text = score.ToString();
    }
}
