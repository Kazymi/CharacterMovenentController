using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Create CharacterConfigurations", fileName = "CharacterConfigurations",
    order = 0)]
public class CharacterConfigurations : ScriptableObject
{
    [field: SerializeField] public float Speed { get; private set; }

    [field: SerializeField] public float SpeedRotate { get; private set; }
}