using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject Text_GameResult;
    public static GameOver instance;
    private void Awake()
    {
        gameObject.SetActive(false); 
        instance = this;
    }

    public void Show()
    {
        gameObject.SetActive(true);

    }

    public void OnClick_Retry() 
    {
        SceneManager.LoadScene("SampleScene");
    }
}
