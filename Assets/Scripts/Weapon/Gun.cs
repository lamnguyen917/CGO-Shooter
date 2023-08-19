using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private LineRenderer aimingLine;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPosition;
    [SerializeField] private LayerMask environmentLayers;
    [SerializeField] private AudioSource audioSource;
    public SphereCollider trigger;
    public Transform rightHandIk;
    public Transform leftHandIk;

    [Header("Gun properties")] [SerializeField]
    private float rate; // number of bullet per second

    private float _timer;

    private void Start()
    {
        aimingLine.startWidth = 0.1f;
        aimingLine.endWidth = 0.1f;
        if (rate == 0) rate = 1;
    }

    public void Shoot()
    {
        if (_timer > 0) return;
        GameObject bulletGameObject =
            Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();
        bullet.Init();
        _timer = 1 / rate;
        
        if (audioSource) audioSource.Play();
    }

    private void Update()
    {
        ShowLine();
        _timer -= Time.deltaTime;
    }


    void ShowLine()
    {
        Vector3 startPosition = transform.position;
        aimingLine.SetPosition(0, startPosition);
        Vector3 endPosition = transform.position + transform.forward * 1000;
        if (Physics.Raycast(startPosition, transform.forward, out RaycastHit hit, Mathf.Infinity, environmentLayers))
        {
            endPosition = hit.point;
            Debug.DrawLine(startPosition, hit.point, Color.blue);
        }

        aimingLine.SetPosition(1, endPosition);
    }
}
