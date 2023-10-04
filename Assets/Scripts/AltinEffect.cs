using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltinEffect : MonoBehaviour
{
    private GameManager gameManager;
    private int minScore = 50,maxScore = 100;
    public ParticleSystem goldEffect;
   
    void Start()
    {
       gameManager = FindObjectOfType<GameManager>(); 
    }
    private void FixedUpdate()
    {
        transform.Rotate(180*Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddScore(Random.Range(minScore,maxScore));
            goldEffect.Play();
            Destroy(this.gameObject,0.2f);
            gameManager.inGameScoreText.text = "Score: " + gameManager.score;
        }
    }



}
