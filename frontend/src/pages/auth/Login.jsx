import { useState, useContext, useEffect } from "react";
import AuthContext from "../../AuthContext";
import { useNavigate } from "react-router-dom";

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
        <div>
            <div>Login Page</div>

            <form action="" onSubmit={handleSubmit}>
                <label htmlFor="">Email</label>
                <input type="email"
                    placeholder="Enter email"
                    value={loginForm.email}
                    required
                    onChange={(e) => {
                        setLoginForm({ ...loginForm, email: e.target.value })
                    }}
                />

                <label htmlFor="">Password</label>
                <input type="password"
                    placeholder="Enter password"
                    value={loginForm.password}
                    required
                    onChange={(e) => {
                        setLoginForm({ ...loginForm, password: e.target.value })
                    }}
                />

                <input type="submit" value="Login" />
            </form>
        </div>
    );
}

export default Login;