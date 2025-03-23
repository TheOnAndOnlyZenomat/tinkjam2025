using UnityEngine;
using TMPro;

public class EnemyStats : MonoBehaviour
{
    public int hp;
    public int damage;
    public float movementSpeed;
    private float internalMovementSpeed;

	private float slowDuration = 0;
	private bool slowReset = true;

	public float isWetDuration = 0;

	public GameObject damageText;

	private void Awake() {
		this.internalMovementSpeed = this.movementSpeed;
	}
   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * internalMovementSpeed * Time.deltaTime);

		float deltaTime = Time.deltaTime;
		if (this.slowDuration > 0) this.slowDuration -= deltaTime;
		if (this.slowDuration <= 0) {
			if (!this.slowReset) {
				this.internalMovementSpeed = this.movementSpeed;
				this.slowReset = true;
			}
		};

		if (this.isWetDuration > 0) this.isWetDuration -= deltaTime;
    }

    public void ApplyDamage() {
        TimerScript.Instance.DamageTime(damage);
    }

	public void Damage(int dmg) {
		this.hp -= dmg;
		GameObject damageTextInstance = Instantiate(damageText, transform.position, Quaternion.identity);
		damageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().text = dmg.ToString();

		if (hp <= 0) {
			Destroy(this.gameObject);
		}
	}

	public void Slow(float duration, float factor) {
		this.slowDuration = duration;
		this.internalMovementSpeed = movementSpeed * factor;
		this.slowReset = false;
	}
}
