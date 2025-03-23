using UnityEngine;

public class HagelsturmStatus : Status
{
	public override string statusName { get; } = "Hagelsturm";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Hagelsturm is applying damage");
		AudioManager.Instance.PlayHagelsturm();
	}
}
