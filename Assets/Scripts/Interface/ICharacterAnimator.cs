using UnityEngine;

public interface ICharacterAnimator {
    Animator Animator { get; set; }
    CharacterState GetState();
    CharacterAnimation GetAnimation();
    CharacterDirection GetDirection();

    void ChangeState(CharacterState state, CharacterDirection direction, bool moving);
}