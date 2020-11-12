using UnityEngine;

public class BlocksGenerator : MonoBehaviour
{
    public GameObject[] blocks;
    [HideInInspector]
    public float y0;
    private float movementSpeed = 0.1f;
    private float movementMagnitude = 1.0f;
    private float heightMagnitude = 1.0f;

    private GameObject currentCube;
    private float movementFrequency;
    private int current_block_index = 0;
    public void StartGame()
    {
        GameManager gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        movementSpeed = gameManager.movementSpeed;
        movementMagnitude = gameManager.movementMagnitude;
        heightMagnitude = gameManager.heightMagnitude;

        float period = 2 * Mathf.PI * Mathf.Sqrt(movementMagnitude / movementSpeed);
        movementFrequency = 1 / period;
        currentCube = GenerateCube();
        currentCube.GetComponent<BlockManager>().previousBlock = GameObject.FindGameObjectWithTag("platform");
        y0 = transform.position.y;
    }

    public void FixedUpdate()
    {
        Vector3 newPos = Vector3.up * y0;
        newPos.x = movementMagnitude * Mathf.Sin(2 * Mathf.PI * movementFrequency * Time.time);
        float dy = -heightMagnitude * Mathf.Cos(2 * Mathf.PI * movementFrequency * Time.time);
        dy = -Mathf.Abs(dy);
        newPos.y += dy;
        transform.position = newPos;
    }

    public void NextBlock()
    {
        currentCube.transform.parent = null;
        GameObject newCube = GenerateCube();
        newCube.GetComponent<BlockManager>().previousBlock = currentCube;
        currentCube = newCube;
    }

    GameObject GenerateCube()
    {
        GameObject new_cube = Instantiate(blocks[current_block_index], transform.position, Quaternion.identity, transform);
        current_block_index += 1;
        if (current_block_index == blocks.Length)
        {
            current_block_index = 0;
        }
        return new_cube;
    }
}
