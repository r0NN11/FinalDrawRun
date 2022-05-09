using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LevelEnd : MonoBehaviour
{
    public UnityEvent OnRoundFinal { get; private set; } = new UnityEvent();
    private bool islevelEnd;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() & !islevelEnd)
        {
            OnRoundFinal.Invoke();
            islevelEnd = true;
        }
    }
    public void EasyWin()
    {
        OnRoundFinal.Invoke();
    }
}
