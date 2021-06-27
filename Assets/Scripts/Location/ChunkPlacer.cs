using UnityEngine;
using System.Collections.Generic;

public class ChunkPlacer : MonoBehaviour
{
    [SerializeField] private Chunk[] _chunks;
    [SerializeField] private Chunk _firstChunk;

    [HideInInspector] public Transform Player;

    private List<Chunk> _spawnerChunks = new List<Chunk>();


    private void Start()
    {
        Player = FindObjectOfType<Player>().transform;

        _spawnerChunks.Add(_firstChunk);
    }

    private void Update()
    {
        if(Player.position.x < _spawnerChunks[_spawnerChunks.Count - 1].End.position.x + 15)
        {
            SpawnChunk();
        }
    }


    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(_chunks[Random.Range(0, _chunks.Length)]);
        newChunk.transform.position = _spawnerChunks[_spawnerChunks.Count - 1].End.position - newChunk.Begin.localPosition;
        _spawnerChunks.Add(newChunk);
    }
}
