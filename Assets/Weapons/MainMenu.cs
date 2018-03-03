using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Button startButton;
    [SerializeField]
    Button exitButton;

    private void Awake()
    {
        startButton.onClick.AddListener(() => SceneManager.LoadScene("Main"));
        exitButton.onClick.AddListener(() => Application.Quit());
    }
}
