import { createContext, useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { getCurrentUser, login as apiLogin } from "./api/UseApi";
import { toast } from "react-toastify";

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    const [token, setToken] = useState(
        localStorage.getItem("token") || null
    );
    const [loading, setLoading] = useState(true);

    const navigate = useNavigate();

    const logout = () => {
        setToken(null);
        setUser(null);
        localStorage.removeItem("token");
        navigate("/home", {state: "Logout successful"});
    };

    useEffect(() => {
        const storedToken = localStorage.getItem("token");

        if (!storedToken) {
            setLoading(false);
            return;
        }

        const loadUser = async () => {
            try {
                // console.log("Starting to load user from token");
                const payload = await getCurrentUser();

                if (payload) {
                    console.log("User loaded successfully:", {
                        email: payload.email,
                    });

                    setUser({
                        id: payload.userId,
                        username: payload.username,
                        email: payload.email,
                    });
                } else {
                    console.log("No payload received, logging out");
                    logout();
                    toast.warning("Session expired, please login again");
                }
            } catch (error) {
                console.error("Error loading user:", error);
                logout();
                toast.warning("Session expired, please login again");
            } finally {
                // console.log("Loading complete, setting loading to false");
                setLoading(false);
            }
        };

        loadUser();
    }, []);

    const login = async (data) => {
        try {
            const res = await apiLogin(data);

            const accessToken = res.token;
            setToken(accessToken);

            localStorage.setItem("token", accessToken);

            const loginUser = await getCurrentUser();

            // console.log("loginUser: ", loginUser);

            setUser({
                id: loginUser.userId,
                username: loginUser.username,
                email: loginUser.email,
            });

            return true;
        } catch (error) {
            console.error("Login error:", error);
            toast.error(error.response?.data?.message || "Login failed");
            return false;
        }
    };

    return (
        <AuthContext.Provider
            value={{
                user,
                token,
                login,
                logout,
                loading
            }}
        >
            {children}
        </AuthContext.Provider>
    );
}

export default AuthContext;
