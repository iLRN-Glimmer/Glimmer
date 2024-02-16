using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class postprocessingcontrol : MonoBehaviour
{
    [SerializeField] private Volume postProcessingVolume;
    [SerializeField] private bool disable;

    [Header("Post P4rocessing Profiles")]
    [SerializeField] private VolumeProfile postProfileMain;
    [SerializeField] private VolumeProfile postProfileSecondary;

    [Header("Post Processing Effects")]
    private Bloom _bloom;

    private void Start()
    {
        postProcessingVolume.profile.TryGet(out _bloom);
    }
    public void MainPostProcess()
    {
        postProcessingVolume.profile = postProfileMain;
    }
    public void SecondaryPostProcess()
    {
        postProcessingVolume.profile = postProfileMain;
    }

    public void DisablePostProcessing()
    {
        disable = !disable;
        postProcessingVolume.enabled = disable;
    }

    private void AdjustBloom()
    {
        _bloom.intensity.value = 10f;
    }
}
