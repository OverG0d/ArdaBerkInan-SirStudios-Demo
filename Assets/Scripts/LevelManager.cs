using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    private int currentScore;
    private int currentNumOfCrystals;
    const int MAX_NUM_OF_CRYSTALS = 5;

    public int scoreRequiredToFinish;
    public int secondsToSpawn;
    public GameObject crystal;
    public GameObject finishScreen;
    public Text scoreText;
    public Text scoreFinishScreenText;
    public AudioClip finishScreenSound;
    public float minX, maxX, minZ, maxZ;

    //Properties
    public static LevelManager Instance { get { return instance; } }
    public int CurrentScore { get { return currentScore; } }
    public int CurrentNumOfCrystals
    {
        get { return currentNumOfCrystals; }
        set
        {
           currentNumOfCrystals = value;           
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        currentScore = 0;
        currentNumOfCrystals = 5;
        scoreText.text = "Score: " + currentScore;       
        InvokeRepeating("SpawnCrystal", 0, secondsToSpawn);
    }

    void SpawnCrystal()
    {
        //Only spawn a crystal if there are less than 5 crystals on the map
        if (currentNumOfCrystals < MAX_NUM_OF_CRYSTALS)
        {
            Instantiate(crystal, new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ)),
            transform.rotation);
            currentNumOfCrystals++;
        }
    }

    public void FinishScreen(int score)
    {
        //Checks if score is equal to 100
        //and if it is, finish the game
        currentScore += score;
        scoreText.text = "Score: " + currentScore;
        scoreFinishScreenText.text = "Score: " + currentScore;
        if (currentScore == scoreRequiredToFinish)
        {
            currentScore = 100;
            finishScreen.SetActive(true);
            AudioPlayer.Instance.PlaySound(finishScreenSound, 1f);
        }
    }
}
