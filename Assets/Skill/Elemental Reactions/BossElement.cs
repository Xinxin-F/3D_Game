using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossElement : MonoBehaviour
{
    private int fireHits = 0;
    private int waterHits = 0;

    // Materials for different states
    [SerializeField] private Material initialMaterial;
    [SerializeField] private Material fireMaterial;
    [SerializeField] private Material waterMaterial;

    private Renderer bossRenderer;

    void Start()
    {
        bossRenderer = GetComponent<Renderer>();
        
        // Set the initial material
        bossRenderer.material = initialMaterial;
    }

    public void OnHit(BulletType bulletType)
    {
        if (bulletType == BulletType.FIRE)
        {
            fireHits++;
        }
        else if (bulletType == BulletType.WATER)
        {
            waterHits++;
        }

        UpdateMaterial();
    }

    // Update the material of the boss based on hits
    private void UpdateMaterial()
    {
        if (fireHits > waterHits)
        {
            bossRenderer.material = fireMaterial;
        }
        else if (waterHits > fireHits)
        {
            bossRenderer.material = waterMaterial;
        }
        else
        {
            bossRenderer.material = initialMaterial;
        }
    }
}