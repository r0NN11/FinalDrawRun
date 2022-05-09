using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FinalParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _finalParticle;
    private GameRules _gameRules;
    private void Start()
    {
        _finalParticle = GetComponentInChildren<ParticleSystem>();
        _gameRules = FindObjectOfType<GameRules>();
        _gameRules.OnLevelEnd.AddListener(ActivateWithDelay);
    }
    private void ActivateFinalParticle()
    {
        float x, y, z;
        x = transform.position.x;
        y = Random.Range(8, 15);
        z = Random.Range(-5, 5);
        Vector3 pos = new Vector3(x, y, z);
        _finalParticle.transform.position = pos;
        _finalParticle.transform.rotation = Random.rotation;
        _finalParticle.Play();
    }
    private void ActivateWithDelay()
    {
        StartCoroutine(ActivatationDelay());
    }
    IEnumerator ActivatationDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.2f);
            ActivateFinalParticle();
        }
    }

}
