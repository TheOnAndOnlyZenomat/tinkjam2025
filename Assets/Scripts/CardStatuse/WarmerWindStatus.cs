using UnityEngine;

public class WarmerWindStatus : Status
{
	public override string statusName { get; } = "warmer Wind";

	public override bool oneshot { get; } = false;
	public override int ticks {get; set; } = 3;
	public override int periode {get; set; } = 1;
	public int damage {get; set; } = 1;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("warmer Wind is applying damage");
		AudioManager.Instance.PlaywarmerWind();

		enemy.GetComponent<EnemyStats>().Damage(this.damage);
	}
}
