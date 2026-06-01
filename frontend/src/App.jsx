import { useEffect, useState } from "react";
import "./App.css";
import CorridaTabela from "./components/CorridaTabela";
import CorridaForm from "./components/CorridaForm";
import Login from "./components/Login";

function App() {
  const [corridas, setCorridas] = useState([]);
  const [logado, setLogado] = useState(false);

  const API_URL = "http://localhost:5095/api/Corrida";

  function carregarCorridas() {
    const token = localStorage.getItem("token");

    fetch(API_URL, {
      method: "GET",
      headers: {
        Authorization: `Bearer ${token}`
      }
    })
      .then((res) => {
        if (!res.ok) {
          throw new Error("Não autorizado");
        }

        return res.json();
      })
      .then((data) => {
        setCorridas(data);
      })
      .catch((error) => {
        console.error("Erro ao buscar corridas:", error);
        localStorage.removeItem("token");
        setLogado(false);
      });
  }

  useEffect(() => {
    const token = localStorage.getItem("token");

    if (token) {
      setLogado(true);
      carregarCorridas();
    }
  }, []);

  function adicionarCorrida(novaCorrida) {
    const token = localStorage.getItem("token");

    fetch(API_URL, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`
      },
      body: JSON.stringify(novaCorrida)
    })
      .then((res) => {
        if (!res.ok) {
          throw new Error("Não autorizado");
        }

        return res.json();
      })
      .then(() => {
        carregarCorridas();
      })
      .catch((error) => {
        console.error("Erro ao cadastrar corrida:", error);
      });
  }

  function deletarCorrida(id) {
    const token = localStorage.getItem("token");

    fetch(`${API_URL}/${id}`, {
      method: "DELETE",
      headers: {
        Authorization: `Bearer ${token}`
      }
    })
      .then((res) => {
        if (!res.ok) {
          throw new Error("Não autorizado");
        }

        carregarCorridas();
      })
      .catch((error) => {
        console.error("Erro ao deletar corrida:", error);
      });
  }

  function aoLogar() {
    setLogado(true);
    carregarCorridas();
  }

  function sair() {
    localStorage.removeItem("token");
    setLogado(false);
    setCorridas([]);
  }

  if (!logado) {
    return <Login onLogin={aoLogar} />;
  }

return (
  <div className="container">
    <div className="header-app">
      <h1>Tabela de Corridas</h1>

      <button className="btn-sair" onClick={sair}>
        Sair
      </button>
    </div>

    <CorridaForm onAdd={adicionarCorrida} />

    <CorridaTabela
      corridas={corridas}
      onDelete={deletarCorrida}
    />
  </div>
);
}

export default App;