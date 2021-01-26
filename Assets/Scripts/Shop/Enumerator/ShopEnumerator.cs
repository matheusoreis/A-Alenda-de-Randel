using System.Collections;
using System.Collections.Generic;

public class ShopEnumerator : IEnumerator<ItemShop> {
    private const int Empty = -1;

    public ItemShop Current {
        get {
            return items[position];
        }
    }

    object IEnumerator.Current {
        get {
            return items[position];
        }
    }

    private int position = Empty;
    private readonly ItemShop[] items;

    public ShopEnumerator(ItemShop[] items) {
        this.items = items;
    }

    public void Dispose() {

    }

    public bool MoveNext() {
        ++position;
        return (position < items.Length);
    }

    public void Reset() {
        position = Empty;
    }
}