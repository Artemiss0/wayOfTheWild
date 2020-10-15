using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Collider _boxCollider;
    private bool _clickable = false;

    [Header("Destroyable Object")]
    public bool isDestroyable;
    public float HitDistance;

    private void Awake()
    {
        _boxCollider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (!isDestroyable)
        {
            return;
        }

        if (Physics.BoxCast(_boxCollider.bounds.center, transform.localScale, transform.forward, out hit, transform.rotation, HitDistance) && !_clickable)
        {
            _clickable = true;
        }

        if (!hit.collider && _clickable)
        {
            _clickable = false;
        }
    }

    private void OnMouseDown()
    {
        if (_clickable && isDestroyable)
        {
            Destroy(this.gameObject);
        }
    }
}
