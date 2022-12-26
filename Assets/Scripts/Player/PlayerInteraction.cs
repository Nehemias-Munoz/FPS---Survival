using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Sonido")] 
    [SerializeField] private AudioSource _audioSource;
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
            Data.SetLives(other.gameObject.GetComponent<MedBox>().lives);
            _audioSource.PlayOneShot(_audioSource.clip);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("SafeZone"))
        {
            SceneManager.LoadScene("NextLevelScene");
        }
    }
}
