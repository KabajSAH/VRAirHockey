using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoringManager : MonoBehaviour
{

    public List<GameObject> scoringAreas = new List<GameObject>();

    public List<TextMeshPro> scoreTexts;
    
    public int score1;
    public int score2;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var scoringArea in scoringAreas)
        {
            ScoringArea scoringAreaScript = scoringArea.GetComponent<ScoringArea>();
            scoringAreaScript.SetScoringManager(this);
        }

        score1 = 0;
        score2 = 0;
    }
    
    public void AddScore(int player)
    {
        if (player == 1) score1++;
        if (player == 2) score2++;
        
        UpdateScoreTexts();
    }
    
    private void UpdateScoreTexts()
    {
        scoreTexts[0].text = score1 + "  -  " + score2;
        scoreTexts[1].text = score2 + "  -  " + score1;
    }
}
