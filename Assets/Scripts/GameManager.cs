using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour {

    [SerializeField] private GameObject planePrefab;
    [SerializeField] private GameObject cloudPrefab;
    [SerializeField] private Tilemap groundTilemap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        // TODO: Generate grid (stretch goal)

        // Generate clouds
        GenerateClouds();

        // Initialize plane
        Instantiate(planePrefab, Vector2.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update() {

    }

    // Generate clouds scattered around the map
    // TODO: Particle system :o
    private void GenerateClouds() {
        // This fields horrible lol but oh well
        Vector3Int tileBoundsMin = groundTilemap.cellBounds.min;
        Vector3Int tileBoundsMax = groundTilemap.cellBounds.max;

        for (int i = tileBoundsMin.x; i < tileBoundsMax.x; i++) {
            for (int j = tileBoundsMin.y; j < tileBoundsMax.y; j++) {
                // TODO: Randomize sprite png?
                // TODO: Randomize rotation?
                // TODO: Jitter location?
                Instantiate(cloudPrefab, new Vector2(i, j), Quaternion.identity);
            }
        }
    }
}
