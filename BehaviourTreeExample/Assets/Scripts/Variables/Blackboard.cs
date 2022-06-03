using System.Collections.Generic;
using UnityEngine;


public class Blackboard : MonoBehaviour
{
    [SerializeReference] public List<BaseScriptableObject> baseSharedVariables = new List<BaseScriptableObject>();

    public Dictionary<string, object> Values = new Dictionary<string, object>();

    private Dictionary<string, object> dictionary = new Dictionary<string, object>();

    public T GetVariable<T>(string name) where T : BaseScriptableObject
    {
        if (dictionary.ContainsKey(name))
        {
            return dictionary[name] as T;
        }
        return null;
    }


    public T GetValue<T>(string name)
    {
        return Values.ContainsKey(name) ? (T)Values[name] : default(T);
    }

    public void SetValue<T>(string name, T item)
    {
        if (Values.ContainsKey(name))
        {
            Values[name] = item;
        }
        else
        {
            Values.Add(name, item);
        }
    }

    public void AddVariable(string name, BaseScriptableObject variable)
    {
        dictionary.Add(name, variable);
    }

    [ContextMenu("Add FloatVariable")]
    public void AddFloatVariable()
    {
        baseSharedVariables.Add(new VariableFloat());
    }

    [ContextMenu("Add GameObjectVariable")]
    public void AddGameObjectVariable()
    {
        baseSharedVariables.Add(new VariableGameObject());
    }
}
