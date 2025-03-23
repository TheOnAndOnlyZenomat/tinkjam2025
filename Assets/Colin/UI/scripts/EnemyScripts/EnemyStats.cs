using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int hp;
    public int damage;
    public float movementSpeed;
    private float internalMovementSpeed;

	private float slowDuration = 0;
	private bool slowReset = true;

	public float isWetDuration = 0;

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
