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
    public List<GameObject> listOfPlanets;
    public int maxPlanets;
    private int planetCount;

    public GameObject easyPlanet;
    public float minEasyPlanetTimer;
    public float easyPlanetTimer;
    public GameObject mediumPlanet;
    public float mediumPlanetTimer;
    public float minMediumPlanetTimer;
    public GameObject hardPlanet;
    public float hardPlanetTimer;
    public float minHardPlanetTimer;

    private IEnumerator coroutine1;
    private IEnumerator coroutine2;
    private IEnumerator coroutine3;

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


        coroutine1 = SpawnEasyPlanet();
        StartCoroutine(coroutine1);

        coroutine2 = SpawnMediumPlanet();
        StartCoroutine(coroutine2);

        coroutine3 = SpawnHardPlanet();
        StartCoroutine(coroutine3);
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
        else
        {
            RectTransform hp = GameObject.Find("TheyHunger").GetComponent<RectTransform>();
            SpriteRenderer hpRend = GameObject.Find("TheyHunger").GetComponent<SpriteRenderer>();
            hp.localScale = new Vector3(worm.hunger, 5, 0);
            if (worm.hunger >= 50)
                hpRend.color = Color.green;
            else if (worm.hunger < 50 && worm.hunger >= 20)
                hpRend.color = Color.yellow;
            else
                hpRend.color = Color.red;
        }
	}

    public void restartGame()
    {
        SceneManager.LoadScene("testland");
    }

    private void spawnPlanets(GameObject planet)
    {
        if(maxPlanets > planetCount)
        {
            // yes hardcoded... Border object.edgeCollider2D 
            float randY = Random.Range(-30, 30);
            float randX = Random.Range(-40, 40);
            GameObject clone = Instantiate(planet, new Vector3(randX,randY,planet.transform.position.z), planet.transform.rotation);
            clone.SetActive(true);
        }
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
    
    public void increaseScore(int increase)
    {
        score = score + increase;
    }

    IEnumerator SpawnEasyPlanet()
    {
        while (true) { 
            spawnPlanets(easyPlanet);
            if (easyPlanetTimer > minEasyPlanetTimer)
            {
                easyPlanetTimer = easyPlanetTimer - 1;
            }
            yield return new WaitForSeconds(easyPlanetTimer);
        }
    }
    IEnumerator SpawnMediumPlanet()
    {
        while (true)
        {
            spawnPlanets(mediumPlanet);
            if (mediumPlanetTimer > minMediumPlanetTimer)
            {
                mediumPlanetTimer = mediumPlanetTimer - 1;
            }
            yield return new WaitForSeconds(mediumPlanetTimer);
        }
    }
    IEnumerator SpawnHardPlanet()
    {
            while (true)
            {
                spawnPlanets(hardPlanet);
            if (hardPlanetTimer > minHardPlanetTimer)
            {
                hardPlanetTimer = hardPlanetTimer - 1;
            }
            yield return new WaitForSeconds(hardPlanetTimer);
            }
    }
}
