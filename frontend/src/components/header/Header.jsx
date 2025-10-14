import "./Header.css";
import { useNavigate } from "react-router-dom";

const Header = () => {
    const navigate = useNavigate();
    return (
        <header>
            <div className="nav">
                <h2>Challenge</h2>

                <p>Searchbar</p>

                <div className="header-btns">
                    <button>Register</button>
                    <button onClick={() => navigate("/home/login")}>Login</button>
                </div>
            </div>

        </header>
    );
}

export default Header;