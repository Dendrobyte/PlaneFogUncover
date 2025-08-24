using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private GameObject planePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        Instantiate(planePrefab, Vector2.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update() {

    }
}
