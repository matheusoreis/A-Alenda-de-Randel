using System.Collections;
using System.Collections.Generic;

public class Shop : IEnumerable<ItemShop> {
    public string Name { get; set; }

    public ItemShop[] Items { get; set; }

    public ItemShop this[int index] {
        get {
            return Items[index];
        }

        set {
            Items[index] = value;
        }
    }

    public Shop() {
        Items = new ItemShop[32];
    }

    public IEnumerator<ItemShop> GetEnumerator() {
        return new ShopEnumerator(Items);
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}