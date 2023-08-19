using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform baseTransform;

    public PlayerControl player;

    public List<EnemySpawner> enemySpawners;
    public int totalEnemies;

    public UnityEvent onEnemySpawn = new UnityEvent();
    public UnityEvent onEnemyDeath = new UnityEvent();
    public UnityEvent onPlayerDeath = new UnityEvent();

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1;
    }

    void Start()
    {
        onEnemySpawn.AddListener(() =>
        {
            totalEnemies++;
            UIManager.Instance.UpdateEnemyCount(totalEnemies);
        });

        onEnemyDeath.AddListener(() =>
        {
            totalEnemies--;
            UIManager.Instance.UpdateEnemyCount(totalEnemies);

            if (totalEnemies <= 0)
            {
                foreach (var spawner in enemySpawners)
                {
                    if (!spawner.IsDone) return;
                }

                StartGameOverProcess();
            }
        });
        onPlayerDeath.AddListener(StartGameOverProcess);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home()
    {
        SceneManager.LoadScene("Main");
    }


    void Update()
    {
    }

    void StartGameOverProcess()
    {
        Pause();
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        Debug.Log("GAME OVER");
        yield return new WaitForSecondsRealtime(2);
        Debug.Log("Load scene" + SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
