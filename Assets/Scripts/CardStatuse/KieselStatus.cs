using UnityEngine;

public class KieselStatus : Status
{
	public override string statusName { get; } = "Kiesel";

	public override void ApplyDamageToEnemy(int enemy) {
		Debug.Log("Kiesel is applying damage");
	}
}
