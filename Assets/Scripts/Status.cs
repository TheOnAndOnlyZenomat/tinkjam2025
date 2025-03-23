using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {
	public virtual string statusName { get; } = "Default";

	public virtual bool oneshot { get; } = true;
	public virtual bool globalStatus { get; } = false;

	public virtual int ticks {get; set; }
	public float current_periode {get; private set; } = 0;
	public virtual int periode {get; set; }

	[SerializeField]
	public List<string> createdBy = new List<string>(2);

	public void ApplyToEnemies(GameObject[] enemies) {
		foreach (GameObject enemy in enemies) {
			Debug.Log($"Oneshot applying effect \"{this.statusName}\" to enemy with name {enemy.name}");
			ApplyDamageToEnemy(enemy);
		}

		Destroy(transform.parent.gameObject);
	}

	/// returns whether or not to remove the status from the region
	public bool ApplyToEnemies(float delta, GameObject[] enemies) {
		this.current_periode += delta;
		if (this.current_periode >= this.periode) {
			foreach (GameObject enemy in enemies) {
				Debug.Log($"Applying effect \"{this.statusName}\" to enemy with name {enemy.name}, last execution was {delta} ago");
				ApplyDamageToEnemy(enemy);
			}

			this.ticks--;
			this.current_periode = 0;

			if (this.ticks <= 0) {
				return true;
			}
		}

		return false;
	}

	public override string ToString() {
		return $"{{ {this.statusName}; oneshot = {this.oneshot}; ticks = {this.ticks}; periode = {this.periode}; current_periode = {this.current_periode}; }}";
	}

	public bool IsCreatedBy(Status[] statuse) {
		bool created = false;

		if (statuse.Length == 1) {
			if (statuse[0].statusName == this.statusName) created = true;
		} else {
			if (this.createdBy.Count == 0) {
				created = false;
			} else {
				List<string> statusNames = new List<string>();
				foreach (Status status in statuse) {
					statusNames.Add(status.statusName);
				}
				created = Helpers.ContainsAll(this.createdBy.ToArray(), statusNames.ToArray());
			}
		}

		return created;
	}

	public virtual void ApplyDamageToEnemy(GameObject enemy) {}
}
