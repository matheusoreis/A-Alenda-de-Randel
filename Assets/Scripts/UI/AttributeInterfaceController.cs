using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttributeInterfaceController : MonoBehaviour {
    public Character Character { get; set; }

    public GameObject Panel;

    public Button ButtonStrength;
    public Button ButtonAgility;
    public Button ButtonConstitution;
    public Button ButtonIntelligence;

    public TMP_Text TextStrength;
    public TMP_Text TextAgility;
    public TMP_Text TextConstitution;
    public TMP_Text TextIntelligence;
    public TMP_Text TextPoints;

    public TMP_Text TextHP;
    public TMP_Text TextMP;
    public TMP_Text TextSP;
    public TMP_Text TextAttack;
    public TMP_Text TextDefense;
    public TMP_Text TextAccuracy;
    public TMP_Text TextEvasion;
    public TMP_Text TextBlock;
    public TMP_Text TextMagicAttack;
    public TMP_Text TextMagicDefense;
    public TMP_Text TextMagicAccuracy;
    public TMP_Text TextMagicResist;
    public TMP_Text TextAmplification;
    public TMP_Text TextCriticalRate;
    public TMP_Text TextCriticalDamage;
    public TMP_Text TextResistCriticalRate;
    public TMP_Text TextResistCriticalDamage;

    // Necessário atualizar o controle pelo update.
    // O método Start quando iniciado, não possui todas as referências dos controles do canvas.
    private bool alreadyUpdated;
    private bool visible = true;

    // Start is called before the first frame update
    void Start() {
        Character = FindObjectOfType(typeof(Character)) as Character;

        if (ButtonStrength != null) {
            ButtonStrength.onClick.AddListener(AddStrength);
        }

        if (ButtonAgility != null) {
            ButtonAgility.onClick.AddListener(AddAgility);
        }

        if (ButtonConstitution != null) {
            ButtonConstitution.onClick.AddListener(AddConstitution);
        }

        if (ButtonIntelligence != null) {
            ButtonIntelligence.onClick.AddListener(AddIntelligence);
        }

        if (Panel != null) {
            Panel.SetActive(visible);
        }
    }

    // Update is called once per frame
    void Update() {
        // Atualiza somente uma vez as informações na tela quando o jogo é iniciado.
        if (!alreadyUpdated) {
            alreadyUpdated = true;
            UpdateText();
        }

        if (Input.GetKeyDown(KeyCode.C)) {
            visible = !visible;
            Panel.SetActive(visible);
        }
    }

    private void AddStrength() {
        if (Character.AttributePoints > 0) {
            ++Character.Primary[(int)AttributeType.Strength];
            --Character.AttributePoints;

            Character.Allocate();
            UpdateText();
        }
    }

    private void AddAgility() {
        if (Character.AttributePoints > 0) {
            ++Character.Primary[(int)AttributeType.Agility];
            --Character.AttributePoints;

            Character.Allocate();
            UpdateText();
        }
    }

    private void AddConstitution() {
        if (Character.AttributePoints > 0) {
            ++Character.Primary[(int)AttributeType.Constitution];
            --Character.AttributePoints;

            Character.Allocate();
            UpdateText();
        }
    }

    private void AddIntelligence() {
        if (Character.AttributePoints > 0) {
            ++Character.Primary[(int)AttributeType.Intelligence];
            --Character.AttributePoints;

            Character.Allocate();
            UpdateText();
        }
    }

    private void UpdateText() {
        TextStrength.SetText("Força: " + Character.Attributes.Primary[(int)AttributeType.Strength]);
        TextAgility.SetText("Agilidade: " + Character.Attributes.Primary[(int)AttributeType.Agility]);
        TextConstitution.SetText("Constituição: " + Character.Attributes.Primary[(int)AttributeType.Constitution]);
        TextIntelligence.SetText("Inteligência: " + Character.Attributes.Primary[(int)AttributeType.Intelligence]);
        TextPoints.SetText("Pontos: " + Character.AttributePoints);

        var hp = Character.Attributes.Vital[(int)VitalType.HP];
        var mp = Character.Attributes.Vital[(int)VitalType.MP];
        var sp = Character.Attributes.Vital[(int)VitalType.SP];

        TextHP.SetText("HP: " + hp + " / " + hp);
        TextMP.SetText("MP: " + mp + " / " + mp);
        TextSP.SetText("SP: " + sp + " / " + sp);

        TextAttack.SetText("Ataque: " + Character.Attributes.Attack);
        TextDefense.SetText("Defesa: " + Character.Attributes.Defense);
        TextAccuracy.SetText("Precisão: " + Character.Attributes.Accuracy);
        TextEvasion.SetText("Evasão: " + Character.Attributes.Evasion);
        TextBlock.SetText("Bloqueio: " + Character.Attributes.Block);

        TextMagicAttack.SetText("Ataque Mágico: " + Character.Attributes.MagicAttack);
        TextMagicDefense.SetText("Defesa Mágica: " + Character.Attributes.MagicDefense);
        TextMagicAccuracy.SetText("Precisão Mágica: " + Character.Attributes.MagicAccuracy);
        TextMagicResist.SetText("Resistência Mágica: " + Character.Attributes.MagicResist);

        TextAmplification.SetText("Amplificação: " + Convert.ToInt32(Character.Attributes.Amplification * 100f) + "%");
        TextCriticalRate.SetText("Taxa Crítica: " + Convert.ToInt32(Character.Attributes.CritRate * 100f) + "%");
        TextCriticalDamage.SetText("Dano Crítico: " + Convert.ToInt32(Character.Attributes.CritDamage * 100f) + "%");
        TextResistCriticalRate.SetText("Resistência Taxa Crítica: " + Convert.ToInt32(Character.Attributes.ResistCritRate * 100f) + "%");
        TextResistCriticalDamage.SetText("Resistência Dano Crítico: " + Convert.ToInt32(Character.Attributes.ResistCritDamage * 100f) + "%");
    }
}