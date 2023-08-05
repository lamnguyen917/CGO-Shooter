using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Image healthBar;
    [SerializeField] private TMP_Text enemyCount;

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
}
