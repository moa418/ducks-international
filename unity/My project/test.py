from qiskit import *;
def runCircuit():
    simulator = Aer.get_backend('qasm_simulator');
    circuit = QuantumCircuit(3, 1);
    circuit.x(0);
    circuit.z(0);
    circuit.measure(0, 0);
    return list(execute(circuit, backend = simulator, shots = 1).result().get_counts().keys())[0];
f = open('c:/Users/benku/unity projects/ducks-international/unity/My project/circ_output.txt', 'w')
f.write(str(runCircuit()))
f.close()