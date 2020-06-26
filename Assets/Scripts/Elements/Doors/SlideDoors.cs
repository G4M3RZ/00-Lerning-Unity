using System.Collections.Generic;
using UnityEngine;

public class SlideDoors : MonoBehaviour
{
    [Range(0,5)]
    public float _openDistance;
    [Range(0,0.5f)]
    public float _openScale;
    [Range(0,5)]
    public float _speed;

    private List<GameObject> _doors;
    private Vector3 _startPos, _startScale;
    public bool _open;

    private void Start()
    {
        _doors = new List<GameObject>();
        
        for (int i = 0; i < transform.childCount; i++)
            _doors.Add(transform.GetChild(i).gameObject);

        _startPos = _doors[0].transform.localPosition;
        _startScale = _doors[0].transform.localScale;
    }

    private void Update()
    {
        if (_open)
            OpenDoors(_startPos.x, _openDistance, _openScale);
        else
            CloseDoors(_startPos.x, _startScale.x);
    }
    void OpenDoors(float pos, float separation, float newScale)
    {
        for (int i = 0; i < _doors.Count; i++)
        {
            SetValues(pos - separation, newScale, _doors[i].transform);
            pos = -pos;
            separation = -separation;
        }
    }
    void CloseDoors(float pos, float scale)
    {
        for (int i = 0; i < _doors.Count; i++)
        {
            SetValues(pos, scale, _doors[i].transform);
            pos = -pos;
        }
    }
    void SetValues(float posX, float scaleX, Transform doors)
    {
        Vector3 _pos = new Vector3(posX, _startPos.y, _startPos.z);
        Vector3 _scale = new Vector3(scaleX, _startScale.y, _startScale.z);

        doors.localPosition = Vector3.Lerp(doors.localPosition, _pos, Time.deltaTime * _speed);
        doors.localScale = Vector3.Lerp(doors.localScale, _scale, Time.deltaTime * _speed);
    }
}