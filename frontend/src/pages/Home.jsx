import "./Home.css";
import Header from "../components/header/Header";
import ShowCard from "../components/show/ShowCard";
import { Outlet, useLocation } from "react-router-dom";
import { useEffect, useState } from "react";
import { getAllShows, getGenres, getShowsByGenre, getUserFavorites } from "../api/UseApi";
import Select from "react-select";
import { ToastContainer, toast } from "react-toastify";

function Home() {
    const sortOptions = [
        { value: 'default', label: 'Sort by' },
        { value: 'title-asc', label: 'Title A–Z' },
        { value: 'title-desc', label: 'Title Z–A' },
        { value: 'rating-asc', label: 'Rating Low–High' },
        { value: 'rating-desc', label: 'Rating High–Low' },
        { value: 'year-asc', label: 'Year Old–New' },
        { value: 'year-desc', label: 'Year New–Old' },
    ];

    const { state } = useLocation();
    // console.log("state: ", state);

    const [shows, setShows] = useState();
    const [filteredShows, setFilteredShows] = useState();
    const [favorites, setFavorites] = useState();
    const [genreOptions, setGenreOptions] = useState();

    // === SEARCH ===
    const [searchTerm, setSearchTerm] = useState("");

    // === PAGINATION LOGIC ===
    const [currentPage, setCurrentPage] = useState(1);
    const showsPerPage = 12;
    const indexOfLastShow = currentPage * showsPerPage;
    const indexOfFirstShow = indexOfLastShow - showsPerPage;
    const currentShows = filteredShows?.slice(indexOfFirstShow, indexOfLastShow);
    const totalPages = Math.ceil(filteredShows?.length / showsPerPage);

    const handlePageChange = (pageNumber) => {
        setCurrentPage(pageNumber);
        window.scrollTo({ top: 0, behavior: "smooth" });
    };

    useEffect(() => {
        fetchAllShows();
        fetchUserFavorites();
        fetchAllGenres();
    }, []);

    useEffect(() => {
        if (state) {
            toast.info(state);
        }
    }, [state]);

    const fetchAllShows = () => {
        getAllShows()
            .then((res) => {
                // console.log(res);
                setShows(res);
                setFilteredShows(res);
            })
            .catch((error) => console.error("Error: ", error));
    }

    const fetchUserFavorites = () => {
        getUserFavorites()
            .then((res) => {
                // console.log("Favorites", res);
                setFavorites(res);
            })
            .catch((error) => {
                console.error("Error: ", error);
            });
    }

    const fetchAllGenres = () => {
        getGenres()
            .then((res) => {
                // console.log("Genres", res);
                const formattedGenres = [
                    { value: "all", label: "All Genres" },
                    ...res.map((g) => ({
                        value: g.id,
                        label: g.name
                    }))
                ];
                setGenreOptions(formattedGenres);
            })
            .catch((error) => {
                console.error("Error: ", error);
            });
    }

    const sortShows = (criteria) => {
        const sorted = [...filteredShows].sort((a, b) => {
            switch (criteria) {
                case "title-asc":
                    return a.title.localeCompare(b.title);
                case "title-desc":
                    return b.title.localeCompare(a.title);
                case "rating-asc":
                    return a.rating - b.rating;
                case "rating-desc":
                    return b.rating - a.rating;
                case "year-asc":
                    return new Date(a.releaseDate) - new Date(b.releaseDate);
                case "year-desc":
                    return new Date(b.releaseDate) - new Date(a.releaseDate);
                default:
                    return 0;
            }
        });
        setFilteredShows(sorted);
        setCurrentPage(1);
    };

    const filterByGenre = async (genre) => {
        let aux = shows;
        if (genre !== "all") {
            try {
                aux = await getShowsByGenre(genre);
                // console.log("Aux: ", aux);
            } catch (error) {
                console.log(error);
            }
        }

        setFilteredShows(aux);
        setCurrentPage(1);
    };

    const handleSearchChange = (e) => {
        const value = e.target.value.toLowerCase();
        setSearchTerm(value);

        if (!value) {
            setFilteredShows(shows);
            setCurrentPage(1);
            return;
        }

        const filtered = shows.filter((show) =>
            show.title.toLowerCase().includes(value)
        );

        setFilteredShows(filtered);
        setCurrentPage(1);
    };

    return (
        <>
            <Header />
            <div className="page-layout">
                <h1 style={{ margin: "0" }}>TV Shows</h1>
                <hr />

                <div style={{ display: "flex", width: "100%", gap: "50px" }}>
                    <input
                        className="searchbar"
                        type="text"
                        placeholder="Search TvShow ..."
                        value={searchTerm}
                        onChange={handleSearchChange}
                    />

                    <div className="react-select">
                        <Select
                            defaultValue={sortOptions[0]}
                            onChange={(selectedOption) => sortShows(selectedOption.value)}
                            options={sortOptions}
                        />
                    </div>

                    {genreOptions && (
                        <div className="react-select">
                            <Select
                                defaultValue={genreOptions[0]}
                                onChange={(selectedOption) => filterByGenre(selectedOption.value)}
                                options={genreOptions}
                            />
                        </div>
                    )}
                </div>

                <hr />

                <div className="shows-grid">
                    {currentShows && currentShows.length > 0 ? (
                        currentShows.map((s) => (
                            <ShowCard
                                show={s}
                                key={s.id}
                                favorites={favorites}
                                setFavorites={setFavorites}
                            />
                        ))
                    ) : (
                        <div>No shows found</div>
                    )}
                </div>

                {/* === PAGINATION CONTROLS === */}
                {totalPages > 1 && (
                    <div className="pagination">
                        <button
                            onClick={() => handlePageChange(currentPage - 1)}
                            disabled={currentPage === 1}
                        >
                            ‹ Prev
                        </button>

                        {[...Array(totalPages)].map((_, index) => (
                            <button
                                key={index}
                                className={currentPage === index + 1 ? "active" : ""}
                                onClick={() => handlePageChange(index + 1)}
                            >
                                {index + 1}
                            </button>
                        ))}

                        <button
                            onClick={() => handlePageChange(currentPage + 1)}
                            disabled={currentPage === totalPages}
                        >
                            Next ›
                        </button>
                    </div>
                )}
            </div>

            <ToastContainer />
            <Outlet />
        </>
    );
}

export default Home;