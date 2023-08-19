using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;
    [SerializeField] private Popup shop;
    [SerializeField] private TMP_Text gemsText;
    [SerializeField] private TMP_Text goldText;

    public UnityEvent onGemChange = new UnityEvent();

    private void Awake()
    {
        Instance = this;
        onGemChange.AddListener(() => { gemsText.SetText(DataManager.Instance.Gems.ToString()); });
    }

    private void Start()
    {
        LoadData();
    }

    void LoadData()
    {
        gemsText.SetText(DataManager.Instance.Gems.ToString());
        goldText.SetText(DataManager.Instance.Golds.ToString());
    }

    public void StartPlay()
    {
        // TODO: create loading scene
        // TODO: create level selector
        SceneManager.LoadScene("Game");
    }

    public void OpenShop()
    {
        shop.Open();
    }

    public void OpenSettings()
    {
        Debug.Log("Add 1000 gems");
        DataManager.Instance.Gems += 1000;
        DataManager.Instance.Save();
        onGemChange.Invoke();
    }

    public void EditCharacter()
    {
        SceneManager.LoadScene("Character");
    }

    public void OpenAchievement()
    {
    }
}
