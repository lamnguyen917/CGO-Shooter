using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Model2PNG : MonoBehaviour
{
    [MenuItem("Tools/Model 2 PNG")]
    public static void Save()
    {
        var asset = Selection.activeObject;
        var tex = AssetPreview.GetAssetPreview(asset);
        var bytes = tex.EncodeToPNG();
        File.WriteAllBytes($"Assets/Models/Weapons/{asset.name}_preview.png", bytes);
    }
}
