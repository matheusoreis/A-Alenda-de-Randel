using UnityEngine;

public interface ICharacterAnimator {
    Animator Animator { get; set; }
    CharacterAnimation Animation { get; set; }
    CharacterState State { get; set; }
    void ChangeState(CharacterDirection direction, bool moving);
}