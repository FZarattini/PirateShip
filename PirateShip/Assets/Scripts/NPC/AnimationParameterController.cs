using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AnimationParameterController : MonoBehaviour
{
    public Animator anim;

    public string[] parameterNames;
    public bool[] parameterValues;



    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        var res = parameterNames.Zip(parameterValues, (n, v) => new { Name = n, Value = v });

        foreach (var z in res)
        {
            anim.SetBool(z.Name, z.Value);

        }
    }
}
