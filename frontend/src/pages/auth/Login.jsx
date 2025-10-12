import { getGenres } from "../../api/UseApi";

function Login() {
    const fetchGenres = async () => {
        try {
            const data = await getGenres();
            console.log(data);
        } catch (error) {
            console.error("Failed to fetch:", error);
        }
    };

    const handleClick = (e) => {
        e.preventDefault();

        fetchGenres();
    }
    return (
        <div>
            <div>Login Page</div>
            <button onClick={handleClick}>Click</button>
        </div>
    );
}

export default Login;