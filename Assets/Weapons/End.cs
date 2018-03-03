using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    [SerializeField]
    Text score;
    [SerializeField]
    Button start;
    [SerializeField]
    Button end;

    private void Start()
    {
        score.text = "SCORE: " + PlayerPrefs.GetString("score");
        start.onClick.AddListener(() => SceneManager.LoadScene("Main"));
        end.onClick.AddListener(() => Application.Quit());
    }
}
