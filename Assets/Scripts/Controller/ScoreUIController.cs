using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUIController : MonoBehaviour
{
    public ScoreManager scoreManager;
    public TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = scoreManager.Score.ToString();
    }
}
