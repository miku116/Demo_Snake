using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioSource gameAudio;  //获取AudioSource组件
    public AudioSource eatAudio;  //获取吃食物的音效
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetBackgroundMusic()
    {
        gameAudio.Play();
    }
    
    public void PlayEatAudio()
    {
        eatAudio.Play();
    }
}
