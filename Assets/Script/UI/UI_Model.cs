using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UI_Model : MonoBehaviour
{
    public ReactiveProperty<float>currentAtb = new FloatReactiveProperty();
}
