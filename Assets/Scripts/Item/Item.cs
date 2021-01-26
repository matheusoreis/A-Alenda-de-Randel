public class Item : Attribute {
    public int Id { get; set; }
    public int Level { get; set; }
    public int IconId { get; set; }
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public ItemRarityType Rarity { get; set; }
    public int Price { get; set; }
    public bool Stackable { get; set; }
}