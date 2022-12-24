using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    float shootForce = 2500f;
    private float shootRate = 0.5f;
    private float shootRateTime = 0;

    [Header("Sonido Disparo")] 
    [SerializeField] private AudioSource _audioSource;
    [SerializeField]private AudioClip _shotSound;

    public Camera playerCamera;

    public float range = 3f;
    
    public LayerMask layerMask;
    // Update is called once per frame
    void Update()
    {
        if (!Input.GetButtonDown("Fire1")) return;
        if (Time.time > shootRateTime && GameManager.Instance.gunAmmo > 0)
        {
            ShootGun();
            GameManager.Instance.gunAmmo--;
            _audioSource.PlayOneShot(_shotSound); 
            shootRateTime = Time.time + shootRate;
        }
    }
    
    void ShootGun()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range, layerMask))
        {
            var zombie = hit.transform.GetComponent<AI>();
            zombie.Kill();
        }
    }
}
