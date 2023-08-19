using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCustomization : MonoBehaviour
{
    [SerializeField] private Transform equipmentContainer;
    [SerializeField] private GameObject itemPrefab;

    private void Start()
    {
        LoadWeapons();
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("Main");
    }


    public void LoadWeapons()
    {
        string[] weaponNames = DataManager.Instance.Weapons.Split(";");
        foreach (var weaponName in weaponNames)
        {
            var itemPath = "Weapons/" + weaponName;
            Debug.Log(itemPath);
            var prefab = Resources.Load<GameObject>(itemPath);
            Debug.Log(prefab.name);
            var data = prefab.GetComponent<BaseItem>();
            var itemObject = Instantiate(itemPrefab, equipmentContainer);
            var equipmentItem = itemObject.GetComponent<EquipmentItem>();
            equipmentItem.Load(data, prefab);
            // if (itemPath.Contains("Sword"))
            // {
            //     var data = prefab.GetComponent<Sword>();
            //     Debug.Log(data.icon);
            // }
            //
            // if (itemPath.Contains("Shield"))
            // {
            // }
        }
    }
}
