using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObject : MonoBehaviour
{
    protected Manager manager;

    [Header("Pooling Object")]
    [SerializeField] private float scrollbackModifier;
    [SerializeField] private int id;

    public virtual float Width { get; }
    public virtual float Height { get; }
    public int ID => id;
    public Manager AssociatedManager { set { manager = value; } }


    // Start is called before the first frame update
    protected virtual void Start() { }

    // Update is called once per frame
    protected virtual void Update()
    {
        ScrollBack();
        DestroyOnOutOfBounds();
    }

    protected void DestroyOnOutOfBounds()
    {
        if (transform.position.x + Width / 2 < GameManager.ScreenWidth * -0.55f)
            if (manager)
                manager.ReturnItem(this);
            else
                Destroy(gameObject);
        if (transform.position.y + Height < GameManager.ScreenHeight / -2)
            if (manager)
                manager.ReturnItem(this);
            else
                Destroy(gameObject);
    }

    protected void ScrollBack()
    {
        transform.position += scrollbackModifier * GameManager.Instance.ScrollBackSpeed * Time.deltaTime * Vector3.left;
    }
}
