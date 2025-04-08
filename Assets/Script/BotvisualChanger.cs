using UnityEngine;

public class BotVisualManager : MonoBehaviour
{
    public GameObject normalPrefab;
    public GameObject poweredPrefab;

    private GameObject currentVisual;
    private GameObject player;
    private Playerstates playerStates;

    public Transform visualParent; // VisualObject ÇÃ Transform

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStates = player.GetComponent<Playerstates>();

        // èâä˙ÇÃå©ÇΩñ⁄ÇÉZÉbÉg
        SetVisual(normalPrefab);
    }

    void Update()
    {
        if (playerStates != null)
        {
            if (playerStates.plstates == 1f && currentVisual.name != poweredPrefab.name + "(Clone)")
            {
                SetVisual(poweredPrefab);
            }
            else if (playerStates.plstates != 1f && currentVisual.name != normalPrefab.name + "(Clone)")
            {
                SetVisual(normalPrefab);
            }
        }
    }

    void SetVisual(GameObject prefab)
    {
        if (currentVisual != null)
        {
            Destroy(currentVisual);
        }

        currentVisual = Instantiate(prefab, visualParent);
        currentVisual.transform.localPosition = Vector3.zero;
    }
}
