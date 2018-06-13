using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab, bulletPrefab2;
    public GameObject bulletSpawn;
    public GameObject bulletSpawn2;
    public AudioClip playerShotSound;

    public float ShotDelay = 0.25f;
    float shotCooldown = 0;

    
    void Update()
    {

        //if the left mouse button is pressed the player ship will fire a single bullet everytime the left mouse button is pressed
        if (Input.GetKeyDown("mouse 0"))
        {
            SoundEffects.Instance.MakePlayerShotSound();
            Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            Instantiate(bulletPrefab2, bulletSpawn2.transform.position, bulletSpawn2.transform.rotation);
        }

        //if the right mouse button is held and the shotCooldown variable is less than or equal to 0 the player ship will fire a bullet
        shotCooldown -= Time.deltaTime;
        if (Input.GetKey("mouse 1") && shotCooldown <= 0)
        {
            shotCooldown = ShotDelay;
            SoundEffects.Instance.MakePlayerShotSound();
            Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            Instantiate(bulletPrefab2, bulletSpawn2.transform.position, bulletSpawn2.transform.rotation);
        }
    }
}

