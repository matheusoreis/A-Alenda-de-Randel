using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    private const float Speed = 2.5f;

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
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        state = GetState(x, y);
        direction = GetMovementDirection(x, y);

        transform.position += new Vector3(x * Speed * Time.deltaTime, y * Speed * Time.deltaTime, 0);

        animator.ChangeState(state, direction, (x != 0 || y != 0));
    }

    CharacterDirection GetMovementDirection(float x, float y) {
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

    CharacterState GetState(float x, float y) {
        return (x != 0 || y != 0) ? CharacterState.Moving : CharacterState.Idle;
    }
}