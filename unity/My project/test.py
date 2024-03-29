from qiskit import *;
def runCircuit():
    simulator = Aer.get_backend('qasm_simulator');circuit = QuantumCircuit(2, 2)
    circuit.cx(0, 1);
    circuit.measure(range(2), range(2));
    circuit.measure(range(2), range(2));
    return list(execute(circuit, backend = simulator, shots = 1).result().get_counts().keys())[0];
f = open('c:/Users/benku/unity projects/ducks-international/unity/My project/circ_output.txt', 'w')
f.write(str(runCircuit()))
f.close()