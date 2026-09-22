using Unity.Cinemachine;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public CinemachineSplineCart enemyCart;
    public float enemySpeed = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SetSpeed(enemySpeed);
        }
    }

    void SetSpeed(float zSpeed)
    {
        var cartSpeed = enemyCart.AutomaticDolly.Method as SplineAutoDolly.FixedSpeed;
        cartSpeed.Speed = zSpeed;
    }
}
