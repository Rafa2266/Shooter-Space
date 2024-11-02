using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject[] parts;
    [SerializeField] private float minForce, maxForce;
    private GameController gameController;

    public void Start()
    {
       gameController= FindObjectOfType<GameController>();

    }
    public void Explode(Transform target,AudioClip deathAudio)
    {
        GameData gameData= FindObjectOfType<GameData>();
        if(gameData.soundOnOff)
        {
            this.gameObject.GetComponent<AudioSource>().clip = deathAudio;
            this.gameObject.GetComponent<AudioSource>().Play();
        }
        for(int i=0;i<parts.Length;i++)
        {
            GameObject tempParts = Instantiate(parts[i],target.position,Quaternion.identity) as GameObject;
            tempParts.transform.parent = gameController.allParts;
            Rigidbody2D rbParts = tempParts.gameObject.GetComponent<Rigidbody2D>();
            rbParts.AddForce(new Vector2(Random.Range( minForce,maxForce), Random.Range(minForce, maxForce)),ForceMode2D.Impulse);
            Destroy(tempParts.gameObject,5f);
        }
    }
}
