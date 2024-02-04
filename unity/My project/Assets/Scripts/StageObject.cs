using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public struct Gate {
    public Gate(string gate, int qubit1, int qubit2 = -1) {
        GateType = gate;
        Qubit1 = qubit1;
        Qubit2 = qubit2;
    }

    public string GateType {get;}
    public int Qubit1 {get;}
    public int Qubit2 {get;}

    public override string ToString() => $"({GateType}, {Qubit1}, {Qubit2})";
}

// public struct Duck {

// }

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

    public bool Measure() {
        string base_string = @"from qiskit import *;
def runCircuit():
    simulator = Aer.get_backend('qasm_simulator');
    circuit = QuantumCircuit(3, 1);";
    base_string += "\n";
        for(int i = 0; i < gate_list.Count; i++) {
            if(gate_list[i].GateType == "X-Gate") {
                base_string += $"    circuit.x({gate_list[i].Qubit1});\n";
            } else if(gate_list[i].GateType == "Z-Gate") {
                base_string += $"    circuit.z({gate_list[i].Qubit1});\n";
            } else if(gate_list[i].GateType == "CX-Gate") {
                base_string += $"    circuit.cx({gate_list[i].Qubit1}, {gate_list[i].Qubit2});\n";
            } else if(gate_list[i].GateType == "CZ-Gate") {
                base_string += $"    circuit.cz({gate_list[i].Qubit1}, {gate_list[i].Qubit2});\n";
            } else if(gate_list[i].GateType == "H-Gate") {
                base_string += $"    circuit.h({gate_list[i].Qubit1});\n";
            } else if(gate_list[i].GateType == "Measure") {
                base_string += $"    circuit.measure({gate_list[i].Qubit1}, 0);\n";
            }
        }
        base_string += "    return list(execute(circuit, backend = simulator, shots = 1).result().get_counts().keys())[0];\n";
        // base_string += "print runCircuit()";
        base_string += @"f = open('c:/Users/benku/unity projects/ducks-international/unity/My project/circ_output.txt', 'w')
f.write(str(runCircuit()))
f.close()";
        File.WriteAllText("./test.py", base_string);
        
        using(System.Diagnostics.Process pProcess = new System.Diagnostics.Process())
        {
            pProcess.StartInfo.FileName = @"C:/Python312/python.exe";
            pProcess.StartInfo.Arguments = "\"c:/Users/benku/unity projects/ducks-international/unity/My project/test.py\""; //argument
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            pProcess.StartInfo.CreateNoWindow = true; //not diplay a windows
            pProcess.Start();
            string output = pProcess.StandardOutput.ReadToEnd(); //The output result
            pProcess.WaitForExit();
        }

        string qubitState = File.ReadAllText("c:/Users/benku/unity projects/ducks-international/unity/My project/circ_output.txt");
        UnityEngine.Debug.Log(qubitState);

        int int_state = Int32.Parse(qubitState);

        if(int_state == 1) {
            return true;
        }
        return false;
    }
}
