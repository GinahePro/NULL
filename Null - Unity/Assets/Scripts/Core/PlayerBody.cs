using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    private Vector3 lookDirection;

    [SerializeField] private Transform playerHead;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LookAt(Vector3 direction)
    {
        this.lookDirection = direction;
        this.updatePlayerHead();
    }

    private void updatePlayerHead()
    {
        this.playerHead.forward = lookDirection;
    }
}
