import { useState } from "react";

function CorridaForm({ onAdd }) {
  const [nome, setNome] = useState("");
  const [distancia, setDistancia] = useState("");

  function handleSubmit(event) {
    event.preventDefault();

    const novaCorrida = {
      nome: nome,
      distancia: Number(distancia)
    };

    onAdd(novaCorrida);

    setNome("");
    setDistancia("");
  }

  return (
    <form onSubmit={handleSubmit} className="form">
      <input
        type="text"
        placeholder="Nome da corrida"
        value={nome}
        onChange={(e) => setNome(e.target.value)}
      />

      <input
        type="number"
        placeholder="Distância"
        value={distancia}
        onChange={(e) => setDistancia(e.target.value)}
      />

      <button type="submit">Cadastrar</button>
    </form>
  );
}

export default CorridaForm;