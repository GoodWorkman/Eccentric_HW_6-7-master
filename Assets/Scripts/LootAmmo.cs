using UnityEngine;

public class LootAmmo : MonoBehaviour
{
    [SerializeField] private int _numberOfBullets;
    [SerializeField] private int _ammoIndex;

    private void OnTriggerEnter(Collider other)
    {
        PlayerArmory playerArmory = other.GetComponentInParent<PlayerArmory>();
        
        if (playerArmory)
        {
            playerArmory.AddBullets(_ammoIndex, _numberOfBullets);
            Destroy(gameObject);
        }
    }
}
