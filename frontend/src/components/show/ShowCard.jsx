import "./ShowCard.css";
import { useNavigate } from "react-router-dom";
import { getYear } from "../../utils/Utils";
import { useState, useEffect } from "react";
import { addShowToFavorites, getUserFavorites, removeShowFromFavorites } from "../../api/UseApi";
import { toast } from "react-toastify";

function ShowCard({ show, favorites, setFavorites }) {
    const navigate = useNavigate();

    const formatString = (str) => {
        return str.toLowerCase().replace(/\s+/g, "+");
    }

    const isFavorite = favorites?.some((fav) => fav.id === show.id);

    const handleFavorite = async (e) => {
        e.stopPropagation();

        try {
            if (isFavorite) {
                await removeShowFromFavorites(show.id);
                setFavorites(prev => prev.filter(aux => aux.id !== show.id))
                toast.success("Show removed from favorites");
            } else {
                await addShowToFavorites(show.id)
                setFavorites(prev => [...prev, show]);
                toast.success("Show added to favorites");
            }
        } catch (error) {
            console.log("Failed to update favorites", error);
            toast.error("Failed to update favorites");
        }
    }

    const renderIsFavorite = () => {
        return (
            <button
                className="favorite"
                onClick={handleFavorite}
            >
                <svg
                    className={`${isFavorite ? "filled" : "empty"}`}
                    xmlns="http://www.w3.org/2000/svg"
                    viewBox="0 0 24 24"
                    width="32"
                    height="32"
                >
                    <path fill="none" d="M0 0H24V24H0z"></path>
                    <path d="M16.5 3C19.538 3 22 5.5 22 9c0 7-7.5 11-10 12.5C9.5 20 2 16 2 9c0-3.5 2.5-6 5.5-6C9.36 3 11 4 12 5c1-1 2.64-2 4.5-2zm-3.566 15.604c.881-.556 1.676-1.109 2.42-1.701C18.335 14.533 20 11.943 20 9c0-2.36-1.537-4-3.5-4-1.076 0-2.24.57-3.086 1.414L12 7.828l-1.414-1.414C9.74 5.57 8.576 5 7.5 5 5.56 5 4 6.656 4 9c0 2.944 1.666 5.533 4.645 7.903.745.592 1.54 1.145 2.421 1.7.299.189.595.37.934.572.339-.202.635-.383.934-.571z"></path>
                </svg>

                <svg
                    className={`${isFavorite ? "empty" : "filled"}`}
                    height="32"
                    width="32"
                    viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg"
                >
                    <path d="M0 0H24V24H0z" fill="none"></path>
                    <path d="M16.5 3C19.538 3 22 5.5 22 9c0 7-7.5 11-10 12.5C9.5 20 2 16 2 9c0-3.5 2.5-6 5.5-6C9.36 3 11 4 12 5c1-1 2.64-2 4.5-2z"></path>
                </svg>
            </button>
        );
    }

    return (
        <div className="card-container" onClick={() => {
            const path = formatString(show.title)
            navigate(`/show/${path}`)
        }}>
            {/* From Uiverse.io by LilaRest */}
            {renderIsFavorite()}

            <div className="showcard-img">
                <img src={show?.img ? show.img : "/images/background.jpg"} alt="TvShow-image" />
            </div>
            <div className="showcard-details">
                <div style={{ padding: "5px 10px" }}>{show?.title ? show.title : "Title"}</div>
                <div style={{ display: "flex", justifyContent: "space-between", padding: "5px 10px" }}>
                    <div>⭐ {show?.rating ? show.rating : "rating"}</div>
                    <div>{show?.releaseDate ? getYear(show.releaseDate) : "date"}</div>
                </div>
            </div>
        </div>
    );
}

export default ShowCard