using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowableValue<T>
{
    private T value;
    

    public T GetValue() {
        return value;
    }

    public void SetValue(T newValue) {
        value = newValue;
        
    }

}
