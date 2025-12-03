using Fusion;
using UnityEngine;

public struct NetworkInputData : INetworkInput
{
    public Vector2 moveActionValue;
    public bool shootActionValue;
    public bool colorActionValue;
    public bool boostActionValue;   // NEW for speed boost
}
