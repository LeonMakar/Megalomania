using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameToken : MonoBehaviour
{
    public Action OnGameTokenDestroy;
    private void OnDestroy()
    {
        OnGameTokenDestroy();
    }
}
