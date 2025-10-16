import axios from "axios";

axios.defaults.baseURL = import.meta.env.VITE_BACKEND_URL;

const getAuthHeaders = () => ({
    Authorization: `Bearer ${localStorage.getItem("token")}`,
});

// Auth
export const login = async (data) => {
    const response = await axios.post("/api/Auth/login", data);
    return response.data;
};

export const register = async (data) => {
    const response = await axios.post("/api/Auth/register", data);
    return response;
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

export const getShowByTitle = async (title) => {
    const response = await axios.get(`/api/TvShows/detailsByName/${title}`, {
        headers: getAuthHeaders(),
    });

    return response.data;
};

export const getAllShows = async () => {
    const response = await axios.get(`/api/TvShows/shows`);

    return response.data;
};

export const getActorById = async (actorId) => {
    const response = await axios.get(`/api/actors/details/${actorId}`, {
        headers: getAuthHeaders(),
    });

    return response.data;
};

export const getUserFavorites = async () => {
    const response = await axios.get("/api/users/favorites", {
        headers: getAuthHeaders(),
    });

    return response.data;
};

export const addShowToFavorites = async (tvshowid) => {
    const response = await axios.post(
        `/api/users/favorites/add/${tvshowid}`,
        {},
        { headers: getAuthHeaders() }
    );
    return response.data;
};

export const removeShowFromFavorites = async (tvshowid) => {
    const response = await axios.delete(
        `/api/users/favorites/remove/${tvshowid}`,
        { headers: getAuthHeaders() }
    );
    return response.data;
};

export const getShowsRecommendations = async () => {
    const response = await axios.get("/api/users/recommendations", {
        headers: getAuthHeaders(),
    });
    return response.data;
};
