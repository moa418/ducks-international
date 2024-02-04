using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Gate {
    public Gate(string gate, int qubit) {
        GateType = gate;
        Qubit = qubit;
    }

    public string GateType { get;}
    public int Qubit { get;}
}

public class StageObject : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Gate> gate_list = new List<Gate>();
    void Start()
    {
        gate_list.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool Measure() {
        /// 
        /// string python_exe = "";
        /// for each gate in gate list:
        ///     if gate == "X-Gate":
        ///         python_exe += "circ.X(0)";
        ///     if gage == "
        ///
        return true;
    }
}
