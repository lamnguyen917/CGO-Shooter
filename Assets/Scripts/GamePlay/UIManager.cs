using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [SerializeField] private Image healthBar;


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
}
