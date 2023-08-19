using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Image healthBar;
    [SerializeField] private TMP_Text enemyCount;
    [SerializeField] private GameObject hudMenu;
    [SerializeField] private GameObject pauseMenu;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateHealBar(float hp, float maxHp)
    {
        healthBar.fillAmount = hp / maxHp;
    }

    public void UpdateEnemyCount(int count)
    {
        enemyCount.SetText(count.ToString());
    }

    public void Pause()
    {
        GameManager.Instance.Pause();
        hudMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        GameManager.Instance.Resume();
        hudMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        GameManager.Instance.Restart();
    }

    public void Home()
    {
        GameManager.Instance.Home();
    }
}
