using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float lifeTime = 3;
    [SerializeField] private float bulletSpeed = 5;

    [SerializeField] private float damage = 10;

    private float _countDown;

    public void Init()
    {
        ResetState();
    }

    void ResetState()
    {
        _countDown = lifeTime;
    }

    void Update()
    {
        if (_countDown < 0)
        {
            Destroy();
        }
        else
        {
            _countDown -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * bulletSpeed;
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            var character = other.GetComponent<BaseCharacter>();
            character.Damage(damage, transform.position);
        }
        
        if (!other.CompareTag("Player") && !other.CompareTag("Gun"))
        {
            Destroy();
        }
    }
}
