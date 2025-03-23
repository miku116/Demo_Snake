using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    int score = 0; // ��¼����

    public TMP_Text scoreText; // ��¼�������ı���
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString(); // ��ʾ��ʼ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScore() // ���÷���
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void AddScore() // ���ӷ���
    {
        score++;
        scoreText.text = score.ToString();
    }
}
