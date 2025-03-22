using UnityEngine;

[System.Serializable]
public class Enemy {
    public GameObject Prefab;
    [Range (0f, 100f)]public float Chance = 100f;

    [HideInInspector] public double _wheight;
}

public class EnemySpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Enemy[] enemies;
    public int startSpawnTime;
    public int spawnTime;
    private double accumulatedWeights;
    private System.Random rand = new System.Random ();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        InvokeRepeating ("Spawn", startSpawnTime, spawnTime);
    }

    private void Awake()
    {
        CalculateWeights ();
    }

    private void Spawn() {
        int spawnPoints = Random.Range (0, this.spawnPoints.Length);
        //int randomEnemy = Random.Range (0, this.enemies.Length);

        Enemy randomEnemy = enemies [GetRandomEnemyIndex ()];

        Instantiate (randomEnemy.Prefab, this.spawnPoints [spawnPoints].position, this.spawnPoints [spawnPoints].rotation);
    }

    private int GetRandomEnemyIndex() {
        double r = rand.NextDouble () * accumulatedWeights;
        for (int i = 0; i < enemies.Length; i++) 
            if (enemies [i]._wheight >= r) 
            return i;
        
        return 0;
    }

    private void CalculateWeights () {
        accumulatedWeights = 0f;
        foreach (Enemy enemy in enemies) {
            accumulatedWeights += enemy.Chance;
            enemy._wheight = accumulatedWeights;
        }
    }
}
