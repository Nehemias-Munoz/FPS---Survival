using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Sonido")] 
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _useSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GunAmmo"))
        {
            GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo;
            _audioSource.PlayOneShot(_audioSource.clip);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("MedAmmo"))
        {
            GameManager.Instance.playerLives = other.gameObject.GetComponent<MedBox>().lives;
            Destroy(other.gameObject);
        }
    }
}
