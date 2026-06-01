import { useState } from "react";

function Login({ onLogin }) {
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");
  const [erro, setErro] = useState("");

  function fazerLogin(e) {
    e.preventDefault();

    fetch("http://localhost:5095/api/Auth/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        email: email,
        senha: senha
      })
    })
      .then((res) => {
        if (!res.ok) {
          throw new Error("E-mail ou senha inválidos");
        }

        return res.json();
      })
      .then((data) => {
        localStorage.setItem("token", data.token);
        setErro("");
        onLogin();
      })
      .catch((error) => {
        setErro(error.message);
      });
  }

  return (
    <div className="login-container">
      <form className="login-card" onSubmit={fazerLogin}>
        <h2>Bem-vindo</h2>

        <input
          type="email"
          placeholder="Digite seu e-mail"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />

        <input
          type="password"
          placeholder="Digite sua senha"
          value={senha}
          onChange={(e) => setSenha(e.target.value)}
        />

        {erro && <p className="erro">{erro}</p>}

        <button type="submit">Entrar</button>
      </form>
    </div>
  );
}

export default Login;