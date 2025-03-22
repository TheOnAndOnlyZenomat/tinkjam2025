using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int hp;
    public int damage;
    public float movementSpeed;
   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
    }

    public void ApplyDamage() {
        TimerScript.Instance.DamageTime(damage);
    }
}
