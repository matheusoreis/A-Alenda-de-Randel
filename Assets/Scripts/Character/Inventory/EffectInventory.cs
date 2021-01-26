using System.Collections;
using System.Collections.Generic;

public class EffectInventory : Attribute, IEnumerable<Inventory> {
    private const int NotFound = -1;

    private readonly Inventory[] inventories;

    public Inventory this[int index] {
        get {
            return inventories[index];
        }

        set {
            inventories[index] = value;
        }
    }

    public int Count {
        get {
            return inventories.Length;
        }
    }

    public EffectInventory() {
        inventories = new Inventory[32];
    }

    public bool Add(Inventory inventory) {
        var index = FindEffectIndex(inventory.Id);
        var result = false;

        // Se não encontrar a conquista.
        if (index == NotFound) {
            // Procura por um slot vazio e adiciona.
            index = FindEmptyIndex();

            if (index > NotFound) {
                result = true;
                inventories[index] = inventory;
            }
        }
        else {
            var old = inventories[index];

            inventories[index] = new Inventory() {
                Id = old.Id,
                Value = old.Value + inventory.Value,
                Level = old.Level + inventory.Level
            };
        }

        return result;
    }

    public void Remove(Inventory inventory) {
        var index = FindEffectIndex(inventory.Id);

        if (index != NotFound) {
            inventories[index] = new Inventory();
        }
    }

    private int FindEmptyIndex() {
        for (var i = 0; i < inventories.Length; i++) {
            if (inventories[i].Id == 0) {
                return i;
            }
        }

        return NotFound;
    }

    private int FindEffectIndex(int id) {
        for (var i = 0; i < inventories.Length; i++) {
            if (inventories[i].Id == id) {
                return i;
            }
        }

        return NotFound;
    }

    public void AllocateAttributes() {
        Clear();

        for (var i = 0; i < inventories.Length; i++) {
            // Allocate(equipments[i], AttributeSignal.Positive, 1);          
        }
    }

    public IEnumerator<Inventory> GetEnumerator() {
        return new InventoryEnumerator(inventories);
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}
