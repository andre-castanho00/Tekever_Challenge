import { useContext } from "react"
import AuthContext from "./AuthContext"
import Page404 from "./pages/Page404";
import { Navigate } from "react-router-dom";

const PrivateRoute = ({ children }) => {
    const { user, loading } = useContext(AuthContext);

    if (loading) {
        return (
            <div className="loaderContainerSpiner">
                <div className="loaderSpiner"></div>
            </div>
        );
    }

    if (!user) {
        return <Navigate to="/" />;
    }

    // if (!hasAnyRole(allowedRoles)) {

    //     if (fallback) {
    //         return fallback;
    //     }

    //     return (
    //         <Page404 />
    //     );
    // }

    return children;
};

export default PrivateRoute;