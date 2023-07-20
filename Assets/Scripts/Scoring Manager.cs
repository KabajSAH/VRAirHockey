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

    public int maxScore = 10;
    public Vector3 palletRespawnPoint;
    public GameObject pallet;
    
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
        
        if(score1 >= maxScore || score2 >= maxScore)
            EndGame();
    }

    public void EndGame()
    {
        //TODO
        if (score1 > score2) Debug.Log(score1 > score2 ? "Player 1 wins!" : "Player 2 wins!");

        score1 = 0;
        score2 = 0;
        UpdateScoreTexts();
        
        pallet.transform.position = palletRespawnPoint;
        Rigidbody rb = pallet.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void UpdateScoreTexts()
    {
        scoreTexts[0].text = score1 + "  -  " + score2;
        scoreTexts[1].text = score2 + "  -  " + score1;
    }
}
