using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int hp;
    public int damage;
    public float movementSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
    }
}
