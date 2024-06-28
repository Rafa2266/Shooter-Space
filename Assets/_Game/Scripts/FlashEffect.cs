using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float duration;
    private SpriteRenderer spriteRenderer;
    private Material defaultMaterial;
    private Coroutine flashCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer= this.GetComponentInChildren<SpriteRenderer>();
        defaultMaterial=spriteRenderer.material;
    }

    public void Flash()
    {
        if(flashCoroutine!= null)
        {
            StopCoroutine(flashCoroutine);
        }

        flashCoroutine = StartCoroutine(FlashCoroutine());
    }

    private IEnumerator FlashCoroutine()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = defaultMaterial;
        flashCoroutine= null;
    }

}
