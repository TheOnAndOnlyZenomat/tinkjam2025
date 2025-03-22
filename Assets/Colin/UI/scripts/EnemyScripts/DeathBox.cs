using Unity.VisualScripting;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) {
            other.gameObject.GetComponent<EnemyStats>().ApplyDamage();
            Destroy(other.gameObject);
        }
        
    }
}
