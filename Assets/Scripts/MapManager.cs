using UnityEngine;

public class MapManager : MonoBehaviour
{
	public static MapManager Instance { get; private set; }

	private Region[] regions;
	private Region activeRegion = null;

	[SerializeField] public GameObject[] cardPool;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Debug.Log("MapManager instance was not me, destroying");
			Destroy(this.gameObject);
		} else {
			Instance = this;
		}
	}

	void Start()
	{
		Debug.Log("Initializing MapManager");

		var regions = Helpers.FindChildObjectsWithTag<Region>(transform, "region");

		this.regions = new Region[regions.Count];
		for (int i = 0; i < this.regions.Length; i++) {
			this.regions[i] = regions[i];
			this.regions[i].init();
			this.regions[i].AddEnemy(1);
		}
	}

	void Update()
	{
		float delta = Time.deltaTime;
		foreach (Region region in this.regions) {
			region.Tick(delta);
		}
	}

	public void ApplyStatus(int index, Status status) {
		this.regions[index].ApplyStatus(status);
	}

	public void SetActiveRegion(Region region) {
		if (region is null) {
			this.activeRegion.Highlight(false);
			this.activeRegion = null;

			return;
		}

		this.activeRegion = region;
		this.activeRegion.Highlight(true);
	}

	public void OnMousePress() {
		if (this.activeRegion is null) return;

		Status[] activeStatuse = HandManager.Instance._activeCards.ToArray();
		if (activeStatuse.Length == 0) return;

		Status[] statuse = new Status[this.cardPool.Length];
		for (int i = 0; i < statuse.Length; i++) {
			GameObject obj = Instantiate(this.cardPool[i]);
			statuse[i] = obj.GetComponent<Transform>().Find("Status").GetComponent<Status>();
		}

		foreach (Status status in statuse) {
			if (status.IsCreatedBy(activeStatuse)) {
				this.activeRegion.ApplyStatus(status);
			} else {
				Destroy(status.transform.parent.gameObject);
			}
		}
	}
}
