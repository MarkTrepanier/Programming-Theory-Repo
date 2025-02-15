using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private Actor player;
    private Actor enemy;
    private TextMeshProUGUI playerHealth;
    private TextMeshProUGUI enemyHealth;
    private TextMeshProUGUI SuccessBanner;
    private  bool m_isGameActive = false;

    private TextMeshProUGUI loseText;
    private TextMeshProUGUI winText;
    private Button restartButton;
    public bool isGameActive { get { return m_isGameActive; } private set { m_isGameActive = value; } }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(player != null)
        {
            playerHealth.text = player.health.ToString();
            enemyHealth.text = enemy.health.ToString();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.Find("Player").GetComponent<Actor>();
        enemy = GameObject.Find("Enemy").GetComponent<Actor>();
        playerHealth = GameObject.Find("Player Health").GetComponent<TextMeshProUGUI>();
        enemyHealth = GameObject.Find("Enemy Health").GetComponent<TextMeshProUGUI>();
        isGameActive = true;
        //restartbutton to be moved to gamer over sequence'
    }

    public void GameOver()
    {
        GameManager.Instance.isGameActive = false;
        restartButton = GameObject.Find("Canvas").transform.Find("Restart Button").GetComponent<Button>();
        restartButton.gameObject.SetActive(true);
        restartButton.onClick.AddListener(StartGame);
        string winner = player.health > 0 ? "WinText" : "LoseText";
        SuccessBanner = GameObject.Find("Canvas").transform.Find(winner).GetComponent<TextMeshProUGUI>();
        SuccessBanner.gameObject.SetActive(true);
    }
}
