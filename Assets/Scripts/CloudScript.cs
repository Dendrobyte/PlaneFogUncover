using System.Collections;
using UnityEngine;

public class CloudScript : MonoBehaviour {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Plane")) {
            StartCoroutine(ShrinkAndDestroySelf());
        }
    }

    IEnumerator ShrinkAndDestroySelf() {
        float duration = 1f;
        float elapsed = 0f;
        Vector3 startScale = transform.localScale;

        while (elapsed < duration) {
            transform.localScale = Vector3.Lerp(startScale, Vector3.zero, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
