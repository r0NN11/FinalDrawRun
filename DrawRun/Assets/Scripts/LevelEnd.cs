using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LevelEnd : MonoBehaviour
{
    public UnityEvent OnRoundFinal { get; private set; } = new UnityEvent();
    private bool _islevelEnd;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() & !_islevelEnd)
        {
            OnRoundFinal?.Invoke();
            _islevelEnd = true;
        }
    }
    public void EasyWin()
    {
        OnRoundFinal?.Invoke();
    }
}
