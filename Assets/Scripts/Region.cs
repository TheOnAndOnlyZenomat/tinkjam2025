using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour {
	List<Status> statuse { get; set; }
	List<GameObject> enemies { get; set; }

	public Grid grid {get; set; }

	public void init(Status[] statuse = null, GameObject[] enemies = null) {
		this.grid = GetComponent<Grid>();
		if (statuse is null) {
			this.statuse = new List<Status>();
		} else {
			this.statuse = new List<Status>(statuse);
		}

		if (enemies is null) {
			this.enemies = new List<GameObject>();
		} else {
			this.enemies = new List<GameObject>(enemies);
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
			Destroy(this.statuse[index].transform.parent.gameObject);
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
		Debug.Log($"status: {status.ToString()}");
		if (!status.oneshot) {
			this.statuse.Add(status);
		} else {
			if (status.globalStatus) {
				List<GameObject> allEnemies = new List<GameObject>();
				foreach (Region region in MapManager.Instance.regions) {
					allEnemies.AddRange(region.enemies);
				}
				status.ApplyToEnemies(allEnemies.ToArray());
			} else {
				status.ApplyToEnemies(this.enemies.ToArray());
			}
		}
	}

	public void AddEnemy(GameObject enemy) {
		this.enemies.Add(enemy);
	}

	public void RemoveEnemy(GameObject enemy) {
		this.enemies.Remove(enemy);
	}

	public void OnMouseEnter() {
		MapManager.Instance.SetActiveRegion(this);
	}

	public void OnMouseExit() {
		MapManager.Instance.SetActiveRegion(null);
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			this.AddEnemy(other.gameObject);
		}
	}

	public void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			this.RemoveEnemy(other.gameObject);
		}
	}

	public void Highlight(bool active) {
		transform.Find("outline").GetComponent<Renderer>().enabled = active;
	}
}
