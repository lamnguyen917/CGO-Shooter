using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentItem : MonoBehaviour
{
    [SerializeField] private Image icon;
    private BaseItem _data;
    private GameObject _prefab;

    public void Load(BaseItem item, GameObject prefab)
    {
        _data = item;
        _prefab = prefab;

        icon.sprite = _data.icon;
    }
}
