import "./ActorDetails.css";
import { useParams, useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import { getActorById } from "../../api/UseApi";
import Header from "../../components/header/Header";
import ShowCard from "../../components/show/ShowCard";

function ActorDetails() {
    let { actorId } = useParams();

    const navigate = useNavigate();

    const [actor, setActor] = useState();
    const [actorShows, setActorShows] = useState();

    useEffect(() => {
        if (actorId) {
            fetchActorById(actorId);
        }
    }, [actorId]);

    const fetchActorById = (actorId) => {
        getActorById(actorId)
            .then((res) => {
                // console.log("Actor details: ", res);
                setActor(res);
                setActorShows(res.tvShows);
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
                        <h1>{actor?.name}</h1>
                        <div>Birth Date {actor?.birthDate ? actor?.birthDate : "N/A"}</div>
                    </div>
                </div>

                <hr />

                <h2>Appeared In</h2>

                <div className="shows-grid">
                    {actorShows?.map(s => (
                        <ShowCard show={s} key={s.id} />
                    ))}
                </div>
            </div>
        </>
    );
}

export default ActorDetails;