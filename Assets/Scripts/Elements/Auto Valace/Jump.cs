using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(0,10)]
    public float _jumpForce;
    private Rigidbody _rgb;
    private AutoValace _autoValance;
    private bool _jump;

    private void Awake()
    {
        _rgb = GetComponent<Rigidbody>();
        _autoValance = GetComponent<AutoValace>();
    }
    void Update()
    {
        if (!_jump)
        {
            _autoValance.Valance(transform.localPosition);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rgb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
                _jump = true;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (_jump)
            _jump = false;
    }
}