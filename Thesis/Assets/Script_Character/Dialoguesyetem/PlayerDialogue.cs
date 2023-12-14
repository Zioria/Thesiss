using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{
   [SerializeField] private DialogueUI dialogueUI;
   public DialogueUI DialogueUI => dialogueUI;
   public IInteractable Interactable { get; set; }
   //private Rigidbody rb;
    // Start is called before the first frame update
    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        if (dialogueUI.IsOpen)return;
       
        
        
        //Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
       // rb.MovePosition(rb.position + input.normalized * Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.F))
        {
            Interactable?.Interact(this);
        }
    }
}
