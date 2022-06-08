using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLevel : MonoBehaviour
{
    public static ScoreLevel instance;
    
    [SerializeField] Text scoreText;
    public static int scoreLevel;
    
    public void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreLevel = 0;
        scoreText.text = scoreLevel.ToString("0");
    }

    // Update is called once per frame
    public void addScore(int plus)
    {
        scoreLevel += plus;
        scoreText.text = scoreLevel.ToString("0");
    }
}
