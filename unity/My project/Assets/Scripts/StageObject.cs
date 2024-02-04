using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Gate1Q {
    public Gate1Q(string gate, int qubit) {
        GateType = gate;
        Qubit = qubit;
    }

    public string GateType { get;}
    public int Qubit { get;}

    public override string ToString() => $"({GateType}, {Qubit})";
}

public struct Gate2Q {
    public Gate2Q(string gate, int qubit1, int qubit2) {
        GateType = gate;
        Qubit1 = qubit1;
        Qubit2 = qubit2;
    }

    public string GateType { get;}
    public int Qubit1 { get;}
    public int Qubit2 { get;}

    public override string ToString() => $"({GateType}, {Qubit1}, {Qubit2})";
}

public class StageObject : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Gate1Q> gate_list = new List<Gate1Q>();
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
