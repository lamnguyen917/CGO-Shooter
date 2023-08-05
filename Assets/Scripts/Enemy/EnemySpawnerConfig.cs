using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Others/Spawner Config")]
public class EnemySpawnerConfig : ScriptableObject
{
    public GameObject prefab;
    public float time = 10;
    public float totalEnemies;

    private float _timer;
    private int _count = 0;

    public bool IsDone => _count >= totalEnemies;

    public void Init()
    {
        _count = 0;
        _timer = 0;
    }

    public void CheckSpawn(Transform startTransform)
    {
        if (IsDone) return;
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            Spawn(startTransform);
            _timer = time;
        }
    }

    void Spawn(Transform startTransform)
    {
        Instantiate(prefab, startTransform.position, startTransform.rotation);
        _count++;
        GameManager.Instance.onEnemySpawn.Invoke();
    }
}
