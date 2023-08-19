using System;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager
{
    private static DataManager _instance;

    public static DataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DataManager();
                _instance.Load();
            }

            return _instance;
        }
    }

    private DataManager()
    {
    }

    public int Golds;
    public int Gems;
    public string Weapons;
    private HashSet<string> _weaponSet = new HashSet<string>();

    public void PurchaseWeapon(ItemData item)
    {
        Gems -= item.Price;
        var itemName = $"{item.Type}/{item.Name}";
        Debug.Log(itemName);
        _weaponSet.Add(itemName);
    }

    public bool IsWeaponPurchased(ItemData item)
    {
        var itemName = $"{item.Type}/{item.Name}";
        return _weaponSet.Contains(itemName);
    }

    public void Load()
    {
        if (!PlayerPrefs.HasKey("game_data"))
        {
            return;
        }

        var data = PlayerPrefs.GetString("game_data");
        var bytes = Convert.FromBase64String(data);
        var json = Encoding.Default.GetString(bytes);
        Debug.Log(json);
        _instance = JsonUtility.FromJson<DataManager>(json);
        if (!String.IsNullOrWhiteSpace(_instance.Weapons))
        {
            _instance._weaponSet.AddRange(_instance.Weapons.Split(";"));
            foreach (var w in _weaponSet)
            {
                Debug.Log(w);
            }
        }
    }

    public void Save()
    {
        if (_weaponSet != null) Weapons = String.Join(";", _weaponSet);
        var json = JsonUtility.ToJson(this);
        byte[] bytes = Encoding.Default.GetBytes(json);
        var data = Convert.ToBase64String(bytes);
        PlayerPrefs.SetString("game_data", data);
    }
}
