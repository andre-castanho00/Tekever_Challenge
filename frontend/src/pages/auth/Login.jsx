import { useState, useContext, useEffect } from "react";
import AuthContext from "../../AuthContext";
import { useNavigate } from "react-router-dom";
import "./Login.css";

function Login() {
    const { login, user } = useContext(AuthContext);
    const [loginForm, setLoginForm] = useState({
        email: "",
        password: "",
    });
    const navigate = useNavigate();

    useEffect(() => {
        if (user) {
            navigate("/home");
        }
    }, [user, navigate]);

    const handleSubmit = async (e) => {
        e.preventDefault();

        await login(loginForm);
    }

    return (
        <div className="background">
            <div className="form-container">
                <div style={{ display: "flex", justifyContent: "space-between", alignItems: "center", paddingBottom: "10px" }}>
                    <h3>Please Login</h3>
                    <div className="close-btn" onClick={() => navigate("/home")}>x</div>
                </div>

                <form className="flex-column spacing" onSubmit={handleSubmit}>
                    <div className="flex-column">
                        <label htmlFor="">Email</label>
                        <input type="email"
                            className="inputs"
                            placeholder="Enter email"
                            value={loginForm.email}
                            required
                            onChange={(e) => {
                                setLoginForm({ ...loginForm, email: e.target.value })
                            }}
                        />
                    </div>

                    <div className="flex-column">
                        <label htmlFor="">Password</label>
                        <input type="password"
                            className="inputs"
                            placeholder="Enter password"
                            value={loginForm.password}
                            required
                            onChange={(e) => {
                                setLoginForm({ ...loginForm, password: e.target.value })
                            }}
                        />
                    </div>

                    <input className="inputs btn" type="submit" value="Login" />
                </form>
            </div>
        </div>
    );
}

export default Login;