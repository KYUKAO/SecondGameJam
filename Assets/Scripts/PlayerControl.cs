using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject WinInterface;
    public GameObject LoseInterface;

    void Start()
    {
        Time.timeScale = 1;   
    }


    void Update()
    {
        
    }
    void Lose()
    {
        Time.timeScale = 0;
        LoseInterface.SetActive(true);
    }
    void Win()
    {
        Time.timeScale = 0;
        WinInterface.SetActive(true);
    }
}
