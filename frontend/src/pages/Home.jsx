import Header from "../components/header/Header";

function Home() {
    return (
        <>
            <Header />
            <div style={{padding: "80px 150px"}}>
                <h1>TV Shows</h1>
                <hr style={{color: "#eee"}}/>
            </div>
        </>
    );
}

export default Home;