using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float Score;

    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(float addition)
    {
        Score += addition;
    }

    private void ResetScore()
    {
        Score = 0;
    }
}
