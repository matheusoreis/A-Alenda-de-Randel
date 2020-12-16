using UnityEngine;
using UnityEngine.Tilemaps;

public class FadeBack : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    Tilemap tileRenderer;

    public bool IsTileChoise;

    public float Transparent = 0.6f;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tileRenderer = GetComponent<Tilemap>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        // Condição para verificar se é um Sprite ou Tilemap
        if (IsTileChoise == true) {
            if (collision.gameObject.CompareTag("Player")) {
                tileRenderer.color = new Color(1f, 1f, 1f, Transparent);
            }
        }
        else {
            if (collision.gameObject.CompareTag("Player")) {
                spriteRenderer.color = new Color(1f, 1f, 1f, Transparent);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        // Condição para verificar se é um Sprite ou Tilemap
        if (IsTileChoise == true) {
            tileRenderer.color = new Color(1f, 1f, 1f, 1f);
        }
        else {
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }       
    }
}