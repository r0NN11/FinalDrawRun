using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInRelease : MonoBehaviour
{
#if !DEBUG
    private void Awake() {
        Destroy(gameObject);
    }
#endif
}

