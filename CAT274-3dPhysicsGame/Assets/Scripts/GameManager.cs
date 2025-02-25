using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;
using System;


public class GameManager : MonoBehaviour
{

    private int score;
    public static GameManager Instance;

    public TextMeshProUGUI txtPlayerScore;
    public TextMeshProUGUI txtHighScore;

    public float endTime = 0.0f;
    const string DIR_DATA = "/Data/";
    const string FILE_HIGH_SCORE = "/highScore/";
    string PATH_HIGH_SCORE;

    public int Score
    {
        get { return score; }
        set 
        {
            score = value;
            if (score > HighScore)
            {
                HighScore = score;
            }
        }
    }

    int highScore;
    public int HighScore
    {
        get { return highScore; }
        set
        {
            highScore = value;
            Directory.CreateDirectory(Application.dataPath + DIR_DATA);
            File.WriteAllText(PATH_HIGH_SCORE, "" + HighScore);
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        PATH_HIGH_SCORE = Application.dataPath + DIR_DATA + FILE_HIGH_SCORE;
        
        
        if (File.Exists(PATH_HIGH_SCORE))
        {
            HighScore = Int32.Parse(File.ReadAllText(PATH_HIGH_SCORE));
        }
    }

    // Update is called once per frame
    void Update()
    {
        txtPlayerScore.text = "Score: " + Score;
        txtHighScore.text = "High Score: " + HighScore;

        endTime += Time.deltaTime;

        if (endTime >= 10.0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
