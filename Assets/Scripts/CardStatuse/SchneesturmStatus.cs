using UnityEngine;

public class SchneesturmStatus : Status
{
	public override string statusName { get; } = "Schneesturm";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Schneesturm is applying damage");
		AudioManager.Instance.PlaySchneesturm();
	}
}
