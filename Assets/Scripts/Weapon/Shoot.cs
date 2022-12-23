using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bullet;
    
    float shootForce = 2500f;
    private float shootRate = 0.5f;
    private float shootRateTime = 0;

    [Header("Sonido Disparo")] 
    [SerializeField] private AudioSource _audioSource;
    [SerializeField]private AudioClip _shotSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > shootRateTime && GameManager.Instance.gunAmmo > 0)
            {
                GameManager.Instance.gunAmmo--;
                _audioSource.PlayOneShot(_shotSound);
                GameObject newBullet;
                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shootForce);
                print("fire");
                shootRateTime = Time.time + shootRate;
                Destroy(newBullet, 5);
            }
        } 
    }
}
