using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : ICharacterAnimator {
    public Animator Animator { get; set; }
    public CharacterAnimation Animation { get; set; }
    public CharacterState State { get; set; }

    /// <summary>
    /// Animações do personagem.
    /// </summary>
    private readonly Dictionary<CharacterAnimation, string> states;

    public CharacterAnimator(Animator animator) {
        Animator = animator;

        states = new Dictionary<CharacterAnimation, string> {
            { CharacterAnimation.IdleUp, "Hero_Idle_Up" },
            { CharacterAnimation.IdleDown, "Hero_Idle_Down" },
            { CharacterAnimation.IdleLeft, "Hero_Idle_Left" },
            { CharacterAnimation.IdleRight, "Hero_Idle_Right" },
            { CharacterAnimation.WalkUp, "Hero_Up" },
            { CharacterAnimation.WalkDown, "Hero_Down" },
            { CharacterAnimation.WalkLeft, "Hero_Left" },
            { CharacterAnimation.WalkRight, "Hero_Right" }
        };
    }

    public void ChangeState(CharacterDirection direction, bool moving) {
        CharacterAnimation _state = CharacterAnimation.IdleUp;

        switch (direction) {
            case CharacterDirection.Up: 
            case CharacterDirection.UpRight: 
            case CharacterDirection.UpLeft:
                _state = moving ? CharacterAnimation.WalkUp : CharacterAnimation.IdleUp;
                break;

            case CharacterDirection.Down: 
            case CharacterDirection.DownRight:
            case CharacterDirection.DownLeft:
                _state = moving ? CharacterAnimation.WalkDown : CharacterAnimation.IdleDown;
                break;

            case CharacterDirection.Left:
                _state = moving ? CharacterAnimation.WalkLeft : CharacterAnimation.IdleLeft;
                break;

            case CharacterDirection.Right:
                _state = moving ? CharacterAnimation.WalkRight : CharacterAnimation.IdleRight;
                break;
        }

        ChangeAnimationState(_state);
    }

    private void ChangeAnimationState(CharacterAnimation newState) {
        if (Animation == newState) {
            return;
        }

        Animator.Play(states[newState]);
        Animation = newState;
    }
}