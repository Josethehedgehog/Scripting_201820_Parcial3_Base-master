using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private ActorController[] players;

    public GameObject prefab;

    [Range(2,4)]
    [SerializeField]
    private int numberOfPlayers;

    private float gameTime = 25F;

    public float CurrentGameTime { get; private set; }

    // Use this for initialization
    private IEnumerator Start()
    {
        SpawnPlayers();
        CurrentGameTime = gameTime;

        // Sets the first random tagged player
        players = FindObjectsOfType<ActorController>();

        yield return new WaitForSeconds(0.5F);

        players[Random.Range(0, players.Length)].onActorTagged(true);
    }

    private void Update()
    {
        CurrentGameTime -= Time.deltaTime;

        if (CurrentGameTime <= 0F)
        {
            //Time.timescale = 0;
            //TODO: Send GameOver event.
            foreach (ActorController item in players)
            {
                item.StopMovement();
            }
        }
    }

    void SpawnPlayers()
    {
        Instantiate(players[0], Vector3.zero, Quaternion.identity);

        for (int i = 0; i < numberOfPlayers; i++)
        {
            GameObject clon = Instantiate(prefab, new Vector3(i*2+5, 0, 0), Quaternion.identity) as GameObject;
            ActorController clonController = clon.GetComponent<ActorController>();

            ActorController[] newPlayer = new ActorController[players.Length + 1];

            for (int j = 0; j < players.Length; j++)
            {
                newPlayer[j] = players[j];
            }

            newPlayer[players.Length] = clonController;

            players = newPlayer;
        }
    }
}