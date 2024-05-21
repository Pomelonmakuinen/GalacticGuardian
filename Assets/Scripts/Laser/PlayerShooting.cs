using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public AudioSource shootSound;
    public GameObject laserPrefab;
    public Transform laserSpawnPoint;
    public float fireRate = 0.25f;
    private float nextFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        shootSound.Play();
        Instantiate(laserPrefab, laserSpawnPoint.position, laserSpawnPoint.rotation);
    }
}
