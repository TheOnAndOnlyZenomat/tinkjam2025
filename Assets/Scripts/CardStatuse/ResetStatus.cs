using UnityEngine;

public class ResetStatus : Status
{
	public override string statusName { get; } = "Reset";

	public float timerBonus = 120f;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Reset is applying damage");
		AudioManager.Instance.PlayReset();

		TimerScript.Instance.SetTime(timerBonus);
	}
}
