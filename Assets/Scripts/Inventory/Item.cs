using System.Collections;
using System.Collections.Generic;

public enum ItemType
{
    Weapon = 0,
    Potion = 1,
}
public class Item 
{
    public ItemType type;
    public int amount;
}
