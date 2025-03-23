using UnityEngine;

public class SchneeballStatus : Status
{
	public override string statusName { get; } = "Schneeball";

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Schneeball is applying damage");
		AudioManager.Instance.PlaySchneebaelleVomSchuhlhof();
	}
}
