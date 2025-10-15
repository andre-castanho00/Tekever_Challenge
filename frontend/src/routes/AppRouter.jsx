import { Routes, Route } from "react-router-dom";
import PrivateRoute from "../PrivateRoute";
import Page404 from "../pages/Page404";

// Auth
import Login from "../pages/auth/Login";
import Register from "../pages/auth/Register";

// Home
import Home from "../pages/Home";

// 
import ShowDetails from "../pages/showDetails/ShowDetails";
import ActorDetails from "../pages/actor/ActorDetails";

import Profile from "../pages/user/Profile";

const AppRouter = () => {
    return (
        <Routes>
            {/* ======================== */}
            {/* AUTH */}
            {/* ======================== */}
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
            {/* PROFILE */}
            {/* ======================== */}
            <Route path="/profile"
                element={
                    <PrivateRoute>
                        <Profile />
                    </PrivateRoute>
                }
            />

            {/* ======================== */}
            {/* TV SHOW */}
            {/* ======================== */}
            <Route path="/show/:title"
                element={
                    <PrivateRoute>
                        <ShowDetails />
                    </PrivateRoute>
                }
            />

            {/* ======================== */}
            {/* ACTOR */}
            {/* ======================== */}
            <Route path="/actor/:actorId"
                element={
                    <PrivateRoute>
                        <ActorDetails />
                    </PrivateRoute>
                }
            />

            {/* ======================== */}
            {/* NOT FOUND PAGES */}
            {/* ======================== */}
            <Route path="/not-found" element={<Page404 />} />
            <Route path="*" element={<Page404 />} />
        </Routes>
    );
}

export default AppRouter;