using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnParticle : MonoBehaviour
{
    [FormerlySerializedAs("Particle")]public GameObject particle;

    public float angleEffect = 90f;
    public float delay = 1;
    public float minX = 0;

    public float maxX = 0;

    public float minZ = 0;

    public float maxZ = 0;

    private Vector3 randomPosition;
    private Vector3 position;
    
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        StartCoroutine(CreateParticle(delay));
    }

    private IEnumerator CreateParticle(float delay)
    {
        while (true)
        {
            randomPosition = new Vector3(position.x +Random.Range(minX, maxX), transform.position.y, position.z + Random.Range(minZ, maxZ));
            GameObject effect = Instantiate(particle, randomPosition, Quaternion.AngleAxis(angleEffect, Vector3.right));
            yield return new WaitForSeconds(delay);
            Destroy(effect);
            yield return new WaitForSeconds(delay);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        position = transform.position;
        Gizmos.DrawLine(position, new Vector3(position.x + maxX, position.y, position.z));
        Gizmos.DrawLine(position, new Vector3(position.x + minX, position.y, position.z));
        Gizmos.DrawLine(position, new Vector3(position.x, position.y, position.z + maxZ));
        Gizmos.DrawLine(position, new Vector3(position.x, position.y, position.z + minZ));
    }
}
