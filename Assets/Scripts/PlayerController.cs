using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    private InputSystem_Actions _input;

    private Item _obj;

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
            var hit = Physics2D.Raycast(_worldPosition, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Items"));

            if (hit.collider == null)
                return;

            Debug.Log(hit.collider.name);
            var item = hit.collider.GetComponent<Item>();

            if (item == null)
                return;

            Debug.Log("sss");
            _obj = item;
            _obj.Take();

            if (_obj is PlayableCard)
            {
                var card = _obj as PlayableCard;
                card.CardHolder().DeleteCard(card);
            }
        }

        if (_input.Player.Attack.WasReleasedThisFrame())
        {
            if (_obj == null)
                return;

            _obj.ResetSway();
            _obj.Release();
            
            var card = _obj as PlayableCard;

            _obj = null;

            if (card == null)
                return;

            Debug.Log("Возвращаю");
            card.CardHolder().AddCard(card);
            card.CardHolder().SortItems();
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