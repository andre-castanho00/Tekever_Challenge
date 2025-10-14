import "./Home.css";
import Header from "../components/header/Header";
import ShowCard from "../components/show/ShowCard";
import { Outlet } from "react-router-dom";
import { useEffect, useState } from "react";

function Home() {
    const tvShows = [
        {
            id: 1,
            title: "Breaking Bad",
            rating: 9.5,
            date: 2008
        },
        {
            id: 2,
            title: "Stranger Things",
            rating: 8.7,
            date: 2016
        },
        {
            id: 3,
            title: "The Office",
            rating: 9.0,
            date: 2005
        },
        {
            id: 4,
            title: "Game of Thrones",
            rating: 9.3,
            date: 2011
        },
        {
            id: 5,
            title: "The Mandalorian",
            rating: 8.6,
            date: 2019
        }
    ];

    const [shows, setShows] = useState(tvShows);

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
                    return a.date - b.date;
                case "year-desc":
                    return b.date - a.date;
                default:
                    return 0;
            }
        });

        setShows(sorted);
    };

    const handleSortChange = (e) => {
        sortShows(e.target.value);
    };

    return (
        <>
            <Header />
            <div style={{ padding: "80px 150px" }}>
                <h1>TV Shows</h1>

                <hr />

                <div>
                    <select onChange={handleSortChange} defaultValue={"default"}>
                        <option value="default" disabled>Sort by ...</option>
                        <option value="asc">Title A–Z</option>
                        <option value="desc">Title Z–A</option>
                        <option value="rating-asc">Rating Low–High</option>
                        <option value="rating-desc">Rating High–Low</option>
                        <option value="year-asc">Year Old–New</option>
                        <option value="year-desc">Year New–Old</option>
                    </select>
                </div>

                <hr />

                <div className="shows-grid">
                    {shows.map(s => (
                        <ShowCard show={s} key={s.id} />
                    ))}
                </div>
            </div>
            <Outlet />
        </>
    );
}

export default Home;