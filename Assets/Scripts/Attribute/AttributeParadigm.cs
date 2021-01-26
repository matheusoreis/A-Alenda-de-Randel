public static class AttributeParadigm {
    private static AttributeGrowth balance;
    private static AttributeGrowth magician;
    private static AttributeGrowth swordmaster;
    private static AttributeGrowth royalguard;
    private static AttributeGrowth shooter;
    private static AttributeGrowth trickster;
    private static AttributeGrowth slayer;

    public static AttributeGrowth Balance {
        get {
            if (balance == null) {
                CreateParadigmBalance();
            }

            return balance;
        }
    }

    public static AttributeGrowth Magician {
        get {
            if (magician == null) {
                magician = new AttributeGrowth();
            }

            return magician;
        }
    }

    public static AttributeGrowth Swordmaster {
        get {
            if (swordmaster == null) {
                swordmaster = new AttributeGrowth();
            }

            return swordmaster;
        }
    }

    public static AttributeGrowth RoyalGuard {
        get {
            if (royalguard == null) {
                royalguard = new AttributeGrowth();
            }

            return royalguard;
        }
    }

    public static AttributeGrowth Shooter {
        get {
            if (shooter == null) {
                shooter = new AttributeGrowth();
            }

            return shooter;
        }
    }

    public static AttributeGrowth Trickster {
        get {
            if (trickster == null) {
                trickster = new AttributeGrowth();
            }

            return trickster;
        }
    }

    public static AttributeGrowth Slayer {
        get {
            if (slayer == null) {
                slayer = new AttributeGrowth();
            }

            return slayer;
        }
    }

    private static void CreateParadigmBalance() {
        balance = new AttributeGrowth() {
            Name = "Balance",
            Attack = 9,
            Defense = 5,
            Accuracy = 5,
            Evasion = 3,
            Block = 1,
            MagicAttack = 9,
            MagicDefense = 5,
            MagicAccuracy = 5,
            MagicResist = 3,
            CritRate = 0.5f,
            CritDamage = 0.5f,
            ResistCritRate = 0.1f,
            ResistCritDamage = 0.1f,
            Amplification = 0.9f
        };

        balance.Vital[(int)VitalType.HP] = 100;
        balance.Vital[(int)VitalType.MP] = 100;
        balance.Vital[(int)VitalType.SP] = 100;

        balance.Primary[(int)AttributeType.Strength] = 10;
        balance.Primary[(int)AttributeType.Agility] = 10;
        balance.Primary[(int)AttributeType.Constitution] = 10;
        balance.Primary[(int)AttributeType.Intelligence] = 10;

        balance.IncrementMaxHp = new int[] { 10, 0, 0, 5, 0 };
        balance.IncrementMaxMp = new int[] { 10, 0, 0, 0, 5 };
        balance.IncrementAttack = new int[] { 5, 4, 0, 0, 0 };
        balance.IncrementDefense = new int[] { 2, 0, 0, 3, 0 };
        balance.IncrementAccuracy = new int[] { 7, 0, 8, 0, 0 };
        balance.IncrementEvasion = new int[] { 3, 0, 4, 0, 0 };
        balance.IncrementBlock = new int[] { 10, 8, 0, 1, 0 };
        balance.IncrementMagicAttack = new int[] { 10, 0, 0, 0, 5 };
        balance.IncrementMagicDefense = new int[] { 8, 0, 0, 1, 5 };
        balance.IncrementMagicAccuracy = new int[] { 5, 0, 5, 0, 1 };
        balance.IncrementMagicResist = new int[] { 10, 0, 0, 1, 4 };
        balance.IncrementCritRate = new float[] { 0.001f, 0, 0.001f, 0, 0 };
        balance.IncrementCritDamage = new float[] { 0.001f, 0.001f, 0, 0, 0.001f };
        balance.IncrementResistCritRate = new float[] { 0.001f, 0.001f, 0.001f, 0.001f, 0.001f };
        balance.IncrementResistCritDamage = new float[] { 0.001f, 0.001f, 0.001f, 0.001f, 0.001f };
    }
}