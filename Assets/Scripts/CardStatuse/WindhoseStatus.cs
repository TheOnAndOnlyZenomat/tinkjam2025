using UnityEngine;

public class WindhoseStatus : Status
{
	public override string statusName { get; } = "Windhose";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Windhose is applying damage");
		AudioManager.Instance.PlayWindhose();
	}
}
