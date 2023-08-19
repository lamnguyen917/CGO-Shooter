using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Shop Data")]
public class ShopData : ScriptableObject
{
    public ItemData[] ItemList;
}
