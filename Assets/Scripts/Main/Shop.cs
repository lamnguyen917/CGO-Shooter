using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Popup
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private ShopData data;

    [SerializeField] private Transform itemList;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        foreach (var itemData in data.ItemList)
        {
            GameObject item = Instantiate(itemPrefab, itemList);
            ShopItem shopItem = item.GetComponent<ShopItem>();
            shopItem.Load(itemData);
        }
    }
}
