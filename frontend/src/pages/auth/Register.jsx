import { useState } from "react";
import { register } from "../../api/UseApi";

function Register() {
    const [registerForm, setRegisterForm] = useState({
        username: "",
        email: "",
        password: "",
    });

    const handleSubmit = async (e) => {
        e.preventDefault();

        console.log("Form: ", registerForm);
        await register(registerForm);
    }

    return (
        <div>
            <div>Register Page</div>

            <form action="" onSubmit={handleSubmit}>
                <label htmlFor="">Username</label>
                <input type="text"
                    placeholder="Enter username"
                    value={registerForm.username}
                    required
                    onChange={(e) => {
                        setRegisterForm({ ...registerForm, username: e.target.value })
                    }}
                />

                <label htmlFor="">Email</label>
                <input type="email"
                    placeholder="Enter email"
                    value={registerForm.email}
                    required
                    onChange={(e) => {
                        setRegisterForm({ ...registerForm, email: e.target.value })
                    }}
                />

                <label htmlFor="">Password</label>
                <input type="password"
                    placeholder="Enter password"
                    value={registerForm.password}
                    required
                    onChange={(e) => {
                        setRegisterForm({ ...registerForm, password: e.target.value })
                    }}
                />

                <input type="submit" value="Register" />
            </form>
        </div>
    );
}

export default Register;