using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Postprocessing1 : MonoBehaviour
{

    [SerializeField] private PostProcessVolume volume;
    private Vignette _vignette;

    private void Start()
    {
        volume.profile.TryGetSettings(out _vignette);
        _vignette.intensity.value = 0.513f;
    }



}
