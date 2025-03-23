using UnityEngine;

public class TreibsandStatus : Status
{
	public override string statusName { get; } = "Treibsand";

	public double vanishChance = 0.1d;

	public override void ApplyDamageToEnemy(GameObject enemy) {
		Debug.Log("Treibsand is applying damage");
		AudioManager.Instance.PlayTreibsand();

		System.Random rng = new System.Random();
		double pick = rng.NextDouble();

		if (pick < this.vanishChance) {
			Destroy(enemy);
		}
	}
}
