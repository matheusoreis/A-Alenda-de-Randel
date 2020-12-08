using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    private const float Speed = 1.8f;

    /// <summary>
    /// Controla a animação do personagem.
    /// </summary>
    private ICharacterAnimator animator;

    private CharacterDirection direction;
    private CharacterState state;

    void Start() {
        direction = CharacterDirection.Down;
        animator = new CharacterAnimator(GetComponent<Animator>());
    }

    // Update is called once per frame
    void Update() {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        if (x > 0) {
            x = 1;
        }
        else if (x < 0) {
            x = -1;
        }

        if (y > 0) {
            y = 1;
        }
        else if (y < 0) {
            y = -1;
        }

        direction = GetMovementDirection(x, y);

        transform.position += new Vector3(x * Speed * Time.deltaTime, y * Speed * Time.deltaTime, 0);
        animator.ChangeState(direction, (x != 0 || y != 0));
    }

    private CharacterDirection GetMovementDirection(float x, float y) {
        if (x == 0 && y > 0) {
            return CharacterDirection.Up;
        }

        if (x == 0 && y < 0) {
            return CharacterDirection.Down;
        }

        if (x < 0 && y == 0) {
            return CharacterDirection.Left;
        }

        if (x > 0 && y == 0) {
            return CharacterDirection.Right;
        }

        if (x > 0 && y > 0) {
            return CharacterDirection.UpRight;
        }

        if (x < 0 && y > 0) {
            return CharacterDirection.UpLeft;
        }

        if (x > 0 && y < 0) {
            return CharacterDirection.DownRight;
        }

        if (x < 0 && y < 0) {
            return CharacterDirection.DownLeft;
        }

        return direction;
    }
}