import "./ShowDetails.css";
import Header from "../../components/header/Header";
import { useParams, useNavigate } from "react-router-dom";
import { getShowByTitle } from "../../api/UseApi";
import { useState, useEffect } from "react";
import { formatDate } from "../../utils/Utils";
import React from "react";

function ShowDetails() {
    let { title } = useParams();

    const navigate = useNavigate();

    const [showDetails, setShowDetails] = useState();
    const [showActors, setShowActors] = useState();
    const [showGenres, setShowGenres] = useState();
    const [showSeasons, setshowSeasons] = useState();
    const [selectedSeason, setSelectedSeason] = useState();
    const [selectedEpisode, setSelectedEpisode] = useState();

    useEffect(() => {
        if (title) {
            fetchShowByTitle(title);
        }
    }, [title]);

    const fetchShowByTitle = (title) => {
        getShowByTitle(title)
            .then((res) => {
                setShowDetails(res);
                setShowActors(res.tvShowActors);
                setShowGenres(res.tvShowGenres);
                setshowSeasons(res.seasons);
            })
            .catch((error) => {
                console.error("Error: ", error);
                navigate("/not-found");
            });
    };

    return (
        <>
            <Header />

            <div className="page-layout">
                <div className="details-container">
                    <div className="show-img">image</div>
                    <div className="info">
                        <h1>{showDetails?.title ? showDetails.title : "title not found"}</h1>
                        <div>Rating {showDetails?.rating}</div>
                        <hr />
                        <div>Description: {showDetails?.description}</div>
                        <hr />
                        <div>Release Date: {formatDate(showDetails?.releaseDate)}</div>

                        <div>
                            Genre: {showGenres?.length ? showGenres.map(showGen => (showGen.genre.name)).join(", ") : "No genre information available"}
                        </div>

                        <div>
                            Cast:{" "}
                            {showActors?.length
                                ? showActors.map((showAct, index) => (
                                    <React.Fragment key={showAct.actor.id}>
                                        <a style={{ color: "white" }} href={`/actor/${showAct.actor.id}`}>{showAct.actor.name}</a>
                                        {index < showActors.length - 1 && ", "}
                                    </React.Fragment>
                                ))
                                : "No cast information available"}
                        </div>

                    </div>
                </div>

                <hr />

                <h2>Seasons</h2>

                <div className="shows-grid">
                    {showSeasons?.map((season, index) => (
                        <div
                            key={index}
                            className={`seasons-card ${selectedSeason?.id === season.id ? "selected" : ""}`}
                            onClick={() => {
                                setSelectedSeason(season)
                                setSelectedEpisode(null)
                            }}
                        >
                            <div>{`Season ${season.seasonNumber}`}</div>
                        </div>
                    ))}
                </div>

                <hr className="divider" />

                {selectedSeason && (
                    <div>
                        <h2>Episodes</h2>

                        <div className="episodes-grid">
                            {selectedSeason.episodes.map((ep, index) => (
                                <div
                                    key={index}
                                    className={`seasons-card ${selectedEpisode?.id === ep.id ? "selected" : ""}`}
                                    onClick={() => setSelectedEpisode(ep)}
                                >
                                    <div>{`${ep.title}`}</div>
                                </div>
                            ))}
                        </div>
                    </div>
                )}

                <hr className="divider" />

                {selectedEpisode && (
                    <div>
                        <h2>Episode Details</h2>

                        <div>Name: {selectedEpisode.title}</div>
                        <div>Duration: {selectedEpisode.duration} min</div>
                        <div>Rating: {selectedEpisode.rating} ⭐</div>

                    </div>
                )}
            </div>
        </>
    );
}

export default ShowDetails;