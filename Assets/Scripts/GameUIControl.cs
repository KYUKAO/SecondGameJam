using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIControl : MonoBehaviour
{
public void Replay()
    {
        SceneManager.LoadScene("Level");
    }
}
