using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : ICharacterAnimator {
    public Animator Animator { get; set; }
    public CharacterState State { get; set; }
    public CharacterAnimation Animation { get; set; }

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

    public void ChangeState(CharacterState state, CharacterDirection direction, bool moving) {
        State = state;

        switch (state) {
            case CharacterState.Moving:
            case CharacterState.Idle:
                ChangeMovingState(direction, moving);

                break;

            case CharacterState.Jumping:
                // Se não houve uma alteração na animação do pulo.
                if (!ChangeJumpingState(direction)) {
                    // Verifica se a animação terminou.
                    if (IsAnimationEnded()) {
                        State = CharacterState.JumpingCompleted;
                    }
                }

                break;

            case CharacterState.AttackingSword:
                if (!ChangeAttackingSwordState(direction)) {
                    // Verifica se a animação de pulo terminou.
                    if (IsAnimationEnded()) {
                        State = CharacterState.AttackingSwordCompleted;
                    }
                }

                break;

            case CharacterState.AttackingBow:
                if (!ChangeAttackingBowState(direction)) {
                    // Verifica se a animação de pulo terminou.
                    if (IsAnimationEnded()) {
                        State = CharacterState.AttackingBowCompleted;
                    }
                }

                break;

            case CharacterState.UsingShield:
                ChangeShieldState(direction);

                break;
        }
    }

    private void ChangeMovingState(CharacterDirection direction, bool moving) {
        var animation = CharacterAnimation.IdleDown;

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

    private bool ChangeJumpingState(CharacterDirection direction) {
        var animation = CharacterAnimation.JumpDown;

        switch (direction) {
            case CharacterDirection.Up:
            case CharacterDirection.UpRight:
            case CharacterDirection.UpLeft:
                animation = CharacterAnimation.JumpUp;
                break;

            case CharacterDirection.Down:
            case CharacterDirection.DownRight:
            case CharacterDirection.DownLeft:
                animation = CharacterAnimation.JumpDown;
                break;

            case CharacterDirection.Left:
                animation = CharacterAnimation.JumpLeft;
                break;

            case CharacterDirection.Right:
                animation = CharacterAnimation.JumpRight;
                break;
        }

        return ChangeAnimationState(animation);
    }

    private bool ChangeAttackingSwordState(CharacterDirection direction) {
        var animation = CharacterAnimation.SwordDown;

        switch (direction) {
            case CharacterDirection.Up:
            case CharacterDirection.UpRight:
            case CharacterDirection.UpLeft:
                animation = CharacterAnimation.SwordUp;
                break;

            case CharacterDirection.Down:
            case CharacterDirection.DownRight:
            case CharacterDirection.DownLeft:
                animation = CharacterAnimation.SwordDown;
                break;

            case CharacterDirection.Left:
                animation = CharacterAnimation.SwordLeft;
                break;

            case CharacterDirection.Right:
                animation = CharacterAnimation.SwordRight;
                break;
        }

        return ChangeAnimationState(animation);
    }

    private bool ChangeAttackingBowState(CharacterDirection direction) {
        var animation = CharacterAnimation.BowDown;

        switch (direction) {
            case CharacterDirection.Up:
            case CharacterDirection.UpRight:
            case CharacterDirection.UpLeft:
                animation = CharacterAnimation.BowUp;
                break;

            case CharacterDirection.Down:
            case CharacterDirection.DownRight:
            case CharacterDirection.DownLeft:
                animation = CharacterAnimation.BowDown;
                break;

            case CharacterDirection.Left:
                animation = CharacterAnimation.BowLeft;
                break;

            case CharacterDirection.Right:
                animation = CharacterAnimation.BowRight;
                break;
        }

        return ChangeAnimationState(animation);
    }

    private void ChangeShieldState(CharacterDirection direction) {
        var animation = CharacterAnimation.ShieldDown;

        switch (direction) {
            case CharacterDirection.Up:
            case CharacterDirection.UpRight:
            case CharacterDirection.UpLeft:
                animation = CharacterAnimation.ShieldUp;
                break;

            case CharacterDirection.Down:
            case CharacterDirection.DownRight:
            case CharacterDirection.DownLeft:
                animation = CharacterAnimation.ShieldDown;
                break;

            case CharacterDirection.Left:
                animation = CharacterAnimation.ShieldLeft;
                break;

            case CharacterDirection.Right:
                animation = CharacterAnimation.ShieldRight;
                break;
        }

        ChangeAnimationState(animation);
    }

    private bool ChangeAnimationState(CharacterAnimation newAnimation) {
        if (Animation == newAnimation) {
            return false;
        }

        Animator.Play(states[newAnimation]);
        Animation = newAnimation;

        return true;
    }

    private bool IsAnimationEnded() {
        return Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f;
    }
}