using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour {
	List<Status> statuse { get; set; }
	List<int> enemies { get; set; }

	public Grid grid {get; set; }

	public void init(Status[] statuse = null, int[] enemies = null) {
		this.grid = GetComponent<Grid>();
		if (statuse is null) {
			this.statuse = new List<Status>();
		} else {
			this.statuse = new List<Status>(statuse);
		}

		if (enemies is null) {
			this.enemies = new List<int>();
		} else {
			this.enemies = new List<int>(enemies);
		}
	}

	public void Tick(float delta) {
		List<int> to_remove = new List<int>();
		for (int i = 0; i < this.statuse.Count; i++) {
			var status = this.statuse[i];
			bool remove = status.ApplyToEnemies(delta, this.enemies.ToArray());
			if (remove) {
				to_remove.Add(i);
			}
		}

		foreach(int index in to_remove) {
			this.statuse.RemoveAt(index);
		}
	}

	public override string ToString() {
		string out_str = "{ ";

		out_str += $"region = {this.grid.name}; ";
		out_str += "statuse = [";
		for (int i = 0; i < this.statuse.Count; i++) {
			out_str += statuse[i].ToString();
			if (i != (this.statuse.Count - 1)) out_str += ", ";
		}
		out_str += "]; ";
		out_str += "enemies = [";
		for (int i = 0; i < this.enemies.Count; i++) {
			out_str += enemies[i];
			if (i != (this.enemies.Count - 1)) out_str += ", ";
		}
		out_str += "]; ";

		out_str += "}";

		return out_str;
	}

	public void ApplyStatus(Status status) {
		if (!status.oneshot) {
			this.statuse.Add(status);
		} else {
			status.ApplyToEnemies(this.enemies.ToArray());
		}
	}

	public void AddEnemy(int enemy) {
		this.enemies.Add(enemy);
	}

	public void OnMouseEnter() {
		MapManager.Instance.SetActiveRegion(this);
	}

	public void OnMouseExit() {
		MapManager.Instance.SetActiveRegion(null);
	}

	public void Highlight(bool active) {
		transform.Find("outline").GetComponent<Renderer>().enabled = active;
	}
}
