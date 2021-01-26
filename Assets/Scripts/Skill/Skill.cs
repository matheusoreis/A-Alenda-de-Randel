public class Skill {
    public int Id { get; set; }
    public string Name { get; set; }
    public SkillType Type { get; set; }
    public SkillAttributeType AttributeType { get; set; }
    public SkillCostType CostType { get; set; }
    public ElementType ElementType { get; set; }
    public int MaximumLevel { get; set; }
    public float Amplification { get; set; }
    public float AmplificationPerLevel { get; set; }
    public int Cost { get; set; }
    public int CostPerLevel { get; set; }
}