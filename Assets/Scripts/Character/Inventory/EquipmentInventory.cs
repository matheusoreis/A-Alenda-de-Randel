using System;
using System.Collections;
using System.Collections.Generic;
public class EquipmentInventory : Attribute, IEnumerable<Inventory> {
    private readonly Inventory[] equipments;

    public Inventory this[EquipmentType equipmentType] {
        get {
            return equipments[(int)equipmentType];
        }

        set {
            equipments[(int)equipmentType] = value;
        }
    }

    public int Count {
        get {
            return equipments.Length;
        }
    }

    public EquipmentInventory() {
        equipments = new Inventory[Enum.GetValues(typeof(EquipmentType)).Length];
    }

    public void AllocateAttributes() {
        Clear();

        for (var i = 0; i < equipments.Length; i++) {
            // Allocate(equipments[i], AttributeSignal.Positive, 1);          
        }
    }

    public IEnumerator<Inventory> GetEnumerator() {
        return new InventoryEnumerator(equipments);
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}