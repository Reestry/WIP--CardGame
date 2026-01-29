using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    private InputSystem_Actions _input;

    private Card _obj;

    private Vector2 _mousePos;

    private Vector3 _worldPosition;

    void Start()
    {
        _input = new InputSystem_Actions();

        _input.Enable();
    }

    private Vector2 _mouseForce;

    void Update()
    {
        _mousePos = _input.Player.MousePos.ReadValue<Vector2>();
        _mouseForce = _input.Player.MouseForce.ReadValue<Vector2>();

        _worldPosition = _cam.ScreenToWorldPoint(_mousePos);

        if (_input.Player.Attack.WasPressedThisFrame())
        {
            var hit = Physics2D.Raycast(_worldPosition, Vector2.zero);

            if (hit.collider == null)
                return;

            var card = hit.collider.GetComponent<Card>();
            Debug.Log("sss");
            _obj = card;
            _obj.Take();
        }

        if (_input.Player.Attack.WasReleasedThisFrame())
        {
            _obj?.ResetSway();
            _obj?.Release();
            _obj = null;
        }

        if (_obj != null)
        {
            _worldPosition.z = 0;

            _obj.gameObject.transform.position = Vector3.Lerp(_obj.gameObject.transform.position, _worldPosition,
                5 * Time.deltaTime);

            _obj.SetSwayAngle(_mouseForce);
        }
    }
}