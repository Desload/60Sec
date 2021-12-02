using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ManualClear
{
    void Clear();
}

public interface ThrowClear
{
    void Clear();
}
public abstract class Weapon
{
    private int efficiency;
    private int maxBlocksClear;
}
