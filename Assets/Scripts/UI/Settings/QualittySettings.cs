using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class QualittySettings : MonoBehaviour
{
    public RenderPipelineAsset _render;
    List<Slider> _vales;

    private void Awake()
    {
        _vales = new List<Slider>();

        for (int i = 0; i < transform.childCount; i++)
            _vales.Add(transform.GetChild(i).GetComponent<Slider>());
    }
}