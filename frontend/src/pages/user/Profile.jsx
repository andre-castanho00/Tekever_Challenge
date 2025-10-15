import "./Profile.css";
import Header from "../../components/header/Header";
import { ToastContainer, toast } from "react-toastify";
import { useState, useEffect, useContext } from "react";
import { getUserFavorites } from "../../api/UseApi";
import ShowCard from "../../components/show/ShowCard";
import AuthContext from "../../AuthContext";

function Profile() {
    const [favorites, setFavorites] = useState();
    const { user } = useContext(AuthContext);
    console.log(user);

    useEffect(() => {
        fetchUserFavorites();
    }, []);

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

    return (
        <>
            <Header />

            <div className="page-layout">
                <h1>{`${user?.username}'s Profile`}</h1>

                <hr className="divider" />

                <h3>My Favorites</h3>

                <div className="shows-grid">
                    {favorites?.map(s => (
                        <ShowCard show={s} key={s.id} />
                    ))}
                </div>

                <hr className="divider" />

                <h3>Recomendations</h3>

            </div>

            <ToastContainer />
        </>
    );
}

export default Profile;