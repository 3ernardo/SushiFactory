using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltAnimator : MonoBehaviour
{
    public float beltAnimSpeed = 0.3f;
    public SkinnedMeshRenderer beltBand;

    private void animateBeltTexture() {
        float offset = Time.time * beltAnimSpeed;
        beltBand.material.SetTextureOffset("_MainTex", new Vector2 (0, offset));
    }

    void Update()
    {
        animateBeltTexture();
    }
}
