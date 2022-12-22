using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bullet;
    
    float shootForce = 1500f;
    private float shootRate = 0.5f;

    private float shootRateTime = 0;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > shootRateTime)
            {
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
