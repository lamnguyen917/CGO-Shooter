using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;

    [SerializeField] private EnemySpawnerConfig config;

    public bool IsDone => config.IsDone;
    
    /**
     * Don't call Start in children classes
     */
    private void Start()
    {
        config.Init();
        ChildStart();
        GameManager.Instance.enemySpawners.Add(this);
    }

    private void Update()
    {
        ChildUpdate();
        config.CheckSpawn(spawnPosition);
    }

    public void Spawn()
    {
        Instantiate(config.prefab, spawnPosition.position, spawnPosition.rotation);
    }

    protected abstract void ChildStart();
    protected abstract void ChildUpdate();
}
