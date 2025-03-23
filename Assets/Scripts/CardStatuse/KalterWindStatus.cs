using UnityEngine;

public class KalterWindStatus : Status
{
	public override string statusName { get; } = "kalter Wind";

	public override bool oneshot { get; } = false;
	public override int ticks {get; set; } = 3;
	public override int periode {get; set; } = 1;

	private float slowDuration = 1;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("kalter Wind is applying damage");
		AudioManager.Instance.PlaykalterWind();

		enemy.GetComponent<EnemyStats>().Slow(this.slowDuration, 0.5f);
	}
}
