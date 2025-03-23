using UnityEngine;

public class SanduhrStatus : Status
{
	public override string statusName { get; } = "Sanduhr";

	public float timerBonus = 30;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Sanduhr is applying damage");
		AudioManager.Instance.PlaySanduhr();

		TimerScript.Instance.SetTime(this.timerBonus);
	}
}
