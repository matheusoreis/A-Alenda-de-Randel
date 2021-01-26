using System;
public class AttributeGrowth : Attribute {
    public string Name { get; set; }
    public int[] IncrementMaxHp { get; set; }
    public int[] IncrementMaxMp { get; set; }
    public int[] IncrementAttack { get; set; }
    public int[] IncrementDefense { get; set; }
    public int[] IncrementAccuracy { get; set; }
    public int[] IncrementEvasion { get; set; }
    public int[] IncrementBlock { get; set; }
    public int[] IncrementMagicAttack { get; set; }
    public int[] IncrementMagicDefense { get; set; }
    public int[] IncrementMagicAccuracy { get; set; }
    public int[] IncrementMagicResist { get; set; }
    public float[] IncrementCritRate { get; set; }
    public float[] IncrementCritDamage { get; set; }
    public float[] IncrementResistCritRate { get; set; }
    public float[] IncrementResistCritDamage { get; set; }

    private readonly int length;

    public AttributeGrowth() : base() {
        var iLength = Enum.GetValues(typeof(AttributeGrowthType)).Length;
        length = Enum.GetValues(typeof(AttributeType)).Length;

        IncrementMaxHp = new int[iLength];
        IncrementMaxMp = new int[iLength];
        IncrementAttack = new int[iLength];
        IncrementDefense = new int[iLength];
        IncrementAccuracy = new int[iLength];
        IncrementEvasion = new int[iLength];
        IncrementBlock = new int[iLength];

        IncrementMagicAttack = new int[iLength];
        IncrementMagicDefense = new int[iLength];
        IncrementMagicAccuracy = new int[iLength];
        IncrementMagicResist = new int[iLength];

        IncrementCritRate = new float[iLength];
        IncrementCritDamage = new float[iLength];
        IncrementResistCritRate = new float[iLength];
        IncrementResistCritDamage = new float[iLength];
    }

    public int GetMaxVital(int level, int[] stats, VitalType vitalType) {
        int[] values = null;

        if (vitalType == VitalType.HP) {
            values = IncrementMaxHp;
        }
        else if (vitalType == VitalType.MP) {
            values = IncrementMaxMp;
        }

        int value = level * values[(int)AttributeGrowthType.Level];

        for (var i = 1; i <= length; i++) {
            value += values[i] * stats[i - 1];
        }

        return value;
    }

    public int GetAttack(int level, int[] stats) {
        int value = level * IncrementAttack[(int)AttributeGrowthType.Level];

        for (var i = 1; i <= length; i++) {
            value += IncrementAttack[i] * stats[i - 1];
        }

        return value;
    }

    public int GetDefense(int level, int[] stats) {
        int value = level * IncrementDefense[(int)AttributeGrowthType.Level];

        for (var i = 1; i <= length; i++) {
            value += IncrementDefense[i] * stats[i - 1];
        }

        return value;
    }

    public int GetAccuracy(int level, int[] stats) {
        int value = level * IncrementAccuracy[(int)AttributeGrowthType.Level];

        for (var i = 1; i <= length; i++) {
            value += IncrementAccuracy[i] * stats[i - 1];
        }

        return value;
    }

    public int GetEvasion(int level, int[] stats) {
        int value = level * IncrementEvasion[(int)AttributeGrowthType.Level];

        for (var i = 1; i <= length; i++) {
            value += IncrementEvasion[i] * stats[i - 1];
        }

        return value;
    }

    public int GetBlock(int level, int[] stats) {
        int value = level * IncrementBlock[(int)AttributeGrowthType.Level];

        for (var i = 1; i <= length; i++) {
            value += IncrementBlock[i] * stats[i - 1];
        }

        return value;
    }

    public int GetMagicAttack(int level, int[] stats) {
        int value = level * IncrementMagicAttack[(int)AttributeGrowthType.Level];

        for (var i = 1; i <= length; i++) {
            value += IncrementMagicAttack[i] * stats[i - 1];
        }

        return value;
    }

    public int GetMagicDefense(int level, int[] stats) {
        int value = level * IncrementMagicDefense[(int)AttributeGrowthType.Level];

        for (var i = 1; i <= length; i++) {
            value += IncrementMagicDefense[i] * stats[i - 1];
        }

        return value;
    }

    public int GetMagicAccuracy(int level, int[] stats) {
        int value = level * IncrementMagicAccuracy[(int)AttributeGrowthType.Level];

        for (var i = 1; i <= length; i++) {
            value += IncrementMagicAccuracy[i] * stats[i - 1];
        }

        return value;
    }

    public int GetMagicResist(int level, int[] stats) {
        int value = level * IncrementMagicResist[(int)AttributeGrowthType.Level];

        for (var i = 1; i <= length; i++) {
            value += IncrementMagicResist[i] * stats[i - 1];
        }

        return value;
    }

    public float GetCriticalRate(int level, int[] stats) {
        float value = level * IncrementCritRate[(int)AttributeGrowthType.Level];

        for (var i = 1; i <= length; i++) {
            value += IncrementCritRate[i] * stats[i - 1];
        }

        return value;
    }

    public float GetCriticalDamage(int level, int[] stats) {
        float value = level * IncrementCritDamage[(int)AttributeGrowthType.Level];

        for (var i = 1; i <= length; i++) {
            value += IncrementCritDamage[i] * stats[i - 1];
        }

        return value;
    }

    public float GetResistCriticalRate(int level, int[] stats) {
        float value = level * IncrementResistCritRate[(int)AttributeGrowthType.Level];

        for (var i = 1; i <= length; i++) {
            value += IncrementResistCritRate[i] * stats[i - 1];
        }

        return value;
    }

    public float GetResistCriticalDamage(int level, int[] stats) {
        float value = level * IncrementResistCritDamage[(int)AttributeGrowthType.Level];

        for (var i = 1; i <= length; i++) {
            value += IncrementResistCritDamage[i] * stats[i - 1];
        }

        return value;
    }

}