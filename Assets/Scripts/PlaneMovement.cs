using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaneMovement : MonoBehaviour {
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float rotateSpeed = 180f;
    private Tilemap groundTilemap;
    private Vector2 currDirection;
    void Start() {
        currDirection = transform.up;

        // Is there a better way than "Find"ing? I guess I would need a better hierarchy, this is ok for now
        GameObject groundTilemapObj = GameObject.Find("Tilemap_Ground");
        groundTilemap = groundTilemapObj.GetComponent<Tilemap>();

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            // Normal ground (note)
            // if (currTile.name == "ground_tile_56") {

            // Only move if next pos is a valid tile
            // TODO: Other tile checks so will be refactoring this, also make enums
            // Will need to move this to some Fly() function to make it better, as we also run low on fuel etc.
            Vector3 nextPos = transform.position + (moveSpeed * Time.deltaTime * (Vector3)currDirection);
            Vector3Int nextCellPos = groundTilemap.WorldToCell(nextPos);
            if (groundTilemap.GetTile(nextCellPos) != null) {
                transform.SetPositionAndRotation(nextPos, transform.rotation);

                // Set camera as a child of the plane so that the camera moves with it
                GameObject.Find("Main Camera").transform.position += moveSpeed * Time.deltaTime * (Vector3)currDirection;
            }

            // TODO: If it is, tween a rotation in the other direction?
        }

        // Wait, I don't need to go backwards lol
        // if (Input.GetKey(KeyCode.S)) {
        //     transform.position += moveSpeed * Time.deltaTime * (Vector3)(currDirection * -1);
        // }
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0f, 0f, -rotateSpeed * Time.deltaTime);
            currDirection = transform.up;
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
            currDirection = transform.up;
        }
    }
}
