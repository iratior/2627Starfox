using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform bulletOrigin;
    public AudioSource disparo;


    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject newBullet = Instantiate(bulletPrefab, bulletOrigin.position, Quaternion.identity);
            newBullet.transform.forward = bulletOrigin.forward;
            disparo.pitch = Random.Range(0.8f, 1.2f);
            disparo.Play();
        }
    }
}