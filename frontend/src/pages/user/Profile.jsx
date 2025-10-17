import "./Profile.css";
import Header from "../../components/header/Header";
import { ToastContainer } from "react-toastify";
import { useState, useEffect, useContext } from "react";
import { getShowsRecommendations, getUserFavorites } from "../../api/UseApi";
import ShowCard from "../../components/show/ShowCard";
import AuthContext from "../../AuthContext";

function Profile() {
    const [favorites, setFavorites] = useState([]);
    const [recommendations, setRecommendations] = useState([]);
    const { user } = useContext(AuthContext);

    // === PAGINATION: Favorites ===
    const [favPage, setFavPage] = useState(1);
    const favsPerPage = 6;
    const favIndexOfLast = favPage * favsPerPage;
    const favIndexOfFirst = favIndexOfLast - favsPerPage;
    const currentFavorites = favorites?.slice(favIndexOfFirst, favIndexOfLast);
    const totalFavPages = Math.ceil(favorites?.length / favsPerPage);

    // === PAGINATION: Recommendations ===
    const [recPage, setRecPage] = useState(1);
    const recsPerPage = 6;
    const recIndexOfLast = recPage * recsPerPage;
    const recIndexOfFirst = recIndexOfLast - recsPerPage;
    const filteredRecs = recommendations?.filter(
        (s) => !favorites?.some((fav) => fav.id === s.id)
    );
    const currentRecommendations = filteredRecs?.slice(recIndexOfFirst, recIndexOfLast);
    const totalRecPages = Math.ceil(filteredRecs?.length / recsPerPage);

    useEffect(() => {
        fetchUserFavorites();
        fetchUserRecommended();
    }, []);

    const fetchUserFavorites = () => {
        getUserFavorites()
            .then((res) => setFavorites(res))
            .catch((error) => console.error("Error fetching favorites: ", error));
    };

    const fetchUserRecommended = () => {
        getShowsRecommendations()
            .then((res) => setRecommendations(res))
            .catch((error) => console.error("Error fetching recommendations: ", error));
    };

    return (
        <>
            <Header />

            <div className="page-layout">
                <h1>{`${user?.username}'s Profile`}</h1>

                <hr className="divider" />

                <h3>My Favorites</h3>
                <div className="shows-grid">
                    {currentFavorites && currentFavorites.length > 0 ? (
                        currentFavorites.map((s) => (
                            <ShowCard
                                show={s}
                                key={s.id}
                                favorites={favorites}
                                setFavorites={setFavorites}
                            />
                        ))
                    ) : (
                        <div>No favorites found</div>
                    )}
                </div>

                {totalFavPages > 1 && (
                    <div className="pagination">
                        <button
                            onClick={() => setFavPage(favPage - 1)}
                            disabled={favPage === 1}
                        >
                            ‹ Prev
                        </button>
                        {[...Array(totalFavPages)].map((_, index) => (
                            <button
                                key={index}
                                className={favPage === index + 1 ? "active" : ""}
                                onClick={() => setFavPage(index + 1)}
                            >
                                {index + 1}
                            </button>
                        ))}
                        <button
                            onClick={() => setFavPage(favPage + 1)}
                            disabled={favPage === totalFavPages}
                        >
                            Next ›
                        </button>
                    </div>
                )}

                <hr className="divider" />

                <h3>Recommendations</h3>
                <div className="shows-grid">
                    {currentRecommendations && currentRecommendations.length > 0 ? (
                        currentRecommendations.map((s) => (
                            <ShowCard
                                show={s}
                                key={s.id}
                                favorites={favorites}
                                setFavorites={setFavorites}
                            />
                        ))
                    ) : (
                        <div>No recommendations found</div>
                    )}
                </div>

                {totalRecPages > 1 && (
                    <div className="pagination">
                        <button
                            onClick={() => setRecPage(recPage - 1)}
                            disabled={recPage === 1}
                        >
                            ‹ Prev
                        </button>
                        {[...Array(totalRecPages)].map((_, index) => (
                            <button
                                key={index}
                                className={recPage === index + 1 ? "active" : ""}
                                onClick={() => setRecPage(index + 1)}
                            >
                                {index + 1}
                            </button>
                        ))}
                        <button
                            onClick={() => setRecPage(recPage + 1)}
                            disabled={recPage === totalRecPages}
                        >
                            Next ›
                        </button>
                    </div>
                )}
            </div>

            <ToastContainer />
        </>
    );
}

export default Profile;
