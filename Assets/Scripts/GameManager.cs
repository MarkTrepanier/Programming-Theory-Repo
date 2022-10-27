using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private Actor player;
    private Actor enemy;
    private TextMeshProUGUI playerHealth;
    private TextMeshProUGUI enemyHealth;
    private  bool m_isGameActive = false;
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
    }

    //set up you win and you lose text objects
    //enemy at 0 win || player at 0 lose
}
