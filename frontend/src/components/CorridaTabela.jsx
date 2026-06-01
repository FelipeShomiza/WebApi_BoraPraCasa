function CorridaTabela({ corridas, onDelete }) {
  return (
    <table>
      <thead>
        <tr>
          <th>ID</th>
          <th>Nome</th>
          <th>Distância</th>
          <th>Valor</th>
          <th>Ações</th>
        </tr>
      </thead>

      <tbody>
        {corridas.length === 0 ? (
          <tr>
            <td colSpan="5">Nenhuma corrida cadastrada</td>
          </tr>
        ) : (
          corridas.map((corrida) => (
            <tr key={corrida.id}>
              <td>{corrida.id}</td>
              <td>{corrida.nome}</td>
              <td>{corrida.distancia} km</td>
              <td>R$ {corrida.valor}</td>
              <td>
                <button onClick={() => onDelete(corrida.id)}>
                  Excluir
                </button>
              </td>
            </tr>
          ))
        )}
      </tbody>
    </table>
  );
}

export default CorridaTabela;