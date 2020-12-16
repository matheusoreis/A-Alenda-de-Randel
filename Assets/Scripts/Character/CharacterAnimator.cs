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
            { CharacterAnimation.IdleUp, "Luca_Idle_Up" },
            { CharacterAnimation.IdleDown, "Luca_Idle_Down" },
            { CharacterAnimation.IdleLeft, "Luca_Idle_Left" },
            { CharacterAnimation.IdleRight, "Luca_Idle_Right" },
            { CharacterAnimation.WalkUp, "Luca_Walk_Up" },
            { CharacterAnimation.WalkDown, "Luca_Walk_Down" },
            { CharacterAnimation.WalkLeft, "Luca_Walk_Left" },
            { CharacterAnimation.WalkRight, "Luca_Walk_Right" },
            { CharacterAnimation.Seated, "Seated" },
            { CharacterAnimation.SwordUp, "Luca_Sword_Up" },
            { CharacterAnimation.SwordDown, "Luca_Sword_Down" },
            { CharacterAnimation.SwordLeft, "Luca_Sword_Left" },
            { CharacterAnimation.SwordRight, "Luca_Sword_Right" },
            { CharacterAnimation.BowUp, "Luca_Bow_Up" },
            { CharacterAnimation.BowDown, "Luca_Bow_Down" },
            { CharacterAnimation.BowLeft, "Luca_Bow_Left" },
            { CharacterAnimation.BowRight, "Luca_Bow_Right" },
            { CharacterAnimation.ShieldUp, "Luca_Shield_Up" },
            { CharacterAnimation.ShieldDown, "Luca_Shield_Down" },
            { CharacterAnimation.ShieldLeft, "Luca_Shield_Left" },
            { CharacterAnimation.ShieldRight, "Luca_Shield_Right" },
            { CharacterAnimation.RollUp, "Luca_Roll_Up" },
            { CharacterAnimation.RollDown, "Luca_Roll_Down" },
            { CharacterAnimation.RollLeft, "Luca_Roll_Left" },
            { CharacterAnimation.RollRight, "Luca_Roll_Right" },
            { CharacterAnimation.JumpUp, "Luca_Jump_Up" },
            { CharacterAnimation.JumpDown, "Luca_Jump_Down" },
            { CharacterAnimation.JumpLeft, "Luca_Jump_Left" },
            { CharacterAnimation.JumpRight, "Luca_Jump_Right" },
            { CharacterAnimation.ClimbUp, "Luca_Climb_Up" },
            { CharacterAnimation.ClimbDown, "Luca_Climb_Down" },
            { CharacterAnimation.ClimbLeft, "Luca_Climb_Left" },
            { CharacterAnimation.ClimbRight, "Luca_Climb_Right" }
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