using UnityEngine;

public class AffectEmission : MonoBehaviour
{
    [Range(0, 10)]
    public float _maxIntensity, _minIntensity, _speed;
    private Material _sphere;

    private void Start()
    {
        _sphere = GetComponent<MeshRenderer>().material;
    }
    private void Update()
    {
        float emission = _minIntensity + Mathf.PingPong(Time.time * _speed, _maxIntensity - _minIntensity);
        Color finalColor = Color.white * Mathf.LinearToGammaSpace(emission);
        _sphere.SetColor("_EmissionColor", finalColor);
    }
}