using UnityEngine;

public interface ICharacterAnimator {
    Animator Animator { get; set; }
    CharacterState State { get; set; }
    CharacterAnimation Animation { get; set; }

    void ChangeState(CharacterState state, CharacterDirection direction, bool moving);
}