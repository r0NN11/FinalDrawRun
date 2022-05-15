using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerOnPathController : MonoBehaviour
{
    public UnityEvent<Animator> OnCollision { get; private set; } = new UnityEvent<Animator>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() & !gameObject.GetComponent<PlayerController>().enabled)
        {
            gameObject.GetComponent<PlayerController>().enabled = true;
            gameObject.GetComponent<PlayerDeathParticle>().enabled = true;
            gameObject.GetComponent<PlayerOnPathAnimation>().enabled = false;
            gameObject.AddComponent<PlayerAnimation>();
            gameObject.layer = other.gameObject.layer;
            gameObject.GetComponentInChildren<SkinnedMeshRenderer>().sharedMaterials = other.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().sharedMaterials;
            OnCollision?.Invoke(other.gameObject.GetComponent<Animator>());
        }
    }
    private void OnDestroy()
    {
        OnCollision.RemoveAllListeners();
    }
}
