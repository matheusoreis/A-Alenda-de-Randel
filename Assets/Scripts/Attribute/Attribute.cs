using System;
public class Attribute {
    public int[] Primary { get; set; }
    public int[] Vital { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Accuracy { get; set; }
    public int Evasion { get; set; }
    public int Block { get; set; }

    public int MagicAttack { get; set; }
    public int MagicDefense { get; set; }
    public int MagicAccuracy { get; set; }
    public int MagicResist { get; set; }

    public float CritRate { get; set; }
    public float CritDamage { get; set; }
    public float ResistCritRate { get; set; }
    public float ResistCritDamage { get; set; }

    public float Amplification { get; set; }

    public Attribute() {
        Vital = new int[Enum.GetValues(typeof(VitalType)).Length];
        Primary = new int[Enum.GetValues(typeof(AttributeType)).Length];
    }

    public void Clear() {
        Array.Clear(Primary, 0, Primary.Length);
        Array.Clear(Vital, 0, Vital.Length);

        Attack = 0;
        Defense = 0;
        Accuracy = 0;
        Evasion = 0;
        Block = 0;

        MagicAttack = 0;
        MagicDefense = 0;
        MagicAccuracy = 0;
        MagicResist = 0;

        CritRate = 0;
        CritDamage = 0;
        ResistCritRate = 0;
        ResistCritDamage = 0;

        Amplification = 0;
    }

    public void Allocate(Attribute attributes, AttributeSignal signal, int level) {
        for (var i = 0; i < Enum.GetValues(typeof(VitalType)).Length; i++) {
            Vital[i] += (int)signal * (level * attributes.Vital[i]);
        }

        for (var i = 0; i < Enum.GetValues(typeof(AttributeType)).Length; i++) {
            Primary[i] += (int)signal * (level * attributes.Primary[i]);
        }

        Attack += (int)signal * (level * attributes.Attack);
        Defense += (int)signal * (level * attributes.Defense);
        Accuracy += (int)signal * (level * attributes.Accuracy);
        Evasion += (int)signal * (level * attributes.Evasion);
        Block += (int)signal * (level * attributes.Block);

        MagicAttack += (int)signal * (level * attributes.MagicAttack);
        MagicDefense += (int)signal * (level * attributes.MagicDefense);
        MagicAccuracy += (int)signal * (level * attributes.MagicAccuracy);
        MagicResist += (int)signal * (level * attributes.MagicResist);

        CritRate += (int)signal * (level * attributes.CritRate);
        CritDamage += (int)signal * (level * attributes.CritDamage);
        ResistCritRate += (int)signal * (level * attributes.ResistCritRate);
        ResistCritDamage += (int)signal * (level * attributes.ResistCritDamage);

        Amplification += (int)signal * (level * attributes.Amplification);
    }
}