using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private NumberField scoreField;

    private Player localPlayer;

    private void Start()
    {
        if (scoreField == null)
            scoreField = GetComponent<NumberField>();
    }

    private void Update()
    {
        if (localPlayer == null)
        {
            // Find all Player objects in the scene (unsorted)
            var players = Object.FindObjectsByType<Player>(FindObjectsSortMode.None);
            foreach (var p in players)
            {
                if (p.HasInputAuthority)
                {
                    localPlayer = p;
                    break;
                }
            }
        }

        if (localPlayer != null && scoreField != null)
        {
            scoreField.SetNumber(localPlayer.Score);
        }
    }
}
