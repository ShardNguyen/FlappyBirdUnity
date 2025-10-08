using UnityEngine;

[CreateAssetMenu(fileName = "BirdData", menuName = "Scriptable Objects/BirdData")]
public class BirdData : ScriptableObject
{
    [SerializeField] public string birdName;
    [SerializeField] public int hitAllowed;
}
