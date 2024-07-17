using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject[] parts;
    [SerializeField] private float minForce, maxForce;

    public void Explode(Transform target,AudioClip deathAudio)
    {
        for(int i=0;i<parts.Length;i++)
        {
            this.gameObject.GetComponent<AudioSource>().clip = deathAudio;
            this.gameObject.GetComponent<AudioSource>().Play();
            GameObject tempParts = Instantiate(parts[i],target.position,Quaternion.identity) as GameObject;
            Rigidbody2D rbParts = tempParts.gameObject.GetComponent<Rigidbody2D>();
            rbParts.AddForce(new Vector2(Random.Range( minForce,maxForce), Random.Range(minForce, maxForce)),ForceMode2D.Impulse);
            Destroy(tempParts.gameObject,5f);
        }
    }
}
