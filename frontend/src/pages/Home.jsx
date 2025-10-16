import "./Home.css";
import Header from "../components/header/Header";
import ShowCard from "../components/show/ShowCard";
import { Outlet, useLocation } from "react-router-dom";
import { useEffect, useState } from "react";
import { getAllShows, getUserFavorites } from "../api/UseApi";
import Select from "react-select";
import { ToastContainer, toast } from "react-toastify";

function Home() {
    const options = [
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

    useEffect(() => {
        fetchAllShows();
        fetchUserFavorites();
    }, []);

    useEffect(() => {
        if (state) {
            toast.info(state);
        }
    }, [state]);

    const fetchAllShows = () => {
        getAllShows()
            .then((res) => {
                console.log(res);
                setShows(res);
                setFilteredShows(res);
            })
            .catch((error) => console.error("Error: ", error));
    }

    const fetchUserFavorites = () => {
        getUserFavorites()
            .then((res) => {
                console.log("Favorites", res);
                setFavorites(res);
            })
            .catch((error) => {
                console.error("Error: ", error);
            });
    }

    const sortShows = (criteria) => {
        const sorted = [...shows].sort((a, b) => {
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

        setShows(sorted);
    };

    return (
        <>
            <Header />
            <div className="page-layout">
                <h1>TV Shows</h1>

                <hr />

                <div className="react-select">
                    <Select
                        defaultValue={options[0]}
                        onChange={(selectedOption) => sortShows(selectedOption.value)}
                        options={options}
                    />
                </div>

                <hr />

                <div className="shows-grid">
                    {shows?.map(s => (
                        <ShowCard show={s} key={s.id} favorites={favorites} setFavorites={setFavorites} />
                    ))}
                </div>
            </div>

            <ToastContainer />
            <Outlet />
        </>
    );
}

export default Home;