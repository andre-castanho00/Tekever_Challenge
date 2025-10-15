import "./Header.css";
import { useNavigate } from "react-router-dom";
import { useContext } from "react";
import AuthContext from "../../AuthContext";

const Header = () => {
    const navigate = useNavigate();
    const { user, logout } = useContext(AuthContext);

    return (
        <header>
            <div className="nav">
                <h2 style={{ cursor: "pointer" }} onClick={() => navigate("/home")}>Challenge</h2>

                <input className="searchbar" type="text" placeholder="Search TvShow ..." name="" id="" />

                <div className="header-btns">
                    {user?.username ? (
                        <>
                            <button onClick={() => navigate("/profile")}>{user.username}</button>
                            <button onClick={() => logout()}>Logout</button>
                        </>
                    ) : (
                        <>
                            <button onClick={() => navigate("/home/register")}>Register</button>
                            <button onClick={() => navigate("/home/login")}>Login</button>
                        </>
                    )}
                </div>
            </div>
        </header>
    );
}

export default Header;