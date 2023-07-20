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
    public Transform palletRespawnPoint;
    public GameObject pallet;
    public Material scoreMat;

    private Color _defaultScoreColor;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var scoringArea in scoringAreas)
        {
            ScoringArea scoringAreaScript = scoringArea.GetComponent<ScoringArea>();
            scoringAreaScript.SetScoringManager(this);
        }

        _defaultScoreColor = new Color(.5f, .5f, .5f, 1f);

        score1 = 0;
        score2 = 0;
        pallet.SetActive(false);
    }
    
    public void AddScore(int player)
    {
        if (player == 1) score1++;
        if (player == 2) score2++;
        
        UpdateScoreTexts();
        
        if(score1 >= maxScore || score2 >= maxScore)
            EndGame();
    }

    private void EndGame()
    {
        if (score1 > score2) scoreMat.color = Color.blue;
        else scoreMat.color = Color.red;
        //Debug.Log(score1 > score2 ? "Player 1 wins!" : "Player 2 wins!");

        
        pallet.SetActive(false);
    }

    public void StartGame()
    {
        scoreMat.color = _defaultScoreColor;
        score1 = 0;
        score2 = 0;
        UpdateScoreTexts();
        
        pallet.transform.position = palletRespawnPoint.position;
        Rigidbody rb = pallet.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        pallet.SetActive(true);
    }

    private void UpdateScoreTexts()
    {
        scoreTexts[0].text = score1 + "  -  " + score2;
        scoreTexts[1].text = score2 + "  -  " + score1;
    }
}
