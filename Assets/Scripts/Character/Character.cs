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
    private bool isJumped;
    private bool isAttackingWithSword;
    private bool isAttackingWithBow;
    private bool isShieldPressed;
    private bool canMove = true;

    private float x;
    private float y;

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
        AttributePoints = 5000;
        Level = 1;

        Allocate();

        direction = CharacterDirection.Down;
        animator = new CharacterAnimator(GetComponent<Animator>());
        physics = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump")) {
            // Não permite que pule com oturas animações acontecendo.
            if (!isShieldPressed && !isAttackingWithSword && !isAttackingWithBow) {
                isJumped = true;
            }
        }

        if (Input.GetButtonDown("Fire1")) {
            // Somente permite atacar enquanto está no chão e sem escudo.
            // Não há animações do personagem atacando no ar.
            if (!isJumped && !isShieldPressed) {
                isAttackingWithSword = true;
                canMove = false;
            }
        }

        if (Input.GetButtonDown("Fire2")) {
            // Somente permite atacar enquanto está no chão e sem escudo.
            // Não há animações do personagem atacando no ar.
            if (!isJumped && !isShieldPressed) {
                isAttackingWithBow = true;
                canMove = false;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            // Somente permite atacar enquanto está no chão.
            // Não há animações do personagem atacando no ar.
            if (!isJumped) {
                isShieldPressed = true;

                // Assim que o escudo for sacado, desabilita os ataques.
                isAttackingWithBow = false;
                isAttackingWithSword = false;
                canMove = false;
            }
        }
        else {
            isShieldPressed = false;

            // Só permite andar novamente se não estiver atacando com a espada E com o arco.
            if (!isAttackingWithSword && !isAttackingWithBow) {
                canMove = true;
            }
        }

        // Obtem a direção do personagem.
        // Somente troca de direção enquanto não está pulando ou atacando.
        // A animação fica presa quando no momento do pulo ou ataque a direção for alterada várias vezes.

        // Mas permite trocar de posição enquanto está com o escudo.
        if (!isJumped && !isAttackingWithSword && !isAttackingWithBow) {
            direction = GetMovementDirection(x, y);
        }

        // Define o estado do personagem.
        ChangeState(x, y);
    }

    private void FixedUpdate() {
        // Move o personagem.
        // Unity moves a Rigidbody in each FixedUpdate call
        if (canMove) {
            Move(x, y);
        }
    }

    private void Move(float x, float y) {
        var move = new Vector3(x, y, 0).normalized * Speed * Time.deltaTime;
        physics.MovePosition(transform.position + move);
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

    private void ChangeState(float x, float y) {
        // Se a animação de pulo terminar, devolve para o estado antigo.
        if (animator.State == CharacterState.JumpingCompleted) {
            isJumped = false;
        }

        if (animator.State == CharacterState.AttackingBowCompleted ) {
            isAttackingWithBow = false;
            canMove = true;
        }

        if (animator.State == CharacterState.AttackingSwordCompleted) {
            isAttackingWithSword = false;
            canMove = true;
        }

        state = CharacterState.Idle;

        if (canMove) {
            // Se estiver movendo-se e não estiver pulando.
            if (x != 0 || y != 0 && !isJumped) {
                state = CharacterState.Moving;
            }
        }

        // Se estiver pulando.
        if (isJumped) {
            state = CharacterState.Jumping;
        }

        if (isAttackingWithSword) {
            state = CharacterState.AttackingSword;
        }

        if (isAttackingWithBow) {
            state = CharacterState.AttackingBow;
        }

        if (isShieldPressed) {
            state = CharacterState.UsingShield;
        }

        animator.ChangeState(state, direction, (x != 0 || y != 0));
    }
}