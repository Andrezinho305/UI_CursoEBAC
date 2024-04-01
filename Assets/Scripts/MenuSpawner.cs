using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuSpawner
{

#if UNITY_EDITOR

    [UnityEditor.MenuItem("EBAC/Test3 %u")]
    public static void Teste3()
    {
        Debug.Log("Spawn Something");
    }

#endif



}
