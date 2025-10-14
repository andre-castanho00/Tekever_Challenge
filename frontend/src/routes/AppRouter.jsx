import { Routes, Route } from "react-router-dom";
import PrivateRoute from "../PrivateRoute";
import Page404 from "../pages/Page404";

// Auth
import Login from "../pages/auth/Login";
import Register from "../pages/auth/Register";
import Home from "../pages/Home";

const AppRouter = () => {
    return (
        <Routes>
            {/* <Route path="/" element={<Home />} /> */}
            {/* 
            <Route path="/home"
                element={
                    // <PrivateRoute>
                    //     <Home />
                    // </PrivateRoute>
                    <Home />
                }
            /> */}

            <Route path="/home"
                element={<Home />}
            >
                <Route path="login"
                    element={<Login />}
                />

                <Route path="register"
                    element={<Register />}
                />
            </Route>

            {/* ======================== */}
            {/* NOT FOUND PAGES */}
            {/* ======================== */}
            <Route path="/not-found" element={<Page404 />} />
            <Route path="*" element={<Page404 />} />
        </Routes>
    );
}

export default AppRouter;