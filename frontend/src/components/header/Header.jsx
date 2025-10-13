import "./Header.css";

const Header = () => {
    return (
        <header>
            <div className="nav">
                <h2>Challenge</h2>

                <p>Searchbar</p>

                <div>
                    <button>Register</button>
                    <button>Login</button>
                </div>
            </div>

        </header>
    );
}

export default Header;