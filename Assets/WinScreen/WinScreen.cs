using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("MainMenu2");
    }
}
