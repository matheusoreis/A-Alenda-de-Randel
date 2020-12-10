using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBack : MonoBehaviour {

    SpriteRenderer spriteRenderer;

    public float transparent = 0.6f;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Player")){
            spriteRenderer.color = new Color(1f, 1f, 1f, transparent);
        }

    }

    void OnTriggerExit2D(Collider2D collision) {
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }

}