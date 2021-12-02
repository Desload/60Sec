using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    
    public static ItemAssets Instance { get; private set; }

    private ItemAssets()
    {

    }

    private void Awake()
    {
        Instance = this;
    }


    public Transform pfTransformItem;

    public Sprite GrenadeSprite, MolotovSprite, FlamethrowerSprite, BucketSprite, ShovelTripleSprite;

    public RuntimeAnimatorController GrenadeAnim, MolotovAnim, FlamethrowerAnim, BucketAnim, ShovelTripleAnim;
}

