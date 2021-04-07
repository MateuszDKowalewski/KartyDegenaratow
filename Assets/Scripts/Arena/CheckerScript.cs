using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class CheckerScript : MonoBehaviour
{
    private Vector2Int[] _possibleMoves;

    public void initailize(CharacterPrefab prefab)
    {
        _possibleMoves = prefab.possibleMoves;
        SpriteRenderer spriteRenderer = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        Debug.Assert(spriteRenderer != null, nameof(spriteRenderer) + " != null");
        spriteRenderer.sprite = prefab.checkerArtwork;
    }

    public Vector2Int[] PossibleMoves => _possibleMoves;
}
