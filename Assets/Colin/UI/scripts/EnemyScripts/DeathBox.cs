using UnityEngine;

public class DeathBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) {
            Destroy(other.gameObject);
            Debug.Log("Collided");
        }
        
    }
}
