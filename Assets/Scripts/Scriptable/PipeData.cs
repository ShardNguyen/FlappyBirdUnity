using UnityEngine;

[CreateAssetMenu(fileName = "PipeData", menuName = "Scriptable Objects/PipeData")]
public class PipeData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] public float gap;
    [SerializeField] public float speed;
}
