using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    int score;
    int survivedSec;
    private Text scoreText;
    private Worm_Head worm;
    private GameObject gameOverPanel;

    // Use this for initialization
    void Start () {
        score = 0;
        survivedSec = 0;
        gameOverPanel = GameObject.Find("DeathPanel");
        StartCoroutine(scoringLoop());
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        worm = GameObject.FindGameObjectWithTag("Player").GetComponent<Worm_Head>();
        // sprites are infront of the canvas stuff.
        GameObject.Find("CanvasPainter").GetComponent<Canvas>().planeDistance = 100;
        gameOverPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        // Update the GUI Score
        scoreText.text = "Score: " + score.ToString();
        // Check for player death
        
        if (worm.isDead())
        {
            // Do game over stuff:
            // Canvas stuff infront of the sprites.
            GameObject.Find("CanvasPainter").GetComponent<Canvas>().planeDistance = 1;
            gameOverPanel.SetActive(true);

            GameObject.Find("FinalScore").GetComponent<Text>().text = score.ToString();
            //GameObject.FindGameObjectWithTag("Player").SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Worm_Head>().detach();
            GameObject.FindGameObjectWithTag("Player").GetComponent<Worm_Head>().die();
        }
	}

    public void restartGame()
    {
        SceneManager.LoadScene("testland");
    }

    private IEnumerator scoringLoop()
    {
        yield return new WaitForSeconds(1);
        score += 10;
        survivedSec += 1;
        // and again.
        if(!worm.isDead())
            StartCoroutine(scoringLoop());
    }
}
