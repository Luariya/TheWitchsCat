using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;
    public Animator animator;
    public Inventory inventory;
    //private Animator animator;
    

    Vector2 movement;

    

   private void Start()
    {
        // animator = GetComponent<Animator>();
       
    }

    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        IInventoryItem item = e.Item;

    }

    private void Update()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            //animator.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
           // animator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
           // animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
           // animator.SetInteger("Direction", 0);
        }

        dir.Normalize();
       // animator.SetBool("IsMoving", dir.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = speed * dir;
        //transform.position += (Vector3)dir * speed * Time.deltaTime;


        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetMouseButtonDown(0))  // Check for left mouse button click
        {
            // Cast a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Check if an item was hit
            if (hit.collider != null)
            {
                IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
                if (item != null)
                {
                    inventory.AddItem(item);
                    Debug.Log("Item picked up");

                    collectionSoundEffect.Play();

                    return;
                }

                Activatable activatable = hit.collider.GetComponent<Activatable>();

                if(activatable)
                {
                    if(inventory.selectedItem.MyActivatable == activatable)
                    {
                        activatable.Activate();
                        inventory.selectedItem.UseItem();
                        inventory.selectedItem = null;
                    }
                        
                    return;
                }
            }

            // Deselects the selected item when not clicking on an activatable or item
            inventory.selectedItem = null;
        }
    }

    [SerializeField] private AudioSource collectionSoundEffect;

  


}


