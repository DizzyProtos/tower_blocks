using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class BlockManager : MonoBehaviour
{
    public UnityEvent blockFall;
    public UnityEvent gameOver;
    [HideInInspector]
    public GameObject previousBlock;
    private int lockOrder = 5;
    private bool isFallen = false;
    private int blockOrder = 0;
    private new Rigidbody rigidbody;

    void Start()
    {
        GameManager gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        lockOrder = gameManager.lockOrder;
        blockFall.AddListener(gameManager.OnBlockFall);
        gameOver.AddListener(gameManager.OnTowerFall);
        rigidbody = GetComponent<Rigidbody>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isFallen)
        {
            blockFall.Invoke();
            IncreaseId();
            isFallen = true;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.useGravity = true;
            transform.parent = null;
        }
        if (previousBlock.transform.position.y > transform.position.y)
        {
            gameOver.Invoke();
        }
    }

    private void IncreaseId()
    {
        blockOrder += 1;
        if (blockOrder == lockOrder)
        {
            rigidbody.isKinematic = true;
            rigidbody.freezeRotation = true;
        }
    }
}
