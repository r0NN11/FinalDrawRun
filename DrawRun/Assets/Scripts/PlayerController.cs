using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    private ObjectPlacer _objectPlacer;
    public UnityEvent OnDeathEvent { get; private set; } = new UnityEvent();
    public UnityEvent OnFireDeathEvent { get; private set; } = new UnityEvent();
    private void Start()
    {
        _objectPlacer = FindObjectOfType<ObjectPlacer>();
        _objectPlacer.AddPlayerObject(gameObject);
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        transform.eulerAngles = new Vector3(0, 90, 0);
    }
    public void Death()
    {
        OnDeathEvent.Invoke();
        SetRigidbodyKinematic(false);
        SetColliderEnablement(true);
        _objectPlacer.RemovePlayerObjects(gameObject);
    }
    public void DeathSeveral()
    {
        OnDeathEvent?.Invoke();
        _objectPlacer.RemoveAndDestroySeveralObjects(gameObject);
    }
    public void FireDeath()
    {
        OnFireDeathEvent?.Invoke();
        StartCoroutine(DestroyWithDelay());
    }
    IEnumerator DestroyWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
            _objectPlacer.RemovePlayerObjects(gameObject);
        }
    }
    private void SetRigidbodyKinematic(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rg in rigidbodies)
        {
            rg.isKinematic = state;
        }
        GetComponent<Rigidbody>().isKinematic = !state;
    }
    private void SetColliderEnablement(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider cr in colliders)
        {
            cr.enabled = state;
        }
        GetComponent<Collider>().enabled = !state;
    }
}
