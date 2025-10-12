import axios from "axios";

axios.defaults.baseURL = import.meta.env.VITE_BACKEND_URL;

const getAuthHeaders = () => ({
    Authorization: `Bearer ${localStorage.getItem("token")}`,
});

// Auth
export const login = async (email, password) => {
    const response = await axios.post("/api/auth/login", {
        email,
        password,
    });
    return response.data;
};

export const register = async ({
    username,
    email,
    password,
}) => {
    const response = await axios.post(
        "/api/auth/register",
        {
            username,
            email,
            password,
        }
    );
    return response.data;
};

// Users
export const getCurrentUser = async () => {
    const response = await axios.get("/api/users/me", {
        headers: getAuthHeaders(),
    });
    return response.data;
};

// Others
export const getGenres = async () => {
    const response = await axios.get("/api/TvShows/genres");

    return response.data;
};