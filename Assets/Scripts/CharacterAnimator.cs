using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : ICharacterAnimator {
    public Animator Animator { get; set; }

    private CharacterDirection direction;
    private CharacterState state;
    private CharacterAnimation animation;

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

    public CharacterState GetState() {
        return state;
    }

    public CharacterAnimation GetAnimation() {
        return animation;
    }

    public CharacterDirection GetDirection() {
        return direction;
    }

    public void ChangeState(CharacterState state, CharacterDirection direction, bool moving) {
        this.state = state;
        this.direction = direction;

        CharacterAnimation animation = CharacterAnimation.IdleUp;

        switch (direction) {
            case CharacterDirection.Up: 
            case CharacterDirection.UpRight: 
            case CharacterDirection.UpLeft:
                animation = moving ? CharacterAnimation.WalkUp : CharacterAnimation.IdleUp;
                break;

            case CharacterDirection.Down: 
            case CharacterDirection.DownRight:
            case CharacterDirection.DownLeft:
                animation = moving ? CharacterAnimation.WalkDown : CharacterAnimation.IdleDown;
                break;

            case CharacterDirection.Left:
                animation = moving ? CharacterAnimation.WalkLeft : CharacterAnimation.IdleLeft;
                break;

            case CharacterDirection.Right:
                animation = moving ? CharacterAnimation.WalkRight : CharacterAnimation.IdleRight;
                break;
        }

        ChangeAnimationState(animation);
    }

    private void ChangeAnimationState(CharacterAnimation newAnimation) {
        if (animation == newAnimation) {
            return;
        }

        Animator.Play(states[newAnimation]);
        animation = newAnimation;
    }
}