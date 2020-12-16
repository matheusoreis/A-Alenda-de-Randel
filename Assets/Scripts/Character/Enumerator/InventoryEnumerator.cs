using System.Collections;
using System.Collections.Generic;

public class InventoryEnumerator : IEnumerator<Inventory> {
    private const int Empty = -1;

    public Inventory Current {
        get {
            return inventories[position];
        }
    }

    object IEnumerator.Current {
        get {
            return inventories[position];
        }
    }

    private int position = Empty;
    private readonly Inventory[] inventories;

    public InventoryEnumerator(Inventory[] inventories) {
        this.inventories = inventories;
    }

    public void Dispose() {

    }

    public bool MoveNext() {
        ++position;
        return (position < inventories.Length);
    }

    public void Reset() {
        position = Empty;
    }
}