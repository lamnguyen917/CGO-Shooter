using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private Button button;
    [SerializeField] private Color purchasedColor;
    [SerializeField] private Color notEnoughColor;
    [SerializeField] private Color normalColor;

    public ItemData _data;

    private void OnEnable()
    {
        MainMenu.Instance.onGemChange.AddListener(RefreshData);
        RefreshData();
    }

    private void OnDisable()
    {
        MainMenu.Instance.onGemChange.RemoveListener(RefreshData);
    }

    public void Load(ItemData data)
    {
        _data = data;
        RefreshData();
    }

    private void RefreshData()
    {
        nameText.SetText(_data.Name);
        priceText.SetText(_data.Price.ToString());
        icon.sprite = _data.Icon;

        var dataMan = DataManager.Instance;
        if (dataMan.IsWeaponPurchased(_data) || dataMan.Gems < _data.Price)
        {
            button.interactable = false;
            priceText.color = dataMan.IsWeaponPurchased(_data) ? purchasedColor : notEnoughColor;
        }
        else
        {
            button.interactable = true;
            priceText.color = normalColor;
        }
    }

    public void Purchase()
    {
        Debug.Log($"Purchase item {_data.Name} with price {_data.Price}");
        if (_data.Price > DataManager.Instance.Gems)
        {
            Debug.LogError("Not enough money");
            return;
        }

        DataManager.Instance.PurchaseWeapon(_data);
        DataManager.Instance.Save();
        MainMenu.Instance.onGemChange.Invoke();
    }
}
