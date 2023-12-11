using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_player : MonoBehaviour
{

    public AudioClip[] Music = new AudioClip[4];
    public AudioSource AS;

    private void Awake()
    {
        AS = this.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (AS.isPlaying == false)
        {
            RandomPlay();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) // MŰ�� �ٽ� ���� �� ��� �׽�Ʈ��
        {
            AS.clip = Music[Random.Range(0, Music.Length)];
            AS.Play();
        }

        if (AS.isPlaying == false)
        {
            RandomPlay();
        }
            
    }

    void RandomPlay()
    {
        AS.clip = Music[Random.Range(0, Music.Length)];
        AS.Play();
    }
}
