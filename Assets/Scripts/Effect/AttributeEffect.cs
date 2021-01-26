public class AttributeEffect : Attribute {
    public int Id { get; set; }
    public string Name { get; set; }
    public int IconId { get; set; }
    public int Duration { get; set; }
    public bool RemoveOnDeath { get; set; }
    public bool Unlimited { get; set; }
    public bool Dispellable { get; set; }
    public AttributeEffectType EffectType { get; set; }
}