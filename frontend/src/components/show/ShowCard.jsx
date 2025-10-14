import "./ShowCard.css";

function ShowCard({ show }) {

    return (
        <div className="card-container">
            <div className="showcard-img">
                <img src={show?.img ? show.img : "/images/background.jpg"} alt="TvShow-image" />
            </div>
            <div className="showcard-details">
                <div style={{ padding: "5px 10px" }}>{show?.title ? show.title : "Title"}</div>
                <div style={{ display: "flex", justifyContent: "space-between", padding: "5px 10px" }}>
                    <div>⭐ {show?.rating ? show.rating : "rating"}</div>
                    <div>{show?.date ? show.date : "date"}</div>
                </div>
            </div>
        </div>
    );
}

export default ShowCard