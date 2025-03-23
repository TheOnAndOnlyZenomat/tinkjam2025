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

	private float burningDuration = 0;
	private float matschDuration = 0;
	private float poisonedDuration = 0;
	private float wetDuration = 0;
	private float iceDuration = 0;

	public SpriteRenderer burningSprite;
	public SpriteRenderer matschSprite;
	public SpriteRenderer poisonedSprite;
	public SpriteRenderer wetSprite;
	public SpriteRenderer iceSprite;

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

		if (this.burningDuration > 0) this.burningDuration -= deltaTime;
		if (this.burningDuration <= 0) {
			this.burningSprite.enabled = false;
		}
		if (this.matschDuration > 0) this.matschDuration -= deltaTime;
		if (this.matschDuration <= 0) {
			this.gameObject.transform.Find("Mudpuddlee").GetComponent<SpriteRenderer>().enabled = false;
		}
		if (this.poisonedDuration > 0) this.poisonedDuration -= deltaTime;
		if (this.poisonedDuration <= 0) {
			this.poisonedSprite.enabled = false;
		}
		if (this.wetDuration > 0) this.wetDuration -= deltaTime;
		if (this.wetDuration <= 0) {
			this.wetSprite.enabled = false;
		}
		if (this.iceDuration > 0) this.iceDuration -= deltaTime;
		if (this.iceDuration <= 0) {
			this.iceSprite.enabled = false;
		}
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

	public void SetBurning(float duration) {
		this.burningDuration += duration;
		this.burningSprite.enabled = true;
	}

	public void SetMatsch(float duration) {
		this.matschDuration += duration;
		this.matschSprite.enabled = true;
	}

	public void SetPoisoned(float duration) {
		this.poisonedDuration += duration;
		this.poisonedSprite.enabled = true;
	}

	public void SetWet(float duration) {
		this.wetDuration += duration;
		this.wetSprite.enabled = true;
	}

	public void SetIce(float duration) {
		this.iceDuration += duration;
		this.iceSprite.enabled = true;
	}
}
