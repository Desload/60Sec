using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{    
    public enum ItemType
    {
        Grenade, //stack
        Molotov, //stack
        Flamethrower,
        Bucket,
        ShovelTriple
    }

    public ItemType itemType;
    public int amount;

    public bool IsStackable()
    {
        switch (itemType)
        {
            default: return false;
            case ItemType.Grenade:
            case ItemType.Molotov:
                return true;
        }        
    }

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default: return null;
            case ItemType.ShovelTriple: return ItemAssets.Instance.ShovelTripleSprite;
            case ItemType.Bucket: return ItemAssets.Instance.BucketSprite;
            case ItemType.Flamethrower: return ItemAssets.Instance.FlamethrowerSprite;
            case ItemType.Molotov: return ItemAssets.Instance.MolotovSprite;
            case ItemType.Grenade: return ItemAssets.Instance.GrenadeSprite;
        }
    }

    public RuntimeAnimatorController GetAnimator()
    {
        return null;
    }
}
