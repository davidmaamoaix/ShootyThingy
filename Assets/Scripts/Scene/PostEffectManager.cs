﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PostEffectManager: MonoBehaviour {

    [SerializeField]
    private Material motionBlur;

    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        Graphics.Blit(source, destination, this.motionBlur);
    }
}
