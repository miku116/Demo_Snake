using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioSource gameAudio;  //��ȡAudioSource���
    public AudioSource eatAudio;  //��ȡ��ʳ�����Ч
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
