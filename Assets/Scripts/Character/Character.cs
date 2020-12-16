using System;
using UnityEngine;

public class Character : MonoBehaviour {
    public int Level { get; set; }
    public int AttributePoints { get; set; }
    public int[] Primary { get; set; }
    public Attribute Attributes { get; set; }
    public AttributeGrowth AttributeStyle { get; set; }

    private const float Speed = 5f;

    /// <summary>
    /// Controla a animação do personagem.
    /// </summary>
    private ICharacterAnimator animator;

    private CharacterDirection direction;
    private CharacterState state;

    private Rigidbody2D physics;

    public void Allocate() {
        Attributes.Clear();

        // Adiciona os atributos do personagem.
        for (var i = 0; i < Primary.Length; i++) {
            Attributes.Primary[i] += Primary[i];
        }

        // Adiciona os valores do estilo.
        Attributes.Allocate(AttributeStyle, AttributeSignal.Positive, 1);

        Attributes.Vital[(int)VitalType.HP] += AttributeStyle.GetMaxVital(Level, Attributes.Primary, VitalType.HP);
        Attributes.Vital[(int)VitalType.MP] += AttributeStyle.GetMaxVital(Level, Attributes.Primary, VitalType.MP);

        // Adiciona o restante com base no estilo.
        Attributes.Attack += AttributeStyle.GetAttack(Level, Attributes.Primary);
        Attributes.Defense += AttributeStyle.GetDefense(Level, Attributes.Primary);
        Attributes.Accuracy += AttributeStyle.GetAccuracy(Level, Attributes.Primary);
        Attributes.Evasion += AttributeStyle.GetEvasion(Level, Attributes.Primary);
        Attributes.Block += AttributeStyle.GetBlock(Level, Attributes.Primary);

        Attributes.MagicAttack += AttributeStyle.GetMagicAttack(Level, Attributes.Primary);
        Attributes.MagicDefense += AttributeStyle.GetMagicDefense(Level, Attributes.Primary);
        Attributes.MagicAccuracy += AttributeStyle.GetMagicAccuracy(Level, Attributes.Primary);
        Attributes.MagicResist += AttributeStyle.GetMagicResist(Level, Attributes.Primary);

        Attributes.CritRate += AttributeStyle.GetCriticalRate(Level, Attributes.Primary);
        Attributes.CritDamage += AttributeStyle.GetCriticalDamage(Level, Attributes.Primary);
        Attributes.ResistCritRate += AttributeStyle.GetResistCriticalRate(Level, Attributes.Primary);
        Attributes.ResistCritDamage += AttributeStyle.GetResistCriticalDamage(Level, Attributes.Primary);
    }

    void Start() {
        Primary = new int[Enum.GetValues(typeof(AttributeType)).Length];

        Attributes = new Attribute();
        AttributeStyle = AttributeParadigm.Balance;

        direction = CharacterDirection.Down;
        animator = new CharacterAnimator(GetComponent<Animator>());

        physics = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        state = GetState(x, y);
        direction = GetMovementDirection(x, y);

        var move = new Vector3(x, y, 0).normalized * Speed * Time.deltaTime;
        physics.MovePosition(transform.position + move);

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