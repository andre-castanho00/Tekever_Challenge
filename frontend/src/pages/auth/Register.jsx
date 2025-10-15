import { useState } from "react";
import { register } from "../../api/UseApi";
import { useNavigate } from "react-router-dom";

function Register() {
    const [registerForm, setRegisterForm] = useState({
        username: "",
        email: "",
        password: "",
    });

    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            console.log("Form: ", registerForm);

            const response = await register(registerForm);
            console.log("Register response:", response);

            // Adjust this check based on your API structure
            if (response.status === 201 || response.success) {
                navigate("/home/login");
            } else {
                console.error("Registration failed:", response);
            }

        } catch (error) {
            console.error("Error during registration:", error);
        }
    };

    return (
        <div className="background">
            <div className="form-container">
                <div style={{ display: "flex", justifyContent: "space-between", alignItems: "center", paddingBottom: "10px" }}>
                    <h3>Please Register</h3>
                    <div className="close-btn" onClick={() => navigate("/home")}>x</div>
                </div>

                <form className="flex-column spacing" onSubmit={handleSubmit}>
                    <div className="flex-column">
                        <label htmlFor="">Username</label>
                        <input type="text"
                            className="inputs"
                            placeholder="Enter username"
                            value={registerForm.username}
                            required
                            onChange={(e) => {
                                setRegisterForm({ ...registerForm, username: e.target.value })
                            }}
                        />
                    </div>

                    <div className="flex-column">
                        <label htmlFor="">Email</label>
                        <input type="email"
                            className="inputs"
                            placeholder="Enter email"
                            value={registerForm.email}
                            required
                            onChange={(e) => {
                                setRegisterForm({ ...registerForm, email: e.target.value })
                            }}
                        />
                    </div>

                    <div className="flex-column">
                        <label htmlFor="">Password</label>
                        <input type="password"
                            className="inputs"
                            placeholder="Enter password"
                            value={registerForm.password}
                            required
                            onChange={(e) => {
                                setRegisterForm({ ...registerForm, password: e.target.value })
                            }}
                        />
                    </div>

                    <input className="inputs btn" type="submit" value="Register" />
                </form>
            </div>
        </div>
    );
}

export default Register;