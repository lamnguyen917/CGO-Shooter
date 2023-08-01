using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPosition;
    public SphereCollider trigger;
    public Transform rightHandIk;
    public Transform leftHandIk;

    public void Shoot()
    {
        GameObject bulletGameObject =
            Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();
        bullet.Init();
    }
}
