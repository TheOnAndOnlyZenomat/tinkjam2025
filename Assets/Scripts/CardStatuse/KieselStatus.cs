using UnityEngine;

public class KieselStatus : Status
{
	public override string statusName { get; } = "Kiesel";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Kiesel is applying damage");
		AudioManager.Instance.PlayKieseln();
	}
}
