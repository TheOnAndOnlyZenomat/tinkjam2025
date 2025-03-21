using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
	public static MapManager Instance { get; private set; }

	private Region[] regions;
	private Region activeRegion = null;

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
		}

		Debug.Log("regions:");

		foreach(Region region in this.regions) {
			Debug.Log(region.ToString());
		}
	}

	void Update()
	{
		float delta = Time.deltaTime;
		foreach (Region region in this.regions) {
			region.Tick(delta);
		}
	}

	private void InitDebug() {
		foreach (Region region in this.regions) {
			region.AddEnemy(0);
			region.ApplyStatus(new Status("test_status", false, 2, 2));
		}
	}

	public void ApplyStatus(int index, Status status) {
		this.regions[index].ApplyStatus(status);
	}

	public void OnMousePress() {
		// get mouse click's position in 2d plane
		Vector3 mouse_world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouse_world.z = 0;

		Debug.Log($"Mouse clicked at {{x: {mouse_world.x}; y: {mouse_world.y}}}");

		Grid grid = this.regions[0].grid;
		Tilemap tilemap = grid.transform.Find("Tilemap").GetComponent<Tilemap>();
		Vector3Int cellCoords = tilemap.WorldToCell(mouse_world);

		tilemap.SetTileFlags(cellCoords, TileFlags.None);
		tilemap.SetColor(cellCoords, Color.red);
	}

	public void SetActiveRegion(Region region) {
		this.activeRegion = region;

		if (region is null) {
			Debug.Log("Unsetting active region");
			return;
		}

		int index = -1;
		for (int i = 0; i < this.regions.Length; i++) {
			if (this.regions[i] == region) index = i;
		}
		Debug.Log($"Active region is {index}");
	}
}
